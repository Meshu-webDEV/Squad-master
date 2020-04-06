using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ssm_mvc_demo1
{
    public partial class upMatchIframe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string match_id = Request.QueryString[0];


            // === M A T C H ===
            Matches match = new Matches();
            string[] matchInfo = match.getMatchInfo(match_id);


            // == MATCHINFO ARRAY : ==
            //0 = NAME //1 = CITY //2 = DATE //3 = TYPE //4 = FIELD

            // === /M A T C H



            // === C O U R T ===
            Courts court = new Courts();
            string[] courtInfo = court.getCourtInfo(Int32.Parse(matchInfo[3]));
            List<String> courtImgs = court.getCourtImages(Int32.Parse(matchInfo[3]));
            string url = "https://www.google.com/maps/embed/v1/place?key=AIzaSyDT-7W1RK56peUVp3CRTKxuQ5pyoifLnH8&q="
                            + courtInfo[3] + "," + courtInfo[4] + "&zoom=12";

            string iframeUrl = "<iframe width=\"210\" height=\"160\" src=\"" + url
                                    + "\"   frameborder=\"0\" style=\"border: 0\" > </iframe>";

            // == COURTINFO ARRAY : ==
            //0 = NAME //1 = CITY //2 = LIMIT //3 = LAT //4 = LNG


            // === /C O U R T ===



            // === FILLING DATA ====


            // Match related info
            Mname.InnerText = matchInfo[0];
            Mcity.InnerText = courtInfo[1];
            Mdatetime.InnerText = matchInfo[1];

            // Court related info
            fillSrc(courtImgs);
            Cname.InnerText = courtInfo[0];
            Clocation.InnerHtml = iframeUrl;

            //viewMatch.Attributes["href"] = System.Web.HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + "/" + "MatchRoom?match_id=" + match_id;

        }


        public void fillSrc(List<String> courtImgs)
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
                carousel.Visible = false;
            }
        }

    }
}