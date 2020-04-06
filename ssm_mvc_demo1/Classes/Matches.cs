using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace ssm_mvc_demo1
{
    public class Matches
    {

        public string id;
        public string name;
        public string city;
        public string time;
        public string date;
        public string datetime;
        public string type;
        public string field;

        static string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        StringBuilder errorMessages = new StringBuilder();

        public Matches()
        {

        }

        public bool createMatch(string name, string type, string field, string d, string ti, string uid)
        {

            Guid guid = Guid.NewGuid();
            string code = guid.ToString();
            bool status = false;
            this.name = name;
            this.type = type;
            this.field = field;

            // datetime
            this.time = ti.Substring(0, 5) + ":00";
            this.date = d;
            this.datetime = date + " " + time;
            // == == == 

            string queryString = "USE ssm_mvc_demo1 " +
                                "INSERT INTO matches(match_name, match_date, match_type, match_field, match_captain, match_code)" +
                                "OUTPUT INSERTED.match_id VALUES(@name, @date, @type, @field, @captain, @code)";


            using (SqlConnection connection = new SqlConnection(cs))
            {

                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Connection.Open();
                    command.Parameters.AddWithValue("@name", this.name);
                    command.Parameters.AddWithValue("@date", datetime);
                    command.Parameters.AddWithValue("@type", this.type);
                    command.Parameters.AddWithValue("@field", this.field);
                    command.Parameters.AddWithValue("@captain", uid);
                    command.Parameters.AddWithValue("@code", code);
                    id = command.ExecuteScalar().ToString();
                    
                    status = true;
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
                    //msg = errorMessages.ToString();
                }
                finally
                {
                    command.Connection.Close();
                }
            }

            return status;
        }

        public string[] getMatchInfo(string id)
        {

            string[] MatchInfo = new string[4];
            string queryString = "USE ssm_mvc_demo1 SELECT match_name, match_date, match_type, match_field FROM matches WHERE match_id=@id";

            using (SqlConnection connection = new SqlConnection(cs))
            {

                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Connection.Open();
                    command.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())// check if selection query does have a returned row:
                    {

                        //FILL MATCH DATA ARRAY FROM THE RETURNED QUERY :

                        // == MATCHINFO ARRAY : ==
                        //0 = NAME //1 = DATE
                        //2 = TYPE //3 = FIELD

                        for (int i = 0; i < MatchInfo.Length; i++)
                        {
                            MatchInfo[i] = reader[i].ToString();
                        }

                        reader.Close();
                        command.Connection.Close();
                    }
                    else// IF NO MATCH FOUND:
                    {

                    }
                    reader.Close();
                    SqlConnection.ClearAllPools();
                    return MatchInfo;

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

            return MatchInfo;
        }

        public List<String> getCourtImages(string cid)
        {
            List<String> images = new List<string>();
            string queryString = "USE ssm_mvc_demo1 SELECT courtImgs.courtImgs_url FROM courts JOIN courtImgs ON courts.court_id = courtImgs.courtImgs_courtId WHERE courts.court_id=@id";

            using (SqlConnection connection = new SqlConnection(cs))
            {

                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Connection.Open();
                    command.Parameters.AddWithValue("@id", cid);

                    SqlDataReader reader = command.ExecuteReader();
                    //int len = reader.

                    if (reader.Read())// check if selection query does have a returned row:
                    {

                        while (reader.Read())
                        {

                            images.Add(reader["courtImgs_url"].ToString());

                        }

                    }
                    else// IF NO IMAGES FOUND:
                    {

                        images.Add("Images not found. locaion: ELSE BLOCK");

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
                    images.Add(errorMessages.ToString());
                }
            }

            return images;

        }

        public List<Courts> GetCourts()
        {

            List<Courts> courtsList = new List<Courts>();

            string queryString = "USE ssm_mvc_demo1 SELECT * FROM courts";

            using (SqlConnection connection = new SqlConnection(cs))
            {

                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        Courts court = new Courts();

                        court.id = (int)reader["court_id"];
                        court.name = reader["court_name"].ToString();
                        court.city = reader["court_city"].ToString();
                        court.limit = (int)reader["court_limit"];
                        court.lat = reader["court_lat"].ToString();
                        court.lng = reader["court_lng"].ToString();

                        courtsList.Add(court);
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

                    Courts court = new Courts();
                    Console.WriteLine(errorMessages.ToString());
                    court.name = errorMessages.ToString();

                    courtsList.Add(court);

                    return courtsList;
                }
                finally
                {
                    command.Connection.Close();
                }
            }


            return courtsList;

        }

        public List<Matches> getUpcoming()
        {

            List<Matches> matchesList = new List<Matches>();

            string queryString = "USE ssm_mvc_demo1 SELECT match_id, match_name, match_date FROM matches WHERE match_date between GETDATE() and GETDATE()+6";

            using (SqlConnection connection = new SqlConnection(cs))
            {

                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        Matches match = new Matches();

                        match.id = reader[0].ToString();
                        match.name = reader[1].ToString();
                        match.date = reader[2].ToString();


                        matchesList.Add(match);
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

                    Matches error = new Matches();
                    Console.WriteLine(errorMessages.ToString());
                    error.name = errorMessages.ToString();

                    matchesList.Add(error);

                }
            }

            return matchesList;
        }

        public bool joinMatch(string uid, string mid, int team)
        {

            string queryString = "USE ssm_mvc_demo1 INSERT INTO[dbo].[matchesPlayers]" +
                                    "(matchesPlayers_matchesId, matchesPlayers_userId, matchesPlayers_team)" +
                                    "VALUES(@mid, @uid, @team)";


            using (SqlConnection connection = new SqlConnection(cs))
            {

                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Connection.Open();
                    command.Parameters.AddWithValue("@mid", mid);
                    command.Parameters.AddWithValue("@uid", uid);
                    command.Parameters.AddWithValue("@team", team);
                    command.ExecuteNonQuery();

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
                    return false;
                }
                finally
                {
                    command.Connection.Close();
                }
            }

            return true;
        }

        public bool leaveMatch(string uid, string mid)
        {

            //DELETE FROM[ssm_mvc_demo1].[dbo].[matchesPlayers] WHERE matchesPlayers_matchesId = '24' and matchesPlayers_userId = '25'

            string queryString = "DELETE FROM[ssm_mvc_demo1].[dbo].[matchesPlayers] " +
                                "WHERE matchesPlayers_matchesId=@mid and matchesPlayers_userId=@uid";
            using (SqlConnection connection = new SqlConnection(cs))
            {

                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Connection.Open();
                    command.Parameters.AddWithValue("@mid", mid);
                    command.Parameters.AddWithValue("@uid", uid);

                    command.ExecuteNonQuery();

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
                    return false;
                }
                finally
                {
                    command.Connection.Close();
                }
            }// END OF USING

            return true;
        }

        public bool alreadyJoined(string uid, string mid)
        {
            //SELECT [matchesPlayers_userId] FROM [ssm_mvc_demo1].[dbo].[matchesPlayers] WHERE matchesPlayers_matchesId = '24' and matchesPlayers_userId = '25'

            string queryString = "SELECT [matchesPlayers_userId] FROM [ssm_mvc_demo1].[dbo].[matchesPlayers] WHERE " +
                                    "matchesPlayers_matchesId=@mid and matchesPlayers_userId=uid";
            using (SqlConnection connection = new SqlConnection(cs))
            {

                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Connection.Open();
                    command.Parameters.AddWithValue("@mid", mid);
                    command.Parameters.AddWithValue("@uid", id);

                    SqlDataReader reader = command.ExecuteReader();

                    return reader.HasRows;

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
            }// END OF USING

            return true;
        }

        public List<string> getTeam(string mid, int team)
        {

            //"SELECT [matchesPlayers_userId] FROM [ssm_mvc_demo1].[dbo].[matchesPlayers] WHERE matchesPlayers_matchesId =@mid  AND	matchesPlayers_team =@team"

            List<string> teamA = new List<string>();
            string queryString = "SELECT [matchesPlayers_userId] " +
                                "FROM [ssm_mvc_demo1].[dbo].[matchesPlayers] " +
                                "WHERE matchesPlayers_matchesId =@mid  AND	matchesPlayers_team =@team";

            using (SqlConnection connection = new SqlConnection(cs))
            {

                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Connection.Open();
                    command.Parameters.AddWithValue("@mid", Int32.Parse(mid));
                    command.Parameters.AddWithValue("@team", team);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            teamA.Add(reader.GetValue(0).ToString());

                        }
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
                    teamA.Add(errorMessages.ToString());
                }
                finally
                {
                    command.Connection.Close();
                }

            }
            return teamA;
        }

        public bool IsTeamFull(string mid, int team)
        {
            Matches match = new Matches();
            string[] matchInfo = match.getMatchInfo(mid);

            List<string> teamList = this.getTeam(mid, team);
            Courts court = new Courts();

            string[] courtInfo = court.getCourtInfo(Int32.Parse(matchInfo[3]));

            string courtLimit = courtInfo[2];
            int teamLimit = Int32.Parse(courtInfo[2]) / 2;

            if (teamList.Count() == teamLimit)
            {// team is full
                return true;
            }

            return false;
        }
        
        public List<Matches> getMyOpenMatches(string uid)
        {
            List<Matches> openMatches = new List<Matches>();
            //USE ssm_mvc_demo1 SELECT match_id, match_name, CONVERT(VARCHAR(10), match_date, 111) AS match_date FROM matches WHERE match_date > GETDATE() AND match_captain='18'
            string queryString = "USE ssm_mvc_demo1 " +
                                "SELECT match_id, match_name, CONVERT(VARCHAR(10), match_date, 111) AS match_date " +
                                "FROM matches " +
                                "WHERE match_date >= GETDATE() AND match_captain=@uid";

            using (SqlConnection connection = new SqlConnection(cs))
            {

                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Connection.Open();
                    command.Parameters.AddWithValue("@uid", uid);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        Matches match = new Matches();

                        match.id = reader[0].ToString();
                        match.name = reader[1].ToString();
                        match.date = reader[2].ToString();

                        openMatches.Add(match);
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

                    Matches error = new Matches();
                    Console.WriteLine(errorMessages.ToString());
                    error.name = errorMessages.ToString();

                }
            }

            return openMatches;
        }// AS A CAPTAIN

        public List<Matches> getMyEndedMatches(string uid)
        {

            //USE ssm_mvc_demo1 SELECT match_id, match_name, CONVERT(VARCHAR(10), match_date, 111) AS match_date FROM matches WHERE match_date < GETDATE() AND match_captain='18'

            List<Matches> endedMatches = new List<Matches>();
            //USE ssm_mvc_demo1 SELECT match_id, match_name, CONVERT(VARCHAR(10), match_date, 111) AS match_date FROM matches WHERE match_date > GETDATE() AND match_captain='18'
            string queryString = "USE ssm_mvc_demo1 " +
                                "SELECT match_id, match_name, CONVERT(VARCHAR(10), match_date, 111) AS match_date " +
                                "FROM matches " +
                                "WHERE match_date < GETDATE() AND match_captain=@uid";

            using (SqlConnection connection = new SqlConnection(cs))
            {

                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Connection.Open();
                    command.Parameters.AddWithValue("@uid", uid);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        Matches match = new Matches();

                        match.id = reader[0].ToString();
                        match.name = reader[1].ToString();
                        match.date = reader[2].ToString();

                        endedMatches.Add(match);
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

                    Matches error = new Matches();
                    Console.WriteLine(errorMessages.ToString());

                }
            }

            return endedMatches;

        }// AS A CAPTAIN

        public List<Matches> getPlayerJoinedMatches(string uid)// AS A PLAYER NOT ENDED
        {
            List<Matches> joinedMatches = new List<Matches>();

            string queryString = "SELECT matchesPlayers_matchesId " +
                                "FROM matchesPlayers " +
                                "INNER JOIN users " +
                                "ON matchesPlayers_userId = users.user_id " +
                                "INNER JOIN matches " +
                                "ON matchesPlayers_matchesId = matches.match_id " +
                                "WHERE users.user_id=@uid AND matches.match_date > GETDATE()";

            //string queryString = "SELECT matchesPlayers_matchesId FROM matchesPlayers INNER JOIN users ON matchesPlayers_userId = users.user_id INNER JOIN matches ON matchesPlayers_matchesId = matches.match_id WHERE users.user_id=@uid AND matches.match_date > GETDATE()";

            using (SqlConnection connection = new SqlConnection(cs))
            {

                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Connection.Open();
                    command.Parameters.AddWithValue("@uid", uid);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        Matches match = new Matches();

                        match.id = reader[0].ToString();
                        match.name = match.getMatchInfo(reader[0].ToString())[0];



                        joinedMatches.Add(match);
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

                    Matches error = new Matches();
                    Console.WriteLine(errorMessages.ToString());
                    error.name = errorMessages.ToString();

                }
            }



            return joinedMatches;
        }

        public string getPvtMatchCode(string mid)
        {

            StringBuilder errorMessages = new StringBuilder();
            string queryString = "USE ssm_mvc_demo1 SELECT match_code " +
                " FROM matches WHERE match_id=@mid";
            string code = "";

            using (SqlConnection connection = new SqlConnection(cs))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Connection.Open();
                    command.Parameters.AddWithValue("@mid", mid);

                    code = command.ExecuteScalar().ToString();

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
                    code = errorMessages.ToString();
                }
                finally
                {
                    command.Connection.Close();
                }

            }
            return code;

        }

        public string getMatchCaptainId(string mid)
        {

            StringBuilder errorMessages = new StringBuilder();

            string queryString = "USE ssm_mvc_demo1 SELECT match_captain " +
                " FROM matches WHERE match_id=@mid";
            string cptn = "";

            using (SqlConnection connection = new SqlConnection(cs))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Connection.Open();
                    command.Parameters.AddWithValue("@mid", mid);

                    cptn = command.ExecuteScalar().ToString();

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
                    cptn = errorMessages.ToString();
                }
                finally
                {
                    command.Connection.Close();
                }

            }

            return cptn;
        }

        public bool toggleMatchType(string mid, string type)
        {
            bool status = false;
            StringBuilder errorMessages = new StringBuilder();

            string queryString = "USE ssm_mvc_demo1 UPDATE matches " +
                "SET match_type=@type FROM matches WHERE match_id=@mid";
            string cptn = "";

            using (SqlConnection connection = new SqlConnection(cs))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Connection.Open();
                    command.Parameters.AddWithValue("@mid", mid);
                    command.Parameters.AddWithValue("@type", type);
                    //command.ExecuteScalar
                    if (command.ExecuteNonQuery() != 0)
                        status = true;

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
                    cptn = errorMessages.ToString();
                }
                finally
                {
                    command.Connection.Close();
                }

            }

            return status;
        }

        public string sendMatchInvite(string receiveid, string senderid, string mid)
        {
            //[invite_id] [invite_resever] [invite_sender] [invite_read] [invite_match]

            Matches match = new Matches();
            string code = match.getPvtMatchCode(mid);

            string queryString = "USE ssm_mvc_demo1 INSERT INTO invites (invite_resever, invite_sender, invite_read, invite_match, invite_code)" +
                                 " VALUES (@resever, @sender, @read, @match, @code)";
            string status = "";
            using (SqlConnection connection = new SqlConnection(cs))
            {

                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Connection.Open();

                    command.Parameters.AddWithValue("@resever", receiveid);
                    command.Parameters.AddWithValue("@sender", senderid);
                    command.Parameters.AddWithValue("@read", 0);
                    command.Parameters.AddWithValue("@match", mid);
                    command.Parameters.AddWithValue("@code", code);

                    if (command.ExecuteNonQuery() > 0)
                        status = "good";
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
                    status = errorMessages.ToString();

                }
                finally
                {
                    command.Connection.Close();
                }
            }

            return status;


        }

        public bool checkMatchAvailability(string mid)
        {

            StringBuilder errorMessages = new StringBuilder();
            string queryString = "USE ssm_mvc_demo1 SELECT match_id " +
                                 " FROM matches WHERE match_id=@mid";


            using (SqlConnection connection = new SqlConnection(cs))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Connection.Open();
                    command.Parameters.AddWithValue("@mid", mid);
                    SqlDataReader reader = command.ExecuteReader();

                    if (!reader.HasRows)
                        return false;

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
            return true;

        }

    }


}