using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SI.SIPHandling.ATT;
using System.Data;
using System.Data.SqlClient;
using SI.Utility;

namespace SI.SIPHandling.DLL
{
    public class DLLSipRegistrationReport
    {
        public List<ATTUnitSIPRequest> searchbyreqno(string scheme_code, string ccode, string reqnofrom, string reqnoto, string l_company_id)
        {
            List<ATTUnitSIPRequest> lstSIPHolders = new List<ATTUnitSIPRequest>();
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@ccode", ccode);
                param[1] = new SqlParameter("@scheme_code", scheme_code);
                //param[2] = new SqlParameter("@FormType", FormType);
                param[2] = new SqlParameter("@reqnofrom", reqnofrom);
                param[3] = new SqlParameter("@reqnoto", reqnoto);
                param[4] = new SqlParameter("@l_company_id", l_company_id);

                ds = DAO.gettable("dbo.searchRegisrationByreqno", param);
                //if (FormType == "P")
                //{
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ATTUnitSIPRequest objatt = new ATTUnitSIPRequest();


                    objatt.Action_Date = string.IsNullOrEmpty(dr["SIP_EFF_DATE"].ToString()) ? "" : Convert.ToDateTime(dr["SIP_EFF_DATE"]).ToString("dd/MM/yyyy"); 
                    objatt.boid = dr["BOID"].ToString();
                    objatt.Name = (dr["Name"].ToString());

                    objatt.Sip_amt = float.Parse(dr["SIP_AMT"].ToString());
                    objatt.Terms = dr["Terms"].ToString();

                    objatt.SIP_Reg_Date = string.IsNullOrEmpty(dr["SIP_Reg_Date"].ToString()) ? "" : Convert.ToDateTime(dr["SIP_Reg_Date"]).ToString("dd/MM/yyyy");
                    objatt.SIP_Last_Date = string.IsNullOrEmpty(dr["SIP_Last_Date"].ToString()) ? "" : Convert.ToDateTime(dr["SIP_Last_Date"]).ToString("dd/MM/yyyy"); 
                    objatt.SIP_Reg_No = dr["SIP_Reg_No"].ToString();
                    objatt.SIP_Interval = dr["SIP_Interval"].ToString();
                    lstSIPHolders.Add(objatt);

                }

                // }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lstSIPHolders;
        }

        public List<ATTUnitSIPRequest> searchbyboid(string scheme_code, string ccode, string Bo_Account_No, string l_company_id)
        {
            List<ATTUnitSIPRequest> lstSIPHolderTran = new List<ATTUnitSIPRequest>();
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@ccode", ccode);
                param[1] = new SqlParameter("@scheme_code", scheme_code);
                param[2] = new SqlParameter("@BOID", Bo_Account_No);
                param[3] = new SqlParameter("@l_company_id", l_company_id);
                ds = DAO.gettable("dbo.searchRegistrationByboid", param);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ATTUnitSIPRequest objatt = new ATTUnitSIPRequest();


                    objatt.Action_Date = string.IsNullOrEmpty(dr["SIP_EFF_DATE"].ToString()) ? "" : Convert.ToDateTime(dr["SIP_EFF_DATE"]).ToString("dd/MM/yyyy"); 
                    objatt.boid = dr["BOID"].ToString();
                    objatt.Name = (dr["Name"].ToString());

                    objatt.Sip_amt = float.Parse(dr["SIP_AMT"].ToString());
                    objatt.Terms = dr["Terms"].ToString();

                    objatt.SIP_Reg_Date = string.IsNullOrEmpty(dr["SIP_Reg_Date"].ToString()) ? "" : Convert.ToDateTime(dr["SIP_Reg_Date"]).ToString("dd/MM/yyyy");
                    objatt.SIP_Last_Date = string.IsNullOrEmpty(dr["SIP_Last_Date"].ToString()) ? "" : Convert.ToDateTime(dr["SIP_Last_Date"]).ToString("dd/MM/yyyy");
                    objatt.SIP_Reg_No = dr["SIP_Reg_No"].ToString();
                    objatt.SIP_Interval = dr["SIP_Interval"].ToString();
                    lstSIPHolderTran.Add(objatt);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lstSIPHolderTran;
        }
    }
}
