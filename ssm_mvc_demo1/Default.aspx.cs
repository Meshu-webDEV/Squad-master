using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace ssm_mvc_demo1
{
    public partial class _Default : Page
    {

        static string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        StringBuilder errorMessages = new StringBuilder();


        protected void Page_Load(object sender, EventArgs e)
        {

            InitiateUpcomingMatches();

            if (Session["username"] == null)
            {
                creatematch.Attributes["class"] = "btn btn-secondary btn-createMatch createMatch-disabled";
                creatematch.Attributes["href"] = "/Login.aspx";
            }


        }

        public int ReturnNumber
        {
            get
            {
                return 1;
            }
        }

        public void InitiateUpcomingMatches()
        {

            Matches match = new Matches();
            List<Matches> matchesList = match.getUpcoming();


            if (matchesList != null)
            {
                for (int i = 0; i < matchesList.Count; i++)
                {
                    createBlockStructure(matchesList[i].id, i);
                }
            }

        }

        [System.Web.Services.WebMethodAttribute]
        public void createBlockStructure(string id, int i)
        {

            Matches match = new Matches();
            string[] matchInfo = match.getMatchInfo(id);

            if (matchInfo[2] == "Public")
            {
                string domain = System.Web.HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + "/";
                string src = domain + "UpcomingBlock?match_id=" + id;
                string iframeTag = " <iframe id='iframe" + i + "' src='" + src + "' frameborder='0' style='width:100%;' class='minus-margin'></iframe>";

                upmatchBlock.InnerHtml += iframeTag;
            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MatchRoom?match_id=" + 21);
        }
    }
}