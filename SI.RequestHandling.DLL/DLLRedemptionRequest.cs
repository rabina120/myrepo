using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SI.Utility;
using SI.RequestHandling.ATT;
using System.Data;
using System.Data.SqlClient;
using SI.KYC.ATT;
using SI.Security.ATT;
using System.Web.Script.Serialization;

namespace SI.RequestHandling.DLL
{
    public class DLLRedemptionRequest
    {

        public string GetSIPDate(int SHHOLDERNO, string scheme_code)
        {
            string SIP_Reg_Date = string.Empty;
            SqlConnection conn = DAO.getConnection();
            SqlParameter[] param = new SqlParameter[5];
            try
            {
                using (conn)
                {

                    SqlCommand cmdd = new SqlCommand();
                    cmdd.Connection = conn;
                    cmdd.CommandText = "GetSIPDate";
                    cmdd.CommandType = CommandType.StoredProcedure;

                    SqlParameter para1 = new SqlParameter();
                    para1.ParameterName = "@SIP_Reg_Date";
                    para1.Value = SIP_Reg_Date;
                    para1.SqlDbType = SqlDbType.NVarChar;
                    para1.Size = 100;
                    para1.Direction = ParameterDirection.InputOutput;
                    cmdd.Parameters.Add(para1);
                    cmdd.Parameters.AddWithValue("@SHHOLDERNO", SHHOLDERNO);
                    cmdd.Parameters.AddWithValue("@scheme_code", scheme_code);
                    cmdd.ExecuteNonQuery();

                    if (cmdd.Parameters["@SIP_Reg_Date"].Value.ToString() == "") { cmdd.Parameters["@SIP_Reg_Date"].Value = 0; }
                    SIP_Reg_Date = Convert.ToDateTime(cmdd.Parameters["@SIP_Reg_Date"].Value).ToString("yyyy-MM-dd");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return SIP_Reg_Date;
        }
        public List<ATTTransactionDetail> GetAllocatedData(int SHHOLDERNO, string scheme_code, string Action, string ccode, int? REQUEST_NO, string Flag)
        {
            List<ATTTransactionDetail> lstsholder = new List<ATTTransactionDetail>();
            string spName = "";
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[5];
            try
            {
                param[0] = new SqlParameter("@SHHOLDERNO", SHHOLDERNO);
                param[1] = new SqlParameter("@scheme_code", scheme_code);
                param[2] = new SqlParameter("@ccode", ccode);
                param[3] = new SqlParameter("@REQUEST_NO", REQUEST_NO);
                param[4] = new SqlParameter("@Action", Action);
                spName = "GetAllocatedData";
                ds = DAO.gettable(spName, param);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ATTTransactionDetail objATT = new ATTTransactionDetail();
                        objATT.SHHOLDERNO = int.Parse((SHHOLDERNO).ToString());
                        objATT.scheme_code = dr["scheme_code"].ToString();
                        objATT.Allocation_no = Int32.Parse(dr["Lot_no"].ToString());
                        objATT.value_dt = Convert.ToDateTime(dr["P_dt"]).ToString("yyyy-MM-dd");
                        objATT.seqno = Int32.Parse(dr["Lot_seqno"].ToString());
                        objATT.Unposted_Unit = (float.Parse(dr["Unit"].ToString()));
                        objATT.inv_amt = (float.Parse(dr["inv_amt"].ToString()));
                        objATT.status = dr["status"].ToString();
                        objATT.tran_type = dr["tran_type"].ToString();
                        var todays_date = DateTime.Now.ToString("yyyy-MM-dd");
                        objATT.value_dt = Convert.ToDateTime(dr["P_dt"]).ToString("yyyy-MM-dd");
                        if (objATT.tran_type == "02")
                        {
                            string SIP_Reg_Date = GetSIPDate(SHHOLDERNO, scheme_code);
                            objATT.SIP_Reg_Date = Convert.ToDateTime(SIP_Reg_Date).ToString("yyyy-MM-dd");
                            TimeSpan ts = DateTime.Parse(todays_date) - DateTime.Parse(SIP_Reg_Date);
                            int day = ts.Days;
                            //objATT.Holding_Days = day;
                            //objATT.value_dt = objATT.SIP_Reg_Date;
                            objATT.Sip_Holding_Days = day;
                            objATT.Sip_value_dt = objATT.SIP_Reg_Date;
                        }
                        //else
                        //{
                        //    objATT.value_dt = Convert.ToDateTime(dr["P_dt"]).ToString("yyyy-MM-dd");
                        //    TimeSpan ts = DateTime.Parse(todays_date) - DateTime.Parse(Convert.ToDateTime(dr["P_dt"]).ToString("yyyy-MM-dd"));
                        //    int day = ts.Days;
                        //    objATT.Holding_Days = day;
                        //}
                        //var todays_date = DateTime.Now.ToString("yyyy-MM-dd");
                        TimeSpan ts1 = DateTime.Parse(todays_date) - DateTime.Parse(objATT.value_dt);
                        int day1 = ts1.Days;
                        objATT.Holding_Days = day1;
                        float locked_unit = GetLocked_Unit(SHHOLDERNO, scheme_code, objATT.Allocation_no, objATT.seqno, objATT.status);
                        var Balance_unit = (float.Parse(dr["Balance_unit"].ToString())) - locked_unit - objATT.Unposted_Unit;
                        objATT.Can_be_sell = float.Parse(String.Format("{0:0.##}", Balance_unit));
                        objATT.balance_unit = (float.Parse(dr["Balance_unit"].ToString()));
                        if (Flag != "A")
                        {
                            //if (Balance_unit == 0)
                            //{
                            //    continue;
                            //}
                            if (objATT.Can_be_sell == 0)
                            {
                                continue;
                            }
                            else { }
                        }
                        objATT.locked_unit = locked_unit;
                        objATT.To_be_Sell = (objATT.balance_unit - objATT.Unposted_Unit - objATT.locked_unit);
                        lstsholder.Add(objATT);

                    }
                }

                return lstsholder;
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }



        public List<ATTTransactionDetail> GetClientDetial(string BOID, string scheme_code, string l_company_id)
        {
            List<ATTTransactionDetail> lstsholder = new List<ATTTransactionDetail>();
            string spName = "";
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[5];
            try
            {
                param[0] = new SqlParameter("@SHHOLDERNO", BOID);
                param[1] = new SqlParameter("@scheme_code", scheme_code);
                param[2] = new SqlParameter("@l_company_id", l_company_id);
                //param[3] = new SqlParameter("@REQUEST_NO", REQUEST_NO);
                //param[4] = new SqlParameter("@Action", Action);
                spName = "GetAllocatedData";
                ds = DAO.gettable(spName, param);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ATTTransactionDetail objATT = new ATTTransactionDetail();
                     

                    }
                }

                return lstsholder;
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

        public float GetUnPosted_Unit(int? SHHOLDERNO, string scheme_code, int Allocation_no, int seqno, int? REQUEST_NO)
        {
            string spName = "";
            float UnPosted_Unit = 0;
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[5];
            try
            {
                param[0] = new SqlParameter("@SHHOLDERNO", SHHOLDERNO);
                param[1] = new SqlParameter("@scheme_code", scheme_code);
                param[2] = new SqlParameter("@Allocation_no", Allocation_no);
                param[3] = new SqlParameter("@seqno", seqno);
                param[4] = new SqlParameter("@REQUEST_NO", REQUEST_NO);
                spName = "GetUnPosted_Unit";
                ds = DAO.gettable(spName, param);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ATTTransactionDetail objATT = new ATTTransactionDetail();
                        objATT.Unposted_Unit = (float.Parse(dr["UnPosted_Unit"].ToString()));
                        UnPosted_Unit = objATT.Unposted_Unit;


                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return UnPosted_Unit;
        }

        public float GetLocked_Unit(int? SHHOLDERNO, string scheme_code, int Allocation_no, int seqno, string status)
        {
            string spName = "";
            float Locked_Unit = 0;
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[5];
            try
            {
                param[0] = new SqlParameter("@SHHOLDERNO", SHHOLDERNO);
                param[1] = new SqlParameter("@scheme_code", scheme_code);
                param[2] = new SqlParameter("@Allocation_no", Allocation_no);
                param[3] = new SqlParameter("@seqno", seqno);
                param[4] = new SqlParameter("@status", status);
                spName = "GetLocked_Unit";
                ds = DAO.gettable(spName, param);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ATTTransactionDetail objATT = new ATTTransactionDetail();
                        objATT.locked_unit = (float.Parse(dr["locked_unit"].ToString()));
                        Locked_Unit = objATT.locked_unit;


                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Locked_Unit;
        }
        public int? SaveRedemptionEntry(ATTShareTransaction objATT, string type)
        {

            string spName1 = "";
            string spName2 = "";
            int? REQUEST_NO = 0;
            int? DREQUEST_NO = 0;

            int[] DREQUEST_NO_array;

            string msg = "No Data To Save !!!";
            SqlTransaction transaction;
            SqlConnection conn = DAO.getConnection();

            msg = "";


            using (conn)
            {
                transaction = conn.BeginTransaction();
                spName1 = "InsertDetailTransactionDirty";
                spName2 = "InsertRedemptionEntryDirty";

                try
                {
                    if (objATT.Transaction.Count > 0)
                    {
                        foreach (ATTTransactionDetail obj in objATT.Transaction)
                        {
                            SqlCommand cmd = new SqlCommand(spName1, conn, transaction);
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@scheme_code", SqlDbType.VarChar, 03).Value = objATT.Scheme_code;
                            cmd.Parameters.Add("@ccode", SqlDbType.VarChar, 04).Value = objATT.ccode;
                            cmd.Parameters.Add("@DREQUEST_NO", SqlDbType.Int).Direction = ParameterDirection.Output;
                            cmd.Parameters.Add("@SHHOLDERNO", SqlDbType.Int).Value = objATT.ShHolderNo;
                            cmd.Parameters.Add("@lotno", SqlDbType.Int).Value = obj.Allocation_no;
                            cmd.Parameters.Add("@seqno", SqlDbType.Int).Value = obj.seqno;
                            cmd.Parameters.Add("@lot_unit", SqlDbType.Decimal).Value = obj.balance_unit;
                            cmd.Parameters.Add("@p_dt", SqlDbType.NVarChar, 50).Value = obj.p_dt;
                            cmd.Parameters.Add("@sell_unit", SqlDbType.Decimal).Value = obj.redem_unit;
                            cmd.Parameters.Add("@charge_amt", SqlDbType.Decimal).Value = obj.exe_load;
                            cmd.Parameters.Add("@inv_amt", SqlDbType.Decimal).Value = obj.inv_amt_redem_unit;
                            cmd.Parameters.Add("@Holding_Days", SqlDbType.Int).Value = obj.Holding_Days;

                            cmd.ExecuteNonQuery();
                            DREQUEST_NO = Convert.ToInt32(cmd.Parameters["@DREQUEST_NO"].Value);

                         
                            msg += " " + DREQUEST_NO;
                        }


                        if (type == "SHolder")
                        {


                            SqlParameter[] param = new SqlParameter[36];
                            param[0] = new SqlParameter("@scheme_code", objATT.Scheme_code);
                            param[1] = new SqlParameter("@ccode", objATT.ccode);
                            param[2] = new SqlParameter("@DREQUEST_NO", DREQUEST_NO);
                            param[3] = new SqlParameter("@SHHOLDERNO", objATT.ShHolderNo);
                            param[4] = new SqlParameter("@FNAME", objATT.FName);
                            param[5] = new SqlParameter("@LNAME", objATT.LName);
                            param[6] = new SqlParameter("@FANAME", objATT.FaName);
                            param[7] = new SqlParameter("@GRFANAME", objATT.GFName);
                            param[8] = new SqlParameter("@address", objATT.address);
                            param[9] = new SqlParameter("@TELNO", objATT.P_Tel_No);
                            param[10] = new SqlParameter("@PANNO", objATT.PAN_No);
                            param[11] = new SqlParameter("@APPLY_UNIT", objATT.APPLY_UNIT);
                            param[12] = new SqlParameter("@APPLY_DT", objATT.APPLY_DT);
                            param[13] = new SqlParameter("@bankcode", objATT.BankCode);
                            param[14] = new SqlParameter("@ACCOUNTNO", objATT.Bank_Account_No);
                            param[15] = new SqlParameter("@ENTRY_BY", objATT.ENTRY_BY);
                            param[16] = new SqlParameter("@ENTRY_DT", objATT.ENTRY_DT);
                            param[17] = new SqlParameter("@APPROVED", objATT.APPROVED);
                            param[18] = new SqlParameter("@APPSTATUS", objATT.APPSTATUS);
                            param[19] = new SqlParameter("@appno", objATT.appno);
                            param[20] = new SqlParameter("@remarks", objATT.remarks);
                            param[21] = new SqlParameter("@boidno", objATT.Bo_Account_No);
                            param[22] = new SqlParameter("@nav_date", objATT.nav_date);
                            param[23] = new SqlParameter("@current_nav", objATT.current_nav);
                            param[24] = new SqlParameter("@SCharge_Code", objATT.SCharge_Code);
                            param[25] = new SqlParameter("@capital_gain_tax", objATT.capital_gain_tax);
                            param[26] = new SqlParameter("@tot_redeem_amt_nav", objATT.tot_redeem_amt_nav);
                            param[27] = new SqlParameter("@tot_redeem_amount", objATT.tot_redeem_amount);
                            param[28] = new SqlParameter("@tot_exit_load", objATT.tot_exit_load);
                            param[29] = new SqlParameter("@tot_capital_gain", objATT.tot_capital_gain);
                            param[30] = new SqlParameter("@capital_gain_tax_amt", objATT.capital_gain_tax_amt);
                            param[31] = new SqlParameter("@other_charges", objATT.other_charges);
                            param[32] = new SqlParameter("@gainloss_status", objATT.gainloss_status);
                            param[33] = new SqlParameter("@branch_code", objATT.Branch_code);
                            param[34] = new SqlParameter("@SEBON_Fee", objATT.SEBON_Fee);
                            param[35] = new SqlParameter("@l_company_id", objATT.l_company_id);
                            DAO.executeTranProcedure(spName2, param, transaction, conn);
                        }
                    }
                    transaction.Commit();


                }

                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Error" + ex.Message);
                }
            }
            return DREQUEST_NO;
        }



        public int? GetRedemRequestNo(string scheme_code, string ccode)
        {

            string msg = "";
            string spName = "";
            DataSet ds = new DataSet();
            int? REQUEST_NO = 0;
            SqlTransaction transaction;
            msg = "Successfully Saved !!!";
            SqlConnection conn = DAO.getConnection();

            using (conn)
            {
                transaction = conn.BeginTransaction();
                SqlCommand cmdd = new SqlCommand();
                cmdd.Connection = conn;
                cmdd.Transaction = transaction;
                cmdd.CommandText = "GetRedemRequestNo";
                cmdd.CommandType = CommandType.StoredProcedure;

                SqlParameter para1 = new SqlParameter();
                para1.ParameterName = "@REQUEST_NO";
                para1.Value = REQUEST_NO;
                para1.SqlDbType = SqlDbType.Int;
                para1.Size = 100;
                para1.Direction = ParameterDirection.InputOutput;
                cmdd.Parameters.Add(para1);
                cmdd.Parameters.AddWithValue("@scheme_code", scheme_code);
                cmdd.Parameters.AddWithValue("@ccode", ccode);



                cmdd.ExecuteNonQuery();

                if (cmdd.Parameters["@REQUEST_NO"].Value.ToString() == "") { cmdd.Parameters["@REQUEST_NO"].Value = 0; }
                REQUEST_NO = int.Parse(cmdd.Parameters["@REQUEST_NO"].Value.ToString()) + 1;
            }
            return REQUEST_NO;

        }
        public List<ATTShareTransaction> GetRedemData(string scheme_code, string ccode, int? REQUEST_NO, string Action, string l_company_id)
        {
            List<ATTTransactionDetail> lstTran = new List<ATTTransactionDetail>();
            List<ATTShareTransaction> lstShareholder = new List<ATTShareTransaction>();
            List<ATTSign> lstsigns = new List<ATTSign>();
            List<ATTShHolder> lstSHolders = new List<ATTShHolder>();
            string spName = "";
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[5];
            try
            {
                //  if (APPSTATUS == "UNPOSTED")
                //  {
                param[0] = new SqlParameter("@scheme_code", scheme_code != null ? scheme_code : null);
                param[1] = new SqlParameter("@ccode", ccode != null ? ccode : null);
                param[2] = new SqlParameter("@REQUEST_NO", REQUEST_NO);
                param[3] = new SqlParameter("@Action", Action);
                param[4] = new SqlParameter("@l_company_id", l_company_id);
                spName = "GetRedemData";
                ds = DAO.gettable(spName, param);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    ATTShareTransaction objATT = new ATTShareTransaction();
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DLLSHolder objdll = new DLLSHolder();
                        objATT.ShHolderNo = int.Parse(dr["SHHOLDERNO"].ToString());
                        objATT.Bo_Account_No = Int64.Parse(dr["Bo_Account_No"].ToString());
                        objATT.REQUEST_NO = int.Parse(dr["REQUEST_NO"].ToString());
                        //lstSHolders = objdll.GetSHolders(scheme_code, objATT.Bo_Account_No, ccode);
                        objATT.Bank_Account_No = dr["boidno"].ToString();
                        objATT.FName = dr["FNAME"].ToString();
                        objATT.LName = dr["LNAME"].ToString();
                        objATT.FaName = dr["FANAME"].ToString();
                        objATT.GFName = dr["GRFANAME"].ToString();
                        objATT.address = dr["address"].ToString();
                        objATT.P_Tel_No = dr["TELNO"].ToString();
                        objATT.Citizenship_No = dr["Citizenship_No"].ToString();
                        objATT.Reg_No = dr["Reg_No"].ToString();
                        objATT.BankCode = dr["BCODE"].ToString();
                        objATT.Branch_code = dr["branch_code"].ToString();
                        objATT.Bank_Account_No = dr["ACCOUNTNO"].ToString();
                        objATT.PAN_No = dr["PANNO"].ToString();
                        objATT.appno = dr["appno"].ToString();
                        objATT.remarks = dr["remarks"].ToString();
                        objATT.APPLY_DT = Convert.ToDateTime(dr["APPLY_DT"]).ToString("yyyy-MM-dd");
                        objATT.APPLY_UNIT = float.Parse(dr["APPLY_UNIT"].ToString());
                        objATT.appno = dr["appno"].ToString();

                        objATT.nav_date = Convert.ToDateTime(dr["nav_date"]).ToString("yyyy-MM-dd");
                        objATT.current_nav = float.Parse(dr["current_nav"].ToString());
                        objATT.SCharge_Code = dr["SCharge_Code"].ToString();
                        objATT.capital_gain_tax = float.Parse(dr["capital_gain_tax"].ToString());

                        objATT.tot_redeem_amount = float.Parse(dr["tot_redeem_amount"].ToString());
                        objATT.tot_redeem_amt_nav = float.Parse(dr["tot_redeem_amt_nav"].ToString());
                        objATT.tot_exit_load = float.Parse(dr["tot_exit_load"].ToString());
                        objATT.tot_capital_gain = float.Parse(dr["tot_capital_gain"].ToString());
                        objATT.capital_gain_tax_amt = float.Parse(dr["capital_gain_tax_amt"].ToString());
                        objATT.other_charges = float.Parse(dr["other_charges"].ToString());
                        objATT.gainloss_status = dr["gainloss_status"].ToString();
                        objATT.SEBON_Fee = float.Parse(dr["SEBON_Fee"].ToString());
                        objATT.BalUnit = (float.Parse(dr["DBBalUnit"].ToString())) - (float.Parse(dr["CRBalUnit"].ToString()));
                        objATT.Inv_Amt = (float.Parse(dr["DBInv_Amt"].ToString())) - (float.Parse(dr["CRInv_Amt"].ToString()));

                        ATTTransactionDetail objtran = new ATTTransactionDetail();
                        objtran.seqno = int.Parse(dr["seqno"].ToString());
                        objtran.Allocation_no = int.Parse(dr["lotno"].ToString());
                        objtran.redem_unit = float.Parse(dr["sell_unit"].ToString());
                        objtran.exe_load = float.Parse(dr["charge_amt"].ToString());
                        objtran.balance_unit = float.Parse(dr["lot_unit"].ToString());
                        objtran.inv_amt_redem_unit = float.Parse(dr["inv_amt"].ToString());
                        objtran.status = dr["status"].ToString();
                        objtran.p_dt = Convert.ToDateTime(dr["p_dt"]).ToString("yyyy-MM-dd");
                        objtran.locked_unit = GetLocked_Unit(objATT.ShHolderNo, scheme_code, objtran.Allocation_no, objtran.seqno, objtran.status);
                        objtran.Unposted_Unit = GetUnPosted_Unit(objATT.ShHolderNo, scheme_code, objtran.Allocation_no, objtran.seqno, objATT.REQUEST_NO);
                        objtran.Holding_Days = int.Parse(dr["Holding_Days"].ToString());
                        lstsigns = GetSign(scheme_code, objATT.ShHolderNo);
                        objATT.Sign = lstsigns;
                        lstTran.Add(objtran);

                    }
                    objATT.Transaction = lstTran;
                    lstShareholder.Add(objATT);
                }


                //   }
                return lstShareholder;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<ATTSign> GetSign(string scheme_code, int? ShHolderNo)
        {
            //List<ATTShHolder> lstSign = new List<ATTShHolder>();
            List<ATTSign> lstsigns = new List<ATTSign>();
            string spName = "";
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[2];
            try
            {
                param[0] = new SqlParameter("@scheme_code", scheme_code != null ? scheme_code : null);
                param[1] = new SqlParameter("@ShHolderNo", ShHolderNo);


                spName = "GetSign";
                ds = DAO.gettable(spName, param);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ATTSign objsign = new ATTSign();
                        string DocSignFile;
                        byte[] SymbolSignByte = dr["Signature"] == DBNull.Value ? null : (byte[])dr["Signature"];
                        if (SymbolSignByte == null)
                        {
                            DocSignFile = null;
                        }
                        else
                        {
                            DocSignFile = image2byteConverter.byte2dataURL(SymbolSignByte);
                        }
                        objsign.signature = DocSignFile;
                        lstsigns.Add(objsign);
                        objsign.seqno = string.IsNullOrEmpty(dr["seqno"].ToString()) ? (int?)null : int.Parse(dr["seqno"].ToString());
                    }
                }
                return lstsigns;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public string DeleteRedemeEntry(string shholderno, string scheme_code, string ccode, int REQUEST_NO, string Action, string UserName)
        {

            string spName1 = "";
            string msg = "No Data To Delete !!!";
            SqlTransaction transaction;
            SqlConnection conn = DAO.getConnection();

            using (conn)
            {
                transaction = conn.BeginTransaction();

                try
                {
                    SqlParameter[] param = new SqlParameter[6];
                    spName1 = "DeleteRedemeEntry";
                    param[0] = new SqlParameter("@SHHOLDERNO", shholderno);
                    param[1] = new SqlParameter("@scheme_code", scheme_code);
                    param[2] = new SqlParameter("@ccode", ccode);
                    param[3] = new SqlParameter("@REQUEST_NO", REQUEST_NO);
                    param[4] = new SqlParameter("@Action", Action);
                    param[5] = new SqlParameter("@UserName", UserName);
                    DAO.executeTranProcedure(spName1, param, transaction, conn);
                    transaction.Commit();
                    msg = "Successfully Deleted !!!";
                }


                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Error" + ex.Message);
                }
            }
            return msg;
        }

        public JsonResponse CHECKUNITTOBEREDEM(string scheme_code, float APPLIED_UNIT, string BOID, string L_COMPANY_ID, int SHHOLDERNO, string APPLY_DT)
        {
            JsonResponse jsonresponse = new JsonResponse();

            List<ATTShHolder> lstSHolders = new List<ATTShHolder>();
            List<ATTSign> lstsigns = new List<ATTSign>();

            string spName = "";
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[6];
            try
            {
                param[0] = new SqlParameter("@BOID", BOID);
                param[1] = new SqlParameter("@scheme_code", scheme_code);
                param[2] = new SqlParameter("@L_COMPANY_ID", L_COMPANY_ID);
                param[3] = new SqlParameter("@APPLIED_UNIT", APPLIED_UNIT);
                param[4] = new SqlParameter("@SHHOLDERNO", SHHOLDERNO);
                param[5] = new SqlParameter("@APPLY_DT", APPLY_DT);

                spName = "CHECKUNITTOBEREDEM";
                ds = DAO.gettable(spName, param);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        jsonresponse.IsSucess = Convert.ToBoolean(dr["IsSucess"].ToString());
                        jsonresponse.Message = dr["Message"].ToString();
                        if (Convert.ToBoolean(dr["IsSucess"].ToString()) == false) throw new Exception(jsonresponse.Message);

                    }
                }

            }

            catch (Exception ex)
            {

                throw ex;
            }
            return jsonresponse;
        }
        public static double Floor(double d, int decimals)
        {
            return Math.Floor(d * Math.Pow(10, decimals)) / Math.Pow(10, decimals);
        }
        public string CheckRedemptionDetail(ATTShareTransaction objATT, string type)
        {
            string msg = string.Empty;
            JsonResponse response = new JsonResponse();
            DLLPurchaseRequest objDll = new DLLPurchaseRequest();
            DLLSHolder dllsholder = new DLLSHolder();
            float nav_value = 0 ;
            float Inv_Amt = 0;
            float BalUnit = 0;
            List<ATTNAV> obj  = objDll.GetNAV(objATT.Scheme_code, objATT.APPLY_DT);
            foreach (var item in obj)
            {
                 nav_value = item.nav_value;
            }
            List<ATTTransactionDetail> lstobj = new List<ATTTransactionDetail>();
            List<ATTShHolder> objsholder = dllsholder.GetSHolders(objATT.Scheme_code.ToString(), Int64.Parse(objATT.Bo_Account_No.ToString()), objATT.ccode.ToString(), objATT.l_company_id, objATT.ShHolderNo.ToString());
           // BalUnit = objsholder.Sum(x =>Convert.ToInt32(x.BalUnit));
            BalUnit = objsholder.Sum(x => (float)Convert.ToDouble(x.BalUnit));
           // Inv_Amt = objsholder.Sum(x => Convert.ToInt32(x.Inv_Amt));
            Inv_Amt = objsholder.Sum(x => (float)Convert.ToDouble(x.Inv_Amt));
            //float Average_Price = Inv_Amt / BalUnit;
            double Average_Price = Inv_Amt / BalUnit;
            List<ATTTransactionDetail> OBJTRANDT = GetAllocatedData(int.Parse(objATT.ShHolderNo.ToString()), objATT.Scheme_code.ToString(), "A", objATT.ccode, 0, "");
            //float total = OBJTRANDT.Sum(x => Convert.ToInt32(x.To_be_Sell));
            float total = OBJTRANDT.Sum(x => (float)Convert.ToDouble(x.To_be_Sell));
            float totalunit = 0;
            int SNO = 1;
            totalunit = objATT.APPLY_UNIT;
            if (objATT.APPLY_UNIT <= total)
            {
                foreach (var TD in OBJTRANDT)
                {
                    var Allocation_no = 0;
                    int seqno = 0;
                    float balance_unit = 0;
                    //float cur_val = 0;
                    double cur_val = 0;
                    string p_dt = "";
                    string Act_p_dt = "";
                    double Act_data2 = 0;
                    double data2 = 0;
                    float redem_unit = 0;
                   
                    //float inv_amt_redem_unit = 0;
                    double Act_inv_amt_redem_unit = 0;
                    double inv_amt_redem_unit = 0;
                    //float exe_load = 0;
                    double exe_load = 0;
                    int Holding_Days = 0;
                    //float capital_gain_amount = 0;
                    //float capital_gain_tax_amount = 0;
                    double capital_gain_amount = 0;
                    double capital_gain_tax_amount = 0;
                    float CGT = 0;
                   
                    float rate = 0;
                    float Can_be_Sell = 0;
                    string tran_type;
                    int Sip_Holding_Days = 0;
                    string Sip_Reg_Date = "";
                    Can_be_Sell = TD.To_be_Sell;
                    if (totalunit > 0)
                    {
                        if (totalunit >= Can_be_Sell)
                        {
                            redem_unit = Can_be_Sell;
                        }
                        else
                        {
                            redem_unit = totalunit;
                        }
                        Allocation_no = TD.Allocation_no;
                        Act_p_dt = TD.value_dt;
                        Act_inv_amt_redem_unit = redem_unit * Average_Price;
                        inv_amt_redem_unit = Math.Round(Act_inv_amt_redem_unit, 2);
                        Holding_Days = TD.Holding_Days;
                        Act_data2 = (nav_value * redem_unit);
                        data2 = Math.Round(Act_data2, 2);
                        tran_type = TD.tran_type;
                        if (tran_type != "02")
                        {
                            p_dt = TD.value_dt;
                        }
                        else
                        {
                            p_dt = TD.SIP_Reg_Date;
                        }
                        seqno = TD.seqno;
                        balance_unit = TD.balance_unit;
                        Sip_Holding_Days=TD.Sip_Holding_Days;
                        Sip_Reg_Date=TD.SIP_Reg_Date;
                        cur_val = data2;
                        DLLPurchaseRequest objchareg = new DLLPurchaseRequest();
                        List<ATTServiceCharge> OBJCharge = objchareg.GetServiceChargeAmt(objATT.Scheme_code, p_dt, objATT.nav_date, "02");
                        foreach (var item in OBJCharge)
                        {
                            rate = item.rate;
                        }
                        double charge_amount = Floor((cur_val * rate / 100),4);
                        //exe_load = (float.Parse(charge_amount.ToString()));
                        if (tran_type != "03")
                        {
                            //exe_load = (float.Parse(charge_amount.ToString()));
                            exe_load = Math.Round(charge_amount,2);
                        }
                        else
                        {
                            exe_load = 0;
                        }
                        if (SNO == 1)
                        {
                            //float amt_before_tax = (cur_val - exe_load - 25);
                            double amt_before_tax = (cur_val - exe_load - 25);
                            if (amt_before_tax > inv_amt_redem_unit)
                            {
                                double data3 = Floor((cur_val - exe_load - 25 - inv_amt_redem_unit), 4);

                                //capital_gain_amount = float.Parse(data3.ToString());
                                capital_gain_amount = Math.Round(data3,2);
                                if (Holding_Days <= 365)
                                {
                                    CGT = 7.5F;
                                    double data4 = Floor((capital_gain_amount * 0.075F), 4);

                                    //capital_gain_tax_amount = float.Parse(data4.ToString());
                                    capital_gain_tax_amount =Math.Round(data4,2);
                                }
                                else
                                {
                                    CGT = 5F;
                                    double data4 = Floor((capital_gain_amount * 0.05F), 4);

                                    //capital_gain_tax_amount = float.Parse(data4.ToString());
                                    capital_gain_tax_amount = Math.Round(data4, 2);
                                }
                              

                            }
                            else
                            {
                                capital_gain_amount = 0;
                                capital_gain_tax_amount = 0;
                                
                            }
                        }
                        else
                        {
                            //var amt_before_tax = (cur_val - exe_load);
                            double amt_before_tax = (cur_val - exe_load);
                            if (amt_before_tax > inv_amt_redem_unit)
                            {
                                double data3 = Floor((cur_val - exe_load  - inv_amt_redem_unit), 4);

                                //capital_gain_amount = float.Parse(data3.ToString());
                                capital_gain_amount = Math.Round(data3,2);
                                if (Holding_Days <= 365)
                                {
                                    CGT = 7.5F;
                                    double data4 = Floor((capital_gain_amount * 0.075F), 4);

                                    //capital_gain_tax_amount = float.Parse(data4.ToString());
                                    capital_gain_tax_amount = Math.Round(data4,2);
                                }
                                else
                                {
                                    CGT = 5F;
                                    double data4 = Floor((capital_gain_amount * 0.05F), 4);

                                   // capital_gain_tax_amount = float.Parse(data4.ToString());
                                    capital_gain_tax_amount = Math.Round(data4, 2);
                                }
                             

                            }
                            else
                            {
                                capital_gain_amount = 0;
                                capital_gain_tax_amount = 0;
                            }
                        }

                    }
                    ATTTransactionDetail objatttran = new ATTTransactionDetail();
                    objatttran.Allocation_no = int.Parse(String.Format("{0:0.##}",Allocation_no));
                    objatttran.balance_unit = float.Parse(String.Format("{0:0.##}", balance_unit));
                    objatttran.redem_unit = float.Parse(String.Format("{0:0.##}",redem_unit));
                    objatttran.inv_amt_redem_unit = float.Parse(String.Format("{0:0.##}",inv_amt_redem_unit));
                    objatttran.exe_load = float.Parse(String.Format("{0:0.##}",exe_load));
                    objatttran.p_dt = Act_p_dt;
                    objatttran.Holding_Days = Holding_Days;
                    objatttran.CGT = float.Parse(String.Format("{0:0.##}",CGT));
                    objatttran.capital_gain_amount = float.Parse(String.Format("{0:0.##}",capital_gain_amount));
                    objatttran.capital_gain_tax_amount = float.Parse(String.Format("{0:0.##}",capital_gain_tax_amount));
                    objatttran.seqno = seqno;
                    lstobj.Add(objatttran);
                    totalunit = totalunit - redem_unit;

                    SNO++;
                }
              //  String.Format("{0:0.##}", 123.4567);      // "123.46"

                float cap_gain = float.Parse(String.Format("{0:0.##}", lstobj.Sum(x => (x.capital_gain_amount))));
                float capital_gain_tax_amt = float.Parse(String.Format("{0:0.##}", lstobj.Sum(x => (x.capital_gain_tax_amount))));
                float tot_exe_load = float.Parse(String.Format("{0:0.##}", lstobj.Sum(x => (x.exe_load))));
                float TOT_REDEM_UNIT = float.Parse(String.Format("{0:0.##}", lstobj.Sum(x => (x.redem_unit))));
                float Total_Inv_Amt = float.Parse(String.Format("{0:0.##}", lstobj.Sum(x => (x.inv_amt_redem_unit))));
                float  SEBON_Fee = 0F;
                float other_charges = 25F;
                float tot_redeem_amt_nav = float.Parse(String.Format("{0:0.##}",TOT_REDEM_UNIT * nav_value));
                string selectedGLStatus = string.Empty;
                float amt_payable_before_tax = (TOT_REDEM_UNIT * nav_value - tot_exe_load - (SEBON_Fee) - (other_charges));
                if (amt_payable_before_tax > Total_Inv_Amt)
                   {

                       selectedGLStatus = "G";
                   }
                   else
                   {
                       selectedGLStatus = "L";

                   }
              
            string spName1 = "";
            string spName2 = "";
            int? DREQUEST_NO = 0;       
            SqlTransaction transaction;
            SqlConnection conn = DAO.getConnection();

                using (conn)
                {
                    transaction = conn.BeginTransaction();
                    spName1 = "InsertDetailTransactionDirty";
                    spName2 = "InsertRedemptionEntryDirty";

                    try
                    {
                        #region To Get MAX ID


                        SqlCommand cmdd = new SqlCommand();
                        cmdd.Connection = conn;
                        cmdd.Transaction = transaction;
                        cmdd.CommandText = "GetDRequestNo";
                        cmdd.CommandType = CommandType.StoredProcedure;

                        SqlParameter para1 = new SqlParameter();
                        para1.ParameterName = "@DREQUEST_NO";
                        para1.Value = DREQUEST_NO;
                        para1.SqlDbType = SqlDbType.Int;
                        para1.Size = 100;
                        para1.Direction = ParameterDirection.InputOutput;
                        cmdd.Parameters.Add(para1);
                        cmdd.ExecuteNonQuery();

                        //if (cmdd.Parameters["@DREQUEST_NO"].Value.ToString() == "") { cmdd.Parameters["@DREQUEST_NO"].Value = 0; }
                        DREQUEST_NO = int.Parse(cmdd.Parameters["@DREQUEST_NO"].Value.ToString());

                        #endregion
                        if (objATT.Transaction.Count > 0)
                        {
                            foreach (ATTTransactionDetail obja in lstobj)
                            {
                                SqlCommand cmd = new SqlCommand(spName1, conn, transaction);
                                cmd.CommandType = CommandType.StoredProcedure;

                                cmd.Parameters.Add("@scheme_code", SqlDbType.VarChar, 03).Value = objATT.Scheme_code;
                                cmd.Parameters.Add("@ccode", SqlDbType.VarChar, 04).Value = objATT.ccode;
                                cmd.Parameters.Add("@DREQUEST_NO", SqlDbType.Int).Value = DREQUEST_NO;
                                cmd.Parameters.Add("@SHHOLDERNO", SqlDbType.Int).Value = objATT.ShHolderNo;
                                cmd.Parameters.Add("@lotno", SqlDbType.Int).Value = obja.Allocation_no;
                                cmd.Parameters.Add("@seqno", SqlDbType.Int).Value = obja.seqno;
                                cmd.Parameters.Add("@lot_unit", SqlDbType.Decimal).Value = obja.balance_unit;
                                cmd.Parameters.Add("@p_dt", SqlDbType.NVarChar, 50).Value = obja.p_dt;
                                cmd.Parameters.Add("@sell_unit", SqlDbType.Decimal).Value = obja.redem_unit;
                                cmd.Parameters.Add("@charge_amt", SqlDbType.Decimal).Value = obja.exe_load;
                                cmd.Parameters.Add("@inv_amt", SqlDbType.Decimal).Value = obja.inv_amt_redem_unit;
                                cmd.Parameters.Add("@Holding_Days", SqlDbType.Int).Value = obja.Holding_Days;
                                cmd.Parameters.Add("@capital_gain_amount", SqlDbType.Decimal).Value = obja.capital_gain_amount;
                                cmd.Parameters.Add("@capital_gain_tax_amount", SqlDbType.Decimal).Value = obja.capital_gain_tax_amount;
                                cmd.Parameters.Add("@CGT", SqlDbType.Decimal).Value = obja.CGT;
                                cmd.ExecuteNonQuery();
                            }
                        }
                        //byte[] img1;

                        //if (objATT.File1 != null)
                        //{
                        //    img1 = image2byteConverter.dataURL2byte(objATT.File1);
                        //}
                        //else img1 = null;

                        SqlParameter[] param = new SqlParameter[36];
                        param[0] = new SqlParameter("@scheme_code", objATT.Scheme_code);
                        param[1] = new SqlParameter("@ccode", objATT.ccode);
                        param[2] = new SqlParameter("@DREQUEST_NO", DREQUEST_NO);
                        param[3] = new SqlParameter("@SHHOLDERNO", objATT.ShHolderNo);
                        param[4] = new SqlParameter("@FNAME", objATT.FName);
                        param[5] = new SqlParameter("@LNAME", objATT.LName);
                        param[6] = new SqlParameter("@FANAME", objATT.FaName);
                        param[7] = new SqlParameter("@GRFANAME", objATT.GFName);
                        param[8] = new SqlParameter("@address", objATT.address);
                        param[9] = new SqlParameter("@TELNO", objATT.P_Tel_No);
                        param[10] = new SqlParameter("@PANNO", objATT.PAN_No);
                        param[11] = new SqlParameter("@APPLY_UNIT", objATT.APPLY_UNIT);
                        param[12] = new SqlParameter("@APPLY_DT", objATT.APPLY_DT);
                        param[13] = new SqlParameter("@bankcode", objATT.BankCode);
                        param[14] = new SqlParameter("@ACCOUNTNO", objATT.Bank_Account_No);
                        param[15] = new SqlParameter("@ENTRY_BY", objATT.ENTRY_BY);
                        param[16] = new SqlParameter("@ENTRY_DT", objATT.ENTRY_DT);
                        param[17] = new SqlParameter("@APPROVED", objATT.APPROVED);
                        param[18] = new SqlParameter("@APPSTATUS", objATT.APPSTATUS);
                        param[19] = new SqlParameter("@appno", objATT.appno);
                        param[20] = new SqlParameter("@remarks", objATT.remarks);
                        param[21] = new SqlParameter("@boidno", objATT.Bo_Account_No);
                        param[22] = new SqlParameter("@nav_date", objATT.nav_date);
                        param[23] = new SqlParameter("@current_nav", nav_value);
                        param[24] = new SqlParameter("@SCharge_Code", objATT.SCharge_Code);
                        param[25] = new SqlParameter("@capital_gain_tax", objATT.capital_gain_tax);
                        param[26] = new SqlParameter("@tot_redeem_amt_nav", tot_redeem_amt_nav);
                        param[27] = new SqlParameter("@tot_redeem_amount", Total_Inv_Amt);
                        param[28] = new SqlParameter("@tot_exit_load", tot_exe_load);
                        param[29] = new SqlParameter("@tot_capital_gain", cap_gain);
                        param[30] = new SqlParameter("@capital_gain_tax_amt", capital_gain_tax_amt);
                        param[31] = new SqlParameter("@other_charges", other_charges);
                        param[32] = new SqlParameter("@gainloss_status", selectedGLStatus);
                        param[33] = new SqlParameter("@branch_code", objATT.Branch_code);
                        param[34] = new SqlParameter("@SEBON_Fee", SEBON_Fee);
                        param[35] = new SqlParameter("@l_company_id", objATT.l_company_id);
                        
                        //param[37] = new SqlParameter("@FileName1", objATT.FileName1);
                        DAO.executeTranProcedure(spName2, param, transaction, conn);
                        transaction.Commit();
                        response.Message = "REQUEST SEND SUCCESFULLY";
                    }
                    catch (Exception ex)
                    {
                        response.IsSucess = false;
                        response.Message = ex.Message;
                    }
                }

            }
            else
            {
                response.IsSucess = false;
                response.Message = "Redemption Unit must be greater than equal to Sum of Can be sell unit";
            }
            return msg;
        }

        public void GetTotal(List<ATTTransactionDetail> obj,float Average_Price,float current_nav )
        {
        float tot_redem_unit = 0;
        float tot_redem_inv = 0;
        float tot_cur_val = 0;
        float tot_exe_load = 0;
        float cap_gain = 0;
        float tot_cap_gain_amount = 0;
        float amt_payable_before_tax =0;
        float capital_gain_tax_amt =0;
        float sebon_fee =0;
        float other_charges=0;
        float SEBON_Fee =0;
        string selectedGLStatus=string.Empty;
        float tot_inv_amt_redem_unit = 0;
        string msg = string.Empty;
        cap_gain = obj.Sum(x => Convert.ToInt32(x.capital_gain_amount));
        capital_gain_tax_amt = obj.Sum(x => Convert.ToInt32(x.capital_gain_tax_amount));
        tot_exe_load = obj.Sum(x => Convert.ToInt32(x.exe_load));
       
             foreach (var item in obj)
              {

                  float redem_unit = item.redem_unit;
                tot_redem_unit = tot_redem_unit + +redem_unit;
                tot_redem_inv = (tot_redem_unit*Average_Price);
                tot_cur_val = (tot_redem_unit* current_nav);         

                float exe_load = item.exe_load;
                tot_exe_load = tot_exe_load + + exe_load;
                tot_inv_amt_redem_unit = tot_redem_inv;
                if(tot_cur_val != null){
                  sebon_fee = (0*tot_cur_val);
                 SEBON_Fee=(sebon_fee);
                }
                other_charges=25F;
                amt_payable_before_tax =  (tot_cur_val - tot_exe_load - (SEBON_Fee) - (other_charges));
                if (amt_payable_before_tax > tot_inv_amt_redem_unit)
                {
                    
                    selectedGLStatus="G";
                }
                else
                {
                   selectedGLStatus="L";
                
                }
               
               cap_gain = item.capital_gain_amount;
               tot_cap_gain_amount = tot_cap_gain_amount + + cap_gain;
               float cap_gain_txt_amt = item.capital_gain_tax_amount;
               capital_gain_tax_amt = capital_gain_tax_amt + + cap_gain_txt_amt;
               }
           }

   
     
        public string VerifyingSecurity(string username, string password, ATTTransactionPin objATT)
        {
            DataSet ds = new DataSet();
            DataSet ds2 = new DataSet();
            bool flag = true;
            string message = "Password Didn't Match !!!";
            try
            {

                var encodedPassword = EncryptDecrypt.Encrypt_Password(password);

                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@UserName", username);
                param[1] = new SqlParameter("@Password", encodedPassword);
                param[2] = new SqlParameter("@Email", username);

                ds = DAO.gettable("GetLoginWebUser", param);
                if (ds.Tables[0].Rows.Count == 1)
                {
                    flag = true;
                    param = new SqlParameter[3];
                    param[0] = new SqlParameter("@BOID", objATT.BOID);
                    param[1] = new SqlParameter("@SHHOLDERNO", objATT.SHHOLDERNO);
                    param[2] = new SqlParameter("@UserID", objATT.UserId);

                    ds = DAO.gettable("GetOldTransactionPin", param);
                    message = "Transaction Pin Didn't Match !!!";
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                        {

                            if (drow["TransactionPin"].ToString() == objATT.OldPin)
                            {
                                message = "Success";

                            }
                        }
                    }

                }
                else
                {

                    flag = false;
                }
            }
            catch (Exception)
            {
                //objLogin.LoggedIn = false;
                throw;
            }
            return message;
        }

        public object VerifyingSecurity(string username, ATTTransactionPin objATT)
        {
            DataSet ds = new DataSet();
            DataSet ds2 = new DataSet();
            bool flag = false;
            string message = "Password Didn't Match !!!";
            try
            {

                
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@BOID", objATT.BOID);
                param[1] = new SqlParameter("@SHHOLDERNO", objATT.SHHOLDERNO);
                param[2] = new SqlParameter("@UserID", objATT.UserId);

                ds = DAO.gettable("GetOldTransactionPin", param);
                message = "Transaction Pin Didn't Match !!!";
                if (ds.Tables[0].Rows.Count == 1)
                {
                    flag = true;
                    foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                    {

                        if (drow["TransactionPin"].ToString() == objATT.OldPin)
                        {
                            message = "Success";
                        }
                    }
                }


                else
                {

                    flag = false;
                }
            }
            catch (Exception)
            {
                //objLogin.LoggedIn = false;
                throw;
            }
            return message;
        }
    }
}
