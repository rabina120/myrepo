using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SI.KYC.ATT
{
  public  class ATTInstitutionDetail
    {
        public string  Scheme_code { get; set; }
        public string ccode { get; set; }
        public int ShHolderNo { get; set; }
        public string RID { get; set; }
        public string Ins_Type { get; set; }
        public string Ins_Name { get; set; }
        public string Ins_Designation { get; set; }
        public string Ins_SpouseName { get; set; }
        public string Ins_FatherName { get; set; }
        public string Ins_GFatherName { get; set; }
        public string Per_Address { get; set; }
        public string Tem_Address { get; set; }
        public string Ins_Tel_No { get; set; }
        public string Ins_Mobile_No { get; set; }
        public string Ins_EmailId { get; set; }
        public string PersonImage { get; set; }
        public string PersonSign { get; set; }
    }
}
