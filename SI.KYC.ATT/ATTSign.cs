using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SI.KYC.ATT
{
    public class ATTSign
    {
        public string compcode { get; set; }
        public int? seqno { get; set; }
        public int shholderno { get; set; }
        public string signature { get; set; }
        public float FileLength { get; set; }
        public string captureby { get; set; }
        public string capturedate { get; set; }
        public string Is_Approved { get; set; }
        public string approvedby { get; set; }
        public string ApprovedDate { get; set; }
        public string action1 { get; set; }
        public string entrydate { get; set; }
        public string entryuser { get; set; }
        public string ScanedBy { get; set; }
        public int PassProcted { get; set; }
    }
}
