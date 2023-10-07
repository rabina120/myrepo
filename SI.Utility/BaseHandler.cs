using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Reflection;
using System.Web.SessionState;
using System.ComponentModel;

using System.Net;
using SI.Security.ATT;
using MF.Utility;


namespace SI.Utility
{
    # region Copyright
    /*
   *********************************************************************************
   Copyright © SOSYS , 2014
   info@ssf.gov.np

   This program is the intellectual property of Ministry of Labour and Employment.
   The program may be used, modified and/or copied only with the written permission 
   in accordance with the terms and conditions stipulated in the agreement/contract 
   under which the program has been supplied.

   *********************************************************************************
   Project              :Social Security Information Management System (SOSYS)  
   File                 :BaseHandler.cs 
   Description          :This Page contain the BaseHandler class
   *********************************************************************************
   <Name>                                          <Date>         <Version>
   Raju Shahi <stylishraju@gmail.com>              18/07/2014      1.0.0                                                                    
   *********************************************************************************
    */
    # endregion

    public abstract partial class BaseHandler : IHttpHandler, IRequiresSessionState
    {

        private HttpContext _context = null;
        public HttpContext context
        {
            get { return _context; }
            private set { _context = value; }
        }

        public virtual void HandleRequest() { }

        public void ProcessRequest(HttpContext context)
        {
            this.context = context;
            //IntegratedTaxSystem.IntegratedTaxSystemServiceReference.User user = new IntegratedTaxSystem.IntegratedTaxSystemServiceReference.User();

            //if (context.Session["User"] == null)
            //{
            //    //context.Response.Redirect("/Home.aspx");
            //    JsonResponse response1 = new JsonResponse();

            //    response1.Message = "Login Failed !!!";
            //    response1.IsSucess = false;

            //    HttpContext.Current.Response.ContentType = "application/json";
            //    HttpContext.Current.Response.Write(response1);

            //    return;
            //    //return JsonUtility.Serialize(response);
            //}


            //if (context.Session["User"] == null)
            //{
            //    user.UserID = "ITS";
            //    user.Password = "WEBUSERT0!RD";
            //    context.Session["User"] = user;
            //}


            //ControllerBase controller = new ControllerBase();
            //if (controller.Message != string.Empty)
            //{
            //    context.Response.Write(controller.Message);
            //    context.Response.End();
            //}

            // it's possible to the requestor to be able to handle everything himself, overriding all this implemention
            string handleRequest = context.Request["handlerequest"];
            if (!string.IsNullOrEmpty(handleRequest) && handleRequest.ToLower() == "true")
            {
                HandleRequest();
                return;
            }

            var ajaxCall = new AjaxCallSignature(context);

            //context.Response.ContentType = string.Empty;
            if (!string.IsNullOrEmpty(ajaxCall.returnType))
            {
                switch (ajaxCall.returnType)
                {
                    case "json":
                        context.Response.ContentType = "application/json";
                        break;
                    case "xml":
                        context.Response.ContentType = "application/xml";
                        break;
                    case "jpg":
                    case "jpeg":
                    case "image/jpg":
                        context.Response.ContentType = "image/jpg";
                        break;
                    default:
                        break;
                }
            }

            // call the requested method
            object result = ajaxCall.Invoke(this, context);

            // if neither on the arguments or the actual method the content type was set then make sure to use the default content type
            if (string.IsNullOrEmpty(context.Response.ContentType) && !SkipContentTypeEvaluation)
            {
                context.Response.ContentType = DefaultContentType();
            }

            // only skip transformations if the requestor explicitly said so
            if (result == null)
            {
                context.Response.Write(string.Empty);
            }
            else if (!SkipDefaultSerialization)
            {
                switch (context.Response.ContentType.ToLower())
                {
                    case "application/json":
                        //JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                        //string json = jsonSerializer.Serialize(result);
                        //context.Response.Write(json);
                        context.Response.Write(result);
                        break;
                    case "application/xml":
                        System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(result.GetType());
                        StringBuilder xmlSb = new StringBuilder();
                        System.Xml.XmlWriter xmlWriter = System.Xml.XmlWriter.Create(xmlSb);
                        xmlSerializer.Serialize(xmlWriter, result);
                        context.Response.Write(xmlSb.ToString());
                        break;
                    case "text/html":
                        context.Response.Write(result);
                        break;
                    default:
                        throw new Exception(string.Format("Unsuported content type [{0}]", context.Response.ContentType));
                }
            }
            else
            {
                context.Response.Write(result);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        public string GenerateToken(string userID, string role, string userType)
        {
            string guid = Guid.NewGuid().ToString();
            HttpContext.Current.Session["Guid"] = guid;
            string token = JSONWebToken.GenerateToken(userID, role, userType, guid);
            HttpContext.Current.Session["Token"] = token;
            return token;
        }

        public string CurrentToken()
        {
            string token = "";
            if (HttpContext.Current.Session["Token"] != null)
                token = HttpContext.Current.Session["Token"].ToString();
            else
                token = null;

            return token;
            //return "1";
        }

        //public string GetUser()
        //{
        //    string BOID = "";
        //    string Email = "";
        //    string UserName = "";
        //    string scheme_code = "";
        //    int UserId;
        //    string Name = "";
        //    string l_company_id = "";
        //    string SHHOLDERNO = "";
        //    string Contact_No = "";
        //    string Contact_No2 = "";

        //    if (HttpContext.Current.Session["User"] != null)
        //    BOID = ((ATTUser)HttpContext.Current.Session["User"]).BOID;
        //    UserName = ((ATTUser)HttpContext.Current.Session["User"]).UserName;
        //    scheme_code = ((ATTUser)HttpContext.Current.Session["User"]).scheme_code;
        //    UserId = ((ATTUser)HttpContext.Current.Session["User"]).UserId; ;
        //    Email = ((ATTUser)HttpContext.Current.Session["User"]).Email; ;
        //    l_company_id = ((ATTUser)HttpContext.Current.Session["User"]).l_company_id; ;
        //    Name = ((ATTUser)HttpContext.Current.Session["User"]).Name; ;
        //    SHHOLDERNO = ((ATTUser)HttpContext.Current.Session["User"]).SHHOLDERNO;
        //    Contact_No = ((ATTUser)HttpContext.Current.Session["User"]).Contact_No;
        //    Contact_No2 = ((ATTUser)HttpContext.Current.Session["User"]).Contact_No2;

        //    return BOID + '/' + UserName + '/' + scheme_code + '/' + Email + '/' + l_company_id + '/' + Name + '/' + SHHOLDERNO + '/' + Contact_No + '/' + Contact_No2 + '/' + UserId;
        //}
        public string GetUser()
        {
            string BOID = "";
            string Email = "";
            string UserName = "";
            string scheme_code = "";
            int UserId;
            string Name = "";
            string l_company_id = "";
            string SHHOLDERNO = "";
            string Contact_No = "";
            string Contact_No2 = "";

            if (HttpContext.Current.Session["User"] != null)
                BOID = ((ATTUser)HttpContext.Current.Session["User"]).BOID;
            UserName = ((ATTUser)HttpContext.Current.Session["User"]).UserName;
            scheme_code = ((ATTUser)HttpContext.Current.Session["User"]).scheme_code;
            UserId = ((ATTUser)HttpContext.Current.Session["User"]).UserId; ;
            Email = ((ATTUser)HttpContext.Current.Session["User"]).Email; ;
            l_company_id = ((ATTUser)HttpContext.Current.Session["User"]).l_company_id; ;
            Name = ((ATTUser)HttpContext.Current.Session["User"]).Name; ;
            SHHOLDERNO = ((ATTUser)HttpContext.Current.Session["User"]).SHHOLDERNO;
            Contact_No = ((ATTUser)HttpContext.Current.Session["User"]).Contact_No;
            Contact_No2 = ((ATTUser)HttpContext.Current.Session["User"]).Contact_No2;
            var data =
                (String.IsNullOrEmpty(BOID) ? "-" : BOID) + '/' +
                (String.IsNullOrEmpty(UserName) ? "-" : UserName) + '/' +
                (String.IsNullOrEmpty(scheme_code) ? "-" : scheme_code) + '/' +
                (String.IsNullOrEmpty(UserId.ToString()) ? 0 : UserId) + '/' +
                (String.IsNullOrEmpty(Email) ? "-" : Email) + '/' +
                (String.IsNullOrEmpty(l_company_id) ? "-" : l_company_id) + '/' +

                (String.IsNullOrEmpty(Name) ? "-" : Name) + '/' +
                (String.IsNullOrEmpty(SHHOLDERNO) ? "-" : SHHOLDERNO) + '/' +
                (String.IsNullOrEmpty(Contact_No) ? "-" : Contact_No) + '/' +
                (String.IsNullOrEmpty(Contact_No2) ? "-" : Contact_No2);
            return data;
            //var  record = null;


        }

        public void SetCaptchaSession(string Captcha)
        {
            HttpContext.Current.Session["captcha"] = Captcha;

        }
        public List<ATTMenu> GetLoginMenus()
        {
            List<ATTMenu> lstMenu = new List<ATTMenu>();

            if (HttpContext.Current.Session["User"] != null)
                lstMenu = ((ATTUser)HttpContext.Current.Session["User"]).Menus;

            return lstMenu;
        }
        public List<ATTMenu> GetSubMenus()
        {
            List<ATTMenu> lstMenu = new List<ATTMenu>();

            if (HttpContext.Current.Session["User"] != null)
                lstMenu = ((ATTUser)HttpContext.Current.Session["User"]).Menus;

            return lstMenu;
        }

        //public string CurrentToken()
        //{
        //    string token = "";

        //    if (HttpContext.Current.Session["Token"] != null)
        //        token = HttpContext.Current.Session["Token"].ToString();
        //    else
        //        token = "-1";

        //    return token;
        //    //return "1";
        //}


        public bool IsValidUser()
        {
            bool flag = false;

            if (HttpContext.Current.Session["User"] != null)
                flag = true;

            return flag;
        }
        public bool IsValidPage()
        {
            bool flag = false;

            if (HttpContext.Current.Session["token"] != null)
                flag = true;

            return flag;
        }

        /// <summary>
        /// Returns the default content type returned by the handler.
        /// </summary>
        /// <returns></returns>
        public virtual string DefaultContentType()
        {
            return "application/json";
        }

        public void SetResponseContentType(string value)
        {
            context.Response.ContentType = value;
        }

        /// <summary>
        /// Setting this to false will make the handler to respond with exacly what the called method returned.
        /// If true the handler will try to serialize the content based on the ContentType set.
        /// </summary>
        public bool SkipDefaultSerialization { get; set; }

        /// <summary>
        /// Setting this to true will avoid the handler to change the content type wither to its default value or to its specified value on the request.
        /// This is useful if you're handling the request yourself and need to specify it yourself.
        /// </summary>
        public bool SkipContentTypeEvaluation { get; set; }

        /// <summary>
        /// Prints an help page discribng the available methods on this handler.
        /// </summary>
        /// <returns></returns>
        public string Help()
        {
            context.Response.ContentType = "text/html";

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<style>");
            sb.AppendLine(".MainHeader { background-color: FFFFE0; border: 1px dashed red; padding: 0 10 0 10; }");
            sb.AppendLine("h3 { background-color: #DCDCDC; }");
            sb.AppendLine("ul { background-color: #FFFFFF; }");
            sb.AppendLine(".type { color: gray; }");
            sb.AppendLine("</style>");

            sb.AppendLine("<div class='MainHeader'><h2>Handler available methods</h2></div>");

            MethodInfo[] methods = this.GetType().GetMethods();	// All methods found on this type
            MethodInfo[] excludeMethods = this.GetType().BaseType.GetMethods();	// methods from the base class are not to be shown

            foreach (var m in methods)
            {
                // do nothing if the current method belongs to the base type.
                // I'm not supporting overrides here, I'm only searching by name, if more than one method with the same name exist they all will be ignored.
                if (excludeMethods.FirstOrDefault(c => c.Name == m.Name) != null)
                    continue;

                ParameterInfo[] parameters = m.GetParameters();

                bool RequiresAuthentication = false;

                sb.AppendLine("<h3>" + m.Name + (RequiresAuthentication ? " <span style=\"color:#f00\">[Requires Authentication]</span>" : string.Empty) + "</h3>");

                sb.AppendLine("<table><tr><td width=\"250px\">");
                sb.AppendLine("<table width=\"100%\">");
                foreach (var p in parameters)
                {
                    sb.AppendLine("<tr><td>" + p.Name + "</td><td><span class='type'>[" + p.ParameterType.ToString() + "]</span></td></tr>");
                }

                sb.AppendLine("</table>");

                sb.AppendLine("</td><td style=\"border-left: 1px dashed #DCDCDC; padding-left: 8px;\">");

                string getJSONSample = "<pre>$.getJSON(\n\t'" + context.Request.Url.LocalPath + "', \n\t{method: \"" + m.Name + "\", returntype: \"json\", args: {";
                foreach (var p in m.GetParameters())
                {
                    getJSONSample += " " + p.Name + ": \"\",";
                }
                getJSONSample = getJSONSample.TrimEnd(',') + " ";
                getJSONSample += "}}, \n\tfunction() { alert('Success!'); });</pre>";
                sb.AppendLine(getJSONSample);

                sb.AppendLine("</td>");
                sb.AppendLine("</tr></table>");
            }
            return sb.ToString();
        }

        public JsonResponse Execute(Func<JsonResponse> action)
        {
            try
            {
                return action();
            }
            catch (Exception ex)
            {
                JsonResponse response = new JsonResponse();
                response.IsSucess = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public void ValidateToken(string Users /* User with their userType */, string Role)
        {
            JWT jwt = new JWT();
            string ClientToken = context.Request.Headers["Token"];
            try
            {
                string guid = context.Session["Guid"].ToString();
                jwt = JSONWebToken.DecodeToken(ClientToken, guid);
            }
            catch (Exception)
            {
                throw new Exception("403");
            }
            string currToken = CurrentToken();
            bool output = currToken == ClientToken;
            if (!string.IsNullOrEmpty(Users))
            {
                string[] lstUsers = Users.Split('|');
                Dictionary<char, string> hashUsers = new Dictionary<char, string>();
                foreach (string user in lstUsers)
                {
                    hashUsers[user[0]] = user.Substring(1);
                }

                if (!hashUsers.ContainsKey(jwt.payload.Type[0]))
                {
                    throw new Exception("403");

                }
                else
                {
                    string[] userlist = hashUsers[jwt.payload.Type[0]].Split(',');
                    bool userAllowed = string.IsNullOrEmpty(hashUsers[jwt.payload.Type[0]]);
                    userAllowed = userAllowed || Array.IndexOf(userlist, jwt.payload.ID) > -1;
                    output = output && userAllowed;
                }
            }
            if (Role != null)
            {
                string[] roles = Role.Split(' ');
                output = output && Array.IndexOf(roles, jwt.payload.Role) > -1;
            }
            if (!output)
            {
                throw new Exception("403");
            }
        }

        public string Execute(Func<string> action)
        {
            try
            {
                return action();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


    }
}
