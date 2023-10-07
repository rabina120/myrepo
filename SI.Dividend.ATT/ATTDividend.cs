using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
    
namespace SI.Dividend.ATT
{       
    public class ATTDividend
    {
        public string l_company_id { get; set; }
        public string scheme_code { get; set; }
        public string ccode { get; set; }
        public string Request_No { get; set; }
        public string cname { get; set; }
        public string Bo_Account_No { get; set; }
        public int ShHolderNo { get; set; }
        public string Email { get; set; }
        public string P_Tel_No { get; set; }
        public string P_Mobile_no { get; set; }
        public string Name { get; set; }
        public string DOB { get; set; }
        public string CitizenshipNo { get; set; }
        public string ENTRY_BY { get; set; }
        public string ENTRY_Date { get; set; }
        public string RequestType { get; set; }
        public string TranType { get; set; }

        public string Action { get; set; }
        public string Approved_By { get; set; }
        public string Approved_Date { get; set; }
        public string Posting_remark { get; set; }

        public string Status { get; set; }
        public string RequestDate { get; set; }
    }
}
