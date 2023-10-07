using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SI.SIPHandling.ATT;
using System.Data;
using SI.Utility;
using System.Data.SqlClient;


namespace SI.SIPHandling.DLL
{
    public class DLLAmendmentRequest
    {
        public List<ATTSIP_Registration> LoadData(string scheme_code, string ccode, string Holder_typeNo, string BOID, string l_company_id)
        {
            List<ATTSIP_Registration> lstshdel = new List<ATTSIP_Registration>();
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();

            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@scheme_code", scheme_code);
            param[1] = new SqlParameter("@ccode", ccode);
            param[2] = new SqlParameter("@Holder_typeNo", Holder_typeNo);
            param[3] = new SqlParameter("@BOID", BOID);
            param[4] = new SqlParameter("@l_company_id", l_company_id);
            
                ds = DAO.gettable("dbo.LoadSIPHolderDetail", param);
            

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
                    objATT.SIP_DT = Convert.ToDateTime(dr["SIP_Reg_Date"]).ToString("yyyy-MM-dd");
                    objATT.Model_of_Sip = string.IsNullOrEmpty(dr["Model_of_SIP"].ToString()) ? "" : dr["Model_of_SIP"].ToString();
                    objATT.Last_Date = string.IsNullOrEmpty(dr["SIP_Last_Date"].ToString()) ? "" : Convert.ToDateTime(dr["SIP_Last_Date"]).ToString("yyyy-MM-dd");
                    objATT.Online = string.IsNullOrEmpty(dr["ISOnline"].ToString()) ? "" : dr["ISOnline"].ToString();
                    objATT.Address = string.IsNullOrEmpty(dr["Address"].ToString()) ? "" : dr["Address"].ToString();
                    objATT.Contact1 = string.IsNullOrEmpty(dr["ContactNo1"].ToString()) ? "" : dr["ContactNo1"].ToString();
                    objATT.Contact2 = string.IsNullOrEmpty(dr["ContactNo2"].ToString()) ? "" : dr["ContactNo2"].ToString();
                    objATT.PayeeName = string.IsNullOrEmpty(dr["PayeeName"].ToString()) ? "" : dr["PayeeName"].ToString();
                    objATT.Introducer = string.IsNullOrEmpty(dr["Introducer"].ToString()) ? "" : dr["Introducer"].ToString();
                    objATT.HolderTypeNo = string.IsNullOrEmpty(dr["HolderType_No"].ToString()) ? "" : dr["HolderType_No"].ToString();
                    // objATT.Contact2 = string.IsNullOrEmpty(dr["Contact2"].ToString()) ? "" : dr["Contact2"].ToString();
                    objATT.Sip_amt = float.Parse(dr["SIP_Amt"].ToString());
                    objATT.SIP_Interval = string.IsNullOrEmpty(dr["SIP_Interval"].ToString()) ? "" : dr["SIP_Interval"].ToString();
                    objATT.SIP_Reg_No = string.IsNullOrEmpty(dr["SIP_Reg_No"].ToString()) ? "" : dr["SIP_Reg_No"].ToString();
                    objATT.HolderType = string.IsNullOrEmpty(dr["Holder_Type_Name"].ToString()) ? "" : dr["Holder_Type_Name"].ToString();
                    objATT.Bank_Account_No = string.IsNullOrEmpty(dr["Bank_Account_No"].ToString()) ? "" : dr["Bank_Account_No"].ToString();
                    objATT.BankCode = string.IsNullOrEmpty(dr["BankCode"].ToString()) ? "" : dr["BankCode"].ToString();
                    objATT.Terms = string.IsNullOrEmpty(dr["Terms"].ToString()) ? "" : dr["Terms"].ToString();
                    objATT.scheme_code = string.IsNullOrEmpty(dr["scheme_code"].ToString()) ? null : dr["scheme_code"].ToString();
                    objATT.ccode = string.IsNullOrEmpty(dr["scheme_code"].ToString()) ? null : dr["ccode"].ToString();
                    objATT.SchemeEnName = string.IsNullOrEmpty(dr["SchemeEnName"].ToString()) ? null : dr["SchemeEnName"].ToString();
                    objATT.cname = string.IsNullOrEmpty(dr["cname"].ToString()) ? null : dr["cname"].ToString();

                    lstshdel.Add(objATT);
                }
            }
            return lstshdel;
        }
        public int? SaveAmmendment(ATTSIP_Registration objATT)
        {

            string spName1 = "";
            string spName2 = "";
            string msg = "No Data To Save !!!";
            int? Amdnt_No = 0;
            SqlTransaction transaction;

            msg = "Successfully Saved !!!";
            SqlConnection conn = DAO.getConnection();

            using (conn)
            {
                transaction = conn.BeginTransaction();


                if (objATT.Amdnt_No != null)
                {
                    Amdnt_No = string.IsNullOrEmpty(objATT.Amdnt_No.ToString()) ? (int?)null : int.Parse(objATT.Amdnt_No.ToString());
                }
                else
                {
                    #region To Get MAX ID


                    SqlCommand cmdd = new SqlCommand();
                    cmdd.Connection = conn;
                    cmdd.Transaction = transaction;
                    cmdd.CommandText = "GetAmmendmentNo";
                    cmdd.CommandType = CommandType.StoredProcedure;

                    SqlParameter para1 = new SqlParameter();
                    para1.ParameterName = "@Amdnt_No";
                    para1.Value = Amdnt_No;
                    para1.SqlDbType = SqlDbType.Int;
                    para1.Size = 100;
                    para1.Direction = ParameterDirection.InputOutput;
                    cmdd.Parameters.Add(para1);
                    cmdd.Parameters.AddWithValue("@scheme_code", objATT.scheme_code);
                    cmdd.Parameters.AddWithValue("@ccode", objATT.ccode);
                    cmdd.Parameters.AddWithValue("@SIP_Reg_No", objATT.SIP_Reg_No);
                    cmdd.ExecuteNonQuery();

                    if (cmdd.Parameters["@Amdnt_No"].Value.ToString() == "") { cmdd.Parameters["@Amdnt_No"].Value = 0; }
                    Amdnt_No = int.Parse(cmdd.Parameters["@Amdnt_No"].Value.ToString()) + 1;

                    #endregion
                }
                if (objATT.Action == "A")
                {
                    spName1 = "dbo.SaveAmmendment";
                    spName2 = "dbo.Insert_Ammendment_BankInfo";

                }
                else if (objATT.Action == "U")
                {
                    spName1 = "dbo.UpdateSIPAmmendment";
                    spName2 = "dbo.Update_Ammendment_BankInfo";
                }
                try
                {
                    SqlParameter[] param = new SqlParameter[41];
                   
                    byte[] img1;
                    byte[] img2;
                    if (objATT.File1 != null)
                    {
                        img1 = image2byteConverter.dataURL2byte(objATT.File1);
                    }
                    else img1 = null;

                    if (objATT.File2 != null)
                    {
                        img2 = image2byteConverter.dataURL2byte(objATT.File2);
                    }
                    else img2 = null;
                    param[0] = new SqlParameter("@scheme_code", objATT.scheme_code);
                    param[1] = new SqlParameter("@ccode", objATT.ccode);
                    param[2] = new SqlParameter("@SIP_Reg_No", objATT.SIP_Reg_No);
                    param[3] = new SqlParameter("@ShHolderNo", objATT.ShHolderNo);
                    param[4] = new SqlParameter("@Name", objATT.Name);
                    param[5] = new SqlParameter("@Address", objATT.Address);
                    param[6] = new SqlParameter("@BOID", objATT.boid);
                    param[7] = new SqlParameter("@Email", objATT.Email);
                    param[8] = new SqlParameter("@ContactNo1", objATT.Contact1);
                    param[9] = new SqlParameter("@ContactNo2", objATT.Contact2);
                    param[10] = new SqlParameter("@HolderType_No", objATT.HolderTypeNo);
                    param[11] = new SqlParameter("@Model_of_SIP", objATT.Model_of_Sip);
                    param[12] = new SqlParameter("@SIP_Interval", objATT.SIP_Interval);
                    param[13] = new SqlParameter("@SIP_Reg_Date", string.IsNullOrEmpty(objATT.SIP_DT) ? null : Convert.ToDateTime(objATT.SIP_DT).ToString("yyyy-MM-dd"));
                    //param[13] = new SqlParameter("@SIP_Reg_Date", string.IsNullOrEmpty(objATT.SIP_DT) ? null : Convert.ToDateTime(objATT.SIP_DT).ToString("yyyy-MM-dd"));
                    param[14] = new SqlParameter("@SIP_Last_Date", string.IsNullOrEmpty(objATT.Last_Date) ? null : Convert.ToDateTime(objATT.Last_Date).ToString("yyyy-MM-dd"));
                    param[15] = new SqlParameter("@SIP_Amt", objATT.Sip_amt);
                    //param[15] = new SqlParameter("@SIP_Amt", objATT.PAN_No);
                    param[16] = new SqlParameter("@PayeeName", objATT.PayeeName);
                    param[17] = new SqlParameter("@Introducer", objATT.Introducer);
                    param[18] = new SqlParameter("@ISOnline", objATT.Online);
                    param[19] = new SqlParameter("@Entry_By", objATT.ENTRY_BY);
                    param[20] = new SqlParameter("@Entry_Date", objATT.ENTRY_DT);
                    param[21] = new SqlParameter("@App_Status", objATT.APPSTATUS);

                    //param[24] = new SqlParameter("@Approved_Date", objATT.bcode_cheque);
                    param[22] = new SqlParameter("@Remarks", objATT.remarks);
                    param[23] = new SqlParameter("@PaymentCode", objATT.PaymentCode);
                    param[24] = new SqlParameter("@St_BankCode", objATT.St_BankCode);
                    param[25] = new SqlParameter("@St_BankAccountNo", objATT.St_BankAccountNo);
                    param[26] = new SqlParameter("@Terms", string.IsNullOrEmpty(objATT.Terms) ? null : (objATT.Terms).ToString());
                    param[27] = new SqlParameter("@IntroducerRem ", objATT.IntroducerRem);
                    param[28] = new SqlParameter("@PayeeContactNo", objATT.PayeeContactNo);
                    param[29] = new SqlParameter("@IsApproved", objATT.IsApproved);
                    param[30] = new SqlParameter("@FileUpload1", img1);
                    param[31] = new SqlParameter("@FileUpload2", img2);
                    param[32] = new SqlParameter("@l_company_id", objATT.l_company_id);
                    param[33] = new SqlParameter("@SIP_Eff_Date", string.IsNullOrEmpty(objATT.SIP_Eff_Date) ? null : Convert.ToDateTime(objATT.SIP_Eff_Date).ToString("yyyy-MM-dd"));
                    param[34] = new SqlParameter("@Is_Unit_Holder", objATT.Is_Unit_Holder);
                    param[35] = new SqlParameter("@Amdnt_No", Amdnt_No);
                    param[36] = new SqlParameter("@BankCode", objATT.BankCode);
                    param[37] = new SqlParameter("@BranchNo", objATT.BranchNo);
                    param[38] = new SqlParameter("@Bank_Account_No", objATT.Bank_Account_No);
                    if (objATT.checkRptTyp == "02")
                    {
                        param[39] = new SqlParameter("@Action", "02");
                    }
                    else
                    {
                        param[39] = new SqlParameter("@Action", "04");
                    }
                    param[40] = new SqlParameter("@TranType", "02");
                    DAO.executeTranProcedure(spName1, param, transaction, conn);

                    
                    transaction.Commit();
                }


                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Error" + ex.Message);
                }

            }

            return Amdnt_No;
        }

        public List<ATTSIP_Registration> GetSipRegNo(string BOID)
        {
            List<ATTSIP_Registration> lstshdel = new List<ATTSIP_Registration>();
            //string SIP_Reg_No = "";
            //string Name = "";
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@BOID", BOID);

            ds = DAO.gettable("GetSipRegNo", param);

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ATTSIP_Registration objATT = new ATTSIP_Registration();
                    objATT.SIP_Reg_No = dr["Sip_Reg_No"].ToString();
                    objATT.Name = dr["Name"].ToString();
                    lstshdel.Add(objATT);
                }

            }
            return lstshdel;

        }

        public List<ATTSIP_Registration> GetSIPHolderDetail(string scheme_code, string ccode, string SIP_Reg_No, string Action, string l_company_id)
        {
            List<ATTSIP_Registration> lstshdel = new List<ATTSIP_Registration>();
            string spName = "";
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            SqlParameter[] param = new SqlParameter[5];
            try
            {

                param[0] = new SqlParameter("@scheme_code", scheme_code != null ? scheme_code : null);
                param[1] = new SqlParameter("@ccode", ccode != null ? ccode : null);
                param[2] = new SqlParameter("@SIP_Reg_No", SIP_Reg_No != null ? SIP_Reg_No : null);
                param[3] = new SqlParameter("@Action", Action);
                param[4] = new SqlParameter("@l_company_id", l_company_id != null ? l_company_id : null);
                spName = "GetSIPHolderDetail";
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
                        objATT.SIP_DT = Convert.ToDateTime(dr["SIP_Reg_Date"]).ToString("yyyy-MM-dd");
                        objATT.Model_of_Sip = string.IsNullOrEmpty(dr["Model_of_SIP"].ToString()) ? "" : dr["Model_of_SIP"].ToString();
                        objATT.SIP_Last_Date = string.IsNullOrEmpty(dr["SIP_Last_Date"].ToString()) ? "" : Convert.ToDateTime(dr["SIP_Last_Date"]).ToString("yyyy-MM-dd");
                        objATT.Online = string.IsNullOrEmpty(dr["ISOnline"].ToString()) ? "" : dr["ISOnline"].ToString();
                        objATT.Address = string.IsNullOrEmpty(dr["Address"].ToString()) ? "" : dr["Address"].ToString();
                        objATT.Contact1 = string.IsNullOrEmpty(dr["ContactNo1"].ToString()) ? "" : dr["ContactNo1"].ToString();
                        objATT.Contact2 = string.IsNullOrEmpty(dr["ContactNo2"].ToString()) ? "" : dr["ContactNo2"].ToString();
                        objATT.PayeeName = string.IsNullOrEmpty(dr["PayeeName"].ToString()) ? "" : dr["PayeeName"].ToString();
                        objATT.Introducer = string.IsNullOrEmpty(dr["Introducer"].ToString()) ? "" : dr["Introducer"].ToString();
                        objATT.HolderTypeNo = string.IsNullOrEmpty(dr["HolderType_No"].ToString()) ? "" : dr["HolderType_No"].ToString();
                        // objATT.Contact2 = string.IsNullOrEmpty(dr["Contact2"].ToString()) ? "" : dr["Contact2"].ToString();
                        objATT.Sip_amt = float.Parse(dr["SIP_Amt"].ToString());
                        objATT.SIP_Interval = string.IsNullOrEmpty(dr["SIP_Interval"].ToString()) ? "" : dr["SIP_Interval"].ToString();
                        objATT.SIP_Reg_No = string.IsNullOrEmpty(dr["SIP_Reg_No"].ToString()) ? "" : dr["SIP_Reg_No"].ToString();
                        objATT.Terms = string.IsNullOrEmpty(dr["Terms"].ToString()) ? null : (dr["Terms"].ToString());
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
                        objATT.BankCode = string.IsNullOrEmpty(dr["BankCode"].ToString()) ? null : (dr["BankCode"].ToString());
                        objATT.BranchNo = string.IsNullOrEmpty(dr["BranchNo"].ToString()) ? null : (dr["BranchNo"].ToString());
                        objATT.Bank_Account_No = string.IsNullOrEmpty(dr["Bank_Account_No"].ToString()) ? null : (dr["Bank_Account_No"].ToString());
                        objATT.IsApproved = string.IsNullOrEmpty(dr["IsApproved"].ToString()) ? null : (dr["IsApproved"].ToString());
                        objATT.APPSTATUS = string.IsNullOrEmpty(dr["App_Status"].ToString()) ? null : (dr["App_Status"].ToString());


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

    }
}
