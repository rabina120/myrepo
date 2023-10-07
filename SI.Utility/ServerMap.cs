using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Web;
using System.Web.Script.Serialization;
using System.IO;
using System.ComponentModel;

namespace SI.Utility
{
  public  class ServerMap
    {
       public string ReadFile(HttpContext context)
       {
          string  fileName = "/Purchase Entry Report -" + System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".pdf";
          string path = HttpContext.Current.Server.MapPath("/Reports" + fileName);
          return path;
       }
    }
}
