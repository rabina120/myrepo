using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATTCollection
{
  public  class ATTEsewa
    {
        public string PREF { get; set; }
        public string BID { get; set; }
        public string CustRefType { get; set; }  //TXNID
        public string scd { get; set; }
        //public string AMOUNT { get; set; } 
        public float AMOUNT { get; set; }
        public string Action { get; set; }
    }
}
