using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SI.Utility;

namespace Openend_SIP
{
    public partial class LoginMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            var characters = "0123456";
            CsrfHandler.GenerateToken(this.Page, characters.ToString(), null, "A");
          

        }
    }
}