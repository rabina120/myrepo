using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SI.SIPHandling.ATT
{
    public class ATTHolderStatement
    {
        public string scheme_code { get; set; }
        public string ccode { get; set; }
        public string cname { get; set; }
        public string SIP_Reg_No { get; set; }
        public string Name { get; set; }
        public string Amount_cr { get; set; }
        public string Amount_dr { get; set; }
        public string BOID { get; set; }
        public string installmentDate { get; set; }
        public string dueDate { get; set; }
        public string appnav { get; set; }
        public string unit { get; set; }
        public string lname { get; set; }
        public string actionDate { get; set; }
        public string payment { get; set; }
        public string trans_no { get; set; }
        public string dp { get; set; }

        public string otherCharges { get; set; }

        public string sebon_fee { get; set; }
    }
}
