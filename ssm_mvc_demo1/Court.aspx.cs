using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ssm_mvc_demo1
{
    public partial class Court : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["courtId"] == null)
            {
                Response.Redirect("/Default.aspx");
            }


            int court_id = Int32.Parse(Request.QueryString["courtId"]);
            string len = Request.QueryString["length"];
            string courtLocationUrl = "https://maps.google.com/?q=";

            Courts court = new Courts();

            string[] courtInfo = court.getCourtInfo(court_id);
            List<String> courtImgs = court.getCourtImages(court_id);

            // == COURTINFO ARRAY : ==
            //0 = NAME //1 = CITY
            //2 = LIMIT //3 = LAT //4 = LNG

            string name = courtInfo[0];
            string city = courtInfo[1];
            string limit = courtInfo[2];
            string lat = courtInfo[3];
            string lng = courtInfo[4];

            courtLocationUrl += lat + "," + lng + "&ll=" + lat + "," + lng + "&z=15";

            courtMap.Attributes["href"] = courtLocationUrl;
            courtName.InnerText = name;
            courtCity.InnerText = "Field city: " + city;
            courtLimit.InnerText = "Field limit: " + limit;


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

            if(courtImgs == null)
            {
                notFound.Visible = true;
            }

        }
    }
}
