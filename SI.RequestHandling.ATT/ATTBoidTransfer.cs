using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SI.RequestHandling.ATT
{
    public class ATTBoidTransfer
    {
        public string Scheme_code { get; set; }
       // public string ccode { get; set; }
        public string Action { get; set; }
        public int? transfer_id { get; set; }
        public int? shholderno { get; set; }
        public string boidno_from { get; set; }
        public string boidno_to { get; set; }
        public string transfer_dt {get;set;}
        public string entry_by {get; set;}
        public string entry_dt {get;set;}
        public string is_approved {get; set;}
        public string approved_by {get;set;}
        public string app_status {get;set;}
        public string approved_dt {get;set;}
        public string approved_remarks {get;set;}
        public string ccode { get; set; }
        public string FName { get; set; }
        public string FaName { get; set; }
        public string GFName { get; set; }
        public string Bo_Account_No { get; set; }
    }
}
