using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace ssm_mvc_demo1
{
    public partial class Friendlist : System.Web.UI.Page
    {

        string userid = "";
        string status = "";
        string matchid = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            // id from session

            if (Session != null)
            {
                userid = Session["userid"].ToString();
            }

            if (Request.QueryString != null)
            {
                status = Request.QueryString["status"].ToString();
                //userid = Request.QueryString["userid"].ToString();
            }
            if (status == "3")// FOR INVITING
            {
                matchid = Request.QueryString["matchid"].ToString();

                Users user1 = new Users();
                //STATUS 1 = ACCEPTED, 0 = PENDING
                List<string[]> friends1 = user1.getFriendList(userid, 1);

                if (friends1 != null && !IsPostBack)
                {

                    for (int i = 0; i < friends1.Count(); i++)
                    {
                        string uid = friends1[i][0];
                        string username = friends1[i][1];

                        string block = "<div class='row d-flex w-100 mt-2 mb-2 mr-0 ml-0 p-2 friend align-items-center' runat='server'>" +
                                        "<div class='col-7' runat='server'> " +
                                            "<div class='sixteenpx' runat='server'>" + username + "</div> " +
                                        "</div> " +
                                        "<div class='col-5 d-flex m-0 p-0 justify-content-end' runat='server'>" +
                                        "<div class='btn btn-sm btn-info mx-1' id='" + uid + "' onclick='sendInvite(this);return true;' runat='server'> Invite </div>" +
                                        "</div> " +
                                    "</div>";

                        dynamicBody.InnerHtml += block;

                    }
                }


            }

            else// FOR REMOVING
            {
                Users user = new Users();
                //STATUS 1 = ACCEPTED, 0 = PENDING
                List<string[]> friends = user.getFriendList(userid, 1);

                if (friends != null && !IsPostBack)
                {

                    for (int i = 0; i < friends.Count(); i++)
                    {
                        string uid = friends[i][0];
                        string username = friends[i][1];

                        string block = "<div class='row d-flex w-100 mt-2 mb-2 mr-0 ml-0 p-2 friend align-items-center' runat='server'>" +
                                        "<div class='col-7' runat='server'> " +
                                            "<div class='sixteenpx' runat='server'>" + username + "</div> " +
                                        "</div> " +
                                        "<div class='col-5 d-flex m-0 p-0 justify-content-end' runat='server'>" +
                                            "<div class='btn btn-sm btn-warning' id='" + uid + "' onclick='removeFriend(this);return true;' runat='server'>" +
                                            " Remove " +
                                            "</div> " +
                                        "</div> " +
                                    "</div>";

                        dynamicBody.InnerHtml += block;

                    }

                }
                else
                {
                    flEmpty.Visible = true;
                }
            }


        }

        protected void remove_Click(object sender, EventArgs e)
        {

            Users user = new Users();
            if (user.removeFriend(userid, removedID.Value))
            {
                Response.Redirect("/FriendList.aspx?status=1&userid=" + userid);
            }

            Response.Redirect("/FriendList.aspx?status=0&userid=" + userid);

        }

        protected void invite_Click(object sender, EventArgs e)
        {
            Matches match = new Matches();
            string st = match.sendMatchInvite("21", userid, matchid);
            //test.InnerText = match.sendMatchInvite();

            if (st == "good")
            {

                Response.Redirect("/FriendList.aspx?status=3&userid=" + userid + "&matchid=" + matchid + "&invited=yes");

            }
            else
            {
                Response.Redirect("/ErrorPage.aspx");
            }



        }
    }
}