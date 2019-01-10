using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Sitecore;
using Sitecore.Data.Items;
using Sitecore.Web.UI.Pages;
using Sitecore.Web.UI.Sheer;
using Sitecore.Web.UI.HtmlControls;
using Sitecore.Web.UI.WebControls;
using Literal = Sitecore.Web.UI.HtmlControls.Literal;
using Sitecore.EmailCampaign.Model.Web;
using System.Collections;
using Epsilon.Digital.Sc;
using Sitecore.Modules.EmailCampaign.Core;
using Acme.Foundation.Helper;

namespace Feature.Admin.Dialogs
{
    public class AddInstanceWizard : WizardForm
    {

        protected GridPanel BUPanel;

        protected GridPanel ErrorPanel;

        protected GridPanel ResultsPanel;

        protected Border Error;

        protected Edit InstanceInput;

        protected Edit HarmonyAuthorizedDomainInput;

        protected Edit OptoutSuffixInput;

        protected Edit OptoutURLInput;

        protected Border Results;

        protected Literal ReviewText;

        protected Literal ErrorText;

        protected Literal ResultsHeader;



        private System.Web.UI.Control parentControl;
        string databasename = Epsilon.Digital.Sc.Constants.MasterDb;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            bool isEvent = Context.ClientPage.IsEvent;
            if (isEvent)
            {
                if (this.ParentControl != null)
                {
                    IEnumerator enumerator = this.ParentControl.Controls.GetEnumerator();
                    try
                    {
                        while (true)
                        {
                            isEvent = enumerator.MoveNext();
                            if (!isEvent)
                            {
                                break;
                            }
                            object current = enumerator.Current;
                            isEvent = current as Combobox == null;
                            if (!isEvent)
                            {
                                //(current as Combobox).Selected = true;
                            }
                        }
                    }
                    finally
                    {
                        IDisposable disposable = enumerator as IDisposable;
                        isEvent = disposable == null;
                        if (!isEvent)
                        {
                            disposable.Dispose();
                        }
                    }
                }
            }
            else
            {

            }
        }


        protected System.Web.UI.Control ParentControl
        {
            get
            {
                System.Web.UI.Control control;
                bool count = this.parentControl != null;

                control = this.parentControl;
                return control;
            }
        }

        //
        // Summary:
        //     Called when the active page has been changed.
        //
        // Parameters:
        //   page:
        //     The page that has been entered.
        //
        //   oldPage:
        //     The page that was left.
        protected override void ActivePageChanged(string page, string oldPage)
        {
            base.ActivePageChanged(page, oldPage);
            string str = page;
            if (str != null)
            {
                if (str == "Importing")
                {
                    this.BackButton.Disabled = true;
                    this.NextButton.Disabled = true;
                }
                else
                {
                    if (str == "Finish")
                    {
                        this.BackButton.Disabled = true;
                    }
                }
            }
        }

        //
        // Summary:
        //     Called when the active page is changing.
        //
        // Parameters:
        //   page:
        //     The page that is being left.
        //
        //   newpage:
        //     The new page that is being entered.
        //
        // Returns:
        //     True, if the change is allowed, otherwise false.
        //
        // Remarks:
        //     Set the newpage parameter to another page ID to control the path through the
        //     wizard pages.
        protected override bool ActivePageChanging(string page, ref string newpage)
        {
            bool flag;
            bool currentRecipientListId;
            bool flag1;
            flag1 = (!newpage.Equals("Importing") ? true : this.RegionInputCompleted());
            currentRecipientListId = flag1;
            flag = (currentRecipientListId ? base.ActivePageChanging(page, ref newpage) : false);
            return flag;
        }

        public virtual void CheckImport()
        {
            Sitecore.Jobs.Job currentJob = JobHelper.CurrentJob;
            bool isDone = currentJob != null;
            bool isFailed = true;
            if (isDone)
            {
                isDone = currentJob.IsDone;
                if (isDone)
                {
                    isFailed = currentJob.Status.Result == null;
                    if (!isFailed)
                    {
                        this.UpdateForm(true);
                    }
                    else
                    {
                        this.UpdateForm(false);
                    }
                    base.Next();
                }
                else
                {
                    SheerResponse.Timer("CheckImport", 300);
                }
            }
            else
            {
                base.Next();
            }
        }

        private void UpdateForm(bool result, string errortext = "")
        {
            if (result)
            {
                this.ResultsHeader.Text = "The instance information has been added successfully.";

                SheerResponse.Eval(string.Concat("$('ErrorPanel').style.display='none", "'"));
                SheerResponse.Eval(string.Concat("$('ResultsPanel').style.display='", "'"));


                SheerResponse.Refresh(this.Results);
                SheerResponse.Refresh(this.Error);
            }
            else
            {
                this.ResultsHeader.Text = "<font color='red'>Add instance failed, see sitecore logs for details.<br/><br/></font>";

                SheerResponse.Eval(string.Concat("$('ErrorPanel').style.display='", "'"));
                SheerResponse.Eval(string.Concat("$('ResultsPanel').style.display='none", "'"));
                this.ErrorText.Text = errortext;

                SheerResponse.Refresh(this.Error);

            }

        }

        protected virtual bool StartImportJob()
        {
            bool flag;
            object[] objArray = new object[] { this.InstanceInput.Value, this.HarmonyAuthorizedDomainInput.Value, this.OptoutSuffixInput.Value, this.OptoutURLInput.Value };



            Sitecore.ExM.Framework.Diagnostics.Logger exmlog = new Sitecore.ExM.Framework.Diagnostics.Logger("exmLogger", "true");

            JobHelper jobHelper = new JobHelper(exmlog);
            string jobName = "AddInstance" + new Guid().ToString();

            //jobHelper.TryStartJob(jobName, "CreateInstance", new LCBInstance(), objArray);
            this.CheckImport();

            flag = true;
            return flag;
        }

        protected virtual bool RegionInputCompleted()
        {

            bool flag;

            bool flag1 = !string.IsNullOrEmpty(this.InstanceInput.Value);
            if (flag1)
            {
                flag = true;
            }
            else
            {
                SheerResponse.Alert(EcmTexts.Localize("You need to enter a region", new object[0]), new string[0]);
                flag = false;
                return flag;
            }


            flag1 = !string.IsNullOrEmpty(this.HarmonyAuthorizedDomainInput.Value);
            if (flag1)
            {

                flag = true;
            }
            else
            {
                SheerResponse.Alert(EcmTexts.Localize("You need to enter a Harmony authorized domain for this instance", new object[0]), new string[0]);
                flag = false;
                return flag;
            }
            flag1 = !string.IsNullOrEmpty(this.OptoutURLInput.Value);
            if (flag1)
            {

                flag = true;
            }
            else
            {
                SheerResponse.Alert(EcmTexts.Localize("You need to enter a corporate optout URL", new object[0]), new string[0]);
                flag = false;
                return flag;
            }

            string errorMessage;

            if (!ValidateInstanceValues(out errorMessage))
            {
                SheerResponse.Alert(EcmTexts.Localize(errorMessage, new object[0]), new string[0]);
                return false;
            }

            this.StartImportJob();
            flag = true;
            return flag;
        }


        private bool ValidateInstanceValues(out string errorMessage)
        {
            bool validation = true;
            errorMessage = string.Empty;


            //Check region already exists in sitecore
            bool count = !string.IsNullOrEmpty(this.TryFindInstance((this.InstanceInput.Value)));
            if (!count)
            {
                errorMessage = "Instance already exists: " + this.InstanceInput.Value + "<br/>";
                validation = false;
            }

            //Make sure valid email domain name is specified for selected LCB instance 
            //Item contentRegionRootFolder = DataAccess.GetItemsByQuery(Settings.GetLCBRegionContentFolderPath(LCBInput.Value), databasename).SingleOrDefault();
            //if (contentRegionRootFolder != null)
            //{
            //    ; 
            //    Item instanceLCB = new LCBInstanceHelper(contentRegionRootFolder).LCBInstanceItem;
            //    if (!(instanceLCB != null && instanceLCB.Fields[FieldNames.HarmonyAuthorizedSendingDomainName] != null && !string.IsNullOrEmpty(instanceLCB.Fields[FieldNames.HarmonyAuthorizedSendingDomainName].Value)))
            //        if (instanceLCB.Fields[FieldNames.HarmonyAuthorizedSendingDomainName] == null || string.IsNullOrEmpty(instanceLCB.Fields[FieldNames.HarmonyAuthorizedSendingDomainName].Value))
            //    {
            //        errorMessage = "Please make sure Harmony Acceptable Domain Name is specified for the selected LCB instance" + "<br/>";
            //        regionValidation = false;
            //    }                             
            //}            
            //Make sure valid email domain name is specified for selected LCB instance End 
            return validation;
        }

        private string TryFindInstance(string name)
        {
            try
            {
                Item item = DataAccess.GetItemsByQuery(Settings.GetLCBContentFolderPath + "/" + name, databasename).SingleOrDefault();
                if (item != null)
                {
                    return "";
                }
                else
                {
                    return name;
                }
            }
            catch (Exception)
            {
                return "";
            }

        }

    }
}