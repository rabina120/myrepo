using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SI.Utility;
using System.Web;
using System.Data.SqlClient;
using SI.Security.ATT;

namespace SI.Security.DLL
{
    public class DLLMenu
    {
        public List<ATTMenu> GetMenus()
        {

            DataSet ds = new DataSet();
            try
            {
                string SP = "GetWebMenu";
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@MenuType", "01");
                ds = DAO.gettable(SP, param);

                List<ATTMenu> lst = new List<ATTMenu>();


                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    ATTMenu obj = new ATTMenu();
                    obj.MenuID = int.Parse(drow["MenuID"].ToString());
                    obj.MenuName = drow["MenuText"].ToString();
                    obj.ToolTip = drow["ToolTip"].ToString();
                    obj.Url = drow["MUrl"].ToString();
                    obj.UsedIn = drow["UsedIn"].ToString();
                    obj.OrderNo = string.IsNullOrEmpty(drow["OrderNo"].ToString()) ? (int?)null : int.Parse(drow["OrderNo"].ToString());
                    obj.ParentID = string.IsNullOrEmpty(drow["ParentId"].ToString()) ? (int?)null : int.Parse(drow["ParentId"].ToString());
                    obj.Level = string.IsNullOrEmpty(drow["Level"].ToString()) ? (int?)null : int.Parse(drow["Level"].ToString());
                    obj.HasChild = drow["HasChild"].ToString();
                    obj.HasAccessed = drow["HasAccessed"].ToString();
                    lst.Add(obj);
                }


                return lst;
            }
            catch (Exception ex)
            {
                return new List<ATTMenu>();

            }
        }
        public List<ATTMenu> GetWebMenus()
        {

            DataSet ds = new DataSet();
            try
            {
                string SP = "GetWebMenu";
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@MenuType", "02");
                ds = DAO.gettable(SP, param);

                List<ATTMenu> lst = new List<ATTMenu>();


                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    ATTMenu obj = new ATTMenu();
                    obj.MenuID = int.Parse(drow["MenuID"].ToString());
                    obj.MenuName = drow["MenuText"].ToString();
                    obj.ToolTip = drow["ToolTip"].ToString();
                    obj.Url = drow["MUrl"].ToString();
                    obj.UsedIn = drow["UsedIn"].ToString();
                    obj.OrderNo = string.IsNullOrEmpty(drow["OrderNo"].ToString()) ? (int?)null : int.Parse(drow["OrderNo"].ToString());
                    obj.ParentID = string.IsNullOrEmpty(drow["ParentId"].ToString()) ? (int?)null : int.Parse(drow["ParentId"].ToString());
                    obj.Level = string.IsNullOrEmpty(drow["Level"].ToString()) ? (int?)null : int.Parse(drow["Level"].ToString());
                    obj.HasChild = drow["HasChild"].ToString();
                    obj.HasAccessed = drow["HasAccessed"].ToString();
                    lst.Add(obj);
                }


                return lst;
            }
            catch (Exception ex)
            {
                return new List<ATTMenu>();

            }
        }
    }
}
