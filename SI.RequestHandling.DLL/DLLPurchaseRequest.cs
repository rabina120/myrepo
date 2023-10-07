using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SI.Utility;
using System.Data;
using System.Data.SqlClient;
using SI.RequestHandling.DLL;
using SI.RequestHandling.ATT;
using SI.KYC.ATT;



namespace SI.RequestHandling.DLL
{
    public class DLLPurchaseRequest
    {
        public List<ATTNAV> GetNAV(string Scheme_code, string ApplyDate)
        {
            DataSet ds = new DataSet();
            List<ATTNAV> lstnav = new List<ATTNAV>();
            SqlConnection conn = DAO.getConnection();
            using (conn)
            {
                try
                {
                    SqlParameter[] param = new SqlParameter[2];
                    param[0] = new SqlParameter("@Scheme_code", Scheme_code);
                    param[1] = new SqlParameter("@ApplyDate", ApplyDate);
                    ds = DAO.gettable("dbo.GetNAV", param);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                       
                        ATTNAV objnav = new ATTNAV();
                        objnav.nav_date = dr["nav_date"].ToString();
                        objnav.nav_date = Convert.ToDateTime(dr["nav_date"]).ToString("yyyy-MM-dd");
                        objnav.nav_value = float.Parse(dr["nav_value"].ToString());
                        
                        lstnav.Add(objnav);
                    }
                 
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                 
            }
            return lstnav;
        }


        public List<ATTShareTransaction> GetUnCheckChequeDetail(string scheme_code, string ccode)
        {

            DataSet ds = new DataSet();
            List<ATTShareTransaction> listST = new List<ATTShareTransaction>();
            SqlConnection conn = new SqlConnection();
            using (conn)
            {
                try
                {
                    SqlParameter[] param = new SqlParameter[2];
                    param[0] = new SqlParameter("@scheme_code", scheme_code);
                    param[1] = new SqlParameter("@ccode", ccode);
                    ds = DAO.gettable("dbo.GetUnCheckChequeDetail", param);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ATTShareTransaction objatt = new ATTShareTransaction();
                        objatt.Scheme_code = dr["SCHEME_CODE"].ToString();
                        objatt.REQUEST_NO = int.Parse(dr["REQUEST_NO"].ToString());
                        objatt.ShHolderNo = string.IsNullOrEmpty(dr["SHHOLDERNO"].ToString()) ? (int?)null : int.Parse(dr["SHHOLDERNO"].ToString());
                        objatt.FName = dr["FNAME"].ToString();
                        objatt.LName = dr["LNAME"].ToString();
                        objatt.FaName = dr["FANAME"].ToString();
                        objatt.CHK_NO = dr["CHK_NO"].ToString();
                        objatt.bankname = dr["bankname"].ToString();
                        objatt.Bo_Account_No = Int64.Parse( dr["boidno"].ToString());
                        objatt.cname = dr["cname"].ToString();
                        objatt.ccode = dr["ccode"].ToString();
                        listST.Add(objatt);

                    }
                }
                catch (Exception ex)
                {
                }
            }
            return listST;
        
        }


        public List<ATTServiceCharge> GetChargeType(string Scheme_code)
        {
            DataSet ds = new DataSet();
            List<ATTServiceCharge> lstSC = new List<ATTServiceCharge>();
            SqlConnection conn = DAO.getConnection();
            using (conn)
            {
                try
                {
                    SqlParameter[] param = new SqlParameter[1];
                    param[0] = new SqlParameter("@Scheme_code", Scheme_code);
                    ds = DAO.gettable("dbo.GetServiceCharge", param);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {

                        ATTServiceCharge objatt = new ATTServiceCharge();
                        objatt.SDescription = dr["SDescription"].ToString();
                        objatt.SCharge_Code = dr["SCharge_Code"].ToString();
                        lstSC.Add(objatt);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            return lstSC;
        }
        public List<ATTServiceCharge> GetServiceChargeAmt(string Scheme_code, string ApplyDate, string NAV_Date, string SCharge_Code)
        {
            float? rate = 0;
            DataSet ds = new DataSet();
            List<ATTServiceCharge> lstSC = new List<ATTServiceCharge>();
            SqlConnection conn = DAO.getConnection();
            using (conn)
            {
                try
                {
                    SqlParameter[] param = new SqlParameter[3];
                    TimeSpan ts = DateTime.Parse(NAV_Date)-DateTime.Parse(ApplyDate);
                    int day = ts.Days;
                    param[0] = new SqlParameter("@Scheme_code", Scheme_code);
                    param[1] = new SqlParameter("@NoOfDays", day);
                    param[2] = new SqlParameter("@SCharge_Code", SCharge_Code);
                    ds = DAO.gettable("dbo.GetServiceChargeAmt", param);

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ATTServiceCharge objatt = new ATTServiceCharge();
                        objatt.rate = float.Parse(dr["rate"].ToString());
                        objatt.Flat_percent = dr["Flat_percent"].ToString();
                        objatt.Holding_Days = day;
                        lstSC.Add(objatt);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            return lstSC;
        }

        public string UpdateToken(string Token, string TXNID, string Action)
        {
            SqlTransaction transaction;
            string msg = "Successfully Updated";
            SqlConnection conn = DAO.getConnection();

            using (conn)
            {
                transaction = conn.BeginTransaction();

                try
                {
                    SqlParameter[] param = new SqlParameter[3];
                    param[0] = new SqlParameter("@Token", Token);
                    param[1] = new SqlParameter("@TXNID", TXNID);
                    param[2] = new SqlParameter("@Action", Action);
                    DAO.executeTranProcedure("UpdateToken", param, transaction, conn);



                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Error" + ex.Message);
                }

                transaction.Commit();


            }
            return msg;
        }
        public string UpdateKhaltiTransactionStatus(ATTPayment objATT, string Action, string GatewayCode, string TXNID, string ReferenceID, string PaymentCode)
        {
            SqlTransaction transaction;
            string msg = "Successfully Updated";
            SqlConnection conn = DAO.getConnection();

            using (conn)
            {
                transaction = conn.BeginTransaction();

                try
                {
                    SqlParameter[] param = new SqlParameter[11];  
                    param[0] = new SqlParameter("@Gatewaycode", GatewayCode);
                    param[1] = new SqlParameter("@TXNID", TXNID);
                    param[2] = new SqlParameter("@ReferenceId", ReferenceID);
                    param[3] = new SqlParameter("@txnAmt", objATT.amount);
                    param[4] = new SqlParameter("@statusDesc", objATT.state.template);
                    param[5] = new SqlParameter("@status", (objATT.state.name == "Completed") ? "SUCCESS" :"FAILURE");
                    param[6] = new SqlParameter("@VendorTXNID", objATT.idx);
                    param[7] = new SqlParameter("@token", objATT.token);
                    param[8] = new SqlParameter("@TranDate", DateTime.Now);
                    param[9] = new SqlParameter("@Action",Action);
                    param[10] = new SqlParameter("@PaymentCode", PaymentCode);
                    DAO.executeTranProcedure("UpdateTransactionDetail", param, transaction, conn);

                    //SqlParameter[] paramgateway = new SqlParameter[7];
                    //paramgateway[0] = new SqlParameter("@Gatewaycode", GatewayCode);
                    //paramgateway[1] = new SqlParameter("@IntegrationCode", "02");
                    //paramgateway[2] = new SqlParameter("@MerchantId", merchantId);
                    //paramgateway[3] = new SqlParameter("@AppId", appId);
                    //paramgateway[4] = new SqlParameter("@ProductName",PayAppName);
                    //paramgateway[5] = new SqlParameter("@ProductUrl", product_url);
                    //paramgateway[6] = new SqlParameter("@Action", Action);
                    //DAO.executeTranProcedure("UpdateGatewayDetail", paramgateway, transaction, conn);


                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Error" + ex.Message);
                }

                transaction.Commit();


            }
            return msg;
        }
        public string UpdateTransactionStatus(ATTPayment objATT, string Action, string ReferenceID, string PayAppName, string GatewayCode, string PaymentCode)
        {
            SqlTransaction transaction;
            string msg = "Successfully Updated";
            SqlConnection conn = DAO.getConnection();

            using (conn)
            {
                transaction = conn.BeginTransaction();

                try
                {

                    //new format 
                    SqlParameter[] param = new SqlParameter[11];  
                    param[0] = new SqlParameter("@Gatewaycode", GatewayCode);
                    param[1] = new SqlParameter("@TXNID", objATT.referenceId);
                    param[2] = new SqlParameter("@ReferenceId", ReferenceID);
                    param[3] = new SqlParameter("@txnAmt", objATT.txnAmt);
                    param[4] = new SqlParameter("@statusDesc", objATT.statusDesc);
                    param[5] = new SqlParameter("@status", objATT.status);
                    param[6] = new SqlParameter("@VendorTXNID", objATT.referenceId);
                    param[7] = new SqlParameter("@token", objATT.referenceId);
                    param[8] = new SqlParameter("@TranDate", DateTime.Now);
                    param[9] = new SqlParameter("@Action", Action);
                    param[10] = new SqlParameter("@PaymentCode", PaymentCode);
                    DAO.executeTranProcedure("UpdateTransactionDetail", param, transaction, conn);

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Error" + ex.Message);
                }

                transaction.Commit();


            }
          return  msg;
        }

        public string UpdateEbankingTransactionStatus(ATTPayment objATT, string Action, string GatewayCode, string PaymentCode)
        {
            SqlTransaction transaction;
            string msg = "Successfully Updated";
            SqlConnection conn = DAO.getConnection();

            using (conn)
            {
                transaction = conn.BeginTransaction();

                try
                {
                    SqlParameter[] param = new SqlParameter[11];
                    param[0] = new SqlParameter("@Gatewaycode", GatewayCode);
                    param[1] = new SqlParameter("@TXNID", objATT.PREF);
                    param[2] = new SqlParameter("@ReferenceId", objATT.CustRefType);
                    param[3] = new SqlParameter("@txnAmt", objATT.AMOUNT);  
                    param[4] = new SqlParameter("@statusDesc", objATT.statusDesc);
                    param[5] = new SqlParameter("@status", objATT.status);
                    param[6] = new SqlParameter("@VendorTXNID", objATT.PREF);
                    param[7] = new SqlParameter("@token", objATT.BID);
                    param[8] = new SqlParameter("@TranDate", DateTime.Now);
                    param[9] = new SqlParameter("@Action", Action);
                    param[10] = new SqlParameter("@PaymentCode", PaymentCode);
                    DAO.executeTranProcedure("UpdateTransactionDetail", param, transaction, conn);


                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Error" + ex.Message);
                }

                transaction.Commit();


            }
            return msg;
        }
        public string SavePurchaseEntry(ATTShareTransaction objATT)
        {

            string spName = "";
            string msg = "No Data To Save !!!";
            int? DREQUEST_NO = 0;
            SqlTransaction transaction;
            int? REQUEST_NO=0;
            string TXNID ;
            msg = "Successfully Saved !!!";
            SqlConnection conn = DAO.getConnection();
            
                using (conn)
                {
                    transaction = conn.BeginTransaction();

                    spName = "InsertDirtyPEntry";

                    try
                    {
                        byte[] img1;

                        if (objATT.File1 != null)
                        {
                            img1 = image2byteConverter.dataURL2byte(objATT.File1);
                        }
                        else img1 = null;

                        byte[] img2;
                        if (objATT.File2 != null)
                        {
                            img2 = image2byteConverter.dataURL2byte(objATT.File2);
                        }
                        else img2 = null;

                        byte[] img3;
                        if (objATT.File3 != null)
                        {
                            img3 = image2byteConverter.dataURL2byte(objATT.File3);
                        }
                        else img3 = null;
                        SqlCommand cmd = new SqlCommand("InsertDirtyPEntry", conn, transaction);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@scheme_code", SqlDbType.VarChar, 03).Value = objATT.Scheme_code;
                        cmd.Parameters.Add("@ccode", SqlDbType.VarChar, 04).Value = objATT.ccode;
                        if (objATT.Action == "I")
                        {
                            cmd.Parameters.Add("@DREQUEST_NO", SqlDbType.Int).Direction = ParameterDirection.Output;
                        }
                        else if (objATT.Action == "A")
                        {
                            cmd.Parameters.Add("@DREQUEST_NO", SqlDbType.Int).Value = objATT.DREQUEST_NO;
                        }
                        cmd.Parameters.Add("@IS_UNIT_HOLDER", SqlDbType.VarChar, 1).Value = objATT.IS_UNIT_HOLDER;
                        cmd.Parameters.Add("@ShHolderNo", SqlDbType.Int).Value = objATT.ShHolderNo;
                        cmd.Parameters.Add("@boidno", SqlDbType.VarChar, 16).Value = objATT.Bo_Account_No;
                        cmd.Parameters.Add("@FName", SqlDbType.VarChar, 55).Value = objATT.FName;
                        cmd.Parameters.Add("@LNAME", SqlDbType.VarChar, 55).Value = objATT.LName;
                        cmd.Parameters.Add("@FANAME", SqlDbType.VarChar, 55).Value = objATT.FaName;
                        cmd.Parameters.Add("@GRFANAME", SqlDbType.VarChar, 55).Value = objATT.GFName;
                        cmd.Parameters.Add("@address", SqlDbType.VarChar, 50).Value = objATT.address;
                        cmd.Parameters.Add("@branch_code", SqlDbType.VarChar, 4).Value = objATT.Branch_code;
                        cmd.Parameters.Add("@TELNO", SqlDbType.VarChar, 55).Value = objATT.P_Tel_No;
                        cmd.Parameters.Add("@bankcode", SqlDbType.VarChar, 3).Value = objATT.BankCode;
                        cmd.Parameters.Add("@ACCOUNTNO", SqlDbType.VarChar, 55).Value = objATT.Bank_Account_No;
                        cmd.Parameters.Add("@PANNO", SqlDbType.VarChar, 50).Value = objATT.PAN_No;
                        cmd.Parameters.Add("@CitizenshipNo", SqlDbType.VarChar, 25).Value = objATT.Citizenship_No;
                        cmd.Parameters.Add("@is_institution", SqlDbType.VarChar, 5).Value = objATT.IsInstitution;
                        cmd.Parameters.Add("@APPLY_UNIT", SqlDbType.Float).Value = objATT.APPLY_UNIT;
                        cmd.Parameters.Add("@APPLY_DT", SqlDbType.DateTime).Value = objATT.APPLY_DT;
                        cmd.Parameters.Add("@AMOUNT", SqlDbType.Decimal).Value = Convert.ToDecimal(objATT.AMOUNT);
                        cmd.Parameters.Add("@CHK_NO", SqlDbType.VarChar, 30).Value = objATT.CHK_NO;
                        cmd.Parameters.Add("@remarks", SqlDbType.VarChar, 6).Value = objATT.remarks;
                        cmd.Parameters.Add("@appno", SqlDbType.VarChar, 50).Value = objATT.appno;
                        cmd.Parameters.Add("@bcode_cheque", SqlDbType.VarChar, 04).Value = objATT.bcode_cheque;
                        cmd.Parameters.Add("@current_nav", SqlDbType.Decimal).Value = objATT.current_nav;
                        cmd.Parameters.Add("@SCharge_Code", SqlDbType.VarChar, 02).Value = objATT.SCharge_Code;
                        cmd.Parameters.Add("@charge_amount", SqlDbType.Decimal).Value = objATT.charge_amount;
                        cmd.Parameters.Add("@ENTRY_BY", SqlDbType.VarChar, 50).Value = objATT.ENTRY_BY;
                        cmd.Parameters.Add("@ENTRY_DT", SqlDbType.VarChar, 50).Value = objATT.ENTRY_DT;
                        cmd.Parameters.Add("@APPSTATUS", SqlDbType.VarChar, 50).Value = objATT.APPSTATUS;
                        cmd.Parameters.Add("@nav_date", SqlDbType.DateTime).Value = objATT.nav_date;
                        cmd.Parameters.Add("@cashorcheque", SqlDbType.VarChar, 6).Value = objATT.cashorcheque;
                        cmd.Parameters.Add("@APPROVED", SqlDbType.VarChar, 50).Value = objATT.APPROVED;
                        cmd.Parameters.Add("@other_charges", SqlDbType.Decimal).Value = objATT.other_charges;
                        cmd.Parameters.Add("@IsChequeClear", SqlDbType.VarChar, 10).Value = objATT.IsChequeClear;
                        cmd.Parameters.Add("@ClearedDate", SqlDbType.DateTime).Value = objATT.ClearedDate;
                        cmd.Parameters.Add("@ChequeCheckedBy", SqlDbType.VarChar, 50).Value = objATT.ChequeCheckedBy;
                        cmd.Parameters.Add("@CashAmount", SqlDbType.Decimal).Value = string.IsNullOrEmpty(objATT.CashAmount) ? (decimal?)0.00 : Convert.ToDecimal(objATT.CashAmount);
                        cmd.Parameters.Add("@ChequeAmount", SqlDbType.Decimal).Value = string.IsNullOrEmpty(objATT.ChequeAmount) ? (decimal?)0.00 : Convert.ToDecimal(objATT.ChequeAmount);
                        cmd.Parameters.Add("@SEBON_Fee", SqlDbType.Decimal).Value = objATT.SEBON_Fee;
                        cmd.Parameters.Add("@P_Mobile_no", SqlDbType.VarChar, 50).Value = objATT.P_Mobile_no;
                        cmd.Parameters.Add("@Is_SIP", SqlDbType.VarChar, 50).Value = objATT.Is_SIP;
                        cmd.Parameters.Add("@l_company_id", SqlDbType.VarChar, 4).Value = objATT.l_company_id;
                        cmd.Parameters.Add("@Action", SqlDbType.VarChar, 50).Value = objATT.Action;
                        cmd.Parameters.Add("@TranType", SqlDbType.VarChar, 50).Value = objATT.TranType;
                        cmd.Parameters.Add("@Status", SqlDbType.VarChar, 50).Value = objATT.Status;
                        cmd.Parameters.Add("@TXNID", SqlDbType.VarChar, 20).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@Email_ID", SqlDbType.VarChar, 50).Value = objATT.Email_ID;
                        cmd.Parameters.Add("@source", SqlDbType.VarChar, 10).Value = objATT.source;
                        cmd.Parameters.Add("@FileUpload1", SqlDbType.Image).Value = img1;
                        cmd.Parameters.Add("@FileUpload2", SqlDbType.Image).Value = img2;
                        cmd.Parameters.Add("@FileUpload3", SqlDbType.Image).Value = img3;
                        cmd.Parameters.Add("@payeename", SqlDbType.VarChar, 55).Value = objATT.payeename;
                        cmd.Parameters.Add("@PayeeContactNo", SqlDbType.VarChar, 55).Value = objATT.PayeeContactNo;
                        cmd.Parameters.Add("@FileName1", SqlDbType.VarChar, 55).Value = objATT.FileName1;
                        cmd.Parameters.Add("@FileName2", SqlDbType.VarChar, 55).Value = objATT.FileName2;
                        cmd.Parameters.Add("@FileName3", SqlDbType.VarChar, 55).Value = objATT.FileName3;

                        cmd.Parameters.Add("@DOB", SqlDbType.DateTime).Value = objATT.DOB;
                        cmd.Parameters.Add("@Gatewaycode", SqlDbType.VarChar, 3).Value = objATT.GatewayCode;
                        cmd.Parameters.Add("@HasDrep", SqlDbType.Bit, 1).Value = objATT.HasDrep;
                        cmd.ExecuteNonQuery();
                        DREQUEST_NO = Convert.ToInt32(cmd.Parameters["@DREQUEST_NO"].Value);
                        TXNID = (cmd.Parameters["@TXNID"].Value).ToString();

                        // DAO.executeTranProcedure(spName, param, transaction, conn);
                    }


                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Error" + ex.Message);
                    }

                    transaction.Commit();
                }
            
            return DREQUEST_NO+" "+TXNID;
            
        }

        public List<ATTShareTransaction> ValidateAmount(string TXNID)
        {
            DataSet ds = new DataSet();
            List<ATTShareTransaction> lstShareholder = new List<ATTShareTransaction>();
            SqlParameter[] param = new SqlParameter[1];
            try
            {

                param[0] = new SqlParameter("@TXNID", TXNID);
                ds = DAO.gettable("ValidateAmount", param);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ATTShareTransaction objATT = new ATTShareTransaction();
                        objATT.AMOUNT = (dr["Amount"].ToString());
                        objATT.DREQUEST_NO = int.Parse(dr["DREQUEST_NO"].ToString());
                        objATT.Bo_Account_No = Int64.Parse(dr["boidno"].ToString());
                        objATT.GatewayCode = (dr["GatewayCode"].ToString());
                        objATT.cashorcheque = (dr["cashorcheque"].ToString());
                        lstShareholder.Add(objATT);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return lstShareholder;
        }


        public List<ATTShareTransaction> GetData(string scheme_code, string ccode, int REQUEST_NO, string Action, string l_company_id)
        {
            List<ATTShareTransaction> lstShareholder = new List<ATTShareTransaction>();
            List<ATTShHolder> lstSHolders = new List<ATTShHolder>();
            string spName = "";
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[5];
            try
            {

                param[0] = new SqlParameter("@scheme_code", scheme_code != null ? scheme_code : null);
                param[1] = new SqlParameter("@ccode", ccode != null ? ccode : null);
                param[2] = new SqlParameter("@REQUEST_NO", REQUEST_NO);
                param[3] = new SqlParameter("@Action", Action);
                param[4] = new SqlParameter("@l_company_id", l_company_id);
                spName = "GetData";
                ds = DAO.gettable(spName, param);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ATTShareTransaction objATT = new ATTShareTransaction();
                        DLLSHolder objdll = new DLLSHolder();
                        objATT.ShHolderNo = string.IsNullOrEmpty(dr["SHHOLDERNO"].ToString()) ? (int?)null : int.Parse(dr["SHHOLDERNO"].ToString());
                        objATT.Bo_Account_No = Int64.Parse(dr["boidno"].ToString());
                        objATT.REQUEST_NO = REQUEST_NO;
                        objATT.FName = string.IsNullOrEmpty(dr["FNAME"].ToString()) ? "" : dr["FNAME"].ToString();
                        objATT.LName = string.IsNullOrEmpty(dr["LNAME"].ToString()) ? "" : dr["LNAME"].ToString();
                        objATT.FaName = string.IsNullOrEmpty(dr["FANAME"].ToString()) ? null : dr["FANAME"].ToString();
                        objATT.GFName = string.IsNullOrEmpty(dr["GRFANAME"].ToString()) ? null : dr["GRFANAME"].ToString();
                        objATT.address = string.IsNullOrEmpty(dr["address"].ToString()) ? null : dr["address"].ToString();
                        objATT.P_Tel_No = string.IsNullOrEmpty(dr["TELNO"].ToString()) ? null : dr["TELNO"].ToString();
                        objATT.P_Mobile_no = string.IsNullOrEmpty(dr["P_Mobile_no"].ToString()) ? null : dr["P_Mobile_no"].ToString();
                        objATT.BankCode = dr["BCODE"].ToString();
                        objATT.Branch_code = string.IsNullOrEmpty(dr["branch_code"].ToString()) ? null : dr["branch_code"].ToString();
                        objATT.Bank_Account_No = dr["ACCOUNTNO"].ToString();
                        objATT.PAN_No = string.IsNullOrEmpty(dr["PANNO"].ToString()) ? null : dr["PANNO"].ToString();
                        objATT.Citizenship_No = string.IsNullOrEmpty(dr["CitizenshipNo"].ToString()) ? null : dr["CitizenshipNo"].ToString();

                        if (dr["IS_UNIT_HOLDER"].ToString() == "Y")
                        {

                            objATT.TotalKitta = GetBalanceUnit(scheme_code, objATT.Bo_Account_No, ccode, objATT.ShHolderNo, l_company_id);
                        }
                        else
                        {
                            objATT.TotalKitta = 0;

                        }
                        objATT.appno = dr["appno"].ToString();
                        objATT.remarks = dr["remarks"].ToString();
                        objATT.CHK_NO = dr["CHK_NO"].ToString();
                        objATT.bcode_cheque = dr["bcode_cheque"].ToString();
                        objATT.APPLY_DT = Convert.ToDateTime(dr["APPLY_DT"]).ToString("yyyy-MM-dd");
                        objATT.APPLY_UNIT = float.Parse(dr["APPLY_UNIT"].ToString());
                        objATT.AMOUNT = (dr["AMOUNT"].ToString());
                        // objATT.AMOUNT = float.Parse(dr["AMOUNT"].ToString());
                        objATT.cashorcheque = dr["cashorcheque"].ToString();
                        objATT.IsInstitution = bool.Parse(dr["is_institution"].ToString());
                        objATT.charge_amount = float.Parse(dr["charge_amount"].ToString());
                        //objATT.nav_date = String.Format("{0:MM.dd.yyyy}", (dr["nav_date"].ToString()));
                        objATT.current_nav = float.Parse(dr["current_nav"].ToString());
                        objATT.nav_date = Convert.ToDateTime(dr["nav_date"]).ToString("yyyy-MM-dd");
                        objATT.other_charges = float.Parse(dr["other_charges"].ToString());
                        objATT.SCharge_Code = (dr["SCharge_Code"].ToString());
                        objATT.IsChequeClear = dr["IsChequeClear"].ToString();
                        objATT.CashAmount = (dr["CashAmount"].ToString());
                        objATT.ChequeAmount = (dr["ChequeAmount"].ToString());
                        objATT.SEBON_Fee = float.Parse(dr["SEBON_Fee"].ToString());
                        // objATT.TotalKitta = int.Parse(dr["TotalKitta"].ToString());
                        objATT.IS_UNIT_HOLDER = dr["IS_UNIT_HOLDER"].ToString();
                        objATT.Is_SIP = dr["Is_SIP"].ToString();
                        objATT.Email_ID = dr["Email_ID"].ToString();
                        objATT.payeename = dr["PayeeName"].ToString();
                        objATT.PayeeContactNo = dr["PayeeContactNo"].ToString();
                        objATT.source = dr["SourceofFund"].ToString();
                        objATT.FileName1 = dr["FileName"].ToString();
                        objATT.FileName2 = dr["FileName2"].ToString();
                        objATT.FileName3 = dr["FileName3"].ToString();
                        objATT.Name = objATT.FName+' '+objATT.LName;
                        string DocSignFile;
                        byte[] SymbolSignByte = dr["FileUpload"] == DBNull.Value ? null : (byte[])dr["FileUpload"];
                        if (SymbolSignByte == null)
                        {
                            DocSignFile = null;
                        }
                        else
                        {
                            DocSignFile = image2byteConverter.byte2dataURL(SymbolSignByte);
                        }
                        string DocFile2;
                        byte[] SymbolFile2Byte = dr["FileUpload2"] == DBNull.Value ? null : (byte[])dr["FileUpload2"];
                        if (SymbolFile2Byte == null)
                        {
                            DocFile2 = null;
                        }
                        else
                        {
                            DocFile2 = image2byteConverter.byte2dataURL(SymbolFile2Byte);
                        }
                        string DocFile3;
                        byte[] SymbolFile3Byte = dr["FileUpload3"] == DBNull.Value ? null : (byte[])dr["FileUpload3"];
                        if (SymbolFile3Byte == null)
                        {
                            DocFile3 = null;
                        }
                        else
                        {
                            DocFile3 = image2byteConverter.byte2dataURL(SymbolFile3Byte);
                        }
                        objATT.File1 = DocSignFile;
                        objATT.File2 = DocFile2;
                        objATT.File3 = DocFile3;
                        // objATT.ShHolder = lstSHolders;
                        objATT.DOB = string.IsNullOrEmpty(dr["DOB"].ToString()) ? "" : Convert.ToDateTime(dr["DOB"]).ToString("yyyy-MM-dd");
                        //Convert.ToDateTime(dr["DOB"]).ToString("yyyy-MM-dd");

                        objATT.Citizenship_No = string.IsNullOrEmpty(dr["CitizenshipNo"].ToString()) ? "" : (dr["CitizenshipNo"]).ToString();
                        objATT.GatewayCode = dr["GatewayCode"].ToString();
                        objATT.HasDrep = string.IsNullOrEmpty(dr["HasDrep"].ToString()) ? false : bool.Parse(dr["HasDrep"].ToString());
                        lstShareholder.Add(objATT);
                    }
                }
                return lstShareholder;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<ATTShareTransaction> GetHolderUnitRpt(string scheme_code, string ccode, string Bo_Account_No, string l_company_id, DateTime startdate, DateTime enddate)
        {
            List<ATTShareTransaction> lstShareholder = new List<ATTShareTransaction>();
            List<ATTShHolder> lstSHolders = new List<ATTShHolder>();
            string spName = "";
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[6];
            try
            {

                param[0] = new SqlParameter("@scheme_code", scheme_code != null ? scheme_code : null);
                param[1] = new SqlParameter("@ccode", ccode != null ? ccode : null);
                param[2] = new SqlParameter("@Bo_Account_No", Bo_Account_No);
                param[3] = new SqlParameter("@l_company_id", l_company_id);
                param[4] = new SqlParameter("@startdate", startdate);
                param[5] = new SqlParameter("@enddate", enddate);
                spName = "GetHolderUnitRpt";
                ds = DAO.gettable(spName, param);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ATTShareTransaction objATT = new ATTShareTransaction();
                        DLLSHolder objdll = new DLLSHolder();
                        objATT.ShHolderNo = string.IsNullOrEmpty(dr["SHHOLDERNO"].ToString()) ? (int?)null : int.Parse(dr["SHHOLDERNO"].ToString());
                        objATT.Bo_Account_No = Int64.Parse(dr["boidno"].ToString());
                        objATT.REQUEST_NO = int.Parse(dr["REQUEST_NO"].ToString());
                        objATT.FName = string.IsNullOrEmpty(dr["FNAME"].ToString()) ? "" : dr["FNAME"].ToString();
                        objATT.LName = string.IsNullOrEmpty(dr["LNAME"].ToString()) ? "" : dr["LNAME"].ToString();
                        objATT.FaName = string.IsNullOrEmpty(dr["FANAME"].ToString()) ? null : dr["FANAME"].ToString();
                        objATT.GFName = string.IsNullOrEmpty(dr["GRFANAME"].ToString()) ? null : dr["GRFANAME"].ToString();
                        objATT.address = string.IsNullOrEmpty(dr["address"].ToString()) ? null : dr["address"].ToString();
                        objATT.P_Tel_No = string.IsNullOrEmpty(dr["TELNO"].ToString()) ? null : dr["TELNO"].ToString();
                        objATT.P_Mobile_no = string.IsNullOrEmpty(dr["P_Mobile_no"].ToString()) ? null : dr["P_Mobile_no"].ToString();
                        objATT.BankCode = dr["BCODE"].ToString();
                        objATT.Branch_code = string.IsNullOrEmpty(dr["branch_code"].ToString()) ? null : dr["branch_code"].ToString();
                        objATT.Bank_Account_No = dr["ACCOUNTNO"].ToString();
                        objATT.PAN_No = string.IsNullOrEmpty(dr["PANNO"].ToString()) ? null : dr["PANNO"].ToString();
                        objATT.Citizenship_No = string.IsNullOrEmpty(dr["CitizenshipNo"].ToString()) ? null : dr["CitizenshipNo"].ToString();
                        objATT.appno = dr["appno"].ToString();
                        objATT.remarks = dr["remarks"].ToString();
                        objATT.CHK_NO = dr["CHK_NO"].ToString();
                        objATT.bcode_cheque = dr["bcode_cheque"].ToString();
                        objATT.APPLY_DT = Convert.ToDateTime(dr["APPLY_DT"]).ToString("yyyy-MM-dd");
                        objATT.APPLY_UNIT = float.Parse(dr["APPLY_UNIT"].ToString());
                        objATT.AMOUNT = (Math.Round(double.Parse(dr["AMOUNT"].ToString()), 2)).ToString(); 
                        // objATT.AMOUNT = float.Parse(dr["AMOUNT"].ToString());
                        objATT.cashorcheque = dr["cashorcheque"].ToString();
                       // objATT.IsInstitution = (dr["is_institution"].ToString());
                        objATT.charge_amount = float.Parse(dr["charge_amount"].ToString());
                        //objATT.nav_date = String.Format("{0:MM.dd.yyyy}", (dr["nav_date"].ToString()));
                        objATT.current_nav = float.Parse(dr["current_nav"].ToString());
                        objATT.nav_date = Convert.ToDateTime(dr["nav_date"]).ToString("yyyy-MM-dd");
                        objATT.other_charges = float.Parse(dr["other_charges"].ToString());
                        objATT.SCharge_Code = (dr["SCharge_Code"].ToString());
                        objATT.IsChequeClear = dr["IsChequeClear"].ToString();
                        //objATT.CashAmount = string.IsNullOrEmpty(dr["CashAmount"].ToString()) ? "0" : dr["CashAmount"].ToString();
                        //objATT.ChequeAmount = string.IsNullOrEmpty(dr["ChequeAmount"].ToString()) ? "0" : dr["ChequeAmount"].ToString(); 
                        objATT.SEBON_Fee = float.Parse(dr["SEBON_Fee"].ToString());
                        // objATT.TotalKitta = int.Parse(dr["TotalKitta"].ToString());
                        objATT.IS_UNIT_HOLDER = dr["IS_UNIT_HOLDER"].ToString();
                        var APPSTATUS = dr["APPSTATUS"].ToString();
                        if (APPSTATUS == "POSTED")
                        {
                            objATT.APPSTATUS = "VERIFIED";
                        }
                        else if (APPSTATUS == "UNPOSTED")
                        {
                            objATT.APPSTATUS = "IN PROCESS";
                        }
                        objATT.ChequeAmount = "0";
                        objATT.CashAmount = "0";
                        if (objATT.cashorcheque == "02")
                        {
                            objATT.ChequeAmount = string.IsNullOrEmpty(dr["ChequeAmount"].ToString()) ? "0" : dr["ChequeAmount"].ToString();
                            objATT.ChequeAmount = (Math.Round(Double.Parse(objATT.ChequeAmount), 2)).ToString();
                        }
                        else
                        {
                            objATT.CashAmount = string.IsNullOrEmpty(dr["CashAmount"].ToString()) ? "0" : dr["CashAmount"].ToString();
                            objATT.CashAmount = (Math.Round(Double.Parse(objATT.CashAmount), 2)).ToString();
                        }

                        //objatt.CashAmount = string.IsNullOrEmpty(dr["CashAmount"].ToString()) ? "0" : dr["CashAmount"].ToString();
                        //objatt.ChequeAmount = string.IsNullOrEmpty(dr["ChequeAmount"].ToString()) ? "0" : dr["ChequeAmount"].ToString();


                        objATT.AMOUNT = (Math.Round(Double.Parse(objATT.AMOUNT), 2)).ToString();


                        var total = Convert.ToDecimal(objATT.CashAmount) + Convert.ToDecimal(objATT.ChequeAmount);
                        objATT.refund_amount = float.Parse((total - Convert.ToDecimal(objATT.AMOUNT)).ToString());
                        objATT.totalreceived = total.ToString();
                     //   objATT.APPSTATUS = dr["APPSTATUS"].ToString();
                        // objATT.ShHolder = lstSHolders;
                        lstShareholder.Add(objATT);
                    }
                }
                return lstShareholder;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public float GetBalanceUnit(string scheme_code, Int64 Bo_Account_No, string ccode,  int? ShHolderNo, string l_company_id)
        {
            List<ATTShHolder> lstSHolders = new List<ATTShHolder>();
            List<ATTSignature> lstsigns = new List<ATTSignature>();
            string spName = "";
            float BalUnit=0;
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[5];
            try
            {
                param[0] = new SqlParameter("@Bo_Account_No", Bo_Account_No);
                param[1] = new SqlParameter("@scheme_code", scheme_code != null ? scheme_code : null);
                param[2] = new SqlParameter("@ccode", ccode != null ? ccode : null);
                param[3] = new SqlParameter("@l_company_id", l_company_id != null ? l_company_id : null);
                param[4] = new SqlParameter("@SHHOLDERNO", ShHolderNo );

                spName = "GetSHoldersInfoByBoid";
                ds = DAO.gettable(spName, param);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        BalUnit = (float.Parse(dr["DBBalUnit"].ToString())) - (float.Parse(dr["CRBalUnit"].ToString()));
                    }
                }
                return BalUnit;

            }

            catch (Exception ex)
            {

                throw ex;
            }
        }
        public string DeletePurchaseEntry(string username, string shholderno, string scheme_code, string ccode, int REQUEST_NO, string l_company_id)
        {

            string spName = "";
            string msg = "No Data To Delete !!!";
            SqlTransaction transaction;


            SqlConnection conn = DAO.getConnection();

            using (conn)
            {
                transaction = conn.BeginTransaction();

                try
                {
                    SqlParameter[] param = new SqlParameter[5];
                    spName = "DeletePurchaseEntry";
                    param[0] = new SqlParameter("@SHHOLDERNO", shholderno);
                    param[1] = new SqlParameter("@scheme_code", scheme_code);
                    param[2] = new SqlParameter("@ccode", ccode);
                    param[3] = new SqlParameter("@REQUEST_NO", REQUEST_NO);
                    param[4] = new SqlParameter("@l_company_id", l_company_id);
                    DAO.executeTranProcedure(spName, param, transaction, conn);
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

        public int? GetRequestNo(string scheme_code, string ccode)
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
                cmdd.CommandText = "GetRequestNo";
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
        public string UpdateChequeStatus(List<ATTShareTransaction> objATT)
        {

            string spName = "";
            string msg = "No Data To Save !!!";
            SqlTransaction transaction;

            msg = "Successfully Saved !!!";
            SqlConnection conn = DAO.getConnection();

            using (conn)
            {
                transaction = conn.BeginTransaction();
                spName = "dbo.UpdateChequeStatus";

                try
                {
                    foreach (var obj in objATT)
                    {
                        SqlParameter[] param = new SqlParameter[6];
                        param[0] = new SqlParameter("@Scheme_code", obj.Scheme_code);

                        param[1] = new SqlParameter("@REQUEST_NO", obj.REQUEST_NO);
                        param[2] = new SqlParameter("@Bo_Account_No", obj.Bo_Account_No);
                        param[3] = new SqlParameter("@ClearedDate", obj.ClearedDate);
                        param[4] = new SqlParameter("@ChequeCheckedBy", obj.ChequeCheckedBy);
                        param[5] = new SqlParameter("@ccode", obj.ccode);
                        DAO.executeTranProcedure(spName, param, transaction, conn);
                        
                    }
                    transaction.Commit();

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Error" + ex.Message);
                }
            }
            return msg;
        }

        public List<ATTBOID> GetDPInfo()
        {
            List<ATTBOID> lstDp = new List<ATTBOID>();

            DataSet ds = new DataSet();
            ds = DAO.gettable("GetDpInfo", null);

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ATTBOID objATT = new ATTBOID();
                    objATT.DPCode = dr["DP_CODE"].ToString();
                    objATT.DP_Id_Cds = dr["DP_Id_Cds"].ToString();
                    objATT.DPName = dr["DP_Id_Cds"].ToString() + ' ' + dr["DP_NAME"].ToString();
                    lstDp.Add(objATT);
                }

            }
            return lstDp;

        }

        public List<ATTShareTransaction> GetDPInfo2()
        {
            List<ATTShareTransaction> lstDp = new List<ATTShareTransaction>();

            DataSet ds = new DataSet();
            ds = DAO.gettable("GetDpInfo", null);

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ATTShareTransaction objATT = new ATTShareTransaction();
                    objATT.DPCode = dr["DP_CODE"].ToString();
                    objATT.DP_Id_Cds = dr["DP_Id_Cds"].ToString();
                    objATT.DepoName = dr["DP_Id_Cds"].ToString() + ' ' + dr["DP_NAME"].ToString();
                    lstDp.Add(objATT);
                }

            }
            return lstDp;

        }

        public string DeletePostedPurchase(string shholderno, string scheme_code, string ccode, int REQUEST_NO, string Action, string username, string l_company_id)
        {

            string spName = "";
            string msg = "No Data To Delete !!!";
            SqlTransaction transaction;


            SqlConnection conn = DAO.getConnection();

            using (conn)
            {
                transaction = conn.BeginTransaction();

                try
                {
                    SqlParameter[] param = new SqlParameter[6];
                    spName = "deleteposteddata";
                    param[0] = new SqlParameter("@SHHOLDERNO", shholderno);
                    param[1] = new SqlParameter("@scheme_code", scheme_code);
                    param[2] = new SqlParameter("@ccode", ccode);
                    param[3] = new SqlParameter("@REQUEST_NO", REQUEST_NO);
                    param[4] = new SqlParameter("@Action", Action);
                    param[5] = new SqlParameter("@username",username);
                    param[6] = new SqlParameter("@l_company_id", l_company_id);
                    DAO.executeTranProcedure(spName, param, transaction, conn);
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
        //public void CreatePDF(ATTShareTransaction objATT)
        //{
        //    string fileName = "/Purchase Entry Report -" + System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".pdf";
        //    string path = Server.MapPath("/Reports" + fileName);
        //}


        public JsonResponse ValidateNAV(string APPLY_DT, string Amount, string APPLY_UNIT)
        {

            string spName = "";
            JsonResponse jsonResponse = new JsonResponse();

            try
            {
                DataSet ds = new DataSet();


                spName = "ValidateNAV";
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@APPLY_DT", APPLY_DT);
                param[1] = new SqlParameter("@Amount", Amount);
                param[2] = new SqlParameter("@APPLY_UNIT", APPLY_UNIT);
                ds = DAO.gettable(spName, param);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        jsonResponse.IsSucess = Convert.ToBoolean(dr["IsSucess"]);
                    }
                }
                else
                {
                    jsonResponse.IsSucess = false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error" + ex.Message);
            }

            return jsonResponse;
        }
    }
}
