using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web;
using MF.Utility;

namespace SI.Utility
{
   public class CsrfHandler
    {
        public static void Validate(Page page, HiddenField forgeryToken)
        {
            if (!page.IsPostBack)
            {
                Guid antiforgeryToken = Guid.NewGuid();
                page.Session["AntiforgeryToken"] = antiforgeryToken;
                forgeryToken.Value = antiforgeryToken.ToString();
            }
            else
            {
                // Guid stored = (Guid)page.Session["AntiforgeryToken"];
                Guid stored = (Guid)page.Session["AntiforgeryToken"];
                Guid sent = new Guid(forgeryToken.Value);
                if (sent != stored)
                {
                    // you can throw an exception, in my case I'm just logging the user out
                    page.Session.Abandon();
                    page.Response.Redirect("~/Default.aspx");
                }
            }



        }

        public static string GenerateToken(Page page,string userID, string role, string userType)
        {
            if (!page.IsPostBack)
            {
                string guid = Guid.NewGuid().ToString();
                HttpContext.Current.Session["Guid"] = guid;
                string token = JSONWebToken.GenerateToken(userID, role, userType, guid);
                HttpContext.Current.Session["Token"] = token;
                return token;
                
            }
            else
            {
                string guid = Guid.NewGuid().ToString();
                var test = HttpContext.Current.Session["Token"];
                var token = CurrentToken();
                HttpContext.Current.Session["Token"] = token;
                return token;
            }
        }

        public static string CurrentToken()
        {
            string token = "";
            if (HttpContext.Current.Session["Token"] != null)
                token = HttpContext.Current.Session["Token"].ToString();
            else
                token = null;

            return token;
            //return "1";
        }
    }
}
