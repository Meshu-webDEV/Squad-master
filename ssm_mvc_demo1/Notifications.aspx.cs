using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ssm_mvc_demo1
{
    public partial class Notifications : System.Web.UI.Page
    {

        string userid = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            userid = Request.QueryString["userid"].ToString();

            Users user = new Users();

            List<string[]> requested = user.getRequestedList(userid, 0);


            if (requested != null)
            {

                for (int i = 0; i < requested.Count(); i++)
                {

                    string reqid = requested[i][0];
                    string username = requested[i][1];

                    string friendReqBlock = "<div runat='server' style='font-size: 12.5px;' class='py-1 my-1'>Friend request</div> " +
                                     "<div class='row notif-row my-2'> " +
                                        "<div runat='server'>" + username + "#" + reqid + "</div> " +
                                        "<div id='" + reqid + "' class='btn btn-sm btn-info p-1 m-1' onclick='accepted(this); return true;'>Accept</div> " +
                                        "<div id='" + reqid + "' class='btn btn-sm btn-warning p-1 m-1' onclick='decline(this); return true;'>Decline</div> " +
                                    "</div>";


                    notif.InnerHtml += friendReqBlock;

                }

            }

            //MATCH INVITES

            List<string[]> invited = user.getMatchInvites(userid);
            //test.InnerText = invited[0][0];


            if (invited != null)
            {

                for (int i = 0; i < invited.Count(); i++)
                {

                    string matchid = invited[i][0];
                    string senderid = invited[i][1];
                    string read = invited[i][2];

                    Matches match = new Matches();
                    string code = match.getPvtMatchCode(matchid);
                    string[] matchinfo = match.getMatchInfo(matchid);
                    string type = matchinfo[2];
                    // == MATCHINFO ARRAY: ==
                    //0 = NAME //1 = DATE
                    //2 = TYPE //3 = FIELD

                    Users user1 = new Users();
                    string username1 = user.getUsername(senderid);

                    string friendReqBlock = "<div runat='server' style='font-size: 12.5px;' class='py-1 my-1'>Match invite ⚽</div> " +
                                     "<div class='row notif-row my-2'> " +
                                        "<div runat='server'>" + username1 + "#" + senderid + "</div> " +
                                        "<div id='" + matchid + "' class='p-1 m-1'>Match invite</div> " +
                                        "<div id='" + matchid + "#" + code + "@" + type + "' class='btn btn-sm btn-success p-1 m-1' onclick='Goto(this); return true;'>View</div> " +
                                    "</div>";


                    notif.InnerHtml += friendReqBlock;


                }

            }
            if (invited == null && requested == null)
            {
                notif.InnerHtml = "<h6 id='notifEmpty' class='notif-Empty' runat='server'>No notifications. </h6>";
            }

        }

        protected void accept_Click(object sender, EventArgs e)
        {

            Users user = new Users();

            if (user.acceptFriend(userid, acceptedID.Value))// ACCEPTED 
            {
                Response.Redirect("/Notifications.aspx?userid=" + userid);
            }
            else
                Response.Redirect("/Notifications.aspx?status=error&userid=" + userid);

        }
        protected void decline_Click(object sender, EventArgs e)
        {

            Users user = new Users();

            if (user.removeFriend(userid, declinedID.Value))
                Response.Redirect("/Notifications.aspx?userid=" + userid);
            else
                Response.Redirect("/Notifications.aspx?status=error&userid=" + userid);

        }

    }
}