using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATTCollection
{
   public  class ATTCIPS
    {
        public string merchantId { get; set; }
        public string appId { get; set; }
        public string referenceId { get; set; }  //TXNID
        public string txnAmt { get; set; }
        public string token { get; set; }
        public string Action { get; set; }
    }
}
