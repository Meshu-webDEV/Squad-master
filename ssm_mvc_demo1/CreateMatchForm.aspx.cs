using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Windows.Forms;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;


namespace ssm_mvc_demo1
{
    public partial class CreateMatchForm : System.Web.UI.Page
    {

        static string path = AppDomain.CurrentDomain.BaseDirectory + "Content\\fieldBlock.txt";
        string[] lines = File.ReadAllLines(path);


        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["username"] == null)
            {
                Response.Redirect("/Login.aspx");
            }
            else
            {
                if (!IsPostBack)
                    fillCourts();
            }


        }

        public void createMatch_Click(object sender, EventArgs e)
        {
            Matches match = new Matches();
            bool isCreated = match.createMatch(matchName.Text, matchType.Text, selectedId.Value, matchDate.Text, matchTime.Text, Session["userid"].ToString());

            if (isCreated)
            {
                if (match.type == "Private")
                {

                    Response.Redirect("~/MatchRoom.aspx?match_id=" + match.id + "&type=" + match.type + "&code=" + match.getPvtMatchCode(match.id));

                }
                if (match.type == "Public")
                    Response.Redirect("~/MatchRoom.aspx?match_id=" + match.id + "&type=" + match.type);

                Response.Redirect("~/MatchRoom.aspx?match_id=" + match.id + "&type=" + "WRONG");
            }

            // should be relocated to my matches page

        }


        public void fillCourts()
        {

            Matches match = new Matches();
            List<Courts> courtsList = match.GetCourts();

            for (int i = 0; i < courtsList.Count; i++)
            {
                createBlockStructure(courtsList[i].lat, courtsList[i].lng, courtsList[i].name, courtsList[i].limit, courtsList[i].city, i, courtsList[i].id);
            }

        }

        public void createBlockStructure(string lat, string lng, string n, int li, string c, int fillIndex, int id)
        {

            string url = "https://www.google.com/maps/embed/v1/place?key=AIzaSyDT-7W1RK56peUVp3CRTKxuQ5pyoifLnH8&q=" + lat + "," + lng + "&zoom=12";
            string directionUrl = "https://www.google.com/maps/search/?api=1&query=" + lat + "," + lng;
            string directionButton = "<a href=\"" + directionUrl + "\" target=\"_blank\" class=\"btn btn-info btn-sm\"> Directions </a>";
            string iframeUrl = "<iframe width=\"150\" height=\"113\" src=\"" + url + "\"   frameborder=\"0\" style=\"border: 0\" > </iframe>";
            string bigIframeUrl = "<iframe width=\"100%\" height=\"100%\" src=\"" + url + "\"   frameborder=\"0\" style=\"border: 0\" > </iframe>";
            string block = "";

            for (int i = 0; i < lines.Length - 1; i++)
            {
                string newl = "";
                bool brk = false;

                switch (i)
                {
                    case 4:
                        newl = lines[i].Replace("court_name", n);
                        fieldCard.InnerHtml += newl;
                        brk = true;
                        break;
                    case 6:
                        newl = lines[i].Replace("court_limit", lines[lines.Length - 1] + " " + li);
                        fieldCard.InnerHtml += newl;
                        brk = true;
                        break;
                    case 7:
                        newl = lines[i].Replace("court_city", c);
                        fieldCard.InnerHtml += newl;
                        brk = true;
                        break;
                    case 9:
                        newl = lines[i].Replace("#Modal", "#Modal" + fillIndex);
                        fieldCard.InnerHtml += newl;
                        brk = true;
                        break;
                    case 15:// INPUT RADIO
                        newl = lines[i].Replace("field_id", id.ToString());
                        fieldCard.InnerHtml += newl;
                        brk = true;
                        break;
                    case 19:
                        newl = lines[i].Replace("Modal", "Modal" + fillIndex);
                        fieldCard.InnerHtml += newl;
                        brk = true;
                        break;
                    case 22:
                        newl = lines[i].Replace("modal_body", bigIframeUrl);
                        fieldCard.InnerHtml += newl;
                        brk = true;
                        break;
                    case 24:
                        newl = lines[i].Replace("map_dir", directionUrl);
                        fieldCard.InnerHtml += newl;
                        brk = true;
                        break;

                }

                if (!brk)
                {
                    fieldCard.InnerHtml += lines[i];
                }

            }

        }

    }
}