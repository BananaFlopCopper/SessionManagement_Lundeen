using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SessionManagement
{
    public partial class _3rdPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string user = Session[Request.QueryString["u"]].ToString();
            string pass = Session[Request.QueryString["p"]].ToString();

            lblUser.Text = "Hello, " + user + "! Your password is " + pass;
        }
    }
}