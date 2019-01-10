<%@ Page Language="C#" AutoEventWireup="true" %>

<%@ Import Namespace="System" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Linq" %>
<%@ Import Namespace="System.IO" %>



<%@ Import Namespace="Sitecore.Data" %>
<%@ Import Namespace="Sitecore.Data.Items" %>
<%@ Import Namespace="Sitecore.Data.Fields" %>
<%@ Import Namespace="Sitecore.Data.Templates" %>
<%@ Import Namespace="Sitecore.Data.Managers" %>


<%@ Import Namespace="FileHelpers" %>

<%@ Import Namespace="Epsilon.Digital.Sc" %>
<%@ Import Namespace="Marriott.LCB.Web" %>
<%@ Import Namespace="Marriott.LCB.Web.Models" %>

<script runat="server">
    string databasename = "Master";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Sitecore.Context.User.IsAdministrator)
        {

            Response.Write("created");
            if (!Page.IsPostBack)
            {

            }
        }
        else
        {
            lblError.Text = "Using <a href='/sitecore/login'> login</a> page , login as admin and revisit this page";
        }


    }






</script>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblError" runat="server" ForeColor="Red" />
            <br />
            <br />

            <br />
            <br />

            <asp:FileUpload ID="FileUpload1" runat="server" />  
            <asp:Button ID="btnImport" runat="server" Text="Import" OnClick="btnImport_Click"/>  

        </div>
    </form>
</body>
</html>

