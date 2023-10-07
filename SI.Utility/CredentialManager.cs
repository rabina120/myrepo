using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SI.Utility
{
    public class CredentialManager
    {
        #region Server Credentials
        public static string UserName
        {
            get { return "sa"; }
        }

        public static string Password
        {

          get { return "P@SSW0RD"; }
         //  get { return "Shareplus_123"; }  //live or test

        }

        public static string ServerIP
        {

           get { return "208.109.10.110"; }
          //get { return "10.129.129.58"; }

        //    get { return "."; }
          
        }

        public static string DatabaseName
        {
            get { return "Shareplus_NIBL_Mutual_Openend"; }

           // get { return "NIBL_Shareplus_Mutual_Openend"; }  //live

        }

    #endregion

        #region Email Credentials

        //commented ones are the credentials for live system
        public static string EmailHost {
         // get { return "mail.niblcapital.com"; }  //live

            get { return "smtp.gmail.com"; }  //test
        }
        public static int EmailPort {
         // get { return 25; } //live
            get { return 587; }  //test
        }
        public static string EmailUserName {
            //get { return "noreply@niblcapital.com"; }  //live
            get { return "niblsip@gmail.com"; }   //test
        }
        public static string EmailPassword
        {
          //get { return "Nepal@123#"; }  //live
           get { return "P@$$WORDNIBLSIP@123"; }
        }
        public static bool EmailEnableSSL
        {
            get { return true; }
        }
        public static bool EmailDefaultCredential
        {
            get { return true; }
        }


        #endregion


        #region API integration of Khalti Gateway Payment

        public static string APIUrlOfKhalti
        {      
            get { return "https://khalti.com/api/v2/payment/verify/"; }   // both live or test
        }
        public static string Khaltiref
        {
           // get { return "live_public_key_b774da1009f44eb2ba520be366cbc259"; }  //live
            get { return "test_public_key_21ac16e7b85a43f2944075016a3de602"; }   //test
        }

        public static string APIKeyOfKhalti
        {
           //get { return "live_secret_key_74441de83d034ae28938a0f85907043d"; }  //live
           get { return "test_secret_key_2cfa887c4475429fa4579a9358c5770e"; }   //test
        }
    
        #endregion

        #region API integration of Connectips Gateway Payment


        public static string ConnectIpsiref
        {
            //get { return "https://login.connectips.com:7443/connectipswebgw/loginpage"; } //live
            get { return "https://uat.connectips.com:7443/connectipswebgw/loginpage"; }  //test
        }
        public static string APIUrlOfConnectIPS
        {
          //  get { return "https://login.connectips.com:7443/connectipswebws/api/creditor/validatetxn"; }  //live
            get { return "https://uat.connectips.com:7443/connectipswebws/api/creditor/validatetxn"; }  //test
        }


        #endregion


        #region API integration of NIBL_Ebanking  Gateway Payment


        public static string EBankingPID
        {
          //  get { return "000000003585"; } //live
            get { return "000000000172"; }  //test
        }
        public static string EBankingLoginURL
        {
          //  get { return "https://www.nibl.com.np/BankAwayRetail/sgonHttpHandler.aspx?Action.ShoppingMall.Login.Init=Y"; }  //live
            get { return "http://202.63.245.70/BankAwayRetail/sgonHttpHandler.aspx?Action.ShoppingMall.Login.Init=Y"; }  //test
        }

        public static string APIUrlOfEbanking
        {
           // get { return "https://www.nibl.com.np/VerifyThis/VerifyThis.asmx"; }  //live
            get { return "http://202.63.245.70/VerifyThis/VerifyThis.asmx"; }  //test
        }


        #endregion


        #region API integration of E_Sewa  Gateway Payment


        public static string Esewascd
        {
        //  get { return "NP-ES-NIBLMF"; }   //live product code NIBL
            get { return "EPAYTEST"; }  //  test
        }
        public static string ESewaRef
        {
       //     get { return "https://esewa.com.np/epay/main"; }  //live
            get { return "https://uat.esewa.com.np/epay/main"; }  //test
        }

        public static string APIUrlOfESewa
        {
         //  get { return "https://esewa.com.np/epay/transrec"; }  //live
            get { return "https://uat.esewa.com.np/epay/transrec"; }  //test
        }

        #endregion


        #region  PayMarchantId and PayAppId  for connectips


        public static string PayMarchantId
        {
          //  get { return "467"; } //live
            get { return "827"; }  //test
        }
        public static string PayAppIdUnitPurchase
        {
         // get { return "MER-467-APP-4"; }  //live
            get { return "MER-827-APP-1"; }  //test
        }

        public static string PayAppIdSIPRegistration
        {
        //    get { return "MER-467-APP-5"; }  //live
            get { return "MER-827-APP-2"; }  //test
        }


        public static string PayAppIdSIPPayment
        {
          //get { return "MER-467-APP-6"; }  //live
           get { return "MER-827-APP-3"; }  //test
        }

        public static string PayAppIdLoginUnitPurchase
        {
        //   get { return "MER-467-APP-7"; }  //live
            get { return "MER-827-APP-4"; }  //test
        }


        public static string PayAppIdLoginSIPPayment
        {
          // get { return "MER-467-APP-8"; }  //live
            get { return "MER-827-APP-5"; }  //test
        }

        public static string PayAppIdLoginSIPRegistration
        {
         //   get { return "MER-467-APP-9"; }  //live
            get { return "MER-827-APP-6"; }  //test
        }


        #endregion

            
        #region   URL of Payment System

        public static string UnitPurchaseURL
        {
           // get { return "https://mutualfund.niblcapital.com/Modules/MainPage/UnitPurchase.aspx"; } //live
            get { return "http://localhost:53161/Modules/MainPage/UnitPurchase.aspx"; }  //test
        }
        public static string SIPRegistrationURL
        {
          //get { return "https://mutualfund.niblcapital.com/Modules/MainPage/SIPRegistration.aspx"; }  //live
            get { return "http://localhost:53161/Modules/MainPage/SIPRegistration.aspx"; }  //test
        }

        public static string SIPPaymentURL
        {
         //   get { return "https://mutualfund.niblcapital.com/Modules/MainPage/SIPPayment.aspx"; }  //live
            get { return "http://localhost:53161/Modules/MainPage/SIPPayment.aspx"; }  //test
        }


        public static string LoginUnitPurchaseURL
        {
         //  get { return "https://mutualfund.niblcapital.com/Modules/RequestHandling/PurchaseRequestEntry.aspx"; }  //live
            get { return "http://localhost:53161/Modules/RequestHandling/PurchaseRequestEntry.aspx"; }  //test
        }

        public static string LoginSIPRegistrationURL
        {
       //      get { return "https://mutualfund.niblcapital.com/Modules/SIPHandling/SIP_Registration.aspx"; }  //live
            get { return "http://localhost:53161/Modules/SIPHandling/SIP_Registration.aspx"; }  //test
        }

        public static string LoginSIPPaymentURL
        {
         //  get { return "https://mutualfund.niblcapital.com/Modules/SIPHandling/SIPPayment.aspx"; }  //live
            get { return "http://localhost:53161/Modules/SIPHandling/SIPPayment.aspx"; }  //test
        }


        #endregion
      


    }
}
