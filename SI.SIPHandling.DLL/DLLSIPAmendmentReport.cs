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
    public class DLLSIPAmendmentReport
    {
        public List<ATTSIPAmendmentRegistDetials> searchbyreqno(string scheme_code, string ccode, string reqnofrom, string reqnoto, string l_company_id)
        {
            List<ATTSIPAmendmentRegistDetials> lstSIPHolders = new List<ATTSIPAmendmentRegistDetials>();
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

                ds = DAO.gettable("dbo.SearchSIPAmendmentByNo", param);
                //if (FormType == "P")
                //{
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ATTSIPAmendmentRegistDetials objatt = new ATTSIPAmendmentRegistDetials();
                    objatt.BOID = dr["BOID"].ToString();
                    objatt.Name = dr["Name"].ToString();

                    objatt.RegDate = string.IsNullOrEmpty(dr["SIP_Reg_Date"].ToString()) ? "" : Convert.ToDateTime(dr["SIP_Reg_Date"]).ToString("dd/MM/yyyy");
                    objatt.AModel = dr["Model_of_sip"].ToString();
                    objatt.RModel = dr["ModelH"].ToString();
                    //objatt.RPayment = 
                    objatt.AInterval = dr["SIP_Interval"].ToString();
                    objatt.RInterval = dr["IntervalH"].ToString();
                    objatt.AAmt = dr["SIP_Amt"].ToString();
                    objatt.RAmt = dr["AmountH"].ToString();
                    objatt.RContact = dr["contactH"].ToString();
                    objatt.AContact = dr["Contactno1"].ToString();
                    objatt.Regno = dr["SIP_Reg_No"].ToString();
                    objatt.EffectieDate = string.IsNullOrEmpty(dr["SIP_Eff_Date"].ToString()) ? "" : Convert.ToDateTime(dr["SIP_Eff_Date"]).ToString("dd/MM/yyyy");
                    objatt.ADueDate = string.IsNullOrEmpty(dr["SIP_Last_Date"].ToString()) ? "" : Convert.ToDateTime(dr["SIP_Last_Date"]).ToString("dd/MM/yyyy");
                    objatt.RDueDate = string.IsNullOrEmpty(dr["duedate"].ToString()) ? "" : Convert.ToDateTime(dr["duedate"]).ToString("dd/MM/yyyy"); 
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

        public List<ATTSIPAmendmentRegistDetials> searchbyboid(string scheme_code, string ccode, string Bo_Account_No, string l_company_id)
        {
            List<ATTSIPAmendmentRegistDetials> lstSIPHolderTran = new List<ATTSIPAmendmentRegistDetials>();
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@ccode", ccode);
                param[1] = new SqlParameter("@scheme_code", scheme_code);
                param[2] = new SqlParameter("@BOID", Bo_Account_No);
                param[3] = new SqlParameter("@l_company_id", l_company_id);
                ds = DAO.gettable("dbo.SearchSIPAmendmentByBOID", param);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ATTSIPAmendmentRegistDetials objatt = new ATTSIPAmendmentRegistDetials();

                    objatt.BOID = dr["BOID"].ToString();
                    objatt.Name = dr["Name"].ToString();

                    objatt.RegDate = string.IsNullOrEmpty(dr["SIP_Reg_Date"].ToString()) ? "" : Convert.ToDateTime(dr["SIP_Reg_Date"]).ToString("dd/MM/yyyy");
                    objatt.AModel = dr["Model_of_sip"].ToString();
                    objatt.RModel = dr["ModelH"].ToString();
                    //objatt.RPayment = 
                    objatt.AInterval = dr["SIP_Interval"].ToString();
                    objatt.RInterval = dr["IntervalH"].ToString();
                    objatt.AAmt = dr["SIP_Amt"].ToString();
                    objatt.RAmt = dr["AmountH"].ToString();
                    objatt.RContact = dr["contactH"].ToString();
                    objatt.AContact = dr["Contactno1"].ToString();
                    objatt.Regno = dr["SIP_Reg_No"].ToString();
                    objatt.EffectieDate = string.IsNullOrEmpty(dr["SIP_Eff_Date"].ToString()) ? "" : Convert.ToDateTime(dr["SIP_Eff_Date"]).ToString("dd/MM/yyyy"); 
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
