using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SI.Utility;
using System.Web;
using System.Data.SqlClient;
using SI.RequestHandling.ATT;
using System.Data;
using SI.KYC.ATT;
using SI.Security.ATT;



namespace SI.RequestHandling.DLL
{
    public class DLLSHolder
    {
        public List<ATTShHolder> GetSHolders(string scheme_code, Int64 Bo_Account_No, string ccode, string l_company_id, string shholder)
        {
            List<ATTShHolder> lstSHolders = new List<ATTShHolder>();
            List<ATTSign> lstsigns = new List<ATTSign>();

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

                spName = "GetSHoldersInfoByBoid";
                ds = DAO.gettable(spName, param);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ATTShHolder objATT = new ATTShHolder();
                        //objATT.Title = dr["Title"].ToString() != "" ? dr["Title"].ToString() : "";
                        objATT.FName = dr["FName"].ToString() != "" ? dr["FName"].ToString() : "";
                        objATT.MName = dr["MName"].ToString() != "" ? dr["MName"].ToString() : "";
                        objATT.LName = dr["LName"].ToString() != "" ? dr["LName"].ToString() : "";
                        objATT.FaName = dr["FaName"].ToString() != "" ? dr["FaName"].ToString() : "";
                        objATT.GFName = dr["GFName"].ToString() != "" ? dr["GFName"].ToString() : "";
                        objATT.Citizenship_No = dr["Citizenship_No"].ToString() != "" ? dr["Citizenship_No"].ToString() : "";
                        objATT.Bo_Account_No = dr["Bo_Account_No"].ToString() != "" ? dr["Bo_Account_No"].ToString() : "";
                        objATT.PAN_No = dr["PAN_No"].ToString() != "" ? dr["PAN_No"].ToString() : "";
                        objATT.Reg_No = dr["Reg_No"].ToString() != "" ? dr["Reg_No"].ToString() : "";
                        objATT.Per_ProvinceName = dr["Per_ProvinceName"].ToString() != "" ? dr["Per_ProvinceName"].ToString() : "";
                        objATT.Per_CountryName = dr["P_ProvinceCode"].ToString() != "" ? dr["Per_CountryName"].ToString() : "";
                        objATT.Per_DistName = dr["Per_DistName"].ToString() != "" ? dr["Per_DistName"].ToString() : "";
                        objATT.P_Mun = dr["P_Mun"].ToString() != "" ? dr["P_Mun"].ToString() : "";
                        objATT.P_Ward_No = dr["P_Ward_No"].ToString() != "" ? dr["P_Ward_No"].ToString() : "";
                        objATT.P_Tole = dr["P_Tole"].ToString() != "" ? dr["P_Tole"].ToString() : "";
                        objATT.P_Tel_No = dr["P_Tel_No"].ToString() != "" ? dr["P_Tel_No"].ToString() : "";
                        objATT.P_Mobile_no = dr["P_Mobile_no"].ToString() != "" ? dr["P_Mobile_no"].ToString() : "";
                        objATT.Bank_Account_No = dr["Bank_Account_No"].ToString() != "" ? dr["Bank_Account_No"].ToString() : "";
                        objATT.BankCode = dr["BankCode"].ToString() != "" ? dr["BankCode"].ToString() : "";
                        //objATT.ccode = dr["ccode"].ToString() != "" ? dr["ccode"].ToString() : "";
                        //objATT.cname = dr["cname"].ToString() != "" ? dr["cname"].ToString() : "";
                        objATT.Branch_code = dr["Branch_code"].ToString() != "" ? dr["Branch_code"].ToString() : "";
                        objATT.IsInstitution = dr["IsInstitution"].ToString() != "" ? dr["IsInstitution"].ToString() : "";
                        objATT.ShHolderNo = int.Parse(dr["ShHolderNo"].ToString());
                        //objATT.Email_ID = dr["Email_ID"].ToString() != "" ? dr["Email_ID"].ToString() : "";
                        objATT.BalUnit = (float.Parse(dr["DBBalUnit"].ToString())) - (float.Parse(dr["CRBalUnit"].ToString()));
                        objATT.Inv_Amt = (double.Parse(dr["DBInv_Amt"].ToString())) - (double.Parse(dr["CRInv_Amt"].ToString()));
                        objATT.Eng_DOB = string.IsNullOrEmpty(dr["Eng_DOB"].ToString()) ? "" : Convert.ToDateTime(dr["Eng_DOB"]).ToString("yyyy-MM-dd");
                        // objATT.HasDrep = dr["HasDrep"].ToString() != "" ? dr["HasDrep"].ToString() : "";
                        objATT.HasDrep = string.IsNullOrEmpty(dr["HasDrep"].ToString()) ? false : bool.Parse(dr["HasDrep"].ToString());
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


        public JsonResponse GetSHolderForDREP(string scheme_code, Int64 Bo_Account_No, string ccode, string l_company_id)
        {
            JsonResponse jsonresponse = new JsonResponse();

            List<ATTShHolder> lstSHolders = new List<ATTShHolder>();
            List<ATTSign> lstsigns = new List<ATTSign>();

            string spName = "";
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[3];
            try
            {
              //  param[0] = new SqlParameter("@Bo_Account_No", Bo_Account_No);
                param[0] = new SqlParameter("@Bo_Account_No", Convert.ToString(Bo_Account_No));
                param[1] = new SqlParameter("@scheme_code", scheme_code != null ? scheme_code : null);
                param[2] = new SqlParameter("@l_company_id", l_company_id != null ? l_company_id : null);

                spName = "GetSHolderForDREP";
                ds = DAO.gettable(spName, param);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        jsonresponse.IsSucess = dr["isSuccess"].ToString() == "" ? false : Convert.ToBoolean(dr["isSuccess"].ToString());
                        jsonresponse.Message = dr["Message"].ToString() == "" ? "Failed" : dr["Message"].ToString();
                        jsonresponse.IsToken = dr["IsToken"].ToString() == "" ? false : Convert.ToBoolean(dr["IsToken"].ToString());
                     
                    }
                }
                else
                {
                    jsonresponse.IsSucess = false;
                    jsonresponse.Message = "Not a Valid User For Drep Request";
                       
                }
                return jsonresponse;

            }

            catch (Exception ex)
            {

                throw ex;
            }
        }


        public List<ATTShHolder> CheckSHolders(string scheme_code, string Bo_Account_No, string l_company_id)
        {
            List<ATTShHolder> lstSHolders = new List<ATTShHolder>();
            List<ATTSign> lstsigns = new List<ATTSign>();

            ATTShHolder jsonresponse = new ATTShHolder();

            string spName = "";
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[3];
            try
            {
                param[0] = new SqlParameter("@Bo_Account_No", Bo_Account_No);
                param[1] = new SqlParameter("@scheme_code", scheme_code != null ? scheme_code : null);
                param[2] = new SqlParameter("@l_company_id", l_company_id != null ? l_company_id : null);
                spName = "GetSHolders";
                ds = DAO.gettable(spName, param);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drow in ds.Tables[0].Rows)
                    {
                        ATTShHolder objATT = new ATTShHolder();
                        objATT.BalUnit = (float.Parse(drow["DBBalUnit"].ToString())) - (float.Parse(drow["CRBalUnit"].ToString()));
                        objATT.Inv_Amt = (float.Parse(drow["DBInv_Amt"].ToString())) - (float.Parse(drow["CRInv_Amt"].ToString()));
                        objATT.IS_UNIT_HOLDER = string.IsNullOrEmpty(drow["IS_UNIT_HOLDER"].ToString()) ? "" : (drow["IS_UNIT_HOLDER"].ToString());
                        objATT.HasDrep = string.IsNullOrEmpty(drow["HasDrep"].ToString()) ? false : bool.Parse(drow["HasDrep"].ToString());
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

        public JsonResponse GetSHoldersforSignUp(string scheme_code, string Bo_Account_No, string ccode, string l_company_id, int shholder)
        {
            List<ATTShHolder> lstSHolders = new List<ATTShHolder>();
            List<ATTSign> lstsigns = new List<ATTSign>();

            JsonResponse jsonresponse = new JsonResponse();

            string spName = "";
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[4];
            try
            {
                param[0] = new SqlParameter("@Bo_Account_No", Bo_Account_No);
                param[1] = new SqlParameter("@scheme_code", scheme_code != null ? scheme_code : null);
                param[2] = new SqlParameter("@ccode", ccode != null ? ccode : null);
                param[3] = new SqlParameter("@l_company_id", l_company_id != null ? l_company_id : null);

                spName = "GetSHoldersforSignUpv2";
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

        public List<ATTShHolder> SearchHoldersByName(string ASearch, string FSearch, string GSearch, string scheme_code)
        {
            List<ATTShHolder> lstSHolders = new List<ATTShHolder>();
            string spName = "";
            DataSet ds = new DataSet();
            string whereCondition = "sh.scheme_code = '" + scheme_code + "'";
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



        public List<ATTShareTransaction> SearchHolders(string ASearch, string FSearch, string GSearch, string scheme_code, string type, string APPSTATUS)
        {
            List<ATTShareTransaction> lstSHolders = new List<ATTShareTransaction>();
            string spName = "";
            DataSet ds = new DataSet();
            string whereCondition = "where scheme_code = '" + scheme_code + "'";

            try
            {

                if (type == "SHolder")
                {
                    if (!(string.IsNullOrEmpty(ASearch)))
                    {
                        whereCondition += " and FNAME like " + "'%" + ASearch + "%'";

                    }
                    if (!(string.IsNullOrEmpty(FSearch)))
                    {
                        whereCondition += " and FaName like " + "'%" + FSearch + "%'";

                    }
                    if (!(string.IsNullOrEmpty(GSearch)))
                    {
                        whereCondition += " and GrFaName like " + "'%" + GSearch + "%'";

                    }
                    if (APPSTATUS == "UNPOSTED")
                    {
                        whereCondition += " and APPSTATUS= '" + APPSTATUS + "'";
                    }
                    SqlParameter[] param = new SqlParameter[1];

                    param[0] = new SqlParameter("@whereCondition", whereCondition);


                    spName = "SearchHolders";
                    ds = DAO.gettable(spName, param);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            ATTShareTransaction objATT = new ATTShareTransaction();
                            objATT.Scheme_code = string.IsNullOrEmpty(dr["scheme_code"].ToString()) ? "" : dr["scheme_code"].ToString();
                            objATT.FaName = string.IsNullOrEmpty(dr["FANAME"].ToString()) ? "" : dr["FANAME"].ToString();
                            objATT.FName = string.IsNullOrEmpty(dr["FNAME"].ToString()) ? "" : dr["FNAME"].ToString();
                            objATT.LName = string.IsNullOrEmpty(dr["LNAME"].ToString()) ? "" : dr["LNAME"].ToString();
                            objATT.ShHolderNo = int.Parse(dr["SHHOLDERNO"].ToString());
                            objATT.address = string.IsNullOrEmpty(dr["address"].ToString()) ? "" : dr["address"].ToString();
                            objATT.P_Tel_No = string.IsNullOrEmpty(dr["TELNO"].ToString()) ? "" : dr["TELNO"].ToString();
                            objATT.REQUEST_NO = string.IsNullOrEmpty(dr["REQUEST_NO"].ToString()) ? 0 : int.Parse(dr["REQUEST_NO"].ToString());
                            objATT.GFName = string.IsNullOrEmpty(dr["GRFANAME"].ToString()) ? "" : dr["GRFANAME"].ToString();
                            objATT.Bo_Account_No = Int64.Parse(dr["boidno"].ToString());

                            lstSHolders.Add(objATT);
                        }
                    }
                }
                return lstSHolders;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<ATTShareTransaction> SearchRedemHolders(string ASearch, string FSearch, string GSearch, string scheme_code, string type, string APPSTATUS)
        {
            List<ATTShareTransaction> lstSHolders = new List<ATTShareTransaction>();
            string spName = "";
            DataSet ds = new DataSet();
            string whereCondition = "where scheme_code = '" + scheme_code + "'";

            try
            {
                if (!(string.IsNullOrEmpty(ASearch)))
                {
                    whereCondition += " and FName like " + "'%" + ASearch + "%'";

                }
                if (!(string.IsNullOrEmpty(FSearch)))
                {
                    whereCondition += " and FaName like " + "'%" + FSearch + "%'";

                }
                if (!(string.IsNullOrEmpty(GSearch)))
                {
                    whereCondition += " and GrFaName like " + "'%" + GSearch + "%'";

                }
                if (APPSTATUS == "UNPOSTED")
                {
                    whereCondition += " and APPSTATUS= '" + APPSTATUS + "'";
                }
                SqlParameter[] param = new SqlParameter[1];

                param[0] = new SqlParameter("@whereCondition", whereCondition);

                spName = "SearchRedemHolders";
                ds = DAO.gettable(spName, param);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ATTShareTransaction objATT = new ATTShareTransaction();
                        objATT.Scheme_code = string.IsNullOrEmpty(dr["scheme_code"].ToString()) ? "" : dr["scheme_code"].ToString();
                        objATT.FaName = string.IsNullOrEmpty(dr["FANAME"].ToString()) ? "" : dr["FANAME"].ToString();
                        objATT.FName = string.IsNullOrEmpty(dr["FNAME"].ToString()) ? "" : dr["FNAME"].ToString();
                        objATT.LName = string.IsNullOrEmpty(dr["LNAME"].ToString()) ? "" : dr["LNAME"].ToString();
                        objATT.ShHolderNo = string.IsNullOrEmpty(dr["SHHOLDERNO"].ToString()) ? (int?)null : int.Parse(dr["SHHOLDERNO"].ToString());
                        objATT.address = string.IsNullOrEmpty(dr["address"].ToString()) ? "" : dr["address"].ToString();
                        objATT.P_Tel_No = string.IsNullOrEmpty(dr["TELNO"].ToString()) ? "" : dr["TELNO"].ToString();
                        objATT.REQUEST_NO = string.IsNullOrEmpty(dr["REQUEST_NO"].ToString()) ? 0 : int.Parse(dr["REQUEST_NO"].ToString());
                        objATT.GFName = string.IsNullOrEmpty(dr["GRFANAME"].ToString()) ? "" : dr["GRFANAME"].ToString();
                        objATT.Bo_Account_No = Int64.Parse(dr["boidno"].ToString());

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


    }
}
