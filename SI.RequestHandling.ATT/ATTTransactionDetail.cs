using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SI.RequestHandling.ATT
{
   public class ATTTransactionDetail
    {
       public int? SHHOLDERNO{get; set;}
       public string scheme_code{get; set;}
       public int seqno { get; set; }
       public int Allocation_no { get; set; }
       public string value_dt { get; set; }
       public float balance_unit { get; set; }
       public float Can_be_sell { get; set; }
       public float redem_unit { get; set; }
       public float inv_amt { get; set; }
       public float inv_amt_redem_unit { get; set; }
       public float cur_val { get; set; }
       public float exe_load { get; set; }
       public float cap_gain_tax { get; set; }
       public string entry_user{get;set;}
       public string entry_dt { get; set; }
       public string SIP_Reg_Date { get; set; }
       public string status { get; set; }
       public int lock_unit{get; set;}
       public int free_unit {get;set;}
       public float Sum_BalanceUnit { get; set; }
       public float CGT { get; set; }
       public float Sum_Inv_Amt { get; set; }
       public string p_dt{get; set;}
       public float Unposted_Unit { get; set; }
       public int Holding_Days { get; set; }
       public float locked_unit { get; set; }
       public string Action { get; set; }
       public string tran_type { get; set; }
       public float To_be_Sell { get; set; }
       public float capital_gain_amount { get; set; }
       public float capital_gain_tax_amount { get; set; }
       //public float Can_be_Sell { get; set; }

       public string Sip_value_dt { get; set; }
       public int Sip_Holding_Days { get; set; }

    }
}
