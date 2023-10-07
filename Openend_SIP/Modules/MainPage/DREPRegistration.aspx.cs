using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SI.Security.BLL;
using SI.Utility;

namespace Openend_SIP.Modules.MainPage
{
    public partial class DREPRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SI.Utility.CsrfHandler.Validate(this.Page, forgeryToken);
            var urlPath = Request.CurrentExecutionFilePath;
            BLLPageAccess bllObj = new BLLPageAccess();
            JsonResponse jsonresponse = bllObj.CheckOnlineAccessPage(urlPath);
            if (!jsonresponse.IsSucess)
            {
                Response.Redirect("~/Modules/NotAuthorised.aspx");

            } 
        }
    }
}