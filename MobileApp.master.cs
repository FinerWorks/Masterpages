using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class Masterpages_MobileApp : System.Web.UI.MasterPage
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
        favicon.Attributes.Add("HREF", GlobalVar.SiteLogoUrl.Replace("~", ""));
        this.Page.Header.Controls.Add(favicon);


        //Response.Cookies["theme"].Value = StringCrypt.Encrypt("a"); 

        //  MenuEmpty.Visible = (String.IsNullOrEmpty(GlobalFunctions.RequestEcryptedCookies("UserID")));
        Menu.Visible = (!String.IsNullOrEmpty(GlobalFunctions.RequestEcryptedCookies("UserID")));
        MenuRight.Visible = (!String.IsNullOrEmpty(GlobalFunctions.RequestEcryptedCookies("UserID")));
        //   HyperLinkMenu.Visible = (!String.IsNullOrEmpty(GlobalFunctions.RequestEcryptedCookies("UserID")));


        //if (Request.AppRelativeCurrentExecutionFilePath.ToLower() != "~/mobileapp/my_account.aspx")
        //{
        //    Menu.Attributes.Add("style", "display:none");
        //}

       





        if (PasswordRequired())
        {

            if (String.IsNullOrEmpty(GlobalFunctions.RequestEcryptedCookies("UserID")))
            {
                Response.Redirect(Request.ApplicationPath);
            }

            if (Request.Cookies["UserRequirePasswordChange"] != null)
            {
                if (GlobalFunctions.ToBoolean(GlobalFunctions.RequestEcryptedCookies("UserRequirePasswordChange")))
                {
                    if (Request.ServerVariables["URL"].ToLower() != (Request.ApplicationPath + "MobileApp/ChangePassword.aspx").ToLower())
                    {
                        Response.Redirect("~/MobileApp/ChangePassword.aspx");
                    }
                }
            }


        }



        //  DivMessages.Visible =  (Request.ServerVariables["URL"].ToLower() == (Request.ApplicationPath + "MobileApp/my_account.aspx").ToLower());

        //   GlobalFunctions.LoadHeaderJavascript(true, false, false);

    }
    public bool PasswordRequired()
    {
        bool RequiresLogin = true;

        if (Request.ServerVariables["URL"].ToLower() == (Request.ApplicationPath + "mobileapp/default.aspx").ToLower())
        {
            RequiresLogin = false;
            // Menu.Visible = false;
            // DivMessages.Visible = false;
        }





        if (Request.ServerVariables["URL"].ToLower() == (Request.ApplicationPath + "mobileapp/geo.aspx").ToLower())
        {
            RequiresLogin = false;
            Menu.Visible = false;
            //  DivMessages.Visible = false;
        }



        return RequiresLogin;

    }



  
}
