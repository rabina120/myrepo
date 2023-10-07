using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SI.Utility
{
    public class JsonResponse
    {
        private bool _IsSucess = false;

        public bool IsSucess
        {
            get { return _IsSucess; }
            set { _IsSucess = value; }
        }

        private string _Message = string.Empty;

        public string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }

        private string _Token = string.Empty;

        public string Token
        {
            get { return _Token; }
            set { _Token = value; }
        }
        public dynamic data { get; set; }
        private object _ResponseData = null;

        public object ResponseData
        {
            get { return _ResponseData; }
            set { _ResponseData = value; }
        }

        private object _Records = null;
        public object Records
        {
            get { return _Records; }
            set { _Records = value; }

        }
        private object _TotalRecords = null;
        public object TotalRecords
        {
            get { return _TotalRecords; }
            set { _TotalRecords = value; }

        }
        private string _CallBack = string.Empty;

        public string CallBack
        {
            get { return _CallBack; }
            set { _CallBack = value; }
        }

        private bool _IsToken = true;

        public bool IsToken
        {
            get { return _IsToken; }
            set { _IsToken = value; }
        }
        private int _TCount;

        public int TCount 
        {
            get { return _TCount; }
            set { _TCount = value; }
        }
    }
}
