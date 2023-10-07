using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SI.KYC.ATT
{
   public class ATTSignature
    {
        public string Scheme_code { get; set; }
        public string ccode { get; set; }
        public int ShHolderNo { get; set; }
        public string Sign1 { get; set; }
        public string Sign2 { get; set; }
        public string Stamp { get; set; }
        public string Thumb_Print { get; set; }
        public string Location { get; set; }
        public string Image { get; set; }
    }
}
