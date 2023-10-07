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
    public class DLLRegCompany
    {
        public List<ATTRegCompany> GetDistrict(string ProvinceCode)
        {
            List<ATTRegCompany> lstCCenter = new List<ATTRegCompany>();

            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ProvinceCode", ProvinceCode != null ? ProvinceCode : null);
            ds = DAO.gettable("GetDistrict", param);

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ATTRegCompany objATT = new ATTRegCompany();
                    objATT.DistCode = dr["DistCode"].ToString();
                    objATT.NpDistName = dr["NpDistName"].ToString();
                    objATT.dname = dr["EnDistName"].ToString();
                    objATT.ProvinceCode = dr["ProvinceCode"].ToString();
                    objATT.CID = int.Parse(dr["CID"].ToString());
                    lstCCenter.Add(objATT);
                }

            }
            return lstCCenter;

        }

        public List<ATTRegCompany> GetState()
        {
            List<ATTRegCompany> lstState = new List<ATTRegCompany>();

            DataSet ds = new DataSet();
            ds = DAO.gettable("GetState", null);

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ATTRegCompany objATT = new ATTRegCompany();
                    objATT.CID = int.Parse(dr["CID"].ToString());
                    objATT.ProvinceCode = dr["ProvinceCode"].ToString();
                    objATT.Sname = dr["ProvinceName"].ToString();
                    lstState.Add(objATT);
                }

            }
            return lstState;

        }

        public int? SaveCompRegistration(ATTRegCompany objATT)
        {

            string spName1 = "";
            string spName2 = "";
            string spName3 = "";
            string msg = "No Data To Save !!!";
            int? SubmissionNo = 0;
            SqlTransaction transaction;

            msg = "Successfully Saved !!!";
            SqlConnection conn = DAO.getConnection();

            using (conn)
            {
                transaction = conn.BeginTransaction();

                if (objATT.Action == "E")
                {
                    SubmissionNo = string.IsNullOrEmpty(objATT.SubmissionNo.ToString()) ? (int?)null : int.Parse(objATT.SubmissionNo.ToString());
                    SqlParameter[] param4 = new SqlParameter[4];
                    param4[0] = new SqlParameter("@scheme_code", objATT.scheme_code);
                    param4[1] = new SqlParameter("@ccode", objATT.ccode);
                    param4[2] = new SqlParameter("@SubmissionNo", SubmissionNo);
                    param4[3] = new SqlParameter("@l_company_id", objATT.l_company_id);
                    DAO.executeTranProcedure("DeleteCompAddress", param4, transaction, conn);

                    SqlParameter[] param5 = new SqlParameter[4];
                    param5[0] = new SqlParameter("@scheme_code", objATT.scheme_code);
                    param5[1] = new SqlParameter("@ccode", objATT.ccode);
                    param5[2] = new SqlParameter("@SubmissionNo", SubmissionNo);
                    param5[3] = new SqlParameter("@l_company_id", objATT.l_company_id);
                    DAO.executeTranProcedure("DeleteCompCertificate", param5, transaction, conn);

                    spName1 = "dbo.EditCompDetail";
                    spName2 = "dbo.InsertAdd_Detail";
                    spName3 = "dbo.InsertCert_Detail";

                }
                //if (objATT.Action == "D")
                //{
                //    SubmissionNo = string.IsNullOrEmpty(objATT.SubmissionNo.ToString()) ? (int?)null : int.Parse(objATT.SubmissionNo.ToString());
                //    SqlParameter[] param4 = new SqlParameter[3];
                //    param4[0] = new SqlParameter("@scheme_code", objATT.scheme_code);
                //    param4[1] = new SqlParameter("@ccode", objATT.ccode);
                //    param4[2] = new SqlParameter("@SubmissionNo", SubmissionNo);
                //    DAO.executeTranProcedure("DeleteCompAddress", param4, transaction, conn);

                //    SqlParameter[] param5 = new SqlParameter[3];
                //    param5[0] = new SqlParameter("@scheme_code", objATT.scheme_code);
                //    param5[1] = new SqlParameter("@ccode", objATT.ccode);
                //    param5[2] = new SqlParameter("@SubmissionNo", SubmissionNo);
                //    DAO.executeTranProcedure("DeleteCompCertificate", param5, transaction, conn);
                //    spName1 = "dbo.DeleteCompDetail";
                //}
                else if (objATT.Action == "A")
                {
                    spName1 = "dbo.InsertComp_Detail";
                    spName2 = "dbo.InsertAdd_Detail";
                    spName3 = "dbo.InsertCert_Detail";
                    if (objATT.SubmissionNo != null)
                    {
                        SubmissionNo = string.IsNullOrEmpty(objATT.SubmissionNo.ToString()) ? (int?)null : int.Parse(objATT.SubmissionNo.ToString());
                    }
                    else
                    {
                        #region To Get MAX ID


                        SqlCommand cmdd = new SqlCommand();
                        cmdd.Connection = conn;
                        cmdd.Transaction = transaction;
                        cmdd.CommandText = "GetSubmissionNo";
                        cmdd.CommandType = CommandType.StoredProcedure;

                        SqlParameter para1 = new SqlParameter();
                        para1.ParameterName = "@SubmissionNo";
                        para1.Value = SubmissionNo;
                        para1.SqlDbType = SqlDbType.Int;
                        para1.Size = 100;
                        para1.Direction = ParameterDirection.InputOutput;
                        cmdd.Parameters.Add(para1);
                        cmdd.Parameters.AddWithValue("@scheme_code", objATT.scheme_code);
                        cmdd.Parameters.AddWithValue("@ccode", objATT.ccode);
                        cmdd.ExecuteNonQuery();

                        if (cmdd.Parameters["@SubmissionNo"].Value.ToString() == "") { cmdd.Parameters["@SubmissionNo"].Value = 0; }
                        SubmissionNo = int.Parse(cmdd.Parameters["@SubmissionNo"].Value.ToString()) + 1;

                        #endregion
                    }

                   }
                    try
                    {
                        SqlParameter[] param = new SqlParameter[18];
                        param[0] = new SqlParameter("@scheme_code", objATT.scheme_code);
                        param[1] = new SqlParameter("@ccode", objATT.ccode);
                        param[2] = new SqlParameter("@SubmissionNo", SubmissionNo);
                        param[3] = new SqlParameter("@Company_Name", objATT.CompName);
                        param[4] = new SqlParameter("@Comp_ContactNo1", objATT.Contact1);
                        param[5] = new SqlParameter("@Comp_ContactNo2", objATT.Contact2);
                        param[6] = new SqlParameter("@Comp_Email", objATT.Email);
                        param[7] = new SqlParameter("@Company_Type", objATT.Comp_Type);
                        param[8] = new SqlParameter("@Comp_Owner_Name", objATT.Owner_Name);
                        param[9] = new SqlParameter("@Comp_Owner_Email", objATT.Owner_Email);
                        param[10] = new SqlParameter("@Comp_Owner_Address", objATT.Owner_Add);
                        param[11] = new SqlParameter("@Comp_Owner_PhoneNo", objATT.Owner_Ph);
                        param[12] = new SqlParameter("@Entry_By", objATT.ENTRY_BY);
                        param[13] = new SqlParameter("@Entry_Date", objATT.ENTRY_DT);
                        param[14] = new SqlParameter("@IsApproved", objATT.IsApproved);
                        param[15] = new SqlParameter("@AppStatus", objATT.APPSTATUS);
                        param[16] = new SqlParameter("@Approved_by", objATT.APPROVED);
                        param[17] = new SqlParameter("@l_company_id", objATT.l_company_id);
                        //param[17] = new SqlParameter("@Approved_Date", objATT.Introducer);
                        DAO.executeTranProcedure(spName1, param, transaction, conn);
                        foreach (ATTAddress_Detail obj in objATT.Address_info)
                        {

                            SqlParameter[] param2 = new SqlParameter[10];
                            param2[0] = new SqlParameter("@scheme_code", objATT.scheme_code);
                            param2[1] = new SqlParameter("@ccode", objATT.ccode);
                            param2[2] = new SqlParameter("@SubmissionNo", SubmissionNo);
                            param2[3] = new SqlParameter("@Address_Type", obj.Type);
                            param2[4] = new SqlParameter("@CID", obj.CID);
                            param2[5] = new SqlParameter("@ProvinceCode", obj.ProvinceCode);
                            param2[6] = new SqlParameter("@District_Code", obj.DistCode);
                            param2[7] = new SqlParameter("@Municipality_No", obj.Municipality);
                            param2[8] = new SqlParameter("@Tole", obj.tole);
                            param2[9] = new SqlParameter("@l_company_id", objATT.l_company_id);
                            DAO.executeTranProcedure(spName2, param2, transaction, conn);
                        }
                        foreach (ATTCertificate_Detail obj in objATT.Certificate_info)
                        {
                            byte[] img;
                            if (obj.File != null)
                            {
                                img = image2byteConverter.dataURL2byte(obj.File);
                            }
                            else img = null;
                            SqlParameter[] param3 = new SqlParameter[9];
                            param3[0] = new SqlParameter("@scheme_code", objATT.scheme_code);
                            param3[1] = new SqlParameter("@ccode", objATT.ccode);
                            param3[2] = new SqlParameter("@SubmissionNo", SubmissionNo);
                            param3[3] = new SqlParameter("@CertType_No", obj.CertType_No);
                            param3[4] = new SqlParameter("@Cert_No", obj.Cer_no);
                            param3[5] = new SqlParameter("@Reg_office", obj.Reg_off);
                            param3[6] = new SqlParameter("@Reg_Date", obj.Reg_Dt);
                            param3[7] = new SqlParameter("@File_Image", img);
                            param3[8] = new SqlParameter("@l_company_id", objATT.l_company_id);
                            DAO.executeTranProcedure(spName3, param3, transaction, conn);
                        }
                        transaction.Commit();
                    }


                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Error" + ex.Message);
                    }

                }

                return SubmissionNo;
            }
        //}
        public List<ATTRegCompany> GetCompDetail(string scheme_code, string ccode,string l_company_id, int? SubmissionNo, string Action)
        {
            List<ATTRegCompany> lstshdel = new List<ATTRegCompany>();
            string spName = "";
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            DataSet ds2 = new DataSet();
            SqlParameter[] param = new SqlParameter[5];
            try
            {

                param[0] = new SqlParameter("@scheme_code", scheme_code != null ? scheme_code : null);
                param[1] = new SqlParameter("@ccode", ccode != null ? ccode : null);
                param[2] = new SqlParameter("@SubmissionNo", SubmissionNo);
                param[3] = new SqlParameter("@Action", Action);
                param[4] = new SqlParameter("@l_company_id", l_company_id);
                spName = "GetCompDetail";
                ds = DAO.gettable(spName, param);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ATTRegCompany objATT = new ATTRegCompany();
                        objATT.CompName = string.IsNullOrEmpty(dr["Company_Name"].ToString()) ? "" : dr["Company_Name"].ToString();
                        objATT.Contact1 = string.IsNullOrEmpty(dr["Comp_ContactNo1"].ToString()) ? "" : dr["Comp_ContactNo1"].ToString();
                        objATT.Contact2 = string.IsNullOrEmpty(dr["Comp_ContactNo2"].ToString()) ? "" : dr["Comp_ContactNo2"].ToString();
                        objATT.Email = string.IsNullOrEmpty(dr["Comp_Email"].ToString()) ? "" : dr["Comp_Email"].ToString();
                        objATT.Comp_Type = string.IsNullOrEmpty(dr["Company_Type"].ToString()) ? "" : dr["Company_Type"].ToString();
                        objATT.Owner_Name = string.IsNullOrEmpty(dr["Comp_Owner_Name"].ToString()) ? "" : dr["Comp_Owner_Name"].ToString();
                        objATT.Owner_Email = string.IsNullOrEmpty(dr["Comp_Owner_Email"].ToString()) ? "" : dr["Comp_Owner_Email"].ToString();
                        objATT.Owner_Add = string.IsNullOrEmpty(dr["Comp_Owner_Address"].ToString()) ? "" : dr["Comp_Owner_Address"].ToString();
                        objATT.Owner_Ph = string.IsNullOrEmpty(dr["Comp_Owner_PhoneNo"].ToString()) ? "" : dr["Comp_Owner_PhoneNo"].ToString();
                        objATT.ENTRY_BY = string.IsNullOrEmpty(dr["Entry_By"].ToString()) ? "" : dr["Entry_By"].ToString();
                        objATT.ENTRY_DT = string.IsNullOrEmpty(dr["Entry_Date"].ToString()) ? "" : Convert.ToDateTime(dr["Entry_Date"]).ToString("yyyy-MM-dd");
                        objATT.SubmissionNo = string.IsNullOrEmpty(dr["SubmissionNo"].ToString()) ? (int?)0 : int.Parse(dr["SubmissionNo"].ToString());

                        SqlParameter[] param2 = new SqlParameter[4];
                        param2[0] = new SqlParameter("@scheme_code", scheme_code != null ? scheme_code : null);
                        param2[1] = new SqlParameter("@ccode", ccode != null ? ccode : null);
                        param2[2] = new SqlParameter("@SubmissionNo", objATT.SubmissionNo);
                        param2[3] = new SqlParameter("@l_company_id", l_company_id);
                        ds1 = DAO.gettable("GetAddDetail", param2);
                        List<ATTAddress_Detail> lstAdd = new List<ATTAddress_Detail>();
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow dr1 in ds1.Tables[0].Rows)
                            {
                                ATTAddress_Detail objATTAdd = new ATTAddress_Detail();
                                objATTAdd.Type = dr1["Address_Type"].ToString();
                                objATTAdd.tole = dr1["Tole"].ToString();
                                objATTAdd.Municipality = dr1["Municipality_No"].ToString();
                                objATTAdd.Dis = dr1["EnDistName"].ToString();
                                objATTAdd.State = dr1["ProvinceName"].ToString();
                                objATTAdd.DistCode = dr1["DistCode"].ToString();
                                objATTAdd.ProvinceCode = dr1["ProvinceCode"].ToString();
                                objATTAdd.CID = int.Parse(dr1["CID"].ToString());
                                lstAdd.Add(objATTAdd);
                            }

                        }

                        SqlParameter[] param3 = new SqlParameter[4];
                        param3[0] = new SqlParameter("@scheme_code", scheme_code != null ? scheme_code : null);
                        param3[1] = new SqlParameter("@ccode", ccode != null ? ccode : null);
                        param3[2] = new SqlParameter("@SubmissionNo", objATT.SubmissionNo);
                        param3[3] = new SqlParameter("@l_company_id", l_company_id);
                        ds2 = DAO.gettable("GetCertDetail", param3);
                        List<ATTCertificate_Detail> lstCert = new List<ATTCertificate_Detail>();
                        if (ds2.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow dr2 in ds2.Tables[0].Rows)
                            {
                                ATTCertificate_Detail objATTCert= new ATTCertificate_Detail();
                                //objATTCert.Cer_Type = dr2["Certificate"].ToString();
                                objATTCert.CertType_No = dr2["CertType_No"].ToString();
                                objATTCert.Cer_no = dr2["Cert_No"].ToString();
                                objATTCert.Reg_off = dr2["Reg_office"].ToString();
                                objATTCert.Reg_Dt = Convert.ToDateTime(dr2["Reg_Date"]).ToString("yyyy-MM-dd");
                                objATTCert.File = dr2["File_Image"].ToString();
                                //objATTCert.State = dr1["ProvinceName"].ToString();
                                lstCert.Add(objATTCert);
                            }

                        }

                        objATT.Address_info = lstAdd;
                        objATT.Certificate_info = lstCert;
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

        public string DeleteCompInfo(string l_company_id, string scheme_code, string ccode, int SubmissionNo)
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
                    SqlParameter[] param = new SqlParameter[4];
                    spName = "DeleteCompInfo";
                    //param[0] = new SqlParameter("@SHHOLDERNO", shholderno);
                    param[0] = new SqlParameter("@scheme_code", scheme_code);
                    param[1] = new SqlParameter("@ccode", ccode);
                    param[2] = new SqlParameter("@SubmissionNo", SubmissionNo);
                    param[3] = new SqlParameter("@l_company_id", l_company_id);
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

        public List<ATTRegCompany> GetCertificate()
        {
            List<ATTRegCompany> lstCCenter = new List<ATTRegCompany>();

            DataSet ds = new DataSet();
            ds = DAO.gettable("GetCertificate", null);

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ATTRegCompany objATT = new ATTRegCompany();
                    objATT.CertType_No = dr["CertType_No"].ToString();
                    objATT.Certificate = dr["Certificate"].ToString();
                    lstCCenter.Add(objATT);
                }

            }
            return lstCCenter;

        }

        public List<ATTRegCompany> GetAddress()
        {
            List<ATTRegCompany> lstCCenter = new List<ATTRegCompany>();

            DataSet ds = new DataSet();
            ds = DAO.gettable("GetAddress", null);

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ATTRegCompany objATT = new ATTRegCompany();
                    objATT.AddType_No = dr["AddType_No"].ToString();
                    objATT.AddressType = dr["AddressType"].ToString();
                    lstCCenter.Add(objATT);
                }

            }
            return lstCCenter;

        }
    }
}
