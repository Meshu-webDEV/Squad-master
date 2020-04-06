using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;


namespace ssm_mvc_demo1
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //string path = Request.Url.AbsolutePath;

            //if (path != "/Default" && (path != "/Signup" || path != "/Login"))
            //{
            //    Response.Redirect("Login.aspx");
            //}



            if (Session["username"] != null)
            {
                string userid = Session["userid"].ToString();
                logoutButton.Visible = true;
                loginButton.Visible = false;
                frndLink.HRef = "/FriendList.aspx?status=0&userid=" + userid;
                notifId.Attributes["src"] = "Notifications.aspx?userid=" + userid;
                mymId.Attributes["data-src"] = "MyMatches.aspx?userid=" + userid;
            }
            else
            {

                profile.Attributes["onclick"] = "";
                profile.Attributes["style"] = "opacity:0.5;";
                frndLink.Attributes["class"] = "disabled-link nav-link";
                bell.Attributes["class"] = "unbutton bell disabled-bell disabled-link";
                ball.Attributes["class"] = "nav-link unbutton disabled-bell disabled-link";
            }
        }

        public void logout_Click(Object sender, EventArgs e)
        {
            Session.Clear();

            Response.Redirect("Default.aspx");
        }

        public void login_Click(Object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        public void Profile_Click(Object sender, EventArgs e)
        {
            Response.Redirect("Profile.aspx?type=1");
        }
    }
}