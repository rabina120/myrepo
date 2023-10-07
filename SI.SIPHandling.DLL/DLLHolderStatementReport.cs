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
    public  class DLLHolderStatementReport
    {
        public List<ATTHolderStatement> GetHolderStatement(string scheme_code, string ccode, DateTime startdate, DateTime enddate, string boid, string l_company_id)
        {
            List<ATTHolderStatement> lstShareHolderTran = new List<ATTHolderStatement>();
            try
            {
                DataSet value = new DataSet();
                DataSet ds = new DataSet();
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@ccode", ccode);
                param[1] = new SqlParameter("@scheme_code", scheme_code);
                param[2] = new SqlParameter("@startDate", startdate);
                param[3] = new SqlParameter("@enddate", enddate);
                param[4] = new SqlParameter("@boid", boid);
                param[5] = new SqlParameter("@l_company_id", l_company_id);
                ds = DAO.gettable("dbo.GetHolderStatement", param);
                SqlParameter[] param1 = new SqlParameter[1];

                foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Double amt;
                        ATTHolderStatement objatt = new ATTHolderStatement();
                        //objatt.scheme_code = (dr["schema_code"].ToString());
                        //objatt.scheme_code = (dr["schema_code"].ToString());
                        objatt.SIP_Reg_No = (dr["SIP_Reg_No"].ToString());
                        objatt.Name = (dr["Name"].ToString());
                        objatt.BOID = (dr["BOIDNo"].ToString());
                        objatt.installmentDate = string.IsNullOrEmpty(dr["entry_dt"].ToString()) ? "" : Convert.ToDateTime(dr["entry_dt"]).ToString("yyyy-MM-dd");
                        //objatt.dueDate = string.IsNullOrEmpty(dr["SIP_Due_day"].ToString()) ? "" : dr["SIP_Due_day"].ToString();
                        objatt.appnav = (dr["current_Nav"].ToString());
                        objatt.unit = dr["APPLY_UNIT"].ToString();
                        objatt.trans_no = dr["collection_id"].ToString();
                        objatt.otherCharges = string.IsNullOrEmpty(dr["other_charges"].ToString()) ? "0" : dr["other_charges"].ToString();
                        objatt.sebon_fee = string.IsNullOrEmpty(dr["sebon_fee"].ToString()) ? "0" : dr["sebon_fee"].ToString();
                        if ((dr["dbcr"].ToString()) == "D")
                        {
                            amt = Math.Round(Double.Parse(dr["Amount"].ToString()), 4);
                            objatt.Amount_cr = amt.ToString();
                            objatt.Amount_dr = "-";
                            objatt.actionDate = string.IsNullOrEmpty(dr["entry_dt"].ToString()) ? "" : Convert.ToDateTime(dr["entry_dt"]).ToString("yyyy-MM-dd");

                            //param1[0] = new SqlParameter("@code", dr["P_PaymentCode"].ToString());
                            param1[0] = new SqlParameter("@code", dr["PaymentCode"].ToString());
                            value = DAO.gettable("dbo.GetPaymentTypeListByCode", param1); ;
                            foreach (DataRow va in value.Tables[0].Rows)
                            {
                                objatt.payment = va["PaymentMode"].ToString();
                            }

                        }
                        else
                        {
                            amt = Math.Round(Double.Parse(dr["Amount"].ToString()), 4);
                            objatt.Amount_dr = amt.ToString();
                            objatt.Amount_cr = "-";
                            objatt.actionDate = string.IsNullOrEmpty(dr["entry_dt"].ToString()) ? "" : Convert.ToDateTime(dr["entry_dt"]).ToString("yyyy-MM-dd");

                            // objatt.dp = (dr["dp_charge"]).ToString();
                            // objatt.unit = (dr["SIP_unit"].ToString());

                        }
                        lstShareHolderTran.Add(objatt);
                    }


            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lstShareHolderTran;
        }
    }
}
