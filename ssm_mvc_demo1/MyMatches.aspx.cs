using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ssm_mvc_demo1
{
    public partial class MyMatches : System.Web.UI.Page
    {
        string userid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null || Session["userid"] == null)
            {
                mymatches.InnerHtml = "<h6 id='notifEmpty' class='notif-Empty' runat='server'>Login to see your matches. </h6>";
            }
            else
            {
                userid = Session["userid"].ToString();

                Matches match = new Matches();
                List<Matches> openMatches = match.getMyOpenMatches(userid); // AS A CAPTAIN
                List<Matches> PlayerJoinedMatches = match.getPlayerJoinedMatches(userid); // AS A PLAYER

                if (openMatches.Count == 0 && PlayerJoinedMatches.Count == 0) // If there is no matches
                {
                    mymatches.InnerHtml = "<h6 id='notifEmpty' class='notif-Empty' runat='server'>No matches. </h6>";
                }
                else
                {
                    for (int i = 0; i < openMatches.Count(); i++) // Loop thru captained matches.
                    {

                        if (openMatches[i].getMatchInfo(openMatches[i].id)[2] == "Private") // Check if match is private.
                        {
                            string code = openMatches[i].getPvtMatchCode(openMatches[i].id);

                            string pvtblock = "<div class='My-matches w-100 p-1 m-2'> " +
                                    "<div class='mym-name'>" + openMatches[i].name + "</div> " +
                                    "<div>" + openMatches[i].date + "</div> " +
                                    "<div id='" + openMatches[i].id + "/" + code + "' class='btn btn-sm btn-dark' onclick='ViewPvtMatch(this);return true;'>View</div> " +
                                "</div>";



                            mymatches.InnerHtml += pvtblock;
                            mymatches.InnerHtml += "<hr class='my-1 w-75' />";
                        }
                        else
                        {
                            string block = "<div class='My-matches w-100 p-1 m-2'> " +
                                    "<div class='mym-name'>" + openMatches[i].name + "</div> " +
                                    "<div>" + openMatches[i].date + "</div> " +
                                    "<div id='" + openMatches[i].id + "' class='btn btn-sm btn-warning' onclick='ViewMatch(this);return true;'>View</div> " +
                                "</div>";



                            mymatches.InnerHtml += block;
                            mymatches.InnerHtml += "<hr class='my-1 w-75' />";
                        }



                    }

                    for (int i = 0; i < PlayerJoinedMatches.Count(); i++)
                    {

                        string block = "<div class='My-matches w-100 p-1 m-2'> " +
                                    "<div class='mym-name'>" + PlayerJoinedMatches[i].name + "</div> " +
                                    "<div>" + PlayerJoinedMatches[i].date + "</div> " +
                                    "<div id='" + PlayerJoinedMatches[i].id + "' class='btn btn-sm btn-success' onclick='ViewMatch(this);return true;'>View</div> " +
                                "</div>";

                        mymatches.InnerHtml += block;

                    }
                }
            
            }

        }
    }
}