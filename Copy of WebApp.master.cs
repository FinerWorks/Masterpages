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

        if (String.IsNullOrEmpty(GlobalFunctions.RequestEcryptedCookies("UserID")))
        {
            Response.Redirect(Request.ApplicationPath);
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
        
       
        GlobalFunctions.LoadHeaderJavascript(true, ShowMegaMenu, false);
       
        MegaMenu1.Visible = ShowMegaMenu;


        if (!String.IsNullOrEmpty(GlobalFunctions.RequestQueryString("data-theme")))
        {
            DivContentPlaceHolder1.Attributes.Add("data-theme", GlobalFunctions.RequestQueryString("data-theme"));
           
        }
        PlaceHolderEmergency.Visible = (GlobalFunctions.ToInt32(GlobalFunctions.RequestEcryptedCookies("UserTypePermissionLevel")) > 89);
        ImageLogo.ImageUrl = GlobalVar.SiteLogoUrl;

    }
}
