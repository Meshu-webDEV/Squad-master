using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace ssm_mvc_demo1
{
    public partial class AddFootballField : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //if (Session["username"] == null)
            //{
            //    Response.Redirect("/Login.aspx");
            //}

        }


        //TODO:
        //    CHANGE THE IMAGE ARRAY TO IMAGES LIST


        public void addCourt_Click(object sender, EventArgs e)
        {
            int courtId;
            string lat = hiddenValue.Value;
            string lng = hiddenValue1.Value;
            int climit = getSelectedIndex(courtLimit.SelectedIndex);
            //string[] images = new string[5];
            List<String> images = new List<string>();
            string path2 = System.Web.HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
            string path = Server.MapPath("~/FieldImages/");


            Courts court = new Courts(courtName.Text, courtCity.Text, climit, lat, lng);
            bool isAdded = court.addField();
            courtId = court.id;

            if (isAdded)
            {

                try
                {

                    if (imageUpload.HasFile)
                    {
                        int count = 0;
                        string folder = courtId.ToString();

                        DirectoryInfo di = Directory.CreateDirectory(path + folder);


                        foreach (HttpPostedFile file in imageUpload.PostedFiles)
                        {

                            if (count > 4)
                                break;

                            string ext = Path.GetExtension(file.FileName).ToLower();
                            file.SaveAs(di.FullName + @"\" + count + ext);

                            //images[count] = count + ext;
                            images.Add(count + ext);

                            count++;
                        }
                    }
                    else
                    {
                        images = null;
                    }

                }
                catch
                {

                }

                string err = court.addImages(courtId, images, path2);

                Response.Redirect("~/SuccessPage.aspx?courtId=" + courtId);
            }



        }

        public int getSelectedIndex(int selected)
        {
            int climit = 0;

            switch (selected)
            {
                case 0:
                    climit = 8;
                    break;
                case 1:
                    climit = 10;
                    break;
                case 2:
                    climit = 12;
                    break;
                case 3:
                    climit = 14;
                    break;
                case 4:
                    climit = 16;
                    break;
                case 5:
                    climit = 18;
                    break;
                case 6:
                    climit = 20;
                    break;
                case 7:
                    climit = 22;
                    break;
            }

            return climit;
        }
    }

}