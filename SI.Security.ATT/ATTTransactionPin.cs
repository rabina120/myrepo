using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SI.Security.ATT
{
    public class ATTTransactionPin
    {
        public string BOID { get; set; }

        public string UserId { get; set; }

        public string SHHOLDERNO { get; set; }

        public string NewPin { get; set; }

        public string OldPin { get; set; }

       public int CReNewPin { get; set; }

        public string Action { get; set; }

        public string Email { get; set; }

        public string EmailOTP { get; set; }



    }
}
