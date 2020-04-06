using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

namespace ssm_mvc_demo1
{
    public partial class Signup : System.Web.UI.Page
    {
        Users user = new Users();
        static string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void signup_Click(object sender, EventArgs e)
        {

            Users newUser = new Users();
            string userid = newUser.signup(username.Text, password.Text, email.Text);
            Users user = newUser.getUserInfo(userid);

            if (user != null)
            {
                Session["userid"] = user.id;
                Session["username"] = user.username;
                Response.Redirect("Profile.aspx?type=1");

            }
            else
            {
                Response.Redirect("ERROR.html");
            }

        }

        public void displayAlertt(string s)
        {
            errorMessage.InnerText = s;

        }


    }
}