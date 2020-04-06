using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Windows.Forms;

namespace ssm_mvc_demo1
{
    public partial class MatchRoom : System.Web.UI.Page
    {

        static string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        StringBuilder errorMessages = new StringBuilder();

        public string match_id;
        public string user_id;
        string type;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null || Session["userid"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }

            else//Session is available
            {
                // Get user ID from session, match ID from URL query string
                user_id = Session["userid"].ToString();
                match_id = Request.QueryString.Get(0);

            }

            Matches match = new Matches();
            string[] MatchInfo = match.getMatchInfo(match_id);

            Courts court = new Courts();
            string[] courtInfo = court.getCourtInfo(Int32.Parse(MatchInfo[3]));

            type = MatchInfo[2];

            if (type == "Private" && isCaptain(user_id, match_id))// if private and captain
            {
                pvt.Visible = true;
            }
            if (type == "Public" && isCaptain(user_id, match_id))// if private and captain
            {
                pvt1.Visible = true;
            }
            if (type == "Public")
            {
                status.Visible = true;
                status.InnerText = "public.";
                status.Attributes["class"] = "subtitle-pub";
            }
            if (type == "Private")
            {
                status.Visible = true;
                status.InnerText = "private.";
                status.Attributes["class"] = "subtitle-pvt";
            }


            
            List<String> courtImgs = court.getCourtImages(Int32.Parse(MatchInfo[3]));

            string courtLocationUrl = "https://maps.google.com/?q=";

            string lat = courtInfo[3];
            string lng = courtInfo[4];

            courtLocationUrl += lat + "," + lng + "&ll=" + lat + "," + lng + "&z=15";

            // == Filling data: ==

            if (!IsPostBack)
            {
                checkIfFull();
                checkIfJoined(user_id, match_id);
                fillDefaultSlots(Int32.Parse(MatchInfo[3]));
                fillSlotsTeam1(match_id);
                fillSlotsTeam2(match_id);
                fillCourtImages(courtImgs);
            }

            matchName.InnerText = MatchInfo[0];
            matchDate.InnerText = MatchInfo[1];

            courtName.InnerText = courtInfo[0];
            matchCity.InnerText = courtInfo[1];
            courtLocation.HRef = courtLocationUrl;
        }

        protected void JoinA_Click(object sender, EventArgs e)
        {

            Matches match = new Matches();

            if (!match.alreadyJoined(user_id, match_id)) // Not joined
            {
                match.joinMatch(user_id, match_id, 1);
            }
            else // Joined already = Leave then => Join
            {
                match.leaveMatch(user_id, match_id);
                match.joinMatch(user_id, match_id, 1);
            }

            Response.Redirect("~/MatchRoom.aspx?match_id=" + match_id);
        }


        protected void JoinB_Click(object sender, EventArgs e)
        {
            Matches match = new Matches();

            if (!match.alreadyJoined(user_id, match_id)) // Not joined
            {
                match.joinMatch(user_id, match_id, 2);
            }
            else // Joined already = Leave then => Join
            {
                match.leaveMatch(user_id, match_id);
                match.joinMatch(user_id, match_id, 2);
            }

            Response.Redirect("~/MatchRoom.aspx?match_id=" + match_id);
        }

        public void LeaveA_Click(object sender, EventArgs e)
        {
            //DELETE FROM [ssm_mvc_demo1].[dbo].[matchesPlayers] WHERE matchesPlayers_matchesId = '24' and matchesPlayers_userId = '25'

            Matches match = new Matches();

            match.leaveMatch(user_id, match_id);
            Response.Redirect("~/MatchRoom.aspx?match_id=" + match_id);
        }

        public void LeaveB_Click(object sender, EventArgs e)
        {
            Matches match = new Matches();

            match.leaveMatch(user_id, match_id);
            Response.Redirect("~/MatchRoom.aspx?match_id=" + match_id);
        }


        public void fillDefaultSlots(int cid)
        {

            Courts court = new Courts();
            string[] courtInfo = court.getCourtInfo(cid);


            for (int i = 0; i < Int32.Parse(courtInfo[2]) / 2; i++)
            {

                switch (i)
                {
                    case 0:
                        Div0.Visible = true;
                        break;
                    case 1:
                        Div1.Visible = true;
                        break;
                    case 2:
                        Div2.Visible = true;
                        break;
                    case 3:
                        Div3.Visible = true;
                        break;
                    case 4:
                        Div4.Visible = true;
                        break;
                    case 5:
                        Div5.Visible = true;
                        break;
                    case 6:
                        Div6.Visible = true;
                        break;
                    case 7:
                        Div7.Visible = true;
                        break;
                    case 8:
                        Div8.Visible = true;
                        break;
                    case 9:
                        Div9.Visible = true;
                        break;
                    case 10:
                        Div10.Visible = true;
                        break;
                }
            }

            for (int i = 0; i < Int32.Parse(courtInfo[2]) / 2; i++)
            {

                switch (i)
                {
                    case 0:
                        Div11.Visible = true;
                        break;
                    case 1:
                        Div12.Visible = true;
                        break;
                    case 2:
                        Div13.Visible = true;
                        break;
                    case 3:
                        Div14.Visible = true;
                        break;
                    case 4:
                        Div15.Visible = true;
                        break;
                    case 5:
                        Div16.Visible = true;
                        break;
                    case 6:
                        Div17.Visible = true;
                        break;
                    case 7:
                        Div18.Visible = true;
                        break;
                    case 8:
                        Div19.Visible = true;
                        break;
                    case 9:
                        Div20.Visible = true;
                        break;
                    case 10:
                        Div21.Visible = true;
                        break;

                }
            }

        }

        public void fillSlotsTeam1(string mid)
        {
            Matches match = new Matches();
            List<string> teamA = match.getTeam(mid, 1);

            for (int i = 0; i < teamA.Count(); i++)
            {

                Users user = new Users();
                string username = user.getUsername(teamA[i]);

                switch (i)
                {
                    case 0:
                        Div0.InnerText = username;
                        Div0.Attributes["class"] = "row d-flex justify-content-start my-2";
                        break;
                    case 1:
                        Div1.InnerText = username;
                        Div1.Attributes["class"] = "row d-flex justify-content-start my-2";
                        break;
                    case 2:
                        Div2.InnerText = username;
                        Div2.Attributes["class"] = "row d-flex justify-content-start my-2";
                        break;
                    case 3:
                        Div3.InnerText = username;
                        Div3.Attributes["class"] = "row d-flex justify-content-start my-2";
                        break;
                    case 4:
                        Div4.InnerText = username;
                        Div4.Attributes["class"] = "row d-flex justify-content-start my-2";
                        break;
                    case 5:
                        Div5.InnerText = username;
                        Div5.Attributes["class"] = "row d-flex justify-content-start my-2";
                        break;
                    case 6:
                        Div6.InnerText = username;
                        Div6.Attributes["class"] = "row d-flex justify-content-start my-2";
                        break;
                    case 7:
                        Div7.InnerText = username;
                        Div7.Attributes["class"] = "row d-flex justify-content-start my-2";
                        break;
                    case 8:
                        Div8.InnerText = username;
                        Div8.Attributes["class"] = "row d-flex justify-content-start my-2";
                        break;
                    case 9:
                        Div9.InnerText = username;
                        Div9.Attributes["class"] = "row d-flex justify-content-start my-2";
                        break;
                    case 10:
                        Div10.InnerText = username;
                        Div10.Attributes["class"] = "row d-flex justify-content-start my-2";
                        break;

                }
            }

        }

        public void fillSlotsTeam2(string mid)
        {

            Matches match = new Matches();
            List<string> teamA = match.getTeam(mid, 2);

            for (int i = 0; i < teamA.Count(); i++)
            {

                Users user = new Users();
                string username = user.getUsername(teamA[i]);

                switch (i)
                {
                    case 0:
                        Div11.InnerText = username;
                        Div11.Attributes["class"] = "row d-flex justify-content-end my-2";
                        break;
                    case 1:
                        Div12.InnerText = username;
                        Div12.Attributes["class"] = "row d-flex justify-content-end my-2";
                        break;
                    case 2:
                        Div13.InnerText = username;
                        Div13.Attributes["class"] = "row d-flex justify-content-end my-2";
                        break;
                    case 3:
                        Div14.InnerText = username;
                        Div14.Attributes["class"] = "row d-flex justify-content-end my-2";
                        break;
                    case 4:
                        Div15.InnerText = username;
                        Div15.Attributes["class"] = "row d-flex justify-content-end my-2";
                        break;
                    case 5:
                        Div16.InnerText = username;
                        Div16.Attributes["class"] = "row d-flex justify-content-end my-2";
                        break;
                    case 6:
                        Div17.InnerText = username;
                        Div17.Attributes["class"] = "row d-flex justify-content-end my-2";
                        break;
                    case 7:
                        Div18.InnerText = username;
                        Div18.Attributes["class"] = "row d-flex justify-content-end my-2";
                        break;
                    case 8:
                        Div19.InnerText = username;
                        Div19.Attributes["class"] = "row d-flex justify-content-end my-2";
                        break;
                    case 9:
                        Div20.InnerText = username;
                        Div20.Attributes["class"] = "row d-flex justify-content-end my-2";
                        break;
                    case 10:
                        Div21.InnerText = username;
                        Div21.Attributes["class"] = "row d-flex justify-content-end my-2";
                        break;
                }
            }

        }

        public void fillCourtImages(List<String> courtImgs)
        {


            int imgsCounter = 0;

            if (courtImgs != null)
            {
                for (int i = 0; i < courtImgs.Count(); i++)
                {

                    string src = courtImgs[i].Replace(@"\", "/");
                    imgsCounter++;

                    switch (i)
                    {
                        case 0:
                            img0.Attributes["src"] = src;
                            break;
                        case 1:
                            img1.Attributes["src"] = src;
                            break;
                        case 2:
                            img2.Attributes["src"] = src;
                            break;
                        case 3:
                            img3.Attributes["src"] = src;
                            break;
                        case 4:
                            img4.Attributes["src"] = src;
                            break;
                    }

                }

                if (courtImgs.Count() < 5)
                {

                    for (int i = 4; i >= imgsCounter; i--)
                    {

                        switch (i)
                        {
                            case 4:
                                imgblock4.Visible = false;
                                break;
                            case 3:
                                imgblock3.Visible = false;
                                break;
                            case 2:
                                imgblock2.Visible = false;
                                break;
                            case 1:
                                imgblock1.Visible = false;
                                break;
                            case 0:
                                imgblock0.Visible = false;
                                break;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {

                    switch (i)
                    {
                        case 4:
                            imgblock4.Visible = false;
                            break;
                        case 3:
                            imgblock3.Visible = false;
                            break;
                        case 2:
                            imgblock2.Visible = false;
                            break;
                        case 1:
                            imgblock1.Visible = false;
                            break;
                        case 0:
                            imgblock0.Visible = false;
                            break;
                    }
                }


            }

            if (courtImgs == null)
            {
                notFound.Visible = true;
            }

        }

        public void checkIfJoined(string uid, string mid)
        {

            //SELECT [matchesPlayers_userId] FROM [ssm_mvc_demo1].[dbo].[matchesPlayers] WHERE matchesPlayers_matchesId = '24' and matchesPlayers_userId = '26'

            string queryString = "SELECT [matchesPlayers_userId], [matchesPlayers_team]" +
                                "FROM [ssm_mvc_demo1].[dbo].[matchesPlayers] " +
                                "WHERE matchesPlayers_matchesId =@mid  AND	matchesPlayers_userId =@uid";



            using (SqlConnection connection = new SqlConnection(cs))
            {

                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Connection.Open();
                    command.Parameters.AddWithValue("@mid", Int32.Parse(mid));
                    command.Parameters.AddWithValue("@uid", Int32.Parse(uid));

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)// Is joined
                    {

                        reader.Read();
                        if (reader.GetValue(1).ToString() == "1")
                        { // TEAM A
                            JoinA.Visible = false;
                            LeaveA.Visible = true;
                            JoinB.Visible = true;
                            LeaveB.Visible = false;
                            int id = Int32.Parse(reader.GetValue(0).ToString());
                            int team = Int32.Parse(reader.GetValue(1).ToString());
                            //reader.Close();
                            //command.Connection.Close();
                            highlightUsername(id);
                        }
                        if (reader.GetValue(1).ToString() == "2")
                        { // TEAM B
                            JoinB.Visible = false;
                            LeaveB.Visible = true;
                            JoinA.Visible = true;
                            LeaveA.Visible = false;
                            int id = Int32.Parse(reader.GetValue(0).ToString());
                            int team = Int32.Parse(reader.GetValue(1).ToString());
                            //reader.Close();
                            //command.Connection.Close();
                            highlightUsername(id);
                        }
                    }
                    else// Not joined
                    {



                    }

                }
                catch (SqlException ex)
                {
                    for (int i = 0; i < ex.Errors.Count; i++)
                    {
                        errorMessages.Append("Index #" + i + "\n" +
                            "Message: " + ex.Errors[i].Message + "\n" +
                            "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                            "Source: " + ex.Errors[i].Source + "\n" +
                            "Procedure: " + ex.Errors[i].Procedure + "\n");
                    }
                    Console.WriteLine(errorMessages.ToString());
                }
                finally
                {
                    command.Connection.Close();
                }

            }

        }

        public void checkIfFull()
        {

            Matches match = new Matches();
            string[] matchInfo = match.getMatchInfo(match_id);
            Courts court = new Courts();
            string[] courtInfo = court.getCourtInfo(Int32.Parse(matchInfo[3]));

            string courtLimit = courtInfo[2];
            int teamLimit = Int32.Parse(courtInfo[2]) / 2;


            // Check if team A is full:
            List<string> teamA = match.getTeam(match_id, 1);

            if (teamA.Count() == teamLimit)// team A is full
            {
                if (!teamA.Contains(user_id))// if not current user:
                {
                    JoinA.Visible = false;
                    teamAfull.Visible = true;
                }
            }

            // Check if team B is full:
            List<string> teamB = match.getTeam(match_id, 2);

            if (teamB.Count() == teamLimit)// team B is full
            {
                if (!teamB.Contains(user_id))// if not current user:
                {
                    JoinB.Visible = false;
                    teamBfull.Visible = true;
                }
            }

        }

        public void highlightUsername(int uid)
        {
            Matches match = new Matches();
            Users user = new Users();
            string username = user.getUsername(uid.ToString());

            currentUser.Value = username;
            if (match.IsTeamFull(match_id, 1))// team A full
            {
                JoinA.Visible = false;
            }
            if (match.IsTeamFull(match_id, 2))// team B full
            {
                JoinB.Visible = false;
            }

        }


        public bool isCodeMatching(string code)
        {

            Matches matchCode = new Matches();
            string cd = matchCode.getPvtMatchCode(match_id);

            if (cd == code)
            {
                return true;
            }

            return false;
        }


        public bool isCaptain(string uid, string mid)
        {
            Matches match = new Matches();
            if (match.getMatchCaptainId(mid) == uid)
                return true;

            return false;
        }

        protected void GoPublic_Click(object sender, EventArgs e)
        {
            Matches match = new Matches();
            match.toggleMatchType(match_id, "Public");

            string[] matchInfo = match.getMatchInfo(match_id);
            //"MatchRoom.aspx?match_id=" + $(element).attr("id") + "&type=Public";
            if (matchInfo[2] == "Public")
                Response.Redirect("~/MatchRoom.aspx?match_id=" + match_id + "&type=Public");
            else
                Response.Redirect("~/Default.aspx");
        }

        protected void GoPrivate_Click(object sender, EventArgs e)
        {
            Matches match = new Matches();
            string code = match.getPvtMatchCode(match_id);

            if (match.toggleMatchType(match_id, "Private"))
                Response.Redirect("~/MatchRoom.aspx?match_id=" + match_id + "&type=Private" + "&code=" + code);
            else
                Response.Redirect("~/Default.aspx");

        }

        protected void inviteMatch_Click(object sender, EventArgs e)
        {

            Matches match = new Matches();

            Response.Redirect("/FriendList.aspx?status=3&userid=" + user_id + "&matchid=" + match_id);

        }
    }

}