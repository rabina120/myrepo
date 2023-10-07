using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SI.SIPHandling.ATT
{
    public class ATTRegCompany
    {
        public string l_company_id { get; set; }
        public string DistCode { get; set; }
        public string dname { get; set; }
        public string NpDistName { get; set; }
        public string ProvinceCode { get; set; }
        public int CID { get; set; }
        public string Sname { get; set; }
        public int? SubmissionNo { get; set; }
        public string scheme_code { get; set; }
        public string ccode { get; set; }
        public string CompName { get; set; }
        public string Contact1 { get; set; }
        public string Contact2 { get; set; }
        public string Email { get; set; }
        public string Comp_Type { get; set; }
        public string Owner_Name { get; set; }
        public string Owner_Email { get; set; }
        public string Owner_Add { get; set; }
        public string Owner_Ph { get; set; }
        public string ENTRY_BY { get; set; }
        public string ENTRY_DT { get; set; }
        public string IsApproved { get; set; }
        public string APPSTATUS { get; set; }
        public string APPROVED { get; set; }
        public string Action { get; set; }
        public string Certificate { get; set; }
        public string CertType_No { get; set; }
        public string AddressType { get; set; }
        public string AddType_No { get; set; }
        public string Approved_by { get; set; }
        public string Approved_Date { get; set; }
        //public string ProvinceCode { get; set; }
        private List<ATTAddress_Detail> _Address_info = new List<ATTAddress_Detail>();
        public List<ATTAddress_Detail> Address_info
        {
            get; //{ return _Address_info; }
            set;//{ _Address_info = value; }
        }
        private List<ATTCertificate_Detail> _Certificate_info = new List<ATTCertificate_Detail>();
        public List<ATTCertificate_Detail> Certificate_info
        {
            get;//{ return Certificate_info; }
            set;//{ Certificate_info = value; }
        }
    }
}
