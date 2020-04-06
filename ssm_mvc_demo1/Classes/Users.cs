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

    public class Users
    {
        // Users data/variables:
        public string id;
        public string username;
        public string password;
        public string email;
        public string avatar;
        public string played;
        public string name;
        public string position;
        public string bio;
        public string profile;
        public string errorMessage;
        //===========================



        static string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        StringBuilder errorMessages = new StringBuilder();

        public Users()
        {

        }

        public Users(string username)
        {
            this.username = username;

        }
        public bool login(string username, string password)
        {


            string queryString = "USE ssm_mvc_demo1 SELECT user_id, user_username, user_password FROM dbo.users WHERE user_username=@username AND user_password=@password";
            bool status = false;
            using (SqlConnection connection = new SqlConnection(cs))
            {

                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Connection.Open();

                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())// check if selection query does have a returned row:
                    {

                        // HERE YOU CAN FILL THE CURRENT USER DATA FROM THE RETURNED QUERY :
                        this.id = reader.GetValue(0).ToString();
                        this.username = reader.GetValue(1).ToString();
                        // password
                        // email
                        // name
                        // age
                        // city
                        // pos
                        // bio
                        status = true;
                    }
                    else// IF NO USER FOUND:
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
                    errorMessage = errorMessages.ToString();
                }
                finally
                {
                    command.Connection.Close();


                }
            }
            return status;
        }

        public string signup(string username, string password, string email)
        {
            Users user = new Users();
            string userid = "";
            Random rnd = new Random();
            string path = System.Web.HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + "/images/avatars/";

            string avatar = path + rnd.Next(1, 6) + ".png";

            StringBuilder errorMessages = new StringBuilder();
            string queryString = "USE ssm_mvc_demo1 INSERT INTO [dbo].[users] " +
                "([user_username] ,[user_password] ,[user_email], [user_avatar])" +
                "output INSERTED.user_id VALUES (@username, @pwd, @email, @avatar)";


            using (SqlConnection connection = new SqlConnection(cs))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Connection.Open();
                    command.Parameters.AddWithValue("username", username);
                    command.Parameters.AddWithValue("pwd", password);
                    command.Parameters.AddWithValue("email", email);
                    command.Parameters.AddWithValue("avatar", avatar);

                    userid = command.ExecuteScalar().ToString();

                    // YOU HAVE TO CHECK IF USERNAME IS UNIQUE AND THERE IS NO DUPLICATES.
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

            return userid;
        }

        public Users getUserInfo(string userid)
        {
            //[user_id][user_username][user_password][user_played][user_email][user_position][user_bio]

            string queryString = "USE ssm_mvc_demo1 SELECT " +
                                "user_id, user_username, user_email, user_played, user_bio, user_avatar, user_position " +
                                "FROM users WHERE user_id=@uid";

            Users user = new Users();

            using (SqlConnection connection = new SqlConnection(cs))
            {

                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Connection.Open();
                    command.Parameters.AddWithValue("@uid", userid);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())// check if selection query does have a returned row:
                    {

                        user.id = reader.GetValue(0).ToString();
                        user.username = reader.GetValue(1).ToString();
                        user.email = reader.GetValue(2).ToString();
                        user.played = reader.GetValue(3).ToString();
                        user.bio = reader.GetValue(4).ToString();
                        user.avatar = reader.GetValue(5).ToString();
                        user.position = reader.GetValue(6).ToString();

                    }
                    else// IF NO USER FOUND:
                    {

                        user.id = "Not found";
                        user.username = "Not found";
                        user.email = "Not found";
                        user.played = "Not found";
                        user.bio = "Not found";

                    }

                    reader.Close();

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
                    user.id = errorMessages.ToString();
                    user.username = errorMessages.ToString();
                    user.email = errorMessages.ToString();
                    user.played = errorMessages.ToString();
                    user.bio = errorMessages.ToString();
                }
                finally
                {
                    command.Connection.Close();
                }
            }// END OF USING

            return user;
        }

        public bool setUserPos(string pos, string bio, string uid)
        {

            bool status = false;
            string queryString = "UPDATE [dbo].[users] SET user_position=@pos, user_bio=@bio WHERE user_id=@id";


            using (SqlConnection connection = new SqlConnection(cs))
            {

                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Connection.Open();

                    command.Parameters.AddWithValue("@pos", pos);
                    command.Parameters.AddWithValue("@bio", bio);
                    command.Parameters.AddWithValue("@id", uid);


                    if (command.ExecuteNonQuery() != 0)// number of affected rows:
                    {
                        status = true;
                    }
                    else
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
            return status;
        }

        public string getUsername(string id)
        {
            string queryString = "USE ssm_mvc_demo1 SELECT user_username FROM dbo.users WHERE user_id=@id";
            string username = null;
            using (SqlConnection connection = new SqlConnection(cs))
            {

                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Connection.Open();
                    command.Parameters.AddWithValue("@id", id);

                    username = command.ExecuteScalar().ToString();

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
                    errorMessage = errorMessages.ToString();

                }
                finally
                {
                    command.Connection.Close();
                }
            }// END OF USING

            return username;
        }


        public bool setUserBio(string username, string bio)
        {

            string queryString = "USE ssm_mvc_demo1 UPDATE dbo.users SET user_bio=@bio WHERE user_username=@username";
            bool status = false;
            using (SqlConnection connection = new SqlConnection(cs))
            {

                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Connection.Open();

                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@bio", bio);

                    int row = command.ExecuteNonQuery();

                    if (row != 0)// check if selection query does have a returned row:
                    {
                        status = true;
                    }
                    else// IF NO USER FOUND:
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

            return status;
        }

        public List<string[]> getFriendList(string uid, int status)
        {
            List<string[]> friends = new List<string[]>();
            string[] ids = new string[6];


            string queryString = "SELECT friendList.friendList_frndid, friendList.friendList_status " +
                                "FROM users " +
                                "JOIN friendList ON users.user_id = friendList.friendList_userid " +
                                "WHERE users.user_id=@uid AND friendList.friendList_status=@status";

            using (SqlConnection connection = new SqlConnection(cs))
            {

                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Connection.Open();
                    command.Parameters.AddWithValue("@uid", uid);
                    command.Parameters.AddWithValue("@status", status);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            string[] frndInfo = new string[2];
                            // ID:
                            //reader.GetValue(0).ToString();
                            Users user = new Users();
                            //string id = reader.GetValue(0).ToString();
                            //string username = user.getUsername(id);
                            frndInfo[0] = reader.GetValue(0).ToString();
                            frndInfo[1] = user.getUsername(reader.GetValue(0).ToString()) + "#" + reader.GetValue(0);
                            friends.Add(frndInfo);

                        }
                    }

                    else
                    {
                        friends = null;
                    }

                    reader.Close();

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
                    //friends.Add(errorMessages.ToString());
                }
                finally
                {
                    command.Connection.Close();
                }
            }

            return friends;
        }

        public List<string[]> getRequestedList(string uid, int status)
        {
            List<string[]> friends = new List<string[]>();


            string queryString = "SELECT friendList.friendList_frndid " +
                                "FROM users " +
                                "JOIN friendList ON users.user_id = friendList.friendList_userid " +
                                "WHERE users.user_id=@uid AND friendList.friendList_status=@status AND friendList.friendList_sender!=@sender";

            using (SqlConnection connection = new SqlConnection(cs))
            {

                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Connection.Open();
                    command.Parameters.AddWithValue("@uid", uid);
                    command.Parameters.AddWithValue("@status", status);
                    command.Parameters.AddWithValue("@sender", uid);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            string[] frndInfo = new string[2];
                            Users user = new Users();
                            frndInfo[0] = reader.GetValue(0).ToString();
                            frndInfo[1] = user.getUsername(reader.GetValue(0).ToString());
                            friends.Add(frndInfo);

                        }
                    }

                    else
                    {
                        friends = null;
                    }


                    reader.Close();
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
                    //friends.Add(errorMessages.ToString());
                }
                finally
                {
                    command.Connection.Close();
                }
            }

            return friends;
        }

        public int isRequested(string uid, string requid)
        {
            int status = -1;

            string queryString = "SELECT friendList.friendList_status " +
                                "FROM users " +
                                "JOIN friendList   ON users.user_id = friendList.friendList_userid " +
                                "WHERE users.user_id=@requid  " +
                                "AND friendList.friendList_frndid=@uid";


            using (SqlConnection connection = new SqlConnection(cs))
            {

                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Connection.Open();
                    command.Parameters.AddWithValue("@requid", requid);
                    command.Parameters.AddWithValue("@uid", uid);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)// check if selection query does have a returned row:
                    {
                        reader.Read();
                        if (reader.GetValue(0).ToString() == "0")
                            status = 0;
                        if (reader.GetValue(0).ToString() == "1")
                            status = 1;
                    }
                    else
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
                    //friends.Add(errorMessages.ToString());
                }
                finally
                {
                    command.Connection.Close();
                }


            }

            return status;
        }

        public bool sendRequest(string uid, string requid)
        {
            bool status = false;
            // ADD: put current userid into the requestedid FreindList table with a status of pending(0)
            //INSERT INTO [dbo].[friendList]  ([friendList_frndid], [friendList_userid], [friendList_status])  VALUES  ( @uid, @requid, @status)

            string queryString = "INSERT INTO [dbo].[friendList] " +
                                "([friendList_frndid], [friendList_userid], [friendList_status], [friendList_sender]) " +
                                "VALUES ( @uid, @requid, @status, @sender) " +
                                "INSERT INTO [dbo].[friendList] " +
                                "([friendList_frndid], [friendList_userid], [friendList_status], [friendList_sender]) " +
                                "VALUES ( @uid1, @requid1, @status1, @sender1) ";

            using (SqlConnection connection = new SqlConnection(cs))
            {

                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Connection.Open();

                    command.Parameters.AddWithValue("@uid", uid);
                    command.Parameters.AddWithValue("@requid", requid);
                    command.Parameters.AddWithValue("@status", 0);
                    command.Parameters.AddWithValue("@sender", uid);
                    command.Parameters.AddWithValue("@uid1", requid);
                    command.Parameters.AddWithValue("@requid1", uid);
                    command.Parameters.AddWithValue("@status1", 0);
                    command.Parameters.AddWithValue("@sender1", uid);

                    if (command.ExecuteNonQuery() != 0)// check if selection query does have a returned row:
                    {
                        status = true;
                    }
                    else// IF NO USER FOUND:
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

            return status;
        }

        public bool acceptFriend(string uid, string reqid)
        {
            bool status = false;
            string queryString = "UPDATE [dbo].[friendList] SET friendList.friendList_status='1' WHERE friendList_frndid=@requested AND friendList_userid=@uid " +
                                "UPDATE [dbo].[friendList] SET friendList.friendList_status='1' WHERE friendList_frndid=@otherrequested AND friendList_userid=@otheruid";


            using (SqlConnection connection = new SqlConnection(cs))
            {

                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Connection.Open();

                    command.Parameters.AddWithValue("@uid", uid);
                    command.Parameters.AddWithValue("@requested", reqid);
                    command.Parameters.AddWithValue("@otherrequested", uid);
                    command.Parameters.AddWithValue("@otheruid", reqid);


                    if (command.ExecuteNonQuery() != 0)// number of affected rows:
                    {
                        status = true;
                    }
                    else
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

            return status;
        }
        public bool removeFriend(string uid, string removed)
        {
            bool status = false;
            string queryString = "DELETE FROM [dbo].[friendList] WHERE friendList_frndid=@removed AND friendList_userid=@uid " +
                "DELETE FROM [dbo].[friendList] WHERE friendList_frndid=@removed1 AND friendList_userid=@uid1 ";
            //DELETE FROM [dbo].[friendList] WHERE friendList_frndid = '21' AND friendList_userid = '18'

            using (SqlConnection connection = new SqlConnection(cs))
            {

                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Connection.Open();

                    command.Parameters.AddWithValue("@uid", uid);
                    command.Parameters.AddWithValue("@removed", removed);
                    command.Parameters.AddWithValue("@uid1", removed);
                    command.Parameters.AddWithValue("@removed1", uid);


                    if (command.ExecuteNonQuery() != 0)// number of affected rows:
                    {
                        status = true;
                    }
                    else
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


            return status;
        }


        public List<string[]> getMatchInvites(string uid)
        {

            List<string[]> matchInvites = new List<string[]>();
            Matches match = new Matches();
            string queryString = "SELECT invite_match, invite_sender FROM invites WHERE invite_resever=@uid";

            using (SqlConnection connection = new SqlConnection(cs))
            {

                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Connection.Open();
                    command.Parameters.AddWithValue("@uid", uid);


                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {

                        while (reader.Read() && match.checkMatchAvailability(reader.GetValue(0).ToString()))
                        {
                            string[] info = new string[3];

                            //MATCH ID
                            info[0] = reader.GetValue(0).ToString();
                            //SENDER ID
                            info[1] = reader.GetValue(1).ToString();

                            matchInvites.Add(info);

                        }
                    }
                    else
                    {
                        matchInvites = null;
                    }

                    reader.Close();

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
                    string[] err = new string[1];
                    err[0] = errorMessages.ToString();
                    matchInvites.Add(err);
                }
                finally
                {
                    command.Connection.Close();
                }
            }

            return matchInvites;
        }
    }


}
