using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SI.RequestHandling.ATT
{
   public class ATTServiceCharge
    {
       public string CompCode { get; set; }
       public string SCharge_Code { get; set; }
       public string SDescription { get; set; }
       public float rate { get; set; }
       public string Flat_percent { get; set; }
       public int Holding_Days { get; set; }
       //public string CompCode { get; set; }
    }
}
