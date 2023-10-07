using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SI.RequestHandling.ATT
{
 public  class ATTEBankingVerifyTxnResponse
    {
        public string VerifyTxnResult { get; set; }
        public string response_code { get; set; }
        public string response { get; set; }
    }
}
