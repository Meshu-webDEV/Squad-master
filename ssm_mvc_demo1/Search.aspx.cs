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
    public partial class Search : System.Web.UI.Page
    {

        static string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        StringBuilder errorMessages = new StringBuilder();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["type"] as string != null)
            {
                string type = Request.QueryString["type"].ToString();
                string query = Request.QueryString["query"].ToString();

                int filter = Int32.Parse(type);

                switch (filter)
                {
                    case 1:
                        searchUser(query);
                        break;
                    case 2:
                        searchMatch(query);
                        break;
                    case 3:
                        searchCourt(query);
                        break;
                }
            }
            // Filter: 1 = User // 2 = Match // 3 = Court


        }

        protected void Search_Click(object sender, EventArgs e)
        {
            string type = searchFilter.SelectedValue;
            string query = searchQ.Text;

            Response.Redirect("~/Search.aspx?type=" + type + "&query=" + query);

        }

        public void searchUser(string query)
        {

            string queryString = "SELECT user_username, user_id FROM dbo.users WHERE user_username LIKE '%" + query + "%'";

            using (SqlConnection connection = new SqlConnection(cs))
            {

                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string username = reader.GetValue(0).ToString();
                            string userid = reader.GetValue(1).ToString();
                            string domain = System.Web.HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + "/";
                            string href = domain + "Profile.aspx?type=2&userid=" + userid;
                            string element = "<a href='" + href + "' class='remove-href'> " +
                                                "<div class='w-100 my-3 result p-3'> " +
                                                    "<h5>" + username + "</h5> " +
                                                "</div> " +
                                            "</a>  " +
                                        "<hr class='my-3' />";

                            searchResults.InnerHtml += element;

                        }
                        reader.Close();
                    }
                    else
                    {
                        searchResults.InnerHtml = "<h5 style='opacity:0.6; width: 100% !important; text-align:center;'> No User was found </h5>";
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
                    errorMsg.InnerText = errorMessages.ToString();
                }
                finally
                {
                    command.Connection.Close();
                }
            }


        }
        public void searchMatch(string query)
        {
            //USE ssm_mvc_demo1 SELECT match_id FROM dbo.matches WHERE match_name LIKE '%Match%'
            string queryString = "SELECT match_id, match_name, match_type FROM dbo.matches WHERE match_name LIKE '%" + query + "%'";

            using (SqlConnection connection = new SqlConnection(cs))
            {

                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (reader.GetValue(2).ToString() == "Public")
                            {
                                string matchid = reader.GetValue(0).ToString();
                                string matchname = reader.GetValue(1).ToString();
                                string domain = System.Web.HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + "/";
                                string href = domain + "Matchroom.aspx?match_id=" + matchid;
                                string element = "<a href='" + href + "' class='remove-href'> " +
                                                    "<div class='w-100 my-3 result p-3'> " +
                                                        "<h5>" + matchname + "</h5> " +
                                                    "</div> " +
                                                "</a>  " +
                                            "<hr class='my-3' />";

                                searchResults.InnerHtml += element;
                            }
                        }

                    }
                    else
                    {
                        searchResults.InnerHtml = "<h5 style='opacity:0.6; width: 100% !important; text-align:center;'> No match was found </h5>";
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
                    errorMsg.InnerText = errorMessages.ToString();
                }
                finally
                {
                    command.Connection.Close();
                }
            }

        }

        public void searchCourt(string query)
        {
            //USE ssm_mvc_demo1 SELECT court_id, court_name FROM courts WHERE court_name LIKE '%test%'
            string queryString = "USE ssm_mvc_demo1 SELECT court_id, court_name FROM courts WHERE court_name LIKE '%" + query + "%'";

            using (SqlConnection connection = new SqlConnection(cs))
            {

                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string courtid = reader.GetValue(0).ToString();
                            string courtname = reader.GetValue(1).ToString();
                            string domain = System.Web.HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + "/";
                            string href = domain + "Court.aspx?courtId=" + courtid;
                            string element = "<a href='" + href + "' class='remove-href'> " +
                                                "<div class='w-100 my-3 result p-3'> " +
                                                    "<h5>" + courtname + "</h5> " +
                                                "</div> " +
                                            "</a>  " +
                                        "<hr class='my-3' />";

                            searchResults.InnerHtml += element;

                        }
                    }
                    else
                    {
                        searchResults.InnerHtml = "<h5 style='opacity:0.6; width: 100% !important; text-align:center;'> No field was found </h5>";
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
                    errorMsg.InnerText = errorMessages.ToString();
                }
                finally
                {
                    command.Connection.Close();
                }
            }

        }



    }
}