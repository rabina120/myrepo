using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SI.Security.ATT
{
   public class ATTMenu
    {
        public int MenuID { get; set; }
        public string MenuName { get; set; }
        public string ToolTip { get; set; }
        public string Url { get; set; }
        public string UsedIn { get; set; }
        public int? OrderNo { get; set; }
        public int? ParentID { get; set; }
        public int? Level { get; set; }
        public string HasChild { get; set; }
        public string HasAccessed { get; set; }
        public string Action { get; set; }
    }
}
