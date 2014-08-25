using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

public partial class Masterpages_WebApp : System.Web.UI.MasterPage
{


    protected void Page_Init(object sender, EventArgs e)
    {
        GlobalVar.LoadVariables(Request.ServerVariables["SERVER_NAME"]);
        

    }

    protected void Page_Load(object sender, EventArgs e)
    {


      

        HtmlGenericControl favicon = new HtmlGenericControl();
        favicon.TagName = "LINK";
        favicon.Attributes.Add("REL", "SHORTCUT ICON");
        favicon.Attributes.Add("HREF", GlobalVar.SiteLogoUrl.Replace("~",""));
        this.Page.Header.Controls.Add(favicon);

        if (String.IsNullOrEmpty(GlobalFunctions.RequestEcryptedCookies("UserID")))
        {
            if ((Request.ServerVariables["URL"].ToLower() != "/default.aspx") && (Request.ServerVariables["URL"].ToLower() != "/changepassword.aspx"))
            {
                Response.Redirect(Request.ApplicationPath);
            }
        }
        
        
        

        if (Request.Cookies["UserRequirePasswordChange"] != null)
        {
            if (GlobalFunctions.ToBoolean(GlobalFunctions.RequestEcryptedCookies("UserRequirePasswordChange")))
            {

                Response.Redirect("~/ChangePassword.aspx");

            }
        }

       
        bool ShowMegaMenu;

        if (GlobalFunctions.RequestQueryString("ShowMegaMenu") == "false")
        {
            ShowMegaMenu = false;
        } else {

            ShowMegaMenu = true;
        }
        
       
       // GlobalFunctions.LoadHeaderJavascript(true, ShowMegaMenu, false);
       
        MegaMenu1.Visible = ShowMegaMenu;


        if (!String.IsNullOrEmpty(GlobalFunctions.RequestQueryString("data-theme")))
        {
            DivContentPlaceHolder1.Attributes.Add("data-theme", GlobalFunctions.RequestQueryString("data-theme"));
           
        }
        PlaceHolderEmergency.Visible = (GlobalFunctions.ToInt32(GlobalFunctions.RequestEcryptedCookies("UserTypePermissionLevel")) > 89);


        DivOfficerList.Visible = (GlobalFunctions.ToInt32(GlobalFunctions.RequestEcryptedCookies("UserTypePermissionLevel")) > 89);
        DivAgencyList.Visible = (GlobalFunctions.ToInt32(GlobalFunctions.RequestEcryptedCookies("UserTypePermissionLevel")) > 89);
        DivPhotoList.Visible = (GlobalFunctions.ToInt32(GlobalFunctions.RequestEcryptedCookies("UserTypePermissionLevel")) > 89);
        DivReportList.Visible = (GlobalFunctions.ToInt32(GlobalFunctions.RequestEcryptedCookies("UserTypePermissionLevel")) > 89);
        DivContactList.Visible = (GlobalFunctions.ToInt32(GlobalFunctions.RequestEcryptedCookies("UserTypePermissionLevel")) > 89);
        DivCompanyList.Visible = (GlobalFunctions.ToInt32(GlobalFunctions.RequestEcryptedCookies("UserTypePermissionLevel")) > 89);
        DivGateList.Visible = (GlobalFunctions.ToInt32(GlobalFunctions.RequestEcryptedCookies("UserTypePermissionLevel")) > 89);
        DivDestinationsList.Visible = (GlobalFunctions.ToInt32(GlobalFunctions.RequestEcryptedCookies("UserTypePermissionLevel")) > 89);
        DivRanchList.Visible = (GlobalFunctions.ToInt32(GlobalFunctions.RequestEcryptedCookies("UserTypePermissionLevel")) > 89);
        DivMessageList.Visible = (GlobalFunctions.ToInt32(GlobalFunctions.RequestEcryptedCookies("UserTypePermissionLevel")) > 89);
        DivUserList.Visible = (GlobalFunctions.ToInt32(GlobalFunctions.RequestEcryptedCookies("UserTypePermissionLevel")) > 89);

        DivTimeSheet.Visible = (GlobalFunctions.ToInt32(GlobalFunctions.RequestEcryptedCookies("UserTypePermissionLevel")) > 89);
        DivTrafficLog.Visible = (GlobalFunctions.ToInt32(GlobalFunctions.RequestEcryptedCookies("UserTypePermissionLevel")) > 9);
        DivTrafficFormSettings.Visible = (GlobalFunctions.ToInt32(GlobalFunctions.RequestEcryptedCookies("UserTypePermissionLevel")) > 19);
        DivVehIntel.Visible = (GlobalFunctions.ToInt32(GlobalFunctions.RequestEcryptedCookies("UserTypePermissionLevel")) > 89);

      //  ImageLogo.ImageUrl = GlobalVar.SiteLogoUrl;

    }
}
