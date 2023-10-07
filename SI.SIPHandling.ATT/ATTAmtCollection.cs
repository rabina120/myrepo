using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SI.SIPHandling.ATT
{
   public  class ATTAmtCollection
    {
        public string l_company_id { get; set; }
        public string scheme_code { get; set; }
        public string ccode { get; set; }
        public string trans_no { get; set; }
        public int? ShHolderNo { get; set; }
        public int? DSIP_Reg_No { get; set; }
        public string SIP_Reg_No { get; set; }
        public string Name { get; set; }
        public float Amount { get; set; }
        public string BOID { get; set; }
        public string tran_dt { get; set; }
        public string PaymentCode { get; set; }
        public string SIP_Amount { get; set; }
        public string Interval_No { get; set; }
        public string cname { get; set; }
        public string SchemeEnName { get; set; }
        public string PaymentMode { get; set; }
        public string dbcr { get; set; }
        public string entry_user { get; set; }
        public string entry_dt { get; set; }
        public string remarks { get; set; }
        public string approved_date { get; set; }
        public int Interval_Seq_No { get; set; }
        public string approved_by { get; set; }
        public string Action { get; set; }
        public string OnlineTransNo { get; set; }
        public string TransStatus { get; set; }
        public string TransactedBy { get; set; }
        public string TXNID { get; set; }
        public string Integrationcode { get; set; }
        public string GatewayCode { get; set; }
    }

}
