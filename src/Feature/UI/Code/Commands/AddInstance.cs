using Sitecore;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Text;
using Sitecore.Web.UI.Sheer;

namespace Feature.Admin.Commands
{
    public class AddInstance: Command
    {
        public override void Execute(CommandContext context)
        {
            Assert.ArgumentNotNull((object)context, nameof(context));

            if (context.Items.Length != 1)
                return;

            Item obj = context.Items[0];

            //UrlString urlString = new UrlString(UIUtil.GetUri("control:CustomAdmin.AddInstanceWizard"));
            UrlString urlString = new UrlString(UIUtil.GetUri("control:EmailCampaign.AddInstanceWizard"));
            urlString.Append("id", obj.ID.ToString());
            urlString.Append("la", obj.Language.ToString());
            urlString.Append("vs", obj.Version.ToString());
            SheerResponse.ShowModalDialog(urlString.ToString());
        }

    }
}