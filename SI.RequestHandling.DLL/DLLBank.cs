using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SI.Utility;
using System.Web;
using System.Data.SqlClient;
using SI.RequestHandling.ATT;

namespace SI.RequestHandling.DLL
{
    public class DLLBank
    {
        public List<ATTBank> GetBank()
        {
            List<ATTBank> lstBank = new List<ATTBank>();

            DataSet ds = new DataSet();
            ds = DAO.gettable("GetBank", null);

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ATTBank objATT = new ATTBank();
                    objATT.bankcode = dr["bankcode"].ToString();
                    objATT.bankname = dr["bankname"].ToString();
                    lstBank.Add(objATT);
                }

            }
            return lstBank;

        }
        public List<ATTBankBranch> GetBranch(string bankcode)
        {
            List<ATTBankBranch> lstbranch = new List<ATTBankBranch>();

            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@bankcode", bankcode != null ? bankcode : null);
            ds = DAO.gettable("GetBranch", param);

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ATTBankBranch objATT = new ATTBankBranch();
                    objATT.branch_code = dr["branch_code"].ToString();
                    objATT.branch_address = dr["address"].ToString() + ' ' + dr["address"].ToString();
                    lstbranch.Add(objATT);
                }

            }
            return lstbranch;

        }
    }
}
