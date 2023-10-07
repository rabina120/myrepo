using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SI.SIPHandling.ATT
{
    public class ATTUnitSIPRequest
    {


        public string scheme_code { get; set; }
        public string ccode { get; set; }
        public string boid { get; set; }
        public string Name { get; set; }
        public int Interval_Seq_No { get; set; }
        public float charge_amount { get; set; }
        public string REQUEST_NO { get; set; }
        public int? ShHolderNo { get; set; }
        public string SIP_Reg_No { get; set; }
        public string IS_UNIT_HOLDER { get; set; }
        public float Sip_amt { get; set; }
        public string SIP_Due_Day { get; set; }
        public float SIP_Unit { get; set; }
        public string Action_Date { get; set; }
        public string Payment_Date { get; set; }
        public string SCharge_Code { get; set; }
        public float DP_Charge { get; set; }
        public float SEBON_Fee { get; set; }
        public string Current_NAV { get; set; }
        public string NAV_Date { get; set; }
        public string PaymentMode { get; set; }
        public string PaymentCode { get; set; }
        public float Refund_Amt { get; set; }
        public float BalanceAmt { get; set; }
        public string IsInstitution { get; set; }
        public string P_PaymentCode { get; set; }
        public string BankAccountNo { get; set; }
        public string PayeeName { get; set; }
        public string Is_SIP { get; set; }
        public string Posting_remark { get; set; }
        public string Status { get; set; }
        public string ENTRY_DT { get; set; }
        public string ENTRY_BY { get; set; }
        public string Approved_Date { get; set; }
        public string Approved_By { get; set; }
        public string IsApproved { get; set; }
        public string Action { get; set; }
        public string cname { get; set; }
        public string SIP_Interval { get; set; }
        public string SIP_Reg_Date { get; set; }
        public string SIP_Last_Date { get; set; }
        public string Interval_No { get; set; }
        public string l_company_id { get; set; }
        public string Terms { get; set; }
        public string remarks { get; set; }// excel
        public string ReceivedAmt { get; set; }// excel
        public string RPaymentCode { get; set; }// excel

        public string TranType { get; set; }
        //    public string Status { get; set; }
        private List<ATTPaymentMode> _PType = new List<ATTPaymentMode>();
        public List<ATTPaymentMode> PType
        {
            get { return _PType; }
            set { _PType = value; }
        }

        public string SchemeEnName { get; set; }


        public string modeofSIP { get; set; }
    }
}
