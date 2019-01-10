using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Epsilon.Digital.Sc;
using Foundation.Log;
using Acme.Foundation.Helper;


using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Security.Accounts;
using System.Web.Security;
using Sitecore.Security.AccessControl;
using Sitecore.SecurityModel;

using FieldNames = Acme.Foundation.Helper.FieldNames;
using Settings = Acme.Foundation.Helper.Settings;

//using static EmailCampaign.Controls.Constants;

namespace Feature.Admin.Helper
{
    public class Instance
    {
        private const string databasename = Epsilon.Digital.Sc.Constants.MasterDb;
        private const string domainSitecore = Acme.Foundation.Helper.Constants.SitecoreDomain;

        private int maxLength = Epsilon.Digital.Sc.Harmony.Helper.HarmonyNameMaxLength;
        private string InstanceAdminRole { get; set; }

        private string InstanceName = string.Empty;
        private string InstancePropertyUserRole { get; set; }

        Item mediaLCBRootFolder = null;
        Item contentLCBRootFolder = null;

        public Instance()
        {
        }

        public Item CreateInstance(string instanceName, string HarmonyAuthorizedDomainInput, string OptoutSuffixInput, string OptoutURLInput)
        {
            InstanceName = instanceName;
            contentLCBRootFolder = DataAccess.GetItemsByQuery(Settings.GetLCBContentFolderPath, databasename).SingleOrDefault();
            if (contentLCBRootFolder == null)
            {

                throw new Exception("Content root folder not found " + Settings.GetLCBContentFolderPath);

                return null;
            }

            mediaLCBRootFolder = DataAccess.GetItemsByQuery(Settings.GetLCBMediaFolderPath, databasename).SingleOrDefault();
            if (mediaLCBRootFolder == null)
            {
                throw new Exception("Media root folder not found " + Settings.GetLCBMediaFolderPath);

                return null;
            }

            //Get valid email domain name from LCB instance item End 
            Item instanceContentFolder = null;
            if (!String.IsNullOrEmpty(InstanceName))
            {
                try
                {


                    //STEP2: Creat Sitecore Items
                    using (SecurityDisabler sd = new SecurityDisabler())
                    {
                        string roleAdminPrefix = "Instance Admins of";
                        InstanceAdminRole = string.Format("{0}\\{1}", domainSitecore, roleAdminPrefix.Trim() + " " + InstanceName);

                        string rolePropertyUserPrefix = !String.IsNullOrEmpty(Settings.GetSetting("PropertyUserRolePrefix")) ? Settings.GetSetting("PropertyUserRolePrefix") : "Property Users of";
                        InstancePropertyUserRole = string.Format("{0}\\{1}", domainSitecore, "Instance " + rolePropertyUserPrefix.Trim() + " " + InstanceName);

                        ////create sitecore role for region access :I) Create Role for Region access in “Sitecore” domain
                        CreateSitecoreInstanceRoles();


                        //// Create Media folder for Instance III) Create Media folder
                        Item instanceMediaFolder = CreateInstanceMediaFolder();
                        if (instanceMediaFolder != null)
                        {
                            //// Create Content folder for region IV) Create Content Instance folder
                            instanceContentFolder = CreateInstanceContentFolder();

                            //STEP3: Associate Sitecore Region item with Harmony entires
                            if (instanceContentFolder != null)
                            {
                                using (new EditContext(instanceContentFolder)) //Store the Harmony ids Back into sitecore redion folder item
                                {
                                    //Set instance media folder icon to region content folder icon
                                    //instanceContentFolder.Appearance.Icon = regionFolder.Appearance.Icon;

                                    //Set region media folder icon to region content folder icon end
                                    instanceContentFolder.Appearance.DisplayName = InstanceName;

                                    if (instanceContentFolder.Fields[FieldNames.HarmonyAuthorizedSendingDomainName] != null)
                                    {
                                        instanceContentFolder.Fields[FieldNames.HarmonyAuthorizedSendingDomainName].Value =
                                        HarmonyAuthorizedDomainInput;
                                    }

                                    if (instanceContentFolder.Fields[FieldNames.GlobalOptoutSuffix] != null)
                                    {
                                        instanceContentFolder.Fields[FieldNames.GlobalOptoutSuffix].Value =
                                        OptoutSuffixInput;
                                    }
                                    if (instanceContentFolder.Fields[FieldNames.GlobalOptoutURL] != null)
                                    {
                                        instanceContentFolder.Fields[FieldNames.GlobalOptoutURL].Value =
                                        OptoutURLInput;
                                    }
                                }
                                /*Publish instance Items*/

                                instanceMediaFolder.Publish();
                                instanceContentFolder.Publish();
                                /*Publish instance Items End*/
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    Foundation.Log.Log.Error("Method Name:" + System.Reflection.MethodBase.GetCurrentMethod().Name + String.Format(" Message: {0}; Source:{1}",
                        ex.Message, ex.Source));
                    return null;
                }
            }
            return instanceContentFolder;
        }
        #region "Private Region Sitecore Methods"
        private Item CreateInstanceMediaFolder()
        {
            Item mediaParentFolder = mediaLCBRootFolder;


            Item mediaFolder = null;
            if (mediaParentFolder != null)
            {
                mediaFolder = mediaParentFolder.Add(ItemUtil.ProposeValidItemName(InstanceName), Factory.GetDatabase(databasename).Branches[ID.Parse(Templates.InstanceBranchMediaTemplate.ToString())]);
                if (mediaFolder != null)
                {
                    SetSitecoreUserAccess(mediaFolder);
                    SetSitecoreAdminAccess(mediaFolder);
                }
            }

            return mediaFolder;
        }
        private Item CreateInstanceContentFolder()
        {
            Item parentFolder = contentLCBRootFolder;
            Item instanceContentFolder = null;
            if (parentFolder != null)
            {

                instanceContentFolder = parentFolder.Add(ItemUtil.ProposeValidItemName(InstanceName), Factory.GetDatabase(databasename).Branches[ID.Parse(Templates.InstanceBranchContentTemplate.ToString())]);
                if (instanceContentFolder != null)
                {

                    //Set access rights for the  region content folder
                    SetSitecoreUserAccess(instanceContentFolder);
                    SetSitecoreAdminAccess(instanceContentFolder);

                }
            }
            return instanceContentFolder;
            ;
        }


        private void SetSitecoreAdminAccess(Item item)
        {
            try
            {
                Role adminRole = Role.FromName(InstanceAdminRole);
                if (adminRole != null)
                {
                    // Get the current accessrules
                    AccessRuleCollection accessRules = item.Security.GetAccessRules();

                    // Apply read access for the "myRole" to the current item
                    // and all it's children

                    accessRules.Helper.AddinheritancePermission(adminRole, AccessRight.Any, PropagationType.Any,
                                                                InheritancePermission.Allow);
                    accessRules.Helper.AddAccessPermission(adminRole, AccessRight.Any, PropagationType.Any,
                                                        AccessPermission.Allow);
                    // Write the rules back to the item
                    item.Editing.BeginEdit();
                    item.Security.SetAccessRules(accessRules);
                    item.Editing.EndEdit();
                }

            }
            catch (Exception ex)
            {
                Foundation.Log.Log.Error("Method Name:" +
                                                        System.Reflection.MethodBase.GetCurrentMethod().Name + " Message:" + ex.Message +
                                                        " HARMONY ERROR externalLCBAdminRoleName ");
            }
        }

        private void SetSitecoreUserAccess(Item item)
        {
            Role userRole = Role.FromName(InstancePropertyUserRole);
            if (userRole != null)
            {
                // Get the current accessrules
                AccessRuleCollection accessRules = item.Security.GetAccessRules();

                accessRules.Helper.AddAccessPermission(userRole, AccessRight.ItemRead, PropagationType.Entity, AccessPermission.Allow); // ITEM READ ALLOW
                accessRules.Helper.AddAccessPermission(userRole, AccessRight.ItemRead, PropagationType.Descendants, AccessPermission.Deny); // DECENDENTS DENY


                // Write the rules back to the item
                item.Editing.BeginEdit();
                item.Security.SetAccessRules(accessRules);
                item.Editing.EndEdit();
            }
        }
        private void CreateSitecoreInstanceRoles()
        {
            //Instance admin user role
            if (!Role.Exists(InstanceAdminRole))
            {
                Roles.CreateRole(InstanceAdminRole);

                //string sitecoreAllRegionalAdminsRole = string.Format("{0}\\{1}", domainSitecore, "Instance Admin Users of " + InstanceName);
                //if (!Role.Exists(sitecoreAllRegionalAdminsRole))
                //{
                //    Roles.CreateRole(sitecoreAllRegionalAdminsRole);
                //}
                //if (RolesInRolesManager.RolesInRolesSupported && !RolesInRolesManager.IsRoleInRole(Role.FromName(InstanceAdminRole), Role.FromName(sitecoreAllRegionalAdminsRole), false))
                //{
                //    RolesInRolesManager.AddRoleToRole(Role.FromName(InstanceAdminRole), Role.FromName(sitecoreAllRegionalAdminsRole));
                //}
            }
            //Instance admin user role end
            //Instance property user role
            if (!Role.Exists(InstancePropertyUserRole))
            {
                Roles.CreateRole(InstancePropertyUserRole);
            }
            string sitecoreAllPropertyUsersRole = string.Format("{0}\\{1}", domainSitecore, "All Properties Users");

            if (RolesInRolesManager.RolesInRolesSupported && !RolesInRolesManager.IsRoleInRole(Role.FromName(InstancePropertyUserRole), Role.FromName(sitecoreAllPropertyUsersRole), false))
            {
                RolesInRolesManager.AddRoleToRole(Role.FromName(InstancePropertyUserRole), Role.FromName(sitecoreAllPropertyUsersRole));
            }
            //Instance property user role end

        }

        #endregion
    }
}