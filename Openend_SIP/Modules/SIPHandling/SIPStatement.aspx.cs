using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SI.Security.BLL;
using SI.Utility;
using SI.Security.ATT;

namespace Openend_SIP.Modules.SIPHandling
{
    public partial class SIPStatement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SI.Utility.CsrfHandler.Validate(this.Page, forgeryToken);
            var urlPath = Request.CurrentExecutionFilePath;
            BLLPageAccess bllObj = new BLLPageAccess();
            JsonResponse jsonresponse = bllObj.CheckOnlineAccessPage(urlPath);
            if (!jsonresponse.IsSucess)
            {
                HttpContext.Current.Session["User"] = null;
                var httpSession = HttpContext.Current.Session;
                HttpContext.Current.Session.Clear();
                HttpContext.Current.Session.Abandon();
                HttpContext.Current.Response.ClearContent();
                HttpContext.Current.Response.ClearHeaders();

            }
            if (HttpContext.Current.Session["User"] != null)
            {
                string boid = ((ATTUser)HttpContext.Current.Session["User"]).BOID;
                string shholderno = ((ATTUser)HttpContext.Current.Session["User"]).SHHOLDERNO;
                string l_company_id = ((ATTUser)HttpContext.Current.Session["User"]).l_company_id;
                BLLUser blluser = new BLLUser();
                JsonResponse jsonresponse1 = blluser.GetDetail("001", boid, shholderno);
                if (jsonresponse1.TCount == 0)
                {
                    HttpContext.Current.Session["User"] = null;
                    var httpSession = HttpContext.Current.Session;
                    HttpContext.Current.Session.Clear();
                    HttpContext.Current.Session.Abandon();
                    HttpContext.Current.Response.ClearContent();
                    HttpContext.Current.Response.ClearHeaders();

                }
            }
        }
    }
}