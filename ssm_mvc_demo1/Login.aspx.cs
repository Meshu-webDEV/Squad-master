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
    public partial class WebForm1 : System.Web.UI.Page
    {
        Users user = new Users();
        static string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login_Click(object sender, EventArgs e)
        {
            bool login = user.login(username.Text, password.Text);

            if (login)
            {
                Session["username"] = user.username;
                Session["userid"] = user.id;
                Response.Redirect("Default.aspx");

            }
            else
            {
                string errorMessage = user.errorMessage;
                displayAlertt(errorMessage);
            }

        }

        public void displayAlertt(string s)
        {
            errorMessage.InnerText = s;

        }

    }
}