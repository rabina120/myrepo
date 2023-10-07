using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SI.KYC.ATT
{
   public class ATTShHolder
    {

        public string Scheme_code { get; set; }
        public string ccode { get; set; }
        public string cname { get; set; }
        public string company_code { get; set; }
        public int? ShHolderNo { get; set; }
        public string Title { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
        public string LName { get; set; }
        public string Nep_DOB { get; set; }
        public string Eng_DOB { get; set; }
        public string NepName { get; set; }
        public string NepAddress { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string Citizenship_No { get; set; }
        public string Cit_Issue_District { get; set; }
        public string Cit_Issue_Dt { get; set; }
        public string Bo_Account_No { get; set; }
        public string PAN_No { get; set; }
        public string NRN_ID { get; set; }
        public string IS_UNIT_HOLDER { get; set; }
        public string P_CountryCode { get; set; }
        public string P_ProvinceCode { get; set; }
        public string P_DistrictCode { get; set; }
        public string P_Mun { get; set; }
        public string P_Ward_No { get; set; }
        public string P_Tole { get; set; }
        public string P_Tel_No { get; set; }
        public string P_Mobile_no { get; set; }
        public string Email_ID { get; set; }
        public string Website { get; set; }
        public string T_CountryCode{ get; set; }
        public string T_ProvinceCode { get; set; }
        public string T_DistrictCode { get; set; }
        public string T_Mun { get; set; }
        public string T_Tel_No { get; set; }
        public string T_Ward_No { get; set; }
        public string T_Tole { get; set; }
        public string T_Mobile_No { get; set; }

        public string FaName { get; set; }
        public string GFName { get; set; }
        public string MotherName { get; set; }
        public string SpouseName { get; set; }
        public string SonName { get; set; }
        public string DaughterName { get; set; }
        public string DaughterinLawName { get; set; }
        public string MotherinLawName { get; set; }
        public string ChiefExecutiveName { get; set; }
        public string FatherinLawName { get; set; }

        public string Ref_Name { get; set; }
        public string Ref_Address { get; set; }
        public string Ref_ContactNo { get; set; }
        public string Reference_No { get; set; }
 
        public string IsMinor { get; set; }
        public string IsInstitution { get; set; }

        public string Com_SecretaryName { get; set; }
        public string Company_Type { get; set; }
        public string Country_of_Registration { get; set; }
        public string Reg_No { get; set; }
        public string Reg_Office { get; set; }
        public string Reg_Date { get; set; }
        public string VAT_Reg_No { get; set; }
        public string Main_Com_Name { get; set; }
        public string Main_Com_Address { get; set; }
        public string Business_Nature { get; set; }
        public string Area_of_Work { get; set; }
        public string IsListed { get; set; }
        public string Listed_Dt { get; set; }
        public string BankAccountType { get; set; }
        public string Bank_Account_No { get; set; }
        public string BankCode { get; set; }
        public string Branch_code { get; set; }
        public string TotalKitta { get; set; }
        public float? TfracKitta { get; set; }
        public string EntryBy { get; set; }
        public string Entry_Dt { get; set; }
        public string Approved { get; set; }
        public string App_Status { get; set; }
        public string Approved_By { get; set; }
        public string App_remarks { get; set; }
        public string App_date { get; set; }
        public string Action { get; set; }
        public float BalUnit { get; set; }
        public double Inv_Amt { get; set; }
        private List<ATTOccupatinDetail> _OccDetail = new List<ATTOccupatinDetail>();
        public List<ATTOccupatinDetail> OccDetail
        {
            get { return _OccDetail; }
            set { _OccDetail = value; }
        }
        private List<ATTInstitutionDetail> _InsDetail = new List<ATTInstitutionDetail>();
        public List<ATTInstitutionDetail> InsDetail
        {
            get { return _InsDetail; }
            set { _InsDetail = value; }
        }
        private List<ATTMinor> _Minor = new List<ATTMinor>();
        public List<ATTMinor> Minor
        {
            get { return _Minor; }
            set { _Minor = value; }
        }
        private List<ATTNominee> _Nominee = new List<ATTNominee>();
        public List<ATTNominee> Nominee
        {
            get { return _Nominee; }
            set { _Nominee = value; }
        }
        private List<ATTInstitutionaldetail_sign> _Ins_Sign = new List<ATTInstitutionaldetail_sign>();
        public List<ATTInstitutionaldetail_sign> Ins_Sign
        {
            get { return _Ins_Sign; }
            set { _Ins_Sign = value; }
        }
        private List<ATTSignature> _Signature = new List<ATTSignature>();
        public List<ATTSignature> Signature
        {
            get { return _Signature; }
            set { _Signature = value; }
        }
        private List<ATTSign> _Sign = new List<ATTSign>();
        public List<ATTSign> Sign
        {
            get { return _Sign; }
            set { _Sign = value; }
        }
        public string Per_ProvinceName { get; set; }
        public string Per_CountryName { get; set; }
        public string Per_DistName { get; set; }
        //public string HasDrep { get; set; }


        public bool HasDrep { get; set; }
    }
}
