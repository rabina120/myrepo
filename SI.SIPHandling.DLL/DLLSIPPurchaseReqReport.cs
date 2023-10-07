using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SI.Utility;
using System.Data;
using System.Data.SqlClient;
using SI.SIPHandling.ATT;

namespace SI.SIPHandling.DLL
{
    public class DLLSIPPurchaseReqReport
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

                ds = DAO.gettable("dbo.searchPurchaseByreqno", param);
                //if (FormType == "P")
                //{
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ATTUnitSIPRequest objatt = new ATTUnitSIPRequest();
                        
                        objatt.SIP_Unit =  float.Parse(dr["sip_unit"].ToString());
                        objatt.Current_NAV = dr["current_nav"].ToString();
                        objatt.DP_Charge = float.Parse(dr["dp_charge"].ToString());
                        objatt.SEBON_Fee = float.Parse(dr["SEBON_Fee"].ToString());
                        objatt.DP_Charge = float.Parse(dr["DP_Charge"].ToString());
                        objatt.Sip_amt = float.Parse(dr["SIP_Amount"].ToString());

                        objatt.REQUEST_NO = dr["REQUEST_NO"].ToString();
                        objatt.NAV_Date = string.IsNullOrEmpty(dr["NAV_Date"].ToString()) ? "" : Convert.ToDateTime(dr["NAV_Date"]).ToString("dd/MM/yyyy");

                        objatt.Action_Date = string.IsNullOrEmpty(dr["Action_Date"].ToString()) ? "" : Convert.ToDateTime(dr["Action_Date"]).ToString("dd/MM/yyyy");
                      
                        objatt.boid = dr["BOID"].ToString();
                        objatt.Name = (dr["FName"].ToString());
                        lstSIPHolders.Add(objatt);
                    }
               
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
                param[3] = new SqlParameter("@l_company_id",l_company_id);
                ds = DAO.gettable("dbo.searchPurchaseByBoid", param);
                
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ATTUnitSIPRequest objatt = new ATTUnitSIPRequest();
                        objatt.SIP_Unit = float.Parse(dr["sip_unit"].ToString());
                        objatt.Current_NAV = dr["current_nav"].ToString();
                        objatt.DP_Charge = float.Parse(dr["dp_charge"].ToString());
                        objatt.SEBON_Fee = float.Parse(dr["SEBON_Fee"].ToString());
                        objatt.DP_Charge = float.Parse(dr["DP_Charge"].ToString());
                        objatt.Sip_amt = float.Parse(dr["SIP_Amount"].ToString());

                        objatt.REQUEST_NO = dr["REQUEST_NO"].ToString();
                        objatt.NAV_Date = string.IsNullOrEmpty(dr["NAV_Date"].ToString()) ? "" : Convert.ToDateTime(dr["NAV_Date"]).ToString("dd/MM/yyyy");

                        objatt.Action_Date = string.IsNullOrEmpty(dr["Action_Date"].ToString()) ? "" : Convert.ToDateTime(dr["Action_Date"]).ToString("dd/MM/yyyy");

                        objatt.boid = dr["BOID"].ToString();
                        objatt.Name = (dr["FName"].ToString());
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
