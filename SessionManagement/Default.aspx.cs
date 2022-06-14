using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SessionManagement
{
	public partial class Default : System.Web.UI.Page
	{
		public struct UserLad
        {
			public UserLad(string user, string pass)
            {
				Name= user;
				Pass= pass;
            }
			public string Name;
			public string Pass;
        }
        public List<UserLad> Users { get; set; }
        protected void Page_Load(object sender, EventArgs e)
		{
			Users = new List<UserLad>();
			Users.Add(new UserLad("bgates","billions"));
			Users.Add(new UserLad("DanHagen's UltraSecure Account", "123"));
			Users.Add(new UserLad("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam nec leo metus. Sed elementum risus risus, a luctus risus tincidunt sed. Pellentesque ornare ex nec dolor luctus aliquet. Ut in dapibus ipsum, a pellentesque dui. Donec ut mauris et purus placerat vehicula eu quis ex. Nullam laoreet cursus justo vel ornare. Mauris ac elit metus. Nullam pharetra enim euismod porta venenatis. Pellentesque non lacus tellus. Duis in dolor ut nunc sagittis ornare. Maecenas varius dolor odio, vel interdum dolor ultricies et. Cras in velit posuere, mattis orci vel, aliquet justo. Pellentesque congue cursus ligula ut interdum. Nulla et rutrum ipsum, at ultricies nisl. Quisque posuere, arcu a viverra congue, nulla nisi sagittis enim, sit amet dignissim neque augue vel lectus.", "Cras et luctus ligula. Proin aliquet imperdiet ligula. Interdum et malesuada fames ac ante ipsum primis in faucibus. Aliquam ullamcorper augue vitae interdum interdum. Integer vitae nunc euismod, lacinia tellus et, mattis nisl. Fusce sit amet elit libero. Integer commodo fermentum ullamcorper. Aliquam at arcu dolor."));
        }

		protected void btnLogIn_Click(object sender, EventArgs e)
		{
			
			if (Users.Contains(new UserLad(txtUser.Text, txtPassword.Text)))
			{

				string user = txtUser.Text;
				string pass = txtPassword.Text;
				Response.Redirect("MembersMain.aspx?u=" + txtUser.Text + "&p=" + txtPassword.Text);
			}
			else
			{
				lblMessage.Text = "Account not recognized";
			}
	
		}
	}
}