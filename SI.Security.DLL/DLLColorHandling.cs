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
    public class DLLColorHandling
    {

        public List<ATTColorCode> ColorCode()
        {
            string spName = "";
            List<ATTColorCode> lstUser = new List<ATTColorCode>();
            try
            {
                DataSet ds = new DataSet();


                spName = "GetColorCode";

                ds = DAO.gettable(spName, null);
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    ATTColorCode obj = new ATTColorCode();
                    obj.BackgroundColor = string.IsNullOrEmpty(drow["BackgroundColor"].ToString()) ? "" : drow["BackgroundColor"].ToString();
                    obj.Color = string.IsNullOrEmpty(drow["Color"].ToString()) ? "" : drow["Color"].ToString();
                    obj.TextColor = string.IsNullOrEmpty(drow["TextColor"].ToString()) ? "" : drow["TextColor"].ToString();
                    obj.logo1 = string.IsNullOrEmpty(drow["logo1"].ToString()) ? "" : drow["logo1"].ToString();
                    obj.logo2 = string.IsNullOrEmpty(drow["logo2"].ToString()) ? "" : drow["logo2"].ToString();
                    obj.logo3 = string.IsNullOrEmpty(drow["logo3"].ToString()) ? "" : drow["logo3"].ToString();
                    obj.Navcolor = string.IsNullOrEmpty(drow["navcolor"].ToString()) ? "" : drow["navcolor"].ToString();
                    obj.midImage = string.IsNullOrEmpty(drow["logo4"].ToString()) ? "" : drow["logo4"].ToString();
                    obj.theadColor = string.IsNullOrEmpty(drow["theadcolor"].ToString()) ? "" : drow["theadcolor"].ToString();
                    obj.Name = string.IsNullOrEmpty(drow["Name"].ToString()) ? "" : drow["Name"].ToString();
                    lstUser.Add(obj);
                }


            }
            catch (Exception ex)
            {
                throw new Exception("Error" + ex.Message);
            }

            return lstUser;

        }

        public List<ATTReportFile> ReportImage(string company_id)
        {
            string spName = "";
            List<ATTReportFile> lstUser = new List<ATTReportFile>();
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@company_id", company_id);

                spName = "GetReportFile";

                ds = DAO.gettable(spName, null);
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    ATTReportFile obj = new ATTReportFile();
                    obj.FooterClient = string.IsNullOrEmpty(drow["FooterClient"].ToString()) ? "" : drow["FooterClient"].ToString();
                    obj.Purchase = string.IsNullOrEmpty(drow["Purchase"].ToString()) ? "" : drow["Purchase"].ToString();
                    obj.Registration = string.IsNullOrEmpty(drow["Registration"].ToString()) ? "" : drow["Registration"].ToString();
                    obj.SIPPurchase = string.IsNullOrEmpty(drow["SIPPurchase"].ToString()) ? "" : drow["SIPPurchase"].ToString();
                    obj.FooterOff = string.IsNullOrEmpty(drow["FooterOff"].ToString()) ? "" : drow["FooterOff"].ToString();
                    obj.Amendment = string.IsNullOrEmpty(drow["Amendment"].ToString()) ? "" : drow["Amendment"].ToString();
                    obj.PurchaseForm = string.IsNullOrEmpty(drow["PurchaseForm"].ToString()) ? "" : drow["PurchaseForm"].ToString();
                    obj.SIPForm = string.IsNullOrEmpty(drow["SIPForm"].ToString()) ? "" : drow["SIPForm"].ToString();
                    obj.CompanyName = string.IsNullOrEmpty(drow["CompanyName"].ToString()) ? "" : drow["CompanyName"].ToString();
                    obj.Transparent = string.IsNullOrEmpty(drow["Transparent"].ToString()) ? "" : drow["Transparent"].ToString();
                    obj.Redemption = string.IsNullOrEmpty(drow["Redemption"].ToString()) ? "" : drow["Redemption"].ToString();
                    obj.PurchaseDecelaration = string.IsNullOrEmpty(drow["PurchaseDecelaration"].ToString()) ? "" : drow["PurchaseDecelaration"].ToString();
                    obj.SIPDecelaration = string.IsNullOrEmpty(drow["SIPDecelaration"].ToString()) ? "" : drow["SIPDecelaration"].ToString();
                    obj.OnlineFooter = string.IsNullOrEmpty(drow["OnlineFooter"].ToString()) ? "" : drow["OnlineFooter"].ToString();
                    obj.Cancellation = string.IsNullOrEmpty(drow["Cancellation"].ToString()) ? "" : drow["Cancellation"].ToString();
                    lstUser.Add(obj);
                }


            }
            catch (Exception ex)
            {
                throw new Exception("Error" + ex.Message);
            }

            return lstUser;
        }
    }
}
