using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SI.KYC.ATT;

namespace SI.RequestHandling.ATT
{
   public class ATTShareTransaction
    {
       public string l_company_id { get; set; }
        public string Scheme_code { get; set; }
        public string ccode { get; set; }
        public int? REQUEST_NO { get; set; }
        public string IS_UNIT_HOLDER { get; set; }
        public int? ShHolderNo { get; set; }
        public Int64 Bo_Account_No { get; set; }
        //public string Bo_Account_No { get; set; }
        public string Name { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string FaName { get; set; }
        public string GFName { get; set; }
        public string address { get; set; }
        public string P_Tel_No { get; set; }
        public string P_Mobile_no { get; set; }
        public string BankCode { get; set; }
        public string Branch_code { get; set; }
        public string Bank_Account_No { get; set; }
        public string PAN_No { get; set; }
        public string Reg_No { get; set; }
        public string Citizenship_No { get; set; }
        public bool IsInstitution { get; set; }
        public float APPLY_UNIT { get; set; }
        public string Email_ID { get; set; }
        public string GatewayCode { get; set; }

        public string payeename { get; set; }
        public string PayeeContactNo { get; set; }

        public string source { get; set; }
        public string File1 { get; set; }
        public string File3 { get; set; }
        public string File2 { get; set; }

        public string FileName1 { get; set; }
        public string FileName2 { get; set; }
        public string FileName3 { get; set; }

        public string APPLY_DT { get; set; }
        public string AMOUNT { get; set; }
        public string cashorcheque { get; set; }
        public string bcode_cheque { get; set; }
        public string CHK_NO { get; set; }
        public string ENTRY_BY { get; set; }
        public string ENTRY_DT { get; set; }
        public string APPROVED { get; set; }
        public string APPSTATUS { get; set; }
        public string APPROVED_BY { get; set; }
        public string APP_DATE { get; set; }

        public string appno { get; set; }
        public string remarks { get; set; }
        public float current_nav { get; set; }
        public string nav_date { get; set; }
        public string exit_load { get; set; }
        public string cal_type { get; set; }
        public float charge_amount { get; set; }
        public string SCharge_Code { get; set; } 
        public string Action { get; set; }
        // public float tot_redeem_amount { get; set; }
        public float tot_redeem_amount { get; set; }
        public float tot_exit_load { get; set; }
        public float tot_capital_gain { get; set; }
        public float capital_gain_tax { get; set; }
        public float tot_redeem_amt_nav { get; set; }
        public float other_charges { get; set; }
        public string Posting_remark { get; set; }
        public string bankname { get; set; }
        public float capital_gain_tax_amt { get; set; }
        public string gainloss_status { get; set; }
        public string totalreceived { get; set; }
        public string CompEnName { get; set; }//purchase entry report
        public string cname { get; set; } // Purchase Entry Report
        public string IsChequeClear { get; set; }
        public string Is_SIP { get; set; }
        public string ClearedDate { get; set; }
        public string ChequeCheckedBy { get; set; }
        public string CashAmount { get; set; }
        public string ChequeAmount { get; set; }
        public float SEBON_Fee { get; set; }
        public float TotalKitta { get; set; }
        public float BalUnit { get; set; }
        public float Inv_Amt { get; set; }
        public int? DREQUEST_NO { get; set; }
        public string TranType { get; set; }
        public string Status { get; set; }
        public string TransNo { get; set; }
        public string TransAmount { get; set; }
        public string TransStatus { get; set; }
        public string TransactedBy { get; set; }

        public float net_payable_bef_tax { get; set; }//UnitRedemption Statement
        public string SchemeName { get; set; }//UnitRedemption Statement
        public string Calculation_For { get; set; }//UnitRedemption Statement

        public string DPName { get; set; }
        public string DPCode { get; set; }
        public string DP_Id_Cds { get; set; }
        public string DepoName { get; set; }

        public string DOB  { get; set; }
       
        private List<ATTTransactionDetail> _Transaction = new List<ATTTransactionDetail>();
        public List<ATTTransactionDetail> Transaction
        {
            get { return _Transaction; }
            set { _Transaction = value; }
        }

        private List<ATTSign> _Sign = new List<ATTSign>();
        public List<ATTSign> Sign
        {
            get { return _Sign; }
            set { _Sign = value; }
        }
        //Refund And Unit Settlement

        public string is_settlement { get; set; }
        public string Unit_settlement { get; set; }
        public float refund_amount { get; set; }
        public string OTP { get; set; }
        public double Amt { get; set; }
        public bool HasDrep { get; set; }
        public string BOID { get; set; }

        public string OTPContact { get; set; }

    }
}
