using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SI.Utility;
using SI.RequestHandling.DLL;
using SI.RequestHandling.ATT;
using System.Data;
using System.Data.SqlClient;
using SI.KYC.ATT;

namespace SI.RequestHandling.DLL
{
   public class DLLRequestHandlingReceipt
    {
       public List<ATTShareTransaction> GetPostedDataByBOID(string scheme_code, string ccode, string FormType, string Bo_Account_No)
       {
           List<ATTShareTransaction> lstShareHolderTran = new List<ATTShareTransaction>();
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] param = new SqlParameter[4];
               param[0] = new SqlParameter("@ccode", ccode);
               param[1] = new SqlParameter("@scheme_code", scheme_code);
               param[2] = new SqlParameter("@FormType", FormType);
               param[3] = new SqlParameter("@Bo_Account_No", Bo_Account_No);
               ds = DAO.gettable("dbo.GetPostedDataByBOID", param);
               if (FormType == "P")
               {
                   foreach (DataRow dr in ds.Tables[0].Rows)
                   {
                       ATTShareTransaction objatt = new ATTShareTransaction();
                       objatt.REQUEST_NO = int.Parse(dr["REQUEST_NO"].ToString());
                       objatt.Bo_Account_No = Int64.Parse(dr["boidno"].ToString());
                       objatt.nav_date = Convert.ToDateTime(dr["nav_date"]).ToString("dd/MM/yyyy");
                       objatt.APPLY_DT = Convert.ToDateTime(dr["APPLY_DT"]).ToString("dd/MM/yyyy");
                       objatt.APPLY_UNIT = float.Parse(dr["APPLY_UNIT"].ToString());
                       objatt.FName = (dr["FName"].ToString());
                       objatt.LName = (dr["LName"].ToString());
                       objatt.current_nav = float.Parse(dr["current_nav"].ToString());
                       objatt.AMOUNT = (dr["AMOUNT"].ToString());
                       // objatt.AMOUNT=String.Format("{0:00}",(dr["AMOUNT"]).ToString()));
                       objatt.Name = (dr["FName"].ToString());
                       objatt.other_charges = float.Parse(dr["other_charges"].ToString());
                       objatt.SEBON_Fee = float.Parse(dr["SEBON_Fee"].ToString());
                       objatt.charge_amount = float.Parse(dr["charge_amount"].ToString());
                       objatt.CashAmount = (dr["CashAmount"].ToString());
                       objatt.ChequeAmount = (dr["ChequeAmount"].ToString());
                       lstShareHolderTran.Add(objatt);
                   }


                   
               }
               else if (FormType == "R")
               {
                   foreach (DataRow dr in ds.Tables[0].Rows)
                   {
                       ATTShareTransaction objatt = new ATTShareTransaction();
                       objatt.REQUEST_NO = int.Parse(dr["REQUEST_NO"].ToString());
                       objatt.Bo_Account_No = Int64.Parse(dr["boidno"].ToString());
                       objatt.nav_date = Convert.ToDateTime(dr["nav_date"]).ToString("dd/MM/yyyy");
                       objatt.APPLY_DT = Convert.ToDateTime(dr["APPLY_DT"]).ToString("dd/MM/yyyy");
                       objatt.APPLY_UNIT = float.Parse(dr["APPLY_UNIT"].ToString());
                       objatt.FName = (dr["FName"].ToString());
                       objatt.LName = (dr["LName"].ToString());
                       objatt.current_nav = float.Parse(dr["current_nav"].ToString());
                       objatt.tot_redeem_amt_nav = float.Parse(dr["tot_redeem_amt_nav"].ToString());
                       objatt.tot_redeem_amount = float.Parse(dr["tot_redeem_amount"].ToString());
                       objatt.tot_exit_load = float.Parse(dr["tot_exit_load"].ToString());
                       objatt.capital_gain_tax = float.Parse(dr["capital_gain_tax"].ToString());
                       objatt.tot_capital_gain = float.Parse(dr["tot_capital_gain"].ToString());
                       objatt.gainloss_status = (dr["gainloss_status"].ToString());
                       objatt.Name = (dr["Name"].ToString());
                       lstShareHolderTran.Add(objatt);


                   }

               }

           }
           catch (Exception ex) {
               throw ex;
           }

           return lstShareHolderTran;
       }

       public List<ATTShareTransaction> GetPostedDataByReqNo(string scheme_code, string ccode, string FormType, string reqnofrom, string reqnoto)
       {
           List<ATTShareTransaction> lstShareHolderTran = new List<ATTShareTransaction>();
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] param = new SqlParameter[5];
               param[0] = new SqlParameter("@ccode", ccode);
               param[1] = new SqlParameter("@scheme_code", scheme_code);
               param[2] = new SqlParameter("@FormType", FormType);
               param[3] = new SqlParameter("@reqnofrom", reqnofrom);
               param[4] = new SqlParameter("@reqnoto", reqnoto);
               ds = DAO.gettable("dbo.GetPostedDataByReqNo", param);
               if (FormType == "P")
               {
                   foreach (DataRow dr in ds.Tables[0].Rows)
                   {
                       ATTShareTransaction objatt = new ATTShareTransaction();
                       objatt.REQUEST_NO = int.Parse(dr["REQUEST_NO"].ToString());
                       objatt.Bo_Account_No = Int64.Parse(dr["boidno"].ToString());
                       objatt.nav_date = Convert.ToDateTime(dr["nav_date"]).ToString("dd/MM/yyyy");
                       objatt.APPLY_DT = Convert.ToDateTime(dr["APPLY_DT"]).ToString("dd/MM/yyyy");
                       objatt.APPLY_UNIT = float.Parse(dr["APPLY_UNIT"].ToString());
                       objatt.FName = (dr["FName"].ToString());
                       objatt.LName = (dr["LName"].ToString());
                       objatt.current_nav = float.Parse(dr["current_nav"].ToString());
                       objatt.AMOUNT = (dr["AMOUNT"].ToString());
                      // objatt.AMOUNT=String.Format("{0:00}",(dr["AMOUNT"]).ToString()));
                       objatt.Name = (dr["Name"].ToString());
                       objatt.other_charges = float.Parse(dr["other_charges"].ToString());
                       objatt.SEBON_Fee = float.Parse(dr["SEBON_Fee"].ToString());
                       objatt.charge_amount = float.Parse(dr["charge_amount"].ToString());
                       objatt.CashAmount = (dr["CashAmount"].ToString());
                       objatt.ChequeAmount = (dr["ChequeAmount"].ToString());
                       lstShareHolderTran.Add(objatt);

                   }

               }
               else if (FormType == "R")
               {
                   foreach (DataRow dr in ds.Tables[0].Rows)
                   {
                       ATTShareTransaction objatt = new ATTShareTransaction();
                       objatt.REQUEST_NO = int.Parse(dr["REQUEST_NO"].ToString());
                       objatt.Bo_Account_No = Int64.Parse(dr["boidno"].ToString());
                       objatt.nav_date = Convert.ToDateTime(dr["nav_date"]).ToString("dd/MM/yyyy");
                       objatt.APPLY_DT = Convert.ToDateTime(dr["APPLY_DT"]).ToString("dd/MM/yyyy");
                       objatt.APPLY_UNIT = float.Parse(dr["APPLY_UNIT"].ToString());
                       objatt.FName = (dr["FName"].ToString());
                       objatt.LName = (dr["LName"].ToString());
                       objatt.current_nav = float.Parse(dr["current_nav"].ToString());
                       objatt.tot_redeem_amt_nav = float.Parse(dr["tot_redeem_amt_nav"].ToString());
                       objatt.tot_redeem_amount = float.Parse(dr["tot_redeem_amount"].ToString());
                       objatt.tot_exit_load = float.Parse(dr["tot_exit_load"].ToString());
                       objatt.capital_gain_tax = float.Parse(dr["capital_gain_tax"].ToString());
                       objatt.tot_capital_gain = float.Parse(dr["tot_capital_gain"].ToString());
                       objatt.gainloss_status = (dr["gainloss_status"].ToString());
                       objatt.Name = (dr["Name"].ToString());
                       lstShareHolderTran.Add(objatt);


                   }

               }

           }
           catch (Exception ex)
           {
               throw ex;
           }

           return lstShareHolderTran;
       }
       public List<ATTShareTransaction> GetStatusByBoid(string scheme_code, string ccode, string FormType,string Type, string ShHolderNo)
       {
           List<ATTShareTransaction> lstShareHolderTran = new List<ATTShareTransaction>();
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] param = new SqlParameter[5];
               param[0] = new SqlParameter("@ccode", ccode);
               param[1] = new SqlParameter("@scheme_code", scheme_code);
               param[2] = new SqlParameter("@FormType", FormType);
               param[3] = new SqlParameter("@ShHolderNo", ShHolderNo);
               param[4] = new SqlParameter("@Type",Type);
               ds = DAO.gettable("dbo.GetStatusByBoid", param);
               if (FormType == "P" && Type == "Re")
               {
                   foreach (DataRow dr in ds.Tables[0].Rows)
                   {
                       ATTShareTransaction objatt = new ATTShareTransaction();
                      // objatt.Bo_Account_No = Int64.Parse(dr["boidno"].ToString());
                       objatt.APPLY_DT = Convert.ToDateTime(dr["APPLY_DT"]).ToString("yyyy/MM/dd");
                       objatt.APPLY_UNIT = float.Parse(dr["APPLY_UNIT"].ToString());
                       objatt.refund_amount = float.Parse(dr["refund_amount"].ToString());
                       var settlement = (dr["is_settlement"].ToString());
                       var status = (dr["settlement_app_status"].ToString());
                       if (settlement == "Y" && status == "POSTED")
                       {
                           objatt.is_settlement = "Settled";
                       }
                       else
                       {
                           objatt.is_settlement = "Not Settled";
                       }
                       
                      
                      // objatt.Unit_settlement = 
                       lstShareHolderTran.Add(objatt);

                   }

                   

               }
               else if (FormType == "R" && Type == "Re")
               {
                   foreach (DataRow dr in ds.Tables[0].Rows)
                   {
                       ATTShareTransaction objatt = new ATTShareTransaction();
                       objatt.APPLY_DT = Convert.ToDateTime(dr["APPLY_DT"]).ToString("yyyy/MM/dd");
                       objatt.APPLY_UNIT = float.Parse(dr["APPLY_UNIT"].ToString());
                       objatt.refund_amount = float.Parse(dr["refund_amount"].ToString());
                       var settlement = (dr["is_settlement"].ToString());
                       var status = (dr["settlement_app_status"].ToString());
                       if (settlement == "Y" && status == "POSTED" )
                       {
                           objatt.is_settlement = "Settled";
                       }
                       else
                       {
                           objatt.is_settlement = "Not Settled";
                       }
                       lstShareHolderTran.Add(objatt);


                   }

               }

               else if (FormType == "P" && Type == "U")
               {
                   foreach (DataRow dr in ds.Tables[0].Rows)
                   {
                       ATTShareTransaction objatt = new ATTShareTransaction();
                       objatt.APPLY_DT = Convert.ToDateTime(dr["APPLY_DT"]).ToString("yyyy/MM/dd");
                       objatt.APPLY_UNIT = float.Parse(dr["APPLY_UNIT"].ToString());
                       var settlement = (dr["is_cds_settlement"].ToString());
                       var status = (dr["cds_settlement_app_status"].ToString());
                       if (settlement == "Y" && status == "POSTED")
                       {
                           objatt.is_settlement = "Settled";
                       }
                       else
                       {
                           objatt.is_settlement = "Not Settled";
                       }
                       lstShareHolderTran.Add(objatt);


                   }

               }

               else if (FormType == "R" && Type == "U")
               {
                   foreach (DataRow dr in ds.Tables[0].Rows)
                   {
                       ATTShareTransaction objatt = new ATTShareTransaction();
                       objatt.APPLY_DT = Convert.ToDateTime(dr["APPLY_DT"]).ToString("yyyy/MM/dd");
                       objatt.APPLY_UNIT = float.Parse(dr["APPLY_UNIT"].ToString());
                       var settlement = (dr["is_cds_settlement"].ToString());
                       var status = (dr["cds_settlement_app_status"].ToString());
                       if (settlement == "Y" && status == "POSTED")
                       {
                           objatt.is_settlement = "Settled";
                       }
                       else
                       {
                           objatt.is_settlement = "Not Settled";
                       }
                       lstShareHolderTran.Add(objatt);


                   }

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
