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
using System.IO;

namespace ssm_mvc_demo1
{
    public class Courts
    {
        public int id;
        public string name;
        public string city;
        public int limit;
        public string lat;
        public string lng;
        public string[] images;


        static string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        StringBuilder errorMessages = new StringBuilder();

        public Courts()
        {

        }

        public Courts(string name, string city, int limit, string lat, string lng)
        {
            this.name = name;
            this.city = city;
            this.limit = limit;
            this.lat = lat;
            this.lng = lng;
        }

        public bool addField()
        {


            StringBuilder errorMessages = new StringBuilder();
            string queryString = "USE ssm_mvc_demo1 INSERT INTO [dbo].[courts] " +
                "([court_name] ,[court_city] ,[court_limit] ,[court_lat] ,[court_lng])" +
                "output INSERTED.court_id VALUES (@name, @city, @limit, @lat, @lng)";


            using (SqlConnection connection = new SqlConnection(cs))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Connection.Open();
                    command.Parameters.AddWithValue("name", this.name);
                    command.Parameters.AddWithValue("city", this.city);
                    command.Parameters.AddWithValue("limit", this.limit);
                    command.Parameters.AddWithValue("lat", this.lat);
                    command.Parameters.AddWithValue("lng", this.lng);
                    this.id = (int)command.ExecuteScalar();


                    return true;
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

            return false;
        }

        public string addImages(int id, List<String> img, string path)
        {// http://localhost:1231

            for (int j = 0; j < img.Count; j++)
            {

                StringBuilder errorMessages = new StringBuilder();
                string queryString = "USE ssm_mvc_demo1 INSERT INTO [dbo].[courtImgs] " +
                    "([courtImgs_url] ,[courtImgs_courtId]) VALUES (@url, @id)";

                string url = path + "\\FieldImages\\" + id + "\\" + img[j];


                using (SqlConnection connection = new SqlConnection(cs))
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    try
                    {
                        command.Connection.Open();
                        command.Parameters.AddWithValue("url", url);
                        command.Parameters.AddWithValue("id", id);
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
                        return errorMessages.ToString();
                    }
                    finally
                    {
                        command.Connection.Close();
                    }

                }

            }

            return "success";
        }

        public List<String> getCourtImages(int cid)
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

                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            images.Add(reader[0].ToString());
                        }
                    }

                    else
                    {
                        images = null;
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
                finally
                {
                    command.Connection.Close();
                }
            }

            return images;

        }

        public string[] getCourtInfo(int cid)
        {

            string[] CourtInfo = new string[5];
            string queryString = "USE ssm_mvc_demo1 SELECT court_name, court_city, court_limit, court_lat, court_lng FROM courts WHERE court_id=@id";

            using (SqlConnection connection = new SqlConnection(cs))
            {

                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Connection.Open();
                    command.Parameters.AddWithValue("@id", cid);


                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())// check if selection query does have a returned row:
                    {

                        // HERE YOU CAN FILL THE CURRENT USER DATA FROM THE RETURNED QUERY :
                        ////this.username = reader["user_username"].ToString();
                        //this.name = reader[0].ToString();
                        //this.city = reader[1].ToString();
                        //this.datetime = reader[2].ToString();

                        // == COURTINFO ARRAY : ==
                        //0 = NAME
                        //1 = CITY //2 = LIMIT
                        //3 = LAT //4 = LNG

                        for (int i = 0; i < CourtInfo.Length; i++)
                        {
                            CourtInfo[i] = reader[i].ToString();
                        }


                    }
                    else// IF NO MATCH FOUND:
                    {


                    }

                    return CourtInfo;

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
                    CourtInfo[0] = errorMessages.ToString();
                }
                finally
                {
                    command.Connection.Close();
                }
            }

            return CourtInfo;
        }


    }
}