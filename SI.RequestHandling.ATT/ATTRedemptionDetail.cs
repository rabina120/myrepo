using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SI.RequestHandling.ATT
{
    public class ATTRedemptionDetail
    {
        public string scheme_code { get; set; }
        public string ccode { get; set; }
        public int REQUEST_NO { get; set; }
        public int SHHOLDERNO { get; set; }
        public int lotno { get; set; }
        public int seqno { get; set; }
        public float lot_unit { get; set; }
        public string p_dt { get; set; }
        public float sell_unit { get; set; }
        public float charge_amt { get; set; }
        public float inv_amt { get; set; }

    }
}
