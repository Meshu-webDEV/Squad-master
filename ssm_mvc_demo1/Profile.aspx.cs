using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ssm_mvc_demo1
{
    public partial class Profile : System.Web.UI.Page
    {
        int editing = 0;
        string type = "";
        string uid = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            // type= 1 self, 2 view

            type = Request.QueryString[0];

            if (type == "1")// self
            {

                //if (editing == 1)
                //{
                //    ddlpos.Visible = true;
                //    editingbio.Visible = true;
                //    bio.Visible = false;
                //    //bio.Attributes["placeholder"] = "";


                //    SubmitGear.Visible = true;
                //}

                if (Session["userid"] != null)
                {

                    ddlpos.Visible = false;
                    editingbio.Visible = false;
                    bio.Visible = true;
                    //bio.Attributes["placeholder"] = "";


                    SubmitGear.Visible = false;

                    uid = Session["userid"].ToString();
                    string userid = Session["userid"].ToString();
                    string user_username = Session["username"].ToString();

                    Users getUser = new Users();

                    Users user = getUser.getUserInfo(userid);

                    // == FILL DATA == 
                    avatar.Attributes["src"] = user.avatar;
                    username.InnerText = user.username + "#" + user.id;
                    bio.Text = user.bio;
                    infoTitle.InnerText = user.username + "'s info";
                    matchesPlayed.InnerText = user.played;
                    position.InnerText = user.position;

                    req.Visible = false;
                }
                else
                {

                }

            }

            if (type == "2")// VIEW
            {
                string userid = Request.QueryString[1];


                Users getUser = new Users();

                Users user = getUser.getUserInfo(userid);

                // == FILL DATA == 
                avatar.Attributes["src"] = user.avatar;
                username.InnerText = user.username + "#" + user.id;
                bio.Text = user.bio;
                infoTitle.InnerText = user.username + "'s info";
                matchesPlayed.InnerText = user.played;
                position.InnerText = user.position;

                gear.Visible = false;
                plus.Visible = false;
                if (Session["userid"] == null)// NOT LOGGED IN
                    req.Visible = false;

                // IF LOGGED IN AND WANT TO CHECK IF OWN PROFILE, TO HIDE ADD FRIEND
                else
                {
                    if (Session["userid"] != null && Session["userid"].ToString() == userid)// LOGGED IN AND NOT SELF
                        req.Visible = false;
                    else// NOT SELF
                        if (user.isRequested(Session["userid"].ToString(), userid) == 0)// IF REQUESTED
                    {
                        req.Visible = false;
                        pending.Visible = true;
                    }
                    if (user.isRequested(Session["userid"].ToString(), userid) == 1)
                        req.Visible = false;



                }
            }

        }

        protected void ProfEdit_Click(object sender, EventArgs e)
        {
            editing = 1;
            ddlpos.Visible = true;
            editingbio.Visible = true;
            bio.Visible = false;
            position.Visible = false;
            //bio.Attributes["placeholder"] = "";


            SubmitGear.Visible = true;

        }

        protected void bioEdit_Click(object sender, EventArgs e)
        {

        }

        protected void req_Click(object sender, EventArgs e)
        {

            string requid = Request.QueryString[1];
            string uid = Session["userid"].ToString();

            Users user = new Users();

            if (user.sendRequest(uid, requid))
                Response.Redirect("~/Profile.aspx?type=2&userid=" + requid);
            else
            {
                Response.Redirect("~/Profile.aspx?status=error");
            }

            //https://localhost:44317/Profile?type=2&userid=18

        }

        protected void SubmitGear_Click(object sender, EventArgs e)
        {

            string pos = ddlpos.SelectedValue;
            string desc = editingbio.InnerText;
            editing = 0;


            Users user = new Users();
            user.setUserPos(pos, desc, uid);

            Response.Redirect("~/Profile.aspx?type=1");

        }
    }
}