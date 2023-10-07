using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SI.Security.ATT;
using System.Data;
using System.Data.SqlClient;
using SI.Utility;


namespace SI.Security.DLL
{
   public class DLLLogin
    {
       public ATTUser LoginUser(ATTUser objLogin)
        {

            DataSet ds = new DataSet();
            DataSet ds2 = new DataSet();
            bool flag = true;
            try
            {
               // UTF8Encoding encoder = new UTF8Encoding();
               // MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
             // byte[] encodedPassword = md5Hasher.ComputeHash(encoder.GetBytes(objLogin.Password));
                var encodedPassword = EncryptDecrypt.Encrypt_Password(objLogin.Password);

                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@UserName", objLogin.UserName);
                param[1] = new SqlParameter("@Password", encodedPassword);
                param[2] = new SqlParameter("@Email", objLogin.Email);
          //      param[3] = new SqlParameter("@IsEmailVerified", objLogin.IsEmailVerified);

                ds = DAO.gettable("GetLoginWebUser", param);
                if (ds.Tables[0].Rows.Count == 1)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {

                        objLogin.UserName = (dr["UserName"].ToString());
                        objLogin.UserId = int.Parse(dr["UserId"].ToString());
                        objLogin.scheme_code = dr["scheme_code"].ToString();
                        objLogin.Counter = (dr["Counter"].ToString());
                        objLogin.BOID = (dr["BOID"].ToString());
                        objLogin.Email = (dr["Email"].ToString());
                        objLogin.RoleId = int.Parse((dr["RoleId"].ToString()));
                        objLogin.Name = ((dr["Name"].ToString()));
                        objLogin.SHHOLDERNO = ((dr["SHHOLDERNO"].ToString()));
                        objLogin.Contact_No = dr["Contact_No"].ToString();
                        objLogin.Contact_No2 = dr["Contact_No2"].ToString();
                    }
                    
                }
                else
                {
                    flag = false;
                }
                objLogin.LoggedIn = flag;
            }
            catch (Exception)
            {
                //objLogin.LoggedIn = false;
                throw;
            }

            return objLogin;
        }

       public List<ATTParaComp> LoadSchemes(string l_company_id, string ccode)
       {
           List<ATTParaComp> lstSchemes = new List<ATTParaComp>();

           DataSet ds = new DataSet();
           SqlParameter[] param = new SqlParameter[2];
           param[0] = new SqlParameter("@l_company_id", l_company_id);
           param[1] = new SqlParameter("@ccode", ccode);
           ds = DAO.gettable("LoadScheme", param);

           if (ds.Tables[0].Rows.Count > 0)
           {
               foreach (DataRow dr in ds.Tables[0].Rows)
               {
                   ATTParaComp objATT = new ATTParaComp();
                   objATT.scheme_code = dr["scheme_code"].ToString();
                   objATT.SchemeEnName = dr["SchemeEnName"].ToString();
                   objATT.MaxKitta = int.Parse(dr["MaxKitta"].ToString());
                   objATT.Minkitta = int.Parse(dr["Minkitta"].ToString());
                   objATT.PerShVal = float.Parse(dr["PerShVal"].ToString());
                   lstSchemes.Add(objATT);
               }

           }
           return lstSchemes;

       }

       public string GetCurrentDate()
       {
           List<ATTParaComp> lstSchemes = new List<ATTParaComp>();
           string date="";
           DataSet ds = new DataSet();
           DateTime result;
           SqlConnection conn = DAO.getConnection();
           using (conn)
           {
               SqlCommand cmdd = new SqlCommand();
               cmdd.Connection = conn;
               cmdd.CommandText = "select GetDate()";
               cmdd.CommandType = CommandType.Text;
               result = (DateTime)(cmdd.ExecuteScalar());
               
           }
           date = result.ToString("yyyy-MM-dd HH:mm:ss");
           return date;

       }
    }
}
