﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SI.Security.BLL;
using SI.Utility;

namespace Openend_SIP.Modules.Container
{
    public partial class Detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
        }
    }
}