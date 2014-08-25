using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Masterpages_ReportPage : System.Web.UI.MasterPage
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
    }
}
