using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SI.Security.ATT;
using System.Data;
using System.Data.SqlClient;
using SI.Utility;
using System.Net.Mail;
using System.Net.Configuration;
using System.Configuration;
using System.Net;
namespace SI.Security.DLL
{
    public class DLLUser
    {
        public List<ATTUser> SearchWebLoginUser(string scheme_code, Int64 Bo_Account_No, string ccode, string l_company_id, string shholder)
        {
            List<ATTUser> lstusers = new List<ATTUser>();
            string spName = "";
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[5];
            try
            {
                param[0] = new SqlParameter("@Bo_Account_No", Bo_Account_No);
                param[1] = new SqlParameter("@scheme_code", scheme_code != null ? scheme_code : null);
                param[2] = new SqlParameter("@ccode", ccode != null ? ccode : null);
                param[3] = new SqlParameter("@l_company_id", l_company_id != null ? l_company_id : null);
                param[4] = new SqlParameter("@SHHOLDERNO", shholder != null ? shholder : null);

                spName = "SearchWebLoginUser";
                ds = DAO.gettable(spName, param);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ATTUser objATT = new ATTUser();
                        objATT.UserId = int.Parse(dr["UserId"].ToString());
                        objATT.BOID = dr["BOID"].ToString();
                        objATT.UserName = dr["UserName"].ToString();
                        lstusers.Add(objATT);

                    }
                }
                return lstusers;

            }

            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<ATTUser> GetWebHolderDetail(string scheme_code, string Bo_Account_No, string UserName, int ShHolderNo)
        {
            List<ATTUser> lstusers = new List<ATTUser>();
            string spName = "";
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[4];
            try
            {
                param[0] = new SqlParameter("@scheme_code", scheme_code);
                param[1] = new SqlParameter("@Bo_Account_No", Bo_Account_No);
                param[2] = new SqlParameter("@UserName", UserName);
                param[3] = new SqlParameter("@ShHolderNo", ShHolderNo);

                spName = "GetWebHolderDetail";
                ds = DAO.gettable(spName, param);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ATTUser objATT = new ATTUser();

                        objATT.BOID = dr["BOID"].ToString();
                        objATT.UserName = dr["UserName"].ToString();
                        objATT.Name = dr["Name"].ToString();
                        objATT.Email = string.IsNullOrEmpty(dr["Email"].ToString()) ? "N/A" : (dr["Email"].ToString()); //dr["Email"].ToString();
                        objATT.DP_NAME = dr["DP_NAME"].ToString();
                        objATT.ActiveStatus = dr["ActiveStatus"].ToString();
                        objATT.Gender = dr["Gender"].ToString();
                        objATT.DOB = Convert.ToDateTime(dr["DOB"]).ToString("yyyy-MM-dd");
                        objATT.Citizenship_No = string.IsNullOrEmpty(dr["Citizenship_No"].ToString()) ? "N/A" : (dr["Citizenship_No"].ToString());// dr["Citizenship_No"].ToString();
                        objATT.PAN_No = string.IsNullOrEmpty(dr["PAN_No"].ToString()) ? "N/A" : (dr["PAN_No"].ToString());
                        objATT.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]).ToString("yyyy-MM-dd");
                        objATT.Contact_No = dr["Contact_No"].ToString();
                        objATT.UserName = dr["UserName"].ToString();
                        objATT.bankname = dr["bankname"].ToString();
                        objATT.Bank_Account_No = dr["Bank_Account_No"].ToString();
                        lstusers.Add(objATT);

                    }
                }
                return lstusers;

            }

            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string SaveWebUser(ATTUser objATT)
        {

            string spName = "dbo.SaveWebUser";
            string msg = "No Data To Save";
            SqlTransaction transaction;
            msg = "Successfully Saved!!!";
            SqlConnection conn = DAO.getConnection();
            using (conn)
            {
                transaction = conn.BeginTransaction();
                try
                {
                    if (objATT.UserId == 0)
                    {
                        #region To Get MAX ID

                        SqlCommand cmdd = new SqlCommand();
                        cmdd.Connection = conn;
                        cmdd.Transaction = transaction;
                        cmdd.CommandText = "GetMaxWebUserId";
                        cmdd.CommandType = CommandType.StoredProcedure;

                        SqlParameter para1 = new SqlParameter();
                        para1.ParameterName = "@MID";
                        para1.Value = objATT.UserId;
                        para1.SqlDbType = SqlDbType.Int;
                        para1.Size = 100;
                        para1.Direction = ParameterDirection.InputOutput;
                        cmdd.Parameters.Add(para1);

                        cmdd.ExecuteNonQuery();

                        if (cmdd.Parameters["@MID"].Value.ToString() == "") { cmdd.Parameters["@MID"].Value = 0; }
                        objATT.UserId = int.Parse(cmdd.Parameters["@MID"].Value.ToString()) + 1;
                    }
                        #endregion
                    if (spName != "")
                    {
                        // UTF8Encoding encoder = new UTF8Encoding();
                        // MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
                        // var encodedPassword = md5Hasher.ComputeHash(encoder.GetBytes(objATT.Password));
                        byte[] img1;
                        byte[] img2;
                        if (objATT.UploadFile != null)
                        {
                            img1 = image2byteConverter.dataURL2byte(objATT.UploadFile);
                        }
                        else img1 = null;

                        if (objATT.Signature1 != null)
                        {
                            img2 = image2byteConverter.dataURL2byte(objATT.Signature1);
                        }
                        else img2 = null;
                        var encodedPassword = EncryptDecrypt.Encrypt_Password(objATT.Password);
                        SqlParameter[] param = new SqlParameter[20];
                        param[0] = new SqlParameter("@UserName", objATT.UserName);
                        param[1] = new SqlParameter("@Password", encodedPassword);
                        param[2] = new SqlParameter("@UserId", objATT.UserId);
                        param[3] = new SqlParameter("@Name", objATT.Name);
                        param[4] = new SqlParameter("@FileUpload1", img1);
                        param[5] = new SqlParameter("@FileUpload2", img2);
                        param[6] = new SqlParameter("@scheme_code", objATT.scheme_code);
                        param[7] = new SqlParameter("@l_company_id", (objATT.l_company_id));
                        param[8] = new SqlParameter("@BOID", (objATT.BOID));
                        param[9] = new SqlParameter("@DOB", (objATT.DOB));
                        param[10] = new SqlParameter("@Email", (objATT.Email));
                        param[11] = new SqlParameter("@Contact_No", (objATT.Contact_No));
                        param[12] = new SqlParameter("@IS_UNIT_HOLDER", (objATT.IS_UNIT_HOLDER));
                        param[13] = new SqlParameter("@Gender", (objATT.Gender));
                        param[14] = new SqlParameter("@SHHOLDERNO", (objATT.SHHOLDERNO));
                        param[15] = new SqlParameter("@Origin", (objATT.Origin));
                        param[16] = new SqlParameter("@Contact_No2", objATT.Contact_No2);
                        param[17] = new SqlParameter("@CitizenshipNo", objATT.Citizenship_No);
                        param[18] = new SqlParameter("@FileName2", objATT.SignName);
                        param[19] = new SqlParameter("@FileName1", objATT.FileName);
                        DAO.executeTranProcedure(spName, param, transaction, conn);
                        transaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Error" + ex.Message);
                }
            }

            return msg;
        }


        public int GetDetail(string scheme_code, string Bo_Account_No, string ShHolderNo)
        {

            string spName = "";
            int sipcount = 0;
            List<ATTUser> lstUser = new List<ATTUser>();

            try
            {
                DataSet ds = new DataSet();
                spName = "GetDetail";
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@scheme_code", scheme_code);
                param[1] = new SqlParameter("@Bo_Account_No", Bo_Account_No);
                param[2] = new SqlParameter("@ShHolderNo", ShHolderNo);
                ds = DAO.gettable(spName, param);
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    sipcount = int.Parse(drow["sipcount"].ToString());


                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error" + ex.Message);
            }

            return sipcount;
        }

        public List<ATTUser> validateEmailaddress(string Email)
        {

            string spName = "";
            List<ATTUser> lstUser = new List<ATTUser>();

            try
            {
                DataSet ds = new DataSet();


                spName = "validateEmailaddress";
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Email", Email);
                ds = DAO.gettable(spName, param);
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    ATTUser objUser = new ATTUser();
                    objUser.Email = drow["Email"].ToString();
                    objUser.UserName = drow["username"].ToString();
                    lstUser.Add(objUser);
                }


            }
            catch (Exception ex)
            {
                throw new Exception("Error" + ex.Message);
            }

            return lstUser;
        }
        public List<ATTUser> validateUserName(string UserName)
        {

            string spName = "";
            List<ATTUser> lstUser = new List<ATTUser>();

            try
            {
                DataSet ds = new DataSet();


                spName = "validateUserName";
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@UserName", UserName);
                ds = DAO.gettable(spName, param);
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    ATTUser objUser = new ATTUser();
                    objUser.UserName = drow["UserName"].ToString();
                    lstUser.Add(objUser);
                }


            }
            catch (Exception ex)
            {
                throw new Exception("Error" + ex.Message);
            }

            return lstUser;
        }
        public string SaveEventLog(ATTUser objATT)
        {

            string spName = "InsertEventLog";
            string msg = "";
            SqlTransaction transaction;

            msg = "Successfully Saved !!!";
            SqlConnection conn = DAO.getConnection();

            using (conn)
            {
                transaction = conn.BeginTransaction();



                try
                {
                    // to insert user
                    //if (objATT.TimeDate == null)
                    //{
                    //    objATT.TimeDate = DateTime.Now.ToString();
                    //}
                    //SqlParameter[] param = new SqlParameter[5];
                    //param[0] = new SqlParameter("@Username", objATT.Username);
                    //param[1] = new SqlParameter("@TimeDate", objATT.TimeDate);
                    //param[2] = new SqlParameter("@IPAddress", objATT.IPAddress);
                    //param[3] = new SqlParameter("@FormName", objATT.FormName);
                    //param[4] = new SqlParameter("@EventRemarks", objATT.EventRemarks);

                    //DAO.executeTranProcedure(spName, param, transaction, conn);
                    //transaction.Commit();

                }


                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Error" + ex.Message);
                }
            }
            return msg;
        }
        public bool CheckWebUserValidity(int UserId)
        {
            SqlConnection conn = DAO.getConnection();
            SqlTransaction transaction;
            using (conn)
            {
                transaction = conn.BeginTransaction();
                SqlCommand cmdd = new SqlCommand();
                cmdd.Connection = conn;
                cmdd.Transaction = transaction;
                cmdd.CommandText = "CheckWebUserValidity";
                cmdd.CommandType = CommandType.StoredProcedure;

                SqlParameter para1 = new SqlParameter();
                para1.ParameterName = "@Flag";
                para1.Value = 0;
                para1.SqlDbType = SqlDbType.Int;
                para1.Size = 100;
                para1.Direction = ParameterDirection.Output;
                cmdd.Parameters.Add(para1);
                cmdd.Parameters.AddWithValue("@UserId", UserId);
                cmdd.ExecuteNonQuery();

                int flag = int.Parse(cmdd.Parameters["@Flag"].Value.ToString());
                if (flag == 1)
                {  // means the date is valid 
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }




        public List<ATTUser> CheckUser(string UserName, string Password)
        {
            List<ATTUser> lstUser = new List<ATTUser>();
            try
            {
                DataSet ds = new DataSet();
                var encodedPassword = EncryptDecrypt.Encrypt_Password(Password);
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@UserName", UserName);
                param[1] = new SqlParameter("@Password", encodedPassword);
                param[2] = new SqlParameter("@Email", UserName);


                ds = DAO.gettable("GetLoginWebUser", param);
                if (ds.Tables[0].Rows.Count == 1)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ATTUser objLogin = new ATTUser();
                        objLogin.UserName = dr["UserName"].ToString();
                        objLogin.UserId = int.Parse(dr["UserId"].ToString());
                        objLogin.scheme_code = dr["scheme_code"].ToString();
                        objLogin.Counter = (dr["Counter"].ToString());
                        objLogin.BOID = (dr["BOID"].ToString());
                        objLogin.Email = (dr["Email"].ToString());
                        objLogin.RoleId = int.Parse((dr["RoleId"].ToString()));
                        //objLogin.ValidDate = dr["ValidDate"].ToString();


                    }
                }


            }
            catch (Exception ex)
            {
                throw new Exception("Error" + ex.Message);
            }

            return lstUser;
        }
        public string CheckAndChangePass(string UserName, string OldPass, string NewPass)
        {
            string msg = "Password Successfully Changed !!!";
            string spName = "UpdateWebUserPassword";
            ATTUser objATT = new ATTUser();
            SqlTransaction transaction;


            SqlConnection conn = DAO.getConnection();
            DataSet ds = new DataSet();
            // to insert user
            UTF8Encoding encoder = new UTF8Encoding();
            var encodedPassword = EncryptDecrypt.Encrypt_Password(OldPass);
            using (conn)
            {
                transaction = conn.BeginTransaction();
                try
                {
                    SqlParameter[] param = new SqlParameter[3];
                    param[0] = new SqlParameter("@UserName", UserName);
                    param[1] = new SqlParameter("@Password", encodedPassword);
                    param[2] = new SqlParameter("@Email", null);
                    ds = DAO.gettable("GetLoginWebUser", param);
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                        {
                            int UserId = int.Parse(drow["UserId"].ToString());
                            var encodedPasswordNew = EncryptDecrypt.Encrypt_Password(NewPass);
                            SqlParameter[] param2 = new SqlParameter[4];
                            param2[0] = new SqlParameter("@Username", UserName);
                            param2[1] = new SqlParameter("@Password", encodedPasswordNew);
                            param2[2] = new SqlParameter("@UserId", UserId);
                            param2[3] = new SqlParameter("@Action", 'A');
                            DAO.executeTranProcedure(spName, param2, transaction, conn);

                            SqlParameter[] param3 = new SqlParameter[2];
                            param3[0] = new SqlParameter("@Username", UserName);
                            param3[1] = new SqlParameter("@UserId", UserId);
                            DAO.executeTranProcedure("InsertWebUserLog", param3, transaction, conn);

                            transaction.Commit();
                            msg = " Password Changed Succesfully!!! ";
                        }
                    }
                    else
                    {
                        msg = "Old Password Doesn't Match !!! ";
                    }

                }

                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Error" + ex.Message);
                }
            }
            return msg;

        }
        public string UpdatePassword(string UserName, string Password, string Email, int UserId)
        {
            string msg = "Password Successfully Changed !!!";
            string spName = "UpdateWebUserPassword";
            ATTUser objATT = new ATTUser();
            SqlTransaction transaction;


            SqlConnection conn = DAO.getConnection();
            DataSet ds = new DataSet();
            // to insert user
            UTF8Encoding encoder = new UTF8Encoding();
            var encodedPassword = EncryptDecrypt.Encrypt_Password(Password);
            using (conn)
            {
                transaction = conn.BeginTransaction();
                try
                {


                    SqlParameter[] param2 = new SqlParameter[4];
                    param2[0] = new SqlParameter("@Username", UserName);
                    param2[1] = new SqlParameter("@Password", encodedPassword);
                    param2[2] = new SqlParameter("@UserId", UserId);
                    param2[3] = new SqlParameter("@Action", 'U');
                    DAO.executeTranProcedure(spName, param2, transaction, conn);
                    transaction.Commit();
                    msg = " Password Changed Succesfully!!! ";


                }

                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Error" + ex.Message);
                }
            }
            return msg;

        }

        public JsonResponse GetUsername(string Email, string BOID)
        {
            string spName = "";
            ATTUser attUser = new ATTUser();
            JsonResponse jsonresponse = new JsonResponse();
            try
            {
                DataSet ds = new DataSet();


                spName = "GetUsername";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Email", Email);
                param[1] = new SqlParameter("@BOID", BOID);
                ds = DAO.gettable(spName, param);
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    attUser.UserName = drow["UserName"].ToString();

                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error" + ex.Message);
            }
            if (attUser != null)
            {
                jsonresponse.Message = attUser.UserName;
            }

            return jsonresponse;
        }

        public List<ATTUser> CheckOldPassword(string Password)
        {
            List<ATTUser> lstUser = new List<ATTUser>();
            try
            {
                DataSet ds = new DataSet();
                var encodedPassword = EncryptDecrypt.Encrypt_Password(Password);
                SqlParameter[] param = new SqlParameter[1];

                param[0] = new SqlParameter("@Password", encodedPassword);



                ds = DAO.gettable("CheckOldPassword", param);
                if (ds.Tables[0].Rows.Count == 1)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ATTUser objLogin = new ATTUser();
                        objLogin.UserName = dr["UserName"].ToString();
                        objLogin.UserId = int.Parse(dr["UserId"].ToString());
                        objLogin.scheme_code = dr["scheme_code"].ToString();
                        objLogin.Counter = (dr["Counter"].ToString());
                        objLogin.BOID = (dr["BOID"].ToString());
                        objLogin.Email = (dr["Email"].ToString());
                        objLogin.RoleId = int.Parse((dr["RoleId"].ToString()));
                        //objLogin.ValidDate = dr["ValidDate"].ToString();
                        lstUser.Add(objLogin);

                    }
                }


            }
            catch (Exception ex)
            {
                throw new Exception("Error" + ex.Message);
            }

            return lstUser;
        }

        public string CheckAndChangeOldPass(string UserName, string OldPass, string NewPass)
        {
            string msg = "Password Successfully Changed !!!";
            //string spName = "UpdateWebUserPassword";
            string spName = "UpdateWebUserOldPassword";
            ATTUser objATT = new ATTUser();
            SqlTransaction transaction;


            SqlConnection conn = DAO.getConnection();
            DataSet ds = new DataSet();
            // to insert user
            UTF8Encoding encoder = new UTF8Encoding();
            var encodedPassword = EncryptDecrypt.Encrypt_Password(OldPass);
            using (conn)
            {
                transaction = conn.BeginTransaction();
                try
                {
                    SqlParameter[] param = new SqlParameter[3];
                    // param[0] = new SqlParameter("@UserName", UserName);
                    param[0] = new SqlParameter("@Name", UserName);
                    param[1] = new SqlParameter("@Password", encodedPassword);
                    param[2] = new SqlParameter("@Email", null);
                    //ds = DAO.gettable("GetLoginWebUser", param);
                    ds = DAO.gettable("GetLoginOldPassData", param);
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                        {
                            int UserId = int.Parse(drow["UserId"].ToString());
                            var encodedPasswordNew = EncryptDecrypt.Encrypt_Password(NewPass);
                            SqlParameter[] param2 = new SqlParameter[4];
                            param2[0] = new SqlParameter("@Name", UserName);
                            param2[1] = new SqlParameter("@Password", encodedPasswordNew);
                            param2[2] = new SqlParameter("@UserId", UserId);
                            param2[3] = new SqlParameter("@Action", 'A');
                            DAO.executeTranProcedure(spName, param2, transaction, conn);
                            transaction.Commit();
                            msg = " Password Changed Succesfully!!! ";
                        }
                    }
                    else
                    {
                        msg = "Old Password Doesn't Match !!! ";
                    }

                }

                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Error" + ex.Message);
                }
            }
            return msg;

        }
        public JsonResponse Changepassword(string UserName, string NewPass, int UserId, string BOID, string Email)
        {
            JsonResponse jsonresponse = new JsonResponse();
            string msg = String.Empty;
            string spName = "Changepassword";
            ATTUser objATT = new ATTUser();
            SqlTransaction transaction;


            SqlConnection conn = DAO.getConnection();
            DataSet ds = new DataSet();
            // to insert user
            UTF8Encoding encoder = new UTF8Encoding();
            var encodedPassword = EncryptDecrypt.Encrypt_Password(NewPass);
            using (conn)
            {
                try
                {
                    SqlParameter[] param = new SqlParameter[6];
                    param[0] = new SqlParameter("@Name", UserName);
                    param[1] = new SqlParameter("@Password", encodedPassword);
                    param[2] = new SqlParameter("@Action", 'A');
                    param[3] = new SqlParameter("@UserId", UserId);
                    param[4] = new SqlParameter("@BOID", BOID);
                    param[5] = new SqlParameter("@Email", Email);
                    ds = DAO.gettable(spName, param);

                    if (ds.Tables[0].Rows.Count >= 1)
                    {
                        foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                        {
                            jsonresponse.IsSucess = drow["isSuccess"].ToString() == "" ? false : Convert.ToBoolean(drow["isSuccess"].ToString());
                            jsonresponse.Message = drow["Message"].ToString() == "" ? "Failed" : drow["Message"].ToString();

                        }

                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error" + ex.Message);
                }
            }
            return jsonresponse;

        }


        public string UpdateWebUser(ATTUser objATT)
        {
            string alert = "";

            SqlConnection con = DAO.getConnection();
            using (con)
            {
                SqlTransaction tran;
                tran = con.BeginTransaction();

                try
                {
                    SqlCommand cmd;
                    cmd = new SqlCommand("UpdateWebUserProfile", con, tran);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = objATT.Name;
                    cmd.Parameters.Add("@DOB", SqlDbType.DateTime).Value = objATT.DOB;
                    cmd.Parameters.Add("@Contact_No", SqlDbType.NVarChar, 12).Value = objATT.Contact_No;
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = objATT.Email;
                    cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = objATT.UserId;
                    cmd.ExecuteNonQuery();
                    tran.Commit();



                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw new Exception("Error" + ex.Message);
                }
            }
            return alert;

        }
        public JsonResponse CheckUserCredentials(string BOID, int SHHOLDERNO, int UserId, string Email)
        {
            JsonResponse jsonresponse = new JsonResponse();
            bool IsSucess;
            string spName = "";
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[4];
            try
            {
                param[0] = new SqlParameter("@BOID", BOID);
                param[1] = new SqlParameter("@SHHOLDERNO", SHHOLDERNO);
                param[2] = new SqlParameter("@UserId", UserId);
                param[3] = new SqlParameter("@Email", Email);
                spName = "CheckUserCredentials";
                ds = DAO.gettable(spName, param);

                jsonresponse.IsSucess = false;

                if (ds.Tables[0].Rows.Count > 0)
                {


                    foreach (DataRow drow in ds.Tables[0].Rows)
                    {
                        jsonresponse.IsSucess = drow["isSuccess"].ToString() == "" ? false : Convert.ToBoolean(drow["isSuccess"].ToString());
                       
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
        public JsonResponse ForgetTransactionPin(ATTTransactionPin objATT)
        {
            string spName = "";
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[6];
            SqlTransaction transaction;
            SqlConnection conn = DAO.getConnection();
            JsonResponse jsonresponse = new JsonResponse();
           
            using (conn)
            {
                transaction = conn.BeginTransaction();

                try
                {
                   
                    jsonresponse = CheckUserCredentials(objATT.BOID.ToString(), int.Parse(objATT.SHHOLDERNO),int.Parse(objATT.UserId),objATT.Email);
                    if (jsonresponse.IsSucess == true)
                    {
                        Random rnd = new Random();
                        int randomPIN = rnd.Next(10000000, 99999999);

                        param[0] = new SqlParameter("@BOID", objATT.BOID);
                        param[1] = new SqlParameter("@PIN", objATT.NewPin);
                        param[2] = new SqlParameter("@SHHOLDERNO", objATT.SHHOLDERNO);
                        param[3] = new SqlParameter("@UserID", objATT.UserId);
                        param[4] = new SqlParameter("@Action", objATT.Action);
                        param[5] = new SqlParameter("@OTP", randomPIN);
                        spName = "ForgetTransactionPin";
                        DAO.executeTranProcedure(spName, param, transaction, conn);


                        SmtpClient smtpClient = new SmtpClient();
                        string msg = string.Empty;
                        try
                        {


                            using (System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage(CredentialManager.EmailUserName, objATT.Email))
                            {
                                mail.To.Add(CredentialManager.EmailUserName);


                                mail.From = new MailAddress(CredentialManager.EmailUserName);//***Company Email Adrress ***

                                mail.Subject = " Your Account Transaction OTP";
                                mail.IsBodyHtml = true;
                                string htmlBody;
                                htmlBody = "Your Transaction OTP is :" + randomPIN;
                                mail.Body = htmlBody;
                                SmtpClient smtp = new SmtpClient();
                                smtp.Host = CredentialManager.EmailHost;
                                smtp.EnableSsl = CredentialManager.EmailEnableSSL;
                                NetworkCredential networkCred = new NetworkCredential(CredentialManager.EmailUserName, CredentialManager.EmailPassword);
                                smtp.UseDefaultCredentials = CredentialManager.EmailDefaultCredential;
                                smtp.Credentials = networkCred;
                                smtp.Port = CredentialManager.EmailPort;
                                smtp.Send(mail);
                                jsonresponse.Message = "Please Verify Your OTP Through Email";
                            }
                        }
                        catch (Exception ex)
                        {
                            jsonresponse.Message = ex.Message;
                            transaction.Rollback();
                        }
                        transaction.Commit();
                    }
                    else
                    {
                        jsonresponse.Message = "Invalid Credential";
                        jsonresponse.IsSucess = false;
                    }
                }

                catch (Exception ex)
                {
                    transaction.Rollback();
                    jsonresponse.Message = ex.Message;
                }
                return jsonresponse;
            }
        }

        public JsonResponse SendMailForOTP(string Email, string ContactNumber)
        {
            JsonResponse response = new JsonResponse();
             JsonResponse otpresponse = new JsonResponse();
            string spName = "";
            MailMessage message = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();

            string msg = string.Empty;
            var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz";
            var Charsarr = new char[6];
            var random = new Random();

            for (int i = 0; i < Charsarr.Length; i++)
            {
                Charsarr[i] = characters[random.Next(characters.Length)];
            }

            var OTP = new String(Charsarr);

            try
            {
                DataSet ds = new DataSet();


                spName = "SaveOtpDetails";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Email", Email);
                param[1] = new SqlParameter("@OTP", OTP);

                ds = DAO.gettable(spName, param);

                using (System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage(CredentialManager.EmailUserName, Email))
                {
                    mail.To.Add(CredentialManager.EmailUserName);
                    mail.Subject = " Your One Time Password ";
                    mail.IsBodyHtml = true;
                    string htmlBody;
                    mail.Body = "<div class= container>";
                    mail.Body += "<p>Dear Sir/Madam,</p>";
                    mail.Body += "<p>ATTN : Please do not reply to this email.This mailbox is not monitored and you will not receive a response.</p>";
                    mail.Body += "<h4>Your OTP is " + OTP + " .</h4>";
                    mail.Body += "<br/>";
                    //mail.Body += EmailMsg;
                    mail.Body += "<p>" + ConfigurationManager.AppSettings["EmailKey1"] + "</p>";
                    mail.Body += "<p>" + ConfigurationManager.AppSettings["EmailKey2"] + "</p>";
                    mail.Body += "<p>" + ConfigurationManager.AppSettings["EmailKey3"] + "</p>";
                    mail.Body += "<p>" + ConfigurationManager.AppSettings["EmailKey4"] + "</p>";
                    mail.Body += "<p>" + ConfigurationManager.AppSettings["EmailKey5"] + "</p>";
                    mail.Body += "<p>" + ConfigurationManager.AppSettings["EmailKey6"] + "<br/></p>";
                    mail.Body += "<p>" + ConfigurationManager.AppSettings["EmailKey7"] + "</p>";
                    mail.Body += "<p>" + ConfigurationManager.AppSettings["EmailKey8"] + "</p>";
                    mail.Body += "</div>";
                    //htmlBody = "Your OTP is " + otp;
                    //mail.Body = htmlBody;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = CredentialManager.EmailHost;
                    smtp.EnableSsl = CredentialManager.EmailEnableSSL;
                    NetworkCredential networkCred = new NetworkCredential(CredentialManager.EmailUserName, CredentialManager.EmailPassword);
                    smtp.UseDefaultCredentials = CredentialManager.EmailDefaultCredential;
                    smtp.Credentials = networkCred;
                    smtp.Port = CredentialManager.EmailPort;
                    smtp.Send(mail);

                    DLLSMS objDll = new DLLSMS();
                    otpresponse = objDll.SENDSMS(ContactNumber, OTP);
                    
                    msg = "Successful";
                    response.Message = msg;
                    response.IsSucess = true;
                }


            }
            catch (Exception ex)
            {
                throw new Exception("Error" + ex.Message);

            }

            return response;
        }

      

            

        public JsonResponse CHECKOTP(string Email, string OTP)
        {

            string spName = "";
            JsonResponse jsonResponse = new JsonResponse();

            try
            {
                DataSet ds = new DataSet();


                spName = "CHECKOTP";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Email", Email);
                param[1] = new SqlParameter("@OTP", OTP);

                ds = DAO.gettable(spName, param);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        jsonResponse.IsSucess = Convert.ToBoolean(dr["IsSucess"]);
                        if (Convert.ToBoolean(dr["IsSucess"].ToString()) == false) throw new Exception("You have entered wrong OTP or the OTP time has expired. PLease Re-Generate the OTP and verify the OTP.");
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
        public JsonResponse VALIDATEOTP(string Email, string OTP)
        {

            string spName = "";
            JsonResponse jsonResponse = new JsonResponse();

            try
            {
                DataSet ds = new DataSet();


                spName = "VALIDATEOTP";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Email", Email);
                param[1] = new SqlParameter("@OTP", OTP);

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
        public JsonResponse VALIDATEOTPANDPIN(string Email, string OTP, string Pin)
        {

            string spName = "";
            JsonResponse jsonResponse = new JsonResponse();

            try
            {
                DataSet ds = new DataSet();


                spName = "VALIDATEOTPANDPIN";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Email", Email);
                param[1] = new SqlParameter("@OTP", OTP);

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

        public string SubmitPinVerification(ATTTransactionPin objATT)
        {
            string spName = "";
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[4];
            SqlTransaction transaction;
            SqlConnection conn = DAO.getConnection();
            String message = "";
            using (conn)
            {
                transaction = conn.BeginTransaction();
                try
                {
                    param[0] = new SqlParameter("@BOID", objATT.BOID);
                    param[1] = new SqlParameter("@SHHOLDERNO", objATT.SHHOLDERNO);
                    param[2] = new SqlParameter("@UserID", objATT.UserId);
                    param[3] = new SqlParameter("@Action", null);

                    spName = "GetTransactionPinDetails";

                    ds = DAO.gettable(spName, param);
                    message = "false";
                    if (ds.Tables[0].Rows.Count >= 1)
                    {
                        foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                        {

                            if (drow["OTP"].ToString() == objATT.EmailOTP)
                            {
                                param = new SqlParameter[5];
                                param[0] = new SqlParameter("@BOID", objATT.BOID);
                                param[1] = new SqlParameter("@SHHOLDERNO", objATT.SHHOLDERNO);
                                param[2] = new SqlParameter("@UserID", objATT.UserId);
                                param[3] = new SqlParameter("@Action", objATT.Action);
                                param[4] = new SqlParameter("@OTP", objATT.EmailOTP);
                                spName = "ForgetTransactionPin";
                                DAO.executeTranProcedure(spName, param, transaction, conn);
                                message = "true";
                                transaction.Commit();
                            }

                        }

                    }


                }
                catch (Exception ex)
                {
                    message = "false";
                    transaction.Rollback();
                    throw ex;

                }
            }
            return message;
        }


        public string ChangeTransactionPin(ATTTransactionPin objATT)
        {
            string spName = "";
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[3];
            SqlTransaction transaction;
            SqlConnection conn = DAO.getConnection();
            String message = "";
            using (conn)
            {
                transaction = conn.BeginTransaction();
                try
                {
                    param[0] = new SqlParameter("@BOID", objATT.BOID);
                    param[1] = new SqlParameter("@SHHOLDERNO", objATT.SHHOLDERNO);
                    param[2] = new SqlParameter("@UserID", objATT.UserId);

                    spName = "GetOldTransactionPin";

                    ds = DAO.gettable(spName, param);
                    message = "false";
                    if (ds.Tables[0].Rows.Count >= 1)
                    {
                        foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                        {

                            if (drow["TransactionPin"].ToString() == objATT.OldPin)
                            {
                                param = new SqlParameter[4];
                                param[0] = new SqlParameter("@BOID", objATT.BOID);
                                param[1] = new SqlParameter("@SHHOLDERNO", objATT.SHHOLDERNO);
                                param[2] = new SqlParameter("@UserID", objATT.UserId);
                                param[3] = new SqlParameter("@NewPin", objATT.NewPin);
                                spName = "ChangeOldTransactionPin";
                                DAO.executeTranProcedure(spName, param, transaction, conn);
                                message = "true";

                                SmtpClient smtpClient = new SmtpClient();
                                string msg = string.Empty;

                                try
                                {

                                    using (System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage(CredentialManager.EmailUserName, objATT.Email))
                                    {
                                        mail.To.Add(CredentialManager.EmailUserName); //***Company Email Adrress ***
                                        mail.To.Add(objATT.Email);
                                        mail.Subject = "Transaction PIN";
                                        mail.IsBodyHtml = true;
                                        string htmlBody;
                                        htmlBody = "Your Transaction PIN Has Been Successfully Changed";
                                        mail.Body = htmlBody;
                                        SmtpClient smtp = new SmtpClient();
                                        smtp.Host = CredentialManager.EmailHost;
                                        smtp.EnableSsl = CredentialManager.EmailEnableSSL;
                                        NetworkCredential networkCred = new NetworkCredential(CredentialManager.EmailUserName, CredentialManager.EmailPassword);
                                        smtp.UseDefaultCredentials = CredentialManager.EmailDefaultCredential;
                                        smtp.Credentials = networkCred;
                                        smtp.Port = CredentialManager.EmailPort;
                                        smtp.Send(mail);
                                    }

                                }
                                catch (Exception ex)
                                {
                                    message = ex.Message;
                                    transaction.Rollback();
                                }
                                transaction.Commit();

                            }

                        }

                    }


                }
                catch (Exception ex)
                {
                    message = "false";
                    transaction.Rollback();
                    throw ex;

                }
            }
            return message;
        }



















        public string ContactNumber { get; set; }
    }
}
