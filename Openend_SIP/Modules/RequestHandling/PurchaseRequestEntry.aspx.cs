using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SI.Security.BLL;
using SI.Utility;

namespace Openend_SIP.Modules.RequestHandling
{
    public partial class PurchaseRequestEntry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SI.Utility.CsrfHandler.Validate(this.Page, forgeryToken);
            var resbankID = Request.Form["BankId"];
            resbankid.Value = resbankID;

            var resPREF = Request.Form["PREF"];
            respref.Value = resPREF;

            var resAMOUNT = Request.Form["AMOUNT"];
            resamount.Value = resAMOUNT;

            var resBID = Request.Form["BID"];
            resbid.Value = resBID;

            var resCustRefType = Request.Form["CustRefType"];
            rescustreftype.Value = resCustRefType;

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

            var Khaltirefs = CredentialManager.Khaltiref;
            Khaltiref.Value = Khaltirefs;

            var ConnectIpsirefs = CredentialManager.ConnectIpsiref;
            ConnectIpsiref.Value = ConnectIpsirefs;

            var EBankingPIDs = CredentialManager.EBankingPID;
            EBankingPID.Value = EBankingPIDs;

            var EBankingLoginURLs = CredentialManager.EBankingLoginURL;
            EBankingLoginURL.Value = EBankingLoginURLs;

            var Esewascds = CredentialManager.Esewascd;
            Esewascd.Value = Esewascds;

            var ESewaRefs = CredentialManager.ESewaRef;
            ESewaRef.Value = ESewaRefs;

            var PayMarchantIds = CredentialManager.PayMarchantId;
            PayMarchantId.Value = PayMarchantIds;

            var PayAppIdLoginUnitPurchases = CredentialManager.PayAppIdLoginUnitPurchase;
            PayAppIdLoginUnitPurchase.Value = PayAppIdLoginUnitPurchases;

            var LoginUnitPurchaseURLs = CredentialManager.LoginUnitPurchaseURL;
            LoginUnitPurchaseURL.Value = LoginUnitPurchaseURLs;
        }
    }
}