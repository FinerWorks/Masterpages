using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Masterpages_Main : System.Web.UI.MasterPage
{

    protected void Page_Init(object sender, EventArgs e)
    {
        GlobalVar.LoadVariables(Request.ServerVariables["SERVER_NAME"]);

    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        
        GlobalFunctions.LoadHeaderJavascript(true, false, false);
        ImageLogo.ImageUrl = GlobalVar.SiteLogoUrl;
       
    }
}
