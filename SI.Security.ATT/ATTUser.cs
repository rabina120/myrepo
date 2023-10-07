using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SI.Security.ATT
{
  public class ATTUser
    {
      public string l_company_id { get; set; }
      public string scheme_code { get; set; }
      public int UserId { get; set; }
      public int RoleId { get; set; }
      public string BOID { get; set; }
      public string UserName { get; set; }
      public string Password { get; set; }
      public string DOB { get; set; }
      public string Email { get; set; }
      public string Name { get; set; }
      public string Contact_No { get; set; }
      public string Contact_No2 { get; set; }
      public string Signature1 { get; set; }
      public string FileName { get; set; }
      public string SignName { get; set; }
      public string UploadFile { get; set; }
      public string SHHOLDERNO { get; set; }
      public string Origin { get; set; }
      public string OTP { get; set; }
      public string OTPContact { get; set; }
        public string Remarks { get; set; }
        public string CreatedDate { get; set; } // change
        public string IS_UNIT_HOLDER { get; set; }
        public string Gender { get; set; }
        public string activationcode { get; set; }//
        public string ActiveStatus { get; set; }//
        public string IsApproved { get; set; }//
        public string ApprovedBy { get; set; }//
        public string ApprovedDate { get; set; }//
        public string Counter { get; set; }
        public bool  LoggedIn { get; set; }
        public string Citizenship_No { get; set; }
        public string Gatewaycode { get; set; }

        public string PAN_No { get; set; }
        public string bankname { get; set; }
        public string DP_NAME { get; set; }
        public string Bank_Account_No { get; set; }
        public List<ATTMenu> Menus { get; set; }
    }
}
