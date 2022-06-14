using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SessionManagement
{
	public partial class MembersMain : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
		
			//string user = Request.QueryString["u"];
			//string pass = Request.QueryString["p"];
			string user = Session[Request.QueryString["u"]].ToString();
			string pass = Session[Request.QueryString["p"]].ToString();

			lblUser.Text = "Hello, " + user + "! Your password is " + pass;
			
		}

        protected void Button1_Click(object sender, EventArgs e)
        {
			Response.Redirect("3rdPage.aspx?" + Request.QueryString.ToString());
		}
    }
}