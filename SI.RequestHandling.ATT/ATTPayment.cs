using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SI.RequestHandling.ATT
{
   public class ATTPayment

    {
       public string merchantId { get; set; }
       public string appId { get; set; }
       public string referenceId { get; set; }
       public string txnAmt { get; set; }
       public string token { get; set; }
       public string statusDesc { get; set; }
       public string status { get; set; }
       public string amount { get; set; }
       public string idx { get; set; }
       public string product_identity { get; set; }
     
       public string Integrationcode { get; set; }
       public string GatewayCode { get; set; }
       public DateTime TranDate { get; set; }
       public string TXNID { get; set; }
       public string product_url { get; set; }
       public ATTState state { get; set; }

        // For Ebanking
        public string BID { get; set; }
        public string PREF { get; set; }
        public string CustRefType { get; set; }
        public string AMOUNT { get; set; }

        // For ESewa
        public string refId { get; set; }
        public string oid { get; set; }
        public string amt { get; set; }
        public string scd { get; set; }

        public ATTEBankingVerifyTxnResponse verifyTxnResult { get; set; }


    }
}
