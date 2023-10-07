using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using SI.Utility;
using System.Text;
using SI.RequestHandling.ATT;
using SI.RequestHandling.BLL;
using System.Xml.Linq;
using RestSharp;
using System.Configuration;
using SI.Common.BLL;
using ATTCollection;
using SI.SIPHandling.BLL;
using SI.RequestHandling.DLL;
using SI.SIPHandling.DLL;
using SI.SIPHandling.ATT;

namespace Openend_SIP.Handler.Collection
{
    /// <summary>
    /// Summary description for CollectionHandler
    /// </summary>
    public class CollectionHandler : BaseHandler
    {
        public object GetToken(string data)
        {

            JsonResponse response = new JsonResponse();
            try
            {
                response.data = CryptoHelper.getIPSToken(data);
                response.Message = "Success";
                response.IsSucess = true;
            }
            catch (Exception ex)
            {
               response.Message = ex.Message;
               response.IsSucess = false;
            }

            return JsonUtility.Serialize(response);
        }


        // Verification of Connect IPS Gateway Payment
        public object ValidatePayment(string data, string Action, string ReferenceID, string AppID, string PayAppName, string GatewayCode, string PaymentCode)
        {
            ATTCIPS objATT = JsonUtility.DeSerialize(data, typeof(ATTCIPS)) as ATTCIPS;
            JsonResponse response = new JsonResponse();
            JsonResponse response1 = new JsonResponse();
            
            string Amount = "";
            if (GatewayCode == "001" || GatewayCode == "004")
            {               
                SI.RequestHandling.BLL.BLLPurchaseRequest bllpur = new SI.RequestHandling.BLL.BLLPurchaseRequest();
                response1 = bllpur.ValidateAmount(objATT.referenceId);            
                DLLPurchaseRequest objDll = new DLLPurchaseRequest();
                List<ATTShareTransaction> obj = objDll.ValidateAmount(objATT.referenceId);
                foreach (var item in obj)
                {                    
                   float purAmt = float.Parse(item.AMOUNT) * 100;
                    Amount = purAmt.ToString();
                }             
            }           
            if (GatewayCode == "002" || GatewayCode == "005" || GatewayCode == "003" || GatewayCode == "006")
            {           
                

                DLLSIP_Registration objDll = new DLLSIP_Registration();
                List<ATTSIP_Registration>  obj= objDll.ValidateSIPAmount(objATT.referenceId,  objATT.Action);
                foreach (var item in obj)
                {
                    float sipAmt = item.Sip_amt * 100;
                    Amount = sipAmt.ToString();

                }
            }
            if (objATT.txnAmt == Amount)
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;                
                WebClient client = new WebClient();
                string apiUrl = CredentialManager.APIUrlOfConnectIPS;
                try
                {
                    string credentials = Convert.ToBase64String(
                            Encoding.ASCII.GetBytes(AppID + ":" + "Abcd@123"));
                    client.Headers[HttpRequestHeader.Authorization] = string.Format(
                        "Basic {0}", credentials);
                    client.Headers["Content-type"] = "application/json";
                    client.Encoding = Encoding.UTF8;
                    response.data = client.UploadString(apiUrl, data);
                    if (Action == "U")
                    {
                        ATTPayment objATTShare = JsonUtility.DeSerialize(response.data, typeof(ATTPayment)) as ATTPayment;
                        SI.RequestHandling.BLL.BLLPurchaseRequest bllObj = new SI.RequestHandling.BLL.BLLPurchaseRequest();
                        response.ResponseData = bllObj.UpdateTransactionStatus(objATTShare, Action, ReferenceID, PayAppName, GatewayCode, PaymentCode);
                    }
                    response.Message = "Success";
                    response.IsSucess = true;
                }
                catch (Exception ex)
                {
                    response.Message = ex.Message;
                    response.IsSucess = false;
                }               
            }
            else 
            {
                response.IsSucess = false;
                response.Message = "Invalid data";
            }
            return JsonUtility.Serialize(response);
        }

        // Verification of Khalti Gateway Payment
        public object VerifyKhaltiPayment(string data, string Action, string GatewayCode, string TXNID, string ReferenceID, string PaymentCode)  
        {
            ATTKhalti objATT = JsonUtility.DeSerialize(data, typeof(ATTKhalti)) as ATTKhalti;
            JsonResponse response = new JsonResponse();
            JsonResponse response1 = new JsonResponse();

            string Amount = "";
            if (GatewayCode == "001" || GatewayCode == "004")
            {
                SI.RequestHandling.BLL.BLLPurchaseRequest bllpur = new SI.RequestHandling.BLL.BLLPurchaseRequest();
                response1 = bllpur.ValidateAmount(objATT.TXNID);
                DLLPurchaseRequest objDll = new DLLPurchaseRequest();
                List<ATTShareTransaction> obj = objDll.ValidateAmount(objATT.TXNID);
                foreach (var item in obj)
                {
                    float purAmt = float.Parse(item.AMOUNT) * 100;
                    Amount = purAmt.ToString();
                }
            }
            if (GatewayCode == "002" || GatewayCode == "005" || GatewayCode == "003" || GatewayCode == "006")
            {
               

                DLLSIP_Registration objDll = new DLLSIP_Registration();
                List<ATTSIP_Registration> obj = objDll.ValidateSIPAmount(objATT.TXNID,  objATT.Action);
                foreach (var item in obj)
                {
                    float sipAmt = item.Sip_amt * 100;
                    Amount = sipAmt.ToString();

                }
            }

            if (objATT.amount == Amount)
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

                WebClient client = new WebClient();
                string apiUrl = CredentialManager.APIUrlOfKhalti;
                try
                {
                    string key = CredentialManager.APIKeyOfKhalti;
                    client.Headers[HttpRequestHeader.Authorization] = string.Format(
                        "Key {0}", key);
                    client.Headers["Content-type"] = "application/json";
                    client.Encoding = Encoding.UTF8;
                    response.data = client.UploadString(apiUrl, data);
                    if (Action == "U")
                    {
                        ATTPayment objATTShare = JsonUtility.DeSerialize(response.data, typeof(ATTPayment)) as ATTPayment;
                        SI.RequestHandling.BLL.BLLPurchaseRequest bllObj = new SI.RequestHandling.BLL.BLLPurchaseRequest();
                        response.ResponseData = bllObj.UpdateKhaltiTransactionStatus(objATTShare, Action, GatewayCode, ReferenceID, TXNID, PaymentCode);
                    }
                    response.Message = "Success";
                    response.IsSucess = true;
                }
                catch (Exception ex)
                {
                    response.Message = ex.Message;
                    response.IsSucess = false;
                }
            }
            else
            {
                response.IsSucess = false;
                response.Message = "Invalid data";
            }
            return JsonUtility.Serialize(response);
        }

        // Verification of E-Banking Gateway Payment
        public object VerifyEBankingPayment(string data, string Action, string GatewayCode, string PaymentCode)
        {
          
            JsonResponse response = new JsonResponse();
            

                ATTPayment objATTShare = JsonUtility.DeSerialize(data, typeof(ATTPayment)) as ATTPayment;

                var client = new RestClient(CredentialManager.APIUrlOfEbanking);

                // var client = new RestClient(ConfigurationManager.AppSettings["APIUrlOfEbanking"]);
                var request = new RestRequest(Method.POST);
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("content-type", "text/xml");

                // Start  Test
                //request.AddHeader("h1", "000000000172");
                //request.AddHeader("h2", "swift");
                //request.AddHeader("h3", "swift1");
                //request.AddParameter("text/xml;charset=utf-8", "<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">" +
                //"<soap:Header><VerifyHeader xmlns=\"http://www.nibl.com.np/\">" +
                //"<H1>000000000172</H1>\r\n " +
                //"<H2>swift</H2>\r\n " +
                //"<H3>swift1</H3></VerifyHeader>" +
                //"</soap:Header>" +
                //"<soap:Body><m:VerifyTxn xmlns:m=\"http://www.nibl.com.np/\">" +
                //"<m:obj1>" + objATTShare.BID + "</m:obj1>" +
                //"<m:obj2>" + objATTShare.CustRefType + "</m:obj2>" +
                //"<m:obj3>" + objATTShare.PREF + "</m:obj3>" +
                //"<m:obj4>" + objATTShare.AMOUNT + "</m:obj4>" +
                //"</m:VerifyTxn></soap:Body></soap:Envelope>", ParameterType.RequestBody);
                // End  Test 

                //  Start Live

                request.AddHeader("h1", "000000003585");
                request.AddHeader("h2", "sahabhagita");
                request.AddHeader("h3", "s@habhagita#123");
                request.AddParameter("text/xml;charset=utf-8", "<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">" +
               "<soap:Header><VerifyHeader xmlns=\"http://www.nibl.com.np/\">" +
               "<H1>000000003585</H1>\r\n " +
               "<H2>sahabhagita</H2>\r\n " +
               "<H3>s@habhagita#123</H3></VerifyHeader>" +
               "</soap:Header>" +
               "<soap:Body><m:VerifyTxn xmlns:m=\"http://www.nibl.com.np/\">" +
               "<m:obj1>" + objATTShare.BID + "</m:obj1>" +
               "<m:obj2>" + objATTShare.CustRefType + "</m:obj2>" +
               "<m:obj3>" + objATTShare.PREF + "</m:obj3>" +
               "<m:obj4>" + objATTShare.AMOUNT + "</m:obj4>" +
               "</m:VerifyTxn></soap:Body></soap:Envelope>", ParameterType.RequestBody);

                //End Live

                try
                {
                    IRestResponse restresponse = client.Execute(request);

                    String xmlContent = restresponse.Content; // Is in xml format
                    XDocument xml = XDocument.Parse(xmlContent);


                    var verifyTxnResponse = xml.Descendants().Where(x => x.Name.LocalName == "VerifyTxnResponse").Select(x => new ATTEBankingVerifyTxnResponse()
                    {
                        VerifyTxnResult = (string)x.Element(x.Name.Namespace + "VerifyTxnResult"),
                    }).FirstOrDefault();
                    string verifyTxnResult = verifyTxnResponse.VerifyTxnResult;
                    string status = null;
                    if (verifyTxnResult.Equals("Failed"))
                    {
                        status = "FAILURE";
                    }
                    else
                    {
                        status = "SUCCESS";
                    }
                    response.data = (data);

                    if (Action == "E")
                    {
                        SI.RequestHandling.BLL.BLLPurchaseRequest bllObj = new SI.RequestHandling.BLL.BLLPurchaseRequest();
                        ATTPayment objATTs = JsonUtility.DeSerialize(response.data, typeof(ATTPayment)) as ATTPayment;
                        objATTs.status = status;
                        objATTs.statusDesc = verifyTxnResult;
                        response.ResponseData = bllObj.UpdateEbankingTransactionStatus(objATTs, Action, GatewayCode, PaymentCode);
                        response.data = status + ' ' + verifyTxnResult;
                    }
                    response.Message = "Success";
                    response.IsSucess = true;
                }
                catch (Exception ex)
                {
                    response.Message = ex.Message;
                    response.IsSucess = false;
                }
            
            return JsonUtility.Serialize(response);         
        }


        public object VerifyEsewaTransaction(string data, string Action, string GatewayCode, string PaymentCode)
        {

            ATTEsewa objATT = JsonUtility.DeSerialize(data, typeof(ATTEsewa)) as ATTEsewa;
            JsonResponse response = new JsonResponse();
            JsonResponse response1 = new JsonResponse();

            float Amount=0 ;
            if (GatewayCode == "001" || GatewayCode == "004")
            {
                SI.RequestHandling.BLL.BLLPurchaseRequest bllpur = new SI.RequestHandling.BLL.BLLPurchaseRequest();
                response1 = bllpur.ValidateAmount(objATT.CustRefType);
                DLLPurchaseRequest objDll = new DLLPurchaseRequest();
                List<ATTShareTransaction> obj = objDll.ValidateAmount(objATT.CustRefType);
                foreach (var item in obj)
                {
                    float purAmt = float.Parse(item.AMOUNT);
                    Amount = purAmt;
                }
            }
            if (GatewayCode == "002" || GatewayCode == "005" || GatewayCode == "003" || GatewayCode == "006")
            {
                

                DLLSIP_Registration objDll = new DLLSIP_Registration();
                List<ATTSIP_Registration> obj = objDll.ValidateSIPAmount(objATT.CustRefType, objATT.Action);
                foreach (var item in obj)
                {
                    float sipAmt = item.Sip_amt;
                    Amount = sipAmt;

                }
            }
            if (objATT.AMOUNT == Amount)
            {
                ATTPayment objATTShare = JsonUtility.DeSerialize(data, typeof(ATTPayment)) as ATTPayment;
                //string apiUrl = ConfigurationManager.AppSettings["APIUrlOfESewa"];
                string apiUrl = CredentialManager.APIUrlOfESewa;
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                string url = apiUrl + "?amt=" + objATTShare.AMOUNT + "&scd=" + objATTShare.scd + "&pid=" + objATTShare.PREF + "&rid=" + objATTShare.BID;

                var request = new RestRequest(Method.GET);
                try
                {
                    var client = new RestClient(url);
                    IRestResponse Esewaresponse = client.Execute(request);
                    String xmlContent = Esewaresponse.Content; // Is in xml format
                    XDocument xml = XDocument.Parse(xmlContent);
                    string Evalue = xml.Root.Value;
                    string Val = (Evalue.Replace("\n", "").Replace("\r", "")).ToUpper();
                    if (Action == "E")
                    {
                        SI.RequestHandling.BLL.BLLPurchaseRequest bllObj = new SI.RequestHandling.BLL.BLLPurchaseRequest();
                        objATTShare.status = Val;
                        objATTShare.statusDesc = Val;
                        response.ResponseData = bllObj.UpdateEbankingTransactionStatus(objATTShare, Action, GatewayCode, PaymentCode);
                        response.data = Val;
                    }
                    response.Message = "Success";
                    response.IsSucess = true;
                }
                catch (Exception ex)
                {
                    response.Message = ex.Message;
                    response.IsSucess = false;
                }
            }
            else
            {
                response.IsSucess = false;
                response.Message = "Invalid data";
            }

            return JsonUtility.Serialize(response);
        }

        public object GetDataByTXNID(string GatewayCode, string TXNID)
        {
            JsonResponse response = new JsonResponse();
            BLLCommon bllObj = new BLLCommon();
            response = bllObj.GetDataByTXNID(GatewayCode, TXNID);
            return JsonUtility.Serialize(response);
        }
    }
}