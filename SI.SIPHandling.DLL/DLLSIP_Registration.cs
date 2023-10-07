using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SI.SIPHandling.ATT;
using SI.Utility;
using System.Data;
using System.Data.SqlClient;
using SI.KYC.ATT; 
using System.Threading.Tasks;  
//using System.Net.Http;  

namespace SI.SIPHandling.DLL
{
    public class DLLSIP_Registration
    {
        public List<SI.SIPHandling.ATT.ATTBank> GetBankName()
        {
            List<SI.SIPHandling.ATT.ATTBank> lstbnk = new List<SI.SIPHandling.ATT.ATTBank>();

            DataSet ds = new DataSet();
            ds = DAO.gettable("GetBankName", null);

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    SI.SIPHandling.ATT.ATTBank objATT = new SI.SIPHandling.ATT.ATTBank();
                    objATT.bankcode = dr["bankcode"].ToString();
                    objATT.bankname = dr["bankname"].ToString();
                    objATT.nrb_type = dr["nrb_type"].ToString();
                    objATT.nrb_code = dr["nrb_code"].ToString();
                    lstbnk.Add(objATT);
                }

            }
            return lstbnk;

        }
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
        public List<ATTHolderType> GetHolderType()
        {
            List<ATTHolderType> lstholder = new List<ATTHolderType>();

            DataSet ds = new DataSet();
            ds = DAO.gettable("GetHolderType", null);

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ATTHolderType objATT = new ATTHolderType();
                    objATT.HolderTypeNo = dr["Holder_Type_No"].ToString();
                    objATT.HolderType = dr["Holder_Type_Name"].ToString();
                    lstholder.Add(objATT);
                }

            }
            return lstholder;

        }

        public List<ATTSIPInterval> GetSipIntervals()
        {
            List<ATTSIPInterval> lstholder = new List<ATTSIPInterval>();

            DataSet ds = new DataSet();
            ds = DAO.gettable("GetSipIntervals", null);

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ATTSIPInterval objATT = new ATTSIPInterval();
                    objATT.Sip_code = dr["Sip_code"].ToString();
                    objATT.SIP_Interval = dr["SIP_Interval"].ToString();
                    objATT.No_of_Months = int.Parse(dr["No_of_Months"].ToString());
                    lstholder.Add(objATT);
                }

            }
            return lstholder;

        }

        public List<ATTPaymentMode> LoadPaymentMode()
        {
            List<ATTPaymentMode> lstpaymentmode = new List<ATTPaymentMode>();

            DataSet ds = new DataSet();
            ds = DAO.gettable("LoadPaymentModeOnline", null);

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ATTPaymentMode objATT = new ATTPaymentMode();
                    objATT.PaymentCode = (dr["PaymentCode"].ToString());
                    objATT.PaymentMode = dr["PaymentMode"].ToString();
                    lstpaymentmode.Add(objATT);
                }

            }
            return lstpaymentmode;

        }

        public List<ATTPaymentMode> LoadPaymentModeforAmend()
        {
            List<ATTPaymentMode> lstpaymentmode = new List<ATTPaymentMode>();

            DataSet ds = new DataSet();
            ds = DAO.gettable("LoadPaymentMode", null);

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ATTPaymentMode objATT = new ATTPaymentMode();
                    objATT.PaymentCode = (dr["PaymentCode"].ToString());
                    objATT.PaymentMode = dr["PaymentMode"].ToString();
                    lstpaymentmode.Add(objATT);
                }

            }
            return lstpaymentmode;

        }

        public string SaveFundCollection(ATTAmtCollection objATT)
        {
            string spName = "";
            string msg = "No Data To Save !!!";
            SqlTransaction transaction;

            msg = "Transaction Succesfull !!!";
            SqlConnection conn = DAO.getConnection();

            using (conn)
            {
                transaction = conn.BeginTransaction();
                try
                {
                    // spName = "SaveCollectionDetail_Dirty";
                       spName = "SaveSIPTransactionDetail_Dirty";
                    SqlParameter[] param = new SqlParameter[17];
                        param[0] = new SqlParameter("@scheme_code", objATT.scheme_code);
                        param[1] = new SqlParameter("@ccode", objATT.ccode);
                        param[2] = new SqlParameter("@Interval_No", 1);
                        param[3] = new SqlParameter("@DSIP_Reg_No", objATT.DSIP_Reg_No);
                        param[4] = new SqlParameter("@ShHolderNo", objATT.ShHolderNo);
                        param[5] = new SqlParameter("@SIPAmount", objATT.Amount);
                        param[6] = new SqlParameter("@ReceiveAmount", objATT.Amount);
                       // param[7] = new SqlParameter("@tran_dt", objATT.tran_dt);
                        param[7] = new SqlParameter("@entry_user", objATT.entry_user);
                        param[8] = new SqlParameter("@entry_dt", objATT.entry_dt);
                        param[9] = new SqlParameter("@remarks", objATT.remarks);
                        param[10] = new SqlParameter("@l_company_id", objATT.l_company_id);
                        param[11] = new SqlParameter("@PaymentCode", objATT.PaymentCode);
                        param[12] = new SqlParameter("@Interval_Seq_No", 1);
                        param[13] = new SqlParameter("@TranType", "02");
                        param[14] = new SqlParameter("@TXNID", objATT.TXNID);
                        param[15] = new SqlParameter("@GatewayCode", objATT.GatewayCode);
                        param[16] = new SqlParameter("@status", 'A');
                    // param[16] = new SqlParameter("@Integrationcode", objATT.Integrationcode);
                    DAO.executeTranProcedure(spName, param, transaction, conn);
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
        public string SaveSipRegistration(ATTSIP_Registration objATT)
        {

            
            string msg = "No Data To Save !!!";
            string DSIP_Reg_No;
            string TXNID;
            SqlTransaction transaction;

            msg = "Submitted Successfully !!!";
            SqlConnection conn = DAO.getConnection();

            using (conn)
            {
                transaction = conn.BeginTransaction();
                    try
                    {
                        byte[] img1;
                        byte[] img2;
                        byte[] img3;
                        
                        if (objATT.File1 != null )
                        {
                            img1 = image2byteConverter.dataURL2byte(objATT.File1);
                        }
                        else img1 = null;

                        if (objATT.File2 != null )
                        {
                            img2 = image2byteConverter.dataURL2byte(objATT.File2);
                        }
                        else img2 = null;

                        if (objATT.File3 != null)
                        {
                            img3 = image2byteConverter.dataURL2byte(objATT.File3);
                        }
                        else img3 = null;
                        SqlParameter[] param = new SqlParameter[44];
                        SqlCommand cmd = new SqlCommand("InsertSipRegistration_dirty", conn, transaction);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@scheme_code", SqlDbType.VarChar, 03).Value = objATT.scheme_code;
                        cmd.Parameters.Add("@ccode", SqlDbType.VarChar, 20).Value = objATT.ccode;
                        if (objATT.Action == "I")
                        {
                            cmd.Parameters.Add("@DSIP_Reg_No", SqlDbType.VarChar, 20).Direction = ParameterDirection.Output;
                        }
                        else if (objATT.Action == "A")
                        {
                            cmd.Parameters.Add("@DSIP_Reg_No", SqlDbType.VarChar, 20).Value = objATT.DSIP_Reg_No;
                        }
                        cmd.Parameters.Add("@ShHolderNo", SqlDbType.Int).Value = objATT.ShHolderNo;
                        cmd.Parameters.Add("@Name", SqlDbType.VarChar, 55).Value = objATT.Name;
                        cmd.Parameters.Add("@Address", SqlDbType.VarChar, 55).Value = objATT.Address;
                        cmd.Parameters.Add("@BOID", SqlDbType.VarChar, 55).Value = objATT.boid;
                        cmd.Parameters.Add("@Email", SqlDbType.VarChar, 55).Value = objATT.Email;
                        cmd.Parameters.Add("@ContactNo1", SqlDbType.VarChar, 55).Value = objATT.Contact1;
                        cmd.Parameters.Add("@ContactNo2", SqlDbType.VarChar, 55).Value = objATT.Contact2;
                        cmd.Parameters.Add("@HolderTypeNo", SqlDbType.VarChar, 5).Value = objATT.HolderTypeNo;
                        cmd.Parameters.Add("@Model_of_Sip", SqlDbType.VarChar, 55).Value = objATT.Model_of_Sip;
                        cmd.Parameters.Add("@SIP_Interval", SqlDbType.VarChar, 55).Value = objATT.SIP_Interval;
                        cmd.Parameters.Add("@SIP_Reg_Date", SqlDbType.DateTime).Value = string.IsNullOrEmpty(objATT.SIP_DT) ? null : Convert.ToDateTime(objATT.SIP_DT).ToString("yyyy-MM-dd");
                        cmd.Parameters.Add("@SIP_Last_Date", SqlDbType.VarChar, 55).Value = string.IsNullOrEmpty(objATT.Last_Date) ? null : Convert.ToDateTime(objATT.Last_Date).ToString("yyyy-MM-dd");
                        cmd.Parameters.Add("@SIP_Amt", SqlDbType.Decimal).Value = objATT.Sip_amt;
                        cmd.Parameters.Add("@PayeeName", SqlDbType.VarChar, 55).Value = objATT.PayeeName;
                        cmd.Parameters.Add("@Introducer", SqlDbType.VarChar, 55).Value = objATT.Introducer;
                        cmd.Parameters.Add("@ISOnline ", SqlDbType.Bit).Value = objATT.Online;
                        cmd.Parameters.Add("@Entry_By", SqlDbType.VarChar, 55).Value = objATT.ENTRY_BY;
                        cmd.Parameters.Add("@Entry_Date", SqlDbType.VarChar, 55).Value = objATT.ENTRY_DT;
                        cmd.Parameters.Add("@App_Status", SqlDbType.VarChar, 55).Value = objATT.APPSTATUS;
                        cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 55).Value = objATT.remarks;
                        cmd.Parameters.Add("@PaymentCode", SqlDbType.VarChar, 55).Value = objATT.PaymentCode;
                        cmd.Parameters.Add("@St_BankCode", SqlDbType.VarChar, 55).Value = objATT.St_BankCode;
                        cmd.Parameters.Add("@Terms", SqlDbType.VarChar, 55).Value = string.IsNullOrEmpty(objATT.Terms) ? null : (objATT.Terms).ToString();
                        cmd.Parameters.Add("@IntroducerRem", SqlDbType.VarChar, 55).Value = objATT.IntroducerRem;
                        cmd.Parameters.Add("@PayeeContactNo", SqlDbType.VarChar, 55).Value = objATT.PayeeContactNo;
                        cmd.Parameters.Add("@IsApproved", SqlDbType.VarChar, 55).Value = objATT.IsApproved;
                        cmd.Parameters.Add("@FileUpload1", SqlDbType.Image).Value = img1;
                        cmd.Parameters.Add("@FileUpload2", SqlDbType.Image).Value = img2;
                        cmd.Parameters.Add("@l_company_id", SqlDbType.VarChar, 03).Value = objATT.l_company_id;
                        cmd.Parameters.Add("@SIP_Eff_Date", SqlDbType.DateTime).Value = string.IsNullOrEmpty(objATT.SIP_Eff_Date) ? null : Convert.ToDateTime(objATT.SIP_Eff_Date).ToString("yyyy-MM-dd");
                        cmd.Parameters.Add("@Is_Unit_Holder", SqlDbType.VarChar, 55).Value = objATT.Is_Unit_Holder;
                        cmd.Parameters.Add("@BankCode", SqlDbType.VarChar, 55).Value = objATT.BankCode;
                        cmd.Parameters.Add("@Bank_Account_No", SqlDbType.VarChar, 55).Value = objATT.Bank_Account_No;
                        cmd.Parameters.Add("@TranType", SqlDbType.VarChar, 55).Value = objATT.TranType;
                        cmd.Parameters.Add("@Status", SqlDbType.VarChar, 55).Value = objATT.Status;
                        cmd.Parameters.Add("@Action", SqlDbType.VarChar, 55).Value = objATT.Action;
                        cmd.Parameters.Add("@FileUpload3", SqlDbType.Image).Value = img3;
                        cmd.Parameters.Add("@source", SqlDbType.VarChar, 55).Value = objATT.source;
                        cmd.Parameters.Add("@TXNID", SqlDbType.VarChar, 55).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@FileName1", SqlDbType.VarChar, 55).Value = objATT.FileName1;
                        cmd.Parameters.Add("@FileName2", SqlDbType.VarChar, 55).Value = objATT.FileName2;
                        cmd.Parameters.Add("@FileName3", SqlDbType.VarChar, 55).Value = objATT.FileName3;
                        cmd.Parameters.Add("@DOB", SqlDbType.DateTime, 55).Value = objATT.DOB;
                        cmd.Parameters.Add("@Gatewaycode", SqlDbType.VarChar, 3).Value = objATT.GatewayCode;
                        cmd.Parameters.Add("@CitizenshipNo", SqlDbType.VarChar, 55).Value = objATT.CitizenshipNo;
                        cmd.Parameters.Add("@Integrationcode", SqlDbType.VarChar, 55).Value = objATT.Integrationcode;
                        cmd.Parameters.Add("@HasDrep", SqlDbType.Bit,1).Value = objATT.HasDrep;
                        cmd.ExecuteNonQuery();
                        DSIP_Reg_No = (cmd.Parameters["@DSIP_Reg_No"].Value).ToString();
                        TXNID = (cmd.Parameters["@TXNID"].Value).ToString();
                       
                    }


                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Error" + ex.Message);
                    }
                    transaction.Commit();
             }

            return DSIP_Reg_No + " " + TXNID;
          }

        
        public List<ATTSIP_Registration> GetSIPHolderDetail(string scheme_code, string ccode, string SIP_Reg_No, string Action, string l_company_id)
        {
            List<ATTSIP_Registration> lstshdel= new List<ATTSIP_Registration>();
            string spName = "";
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            SqlParameter[] param = new SqlParameter[5];
            try
            {

                param[0] = new SqlParameter("@scheme_code", scheme_code != null ? scheme_code : null);
                param[1] = new SqlParameter("@ccode", ccode != null ? ccode : null);
                param[2] = new SqlParameter("@SIP_Reg_No", SIP_Reg_No);
                param[3] = new SqlParameter("@Action", Action);
                param[4] = new SqlParameter("@l_company_id", l_company_id != null ? l_company_id : null);
                spName = "FetchSIPHolderDetail";
                ds = DAO.gettable(spName, param);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ATTSIP_Registration objATT = new ATTSIP_Registration();
                        //Convert.ToDateTime(dr["p_dt"]).ToString("yyyy-MM-dd");SIP_Reg_Date
                        objATT.ShHolderNo = string.IsNullOrEmpty(dr["ShHolderNo"].ToString()) ? (int?)null : int.Parse(dr["ShHolderNo"].ToString());
                        objATT.Name = string.IsNullOrEmpty(dr["Name"].ToString()) ? "" : dr["Name"].ToString();
                        objATT.Email = string.IsNullOrEmpty(dr["Email"].ToString()) ? "" : dr["Email"].ToString();
                        objATT.boid = string.IsNullOrEmpty(dr["BOID"].ToString()) ? "" : dr["BOID"].ToString();
                        objATT.SIP_DT =  Convert.ToDateTime(dr["SIP_Reg_Date"]).ToString("yyyy-MM-dd");
                        objATT.Model_of_Sip = string.IsNullOrEmpty(dr["Model_of_SIP"].ToString()) ? "" : dr["Model_of_SIP"].ToString();
                        objATT.SIP_Last_Date = string.IsNullOrEmpty(dr["SIP_Last_Date"].ToString()) ? "" : Convert.ToDateTime(dr["SIP_Last_Date"]).ToString("yyyy-MM-dd");
                        objATT.Online = string.IsNullOrEmpty(dr["ISOnline"].ToString()) ? "" : dr["ISOnline"].ToString();
                        objATT.Address = string.IsNullOrEmpty(dr["Address"].ToString()) ? "" : dr["Address"].ToString();
                        objATT.Contact1 = string.IsNullOrEmpty(dr["ContactNo1"].ToString()) ? "" : dr["ContactNo1"].ToString();
                        objATT.Contact2 = string.IsNullOrEmpty(dr["ContactNo2"].ToString()) ? "" : dr["ContactNo2"].ToString();
                        objATT.PayeeName = string.IsNullOrEmpty(dr["PayeeName"].ToString()) ? "" : dr["PayeeName"].ToString();
                        objATT.Introducer = string.IsNullOrEmpty(dr["Introducer"].ToString()) ? "" : dr["Introducer"].ToString();
                        objATT.HolderTypeNo = string.IsNullOrEmpty(dr["HolderType_No"].ToString()) ? "" : dr["HolderType_No"].ToString();
                        objATT.Bank_Account_No = string.IsNullOrEmpty(dr["Bank_Account_No"].ToString()) ? "" : dr["Bank_Account_No"].ToString();
                        objATT.BankCode = string.IsNullOrEmpty(dr["BankCode"].ToString()) ? "" : dr["BankCode"].ToString();
                        objATT.Sip_amt = float.Parse(dr["SIP_Amt"].ToString());
                        objATT.SIP_Interval = string.IsNullOrEmpty(dr["SIP_Interval"].ToString()) ? "" : dr["SIP_Interval"].ToString();
                        objATT.SIP_Reg_No = string.IsNullOrEmpty(dr["SIP_Reg_No"].ToString()) ? ""  : (dr["SIP_Reg_No"].ToString());
                        objATT.Terms = string.IsNullOrEmpty(dr["Terms"].ToString()) ?null:(dr["Terms"].ToString());
                        objATT.PayeeContactNo = string.IsNullOrEmpty(dr["PayeeContactNo"].ToString()) ? null : (dr["PayeeContactNo"].ToString());
                        objATT.IntroducerRem = string.IsNullOrEmpty(dr["IntroducerRem"].ToString()) ? null : (dr["IntroducerRem"].ToString());
                        objATT.St_BankCode = string.IsNullOrEmpty(dr["St_BankCode"].ToString()) ? null : (dr["St_BankCode"].ToString());
                        objATT.St_BankAccountNo = string.IsNullOrEmpty(dr["St_BankAccountNo"].ToString()) ? null : (dr["St_BankAccountNo"].ToString());
                        objATT.PaymentCode = string.IsNullOrEmpty(dr["PaymentCode"].ToString()) ? null : (dr["PaymentCode"].ToString());
                        objATT.SIP_Eff_Date = string.IsNullOrEmpty(dr["SIP_Eff_Date"].ToString()) ? "" : Convert.ToDateTime(dr["SIP_Eff_Date"]).ToString("yyyy-MM-dd");
                        objATT.Action_Date = string.IsNullOrEmpty(dr["Action_Date"].ToString()) ? "" : Convert.ToDateTime(dr["Action_Date"]).ToString("yyyy-MM-dd");
                        objATT.New_Action_Date = string.IsNullOrEmpty(dr["New_Action_Date"].ToString()) ? "" : Convert.ToDateTime(dr["New_Action_Date"]).ToString("yyyy-MM-dd");
                        objATT.Amdnt_No = string.IsNullOrEmpty(dr["Amdnt_No"].ToString()) ? null : (dr["Amdnt_No"].ToString());
                        objATT.Is_Unit_Holder = string.IsNullOrEmpty(dr["Is_Unit_Holder"].ToString()) ? null : (dr["Is_Unit_Holder"].ToString());
                        objATT.source = string.IsNullOrEmpty(dr["sourceoffund"].ToString()) ? null : (dr["sourceoffund"].ToString());
                        objATT.Interval = string.IsNullOrEmpty(dr["Interval"].ToString()) ? null : (dr["Interval"].ToString());
                        objATT.DSIP_Reg_No = string.IsNullOrEmpty(dr["DSIP_Reg_No"].ToString()) ? null : (dr["DSIP_Reg_No"].ToString());
                        objATT.PaymentMode = string.IsNullOrEmpty(dr["paymenttype"].ToString()) ? null : (dr["paymenttype"].ToString());
                        objATT.SIP_Reg_Date = string.IsNullOrEmpty(dr["SIP_Reg_Date"].ToString()) ? null : (dr["SIP_Reg_Date"].ToString());

                        string DocFile1;
                        byte[] SymbolFile1Byte = dr["FileUpload1"] == DBNull.Value ? null : (byte[])dr["FileUpload1"];
                        if (SymbolFile1Byte == null)
                        {
                            DocFile1 = null;
                        }
                        else
                        {
                            DocFile1 = image2byteConverter.byte2dataURL(SymbolFile1Byte);
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
                       
                        objATT.File1 = DocFile1;
                        objATT.File2 = DocFile2;
                        objATT.File3 = DocFile3;
                        objATT.FileName1 = dr["FileName1"].ToString();
                        objATT.FileName2 = dr["FileName2"].ToString();
                        objATT.FileName3 = dr["FileName3"].ToString();
                        objATT.DOB = string.IsNullOrEmpty(dr["DOB"].ToString()) ? "" : Convert.ToDateTime(dr["DOB"]).ToString("yyyy-MM-dd");
                        objATT.CitizenshipNo = string.IsNullOrEmpty(dr["CitizenshipNo"].ToString()) ? "" : dr["CitizenshipNo"].ToString();
                        objATT.Integrationcode = dr["Integrationcode"].ToString();
                        objATT.HasDrep = string.IsNullOrEmpty(dr["HasDrep"].ToString()) ? false : bool.Parse(dr["HasDrep"].ToString());
                        lstshdel.Add(objATT);
                    }
                }
                return lstshdel;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<ATTShHolder> SearchHoldersByName(string ASearch, string FSearch, string GSearch, string scheme_code, string l_company_id)
        {
            
            List<ATTShHolder> lstSHolders = new List<ATTShHolder>();
            string spName = "";
            DataSet ds = new DataSet();
            string whereCondition = "sh.scheme_code = '" + scheme_code + "' and sh.l_company_id = '" + l_company_id +"'";
            try
            {

                if (!(string.IsNullOrEmpty(ASearch)))
                {
                    whereCondition += " and sh.FName like " + "'%" + ASearch + "%'";

                }
                if (!(string.IsNullOrEmpty(FSearch)))
                {
                    whereCondition += " and sh.FaName like " + "'%" + FSearch + "%'";

                }
                if (!(string.IsNullOrEmpty(GSearch)))
                {
                    whereCondition += " and sh.GFName like " + "'%" + GSearch + "%'";

                }

                whereCondition += " and sh.App_Status= '" + "POSTED" + "'";

                SqlParameter[] param = new SqlParameter[1];

                param[0] = new SqlParameter("@whereCondition", whereCondition);


                spName = "SearchShHolders";
                ds = DAO.gettable(spName, param);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ATTShHolder objATT = new ATTShHolder();
                        objATT.ShHolderNo = int.Parse(dr["ShHolderNo"].ToString());
                        objATT.Title = dr["Title"].ToString() != "" ? dr["Title"].ToString() : "";
                        objATT.FName = dr["FName"].ToString() != "" ? dr["FName"].ToString() : "";
                        objATT.MName = dr["MName"].ToString() != "" ? dr["MName"].ToString() : "";
                        objATT.LName = dr["LName"].ToString() != "" ? dr["LName"].ToString() : "";
                        objATT.FaName = dr["FaName"].ToString() != "" ? dr["FaName"].ToString() : "";
                        objATT.GFName = dr["GFName"].ToString() != "" ? dr["GFName"].ToString() : "";
                        objATT.Citizenship_No = dr["Citizenship_No"].ToString() != "" ? dr["Citizenship_No"].ToString() : "";
                        objATT.Bo_Account_No = dr["Bo_Account_No"].ToString() != "" ? dr["Bo_Account_No"].ToString() : "";
                        objATT.PAN_No = dr["PAN_No"].ToString() != "" ? dr["PAN_No"].ToString() : "";
                        objATT.Reg_No = dr["Reg_No"].ToString() != "" ? dr["Reg_No"].ToString() : "";
                        objATT.ccode = dr["ccode"].ToString() != "" ? dr["ccode"].ToString() : "";
                        objATT.cname = dr["cname"].ToString() != "" ? dr["cname"].ToString() : "";
                        objATT.Bank_Account_No = dr["Bank_Account_No"].ToString() != "" ? dr["Bank_Account_No"].ToString() : "";
                        objATT.BankCode = dr["BankCode"].ToString() != "" ? dr["BankCode"].ToString() : "";
                        objATT.Branch_code = dr["Branch_code"].ToString() != "" ? dr["Branch_code"].ToString() : "";
                        objATT.IsInstitution = dr["IsInstitution"].ToString() != "" ? dr["IsInstitution"].ToString() : "";
                        lstSHolders.Add(objATT);

                    }
                }
                return lstSHolders;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<ATTSIP_Registration> GetHolderInfoByBoid(string scheme_code, Int64 Bo_Account_No, string ccode, string l_company_id)
        {
            List<ATTSIP_Registration> lstSHolders = new List<ATTSIP_Registration>();
            //List<ATTSign> lstsigns = new List<ATTSign>();

            string spName = "";
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[4];
            try
            {
                param[0] = new SqlParameter("@Bo_Account_No", Bo_Account_No);
                param[1] = new SqlParameter("@scheme_code", scheme_code != null ? scheme_code : null);
                param[2] = new SqlParameter("@ccode", ccode != null ? ccode : null);
                param[3] = new SqlParameter("@l_company_id", l_company_id != null ? l_company_id : null);


                spName = "GetHolderInfoByBoid";
                ds = DAO.gettable(spName, param);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ATTSIP_Registration objATT = new ATTSIP_Registration();
                        //objATT.Title = dr["Title"].ToString() != "" ? dr["Title"].ToString() : "";
                        objATT.FName = dr["FName"].ToString() != "" ? dr["FName"].ToString() : "";
                        objATT.MName = dr["MName"].ToString() != "" ? dr["MName"].ToString() : "";
                        objATT.LName = dr["LName"].ToString() != "" ? dr["LName"].ToString() : "";
                        objATT.Email = dr["Email_ID"].ToString() != "" ? dr["Email_ID"].ToString() : "";
                        objATT.Address = dr["T_Tole"].ToString() != "" ? dr["T_Tole"].ToString() : "";
                        objATT.Contact1 = dr["P_Mobile_No"].ToString() != "" ? dr["P_Mobile_No"].ToString() : "";
                        objATT.Contact2 = dr["T_Mobile_No"].ToString() != "" ? dr["T_Mobile_No"].ToString() : "";

                        lstSHolders.Add(objATT);

                    }
                }
                return lstSHolders;

            }

            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<ATTSIP_Registration> GetSIPHolderInfoByBoid(string scheme_code, string Bo_Account_No, string ccode, string l_company_id)
        {
            List<ATTSIP_Registration> lstSHolders = new List<ATTSIP_Registration>();
            //List<ATTSign> lstsigns = new List<ATTSign>();

            string spName = "";
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[4];
            try
            {
                param[0] = new SqlParameter("@Bo_Account_No", Bo_Account_No);
                param[1] = new SqlParameter("@scheme_code", scheme_code != null ? scheme_code : null);
                param[2] = new SqlParameter("@ccode", ccode != null ? ccode : null);
                param[3] = new SqlParameter("@l_company_id", l_company_id != null ? l_company_id : null);


                spName = "GetSIPHolderInfoByBoid";
                ds = DAO.gettable(spName, param);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ATTSIP_Registration objATT = new ATTSIP_Registration();
                        objATT.Name = dr["Name"].ToString() != "" ? dr["Name"].ToString() : "";
                        objATT.Email = dr["Email"].ToString() != "" ? dr["Email"].ToString() : "";;
                        objATT.Contact1 = dr["ContactNo1"].ToString() != "" ? dr["ContactNo1"].ToString() : "";
                        objATT.Contact2 = dr["ContactNo2"].ToString() != "" ? dr["ContactNo2"].ToString() : "";
                        objATT.SIP_DT = Convert.ToDateTime(dr["SIP_Reg_Date"]).ToString("yyyy-MM-dd");
                        objATT.Model_of_Sip = string.IsNullOrEmpty(dr["Model_of_SIP"].ToString()) ? "" : dr["Model_of_SIP"].ToString();
                        objATT.SIP_Last_Date = string.IsNullOrEmpty(dr["SIP_Last_Date"].ToString()) ? "" : Convert.ToDateTime(dr["SIP_Last_Date"]).ToString("yyyy-MM-dd");
                        objATT.Sip_amt = float.Parse(dr["SIP_Amt"].ToString());
                        objATT.SIP_Interval = string.IsNullOrEmpty(dr["SIP_Interval"].ToString()) ? "" : dr["SIP_Interval"].ToString();
                        objATT.SIP_Reg_No = string.IsNullOrEmpty(dr["SIP_Reg_No"].ToString()) ? "": (dr["SIP_Reg_No"].ToString());
                        objATT.Terms = string.IsNullOrEmpty(dr["Terms"].ToString()) ? null : (dr["Terms"].ToString());
                        objATT.PayeeContactNo = string.IsNullOrEmpty(dr["PayeeContactNo"].ToString()) ? null : (dr["PayeeContactNo"].ToString());
                        objATT.IntroducerRem = string.IsNullOrEmpty(dr["IntroducerRem"].ToString()) ? null : (dr["IntroducerRem"].ToString());
                        objATT.St_BankCode = string.IsNullOrEmpty(dr["St_BankCode"].ToString()) ? null : (dr["St_BankCode"].ToString());
                        objATT.St_BankAccountNo = string.IsNullOrEmpty(dr["St_BankAccountNo"].ToString()) ? null : (dr["St_BankAccountNo"].ToString());
                        objATT.PaymentCode = string.IsNullOrEmpty(dr["PaymentCode"].ToString()) ? null : (dr["PaymentCode"].ToString());
                        objATT.SIP_Eff_Date = string.IsNullOrEmpty(dr["Action_Date"].ToString()) ? "" : Convert.ToDateTime(dr["Action_Date"]).ToString("yyyy-MM-dd");

                        lstSHolders.Add(objATT);

                    }
                }
                return lstSHolders;

            }

            catch (Exception ex)
            {

                throw ex;
            }
        }
        public JsonResponse CheckSIPSHolders(string scheme_code, string Bo_Account_No, string l_company_id)
        {
            JsonResponse jsonresponse = new JsonResponse();
       
            string spName = "";
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[3];
            try
            {
                param[0] = new SqlParameter("@Bo_Account_No", Bo_Account_No);
                param[1] = new SqlParameter("@scheme_code", scheme_code != null ? scheme_code : null);
                param[2] = new SqlParameter("@l_company_id", l_company_id != null ? l_company_id : null);
                spName = "CheckSIPSHolders";
                ds = DAO.gettable(spName, param);

                jsonresponse.IsSucess = false;

                if (ds.Tables[0].Rows.Count > 0)
                {


                    foreach (DataRow drow in ds.Tables[0].Rows)
                    {
                        jsonresponse.IsSucess = drow["isSuccess"].ToString() == "" ? false : Convert.ToBoolean(drow["isSuccess"].ToString());
                        jsonresponse.Message = drow["Message"].ToString() == "" ? "Failed" : drow["Message"].ToString();


                    }

                }
                else
                {
                    jsonresponse.IsSucess = false;
                    jsonresponse.Message = "NO Record Found";
                }

                return jsonresponse;

            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ATTSIP_Registration> ValidateSIPAmount(string TXNID,string Action)
        {
            DataSet ds = new DataSet();
            List<ATTSIP_Registration> lstShareholder = new List<ATTSIP_Registration>();
            SqlParameter[] param = new SqlParameter[2];
            try
            {

                param[0] = new SqlParameter("@TXNID", TXNID);
                param[1] = new SqlParameter("@Action", Action);
                ds = DAO.gettable("ValidateSIPAmount", param);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ATTSIP_Registration objATT = new ATTSIP_Registration();
                        objATT.Sip_amt = float.Parse(dr["SIP_Amt"].ToString());
                        objATT.DSIP_Reg_No = (dr["DSIP_Reg_No"].ToString());
                        objATT.SIP_Reg_No = string.IsNullOrEmpty(dr["SIP_Reg_No"].ToString()) ? null : (dr["SIP_Reg_No"].ToString()); 
                        objATT.boid = (dr["BOID"].ToString());
                        objATT.Integrationcode = (dr["Integrationcode"].ToString());
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
      }
 }

