using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ssm_mvc_demo1
{
    public partial class UpcomingBlock : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string match_id = Request.QueryString[0];

            Matches match = new Matches();
            string[] matchInfo = match.getMatchInfo(match_id);

            string date = matchInfo[1].Substring(0, matchInfo[1].IndexOf(" ") + 1);

            string time = matchInfo[1].Substring(matchInfo[1].IndexOf(" "));
            string ampm = matchInfo[1][matchInfo[1].Length - 2].ToString() + matchInfo[1][matchInfo[1].Length - 1].ToString();
            // == MATCHINFO ARRAY : ==
            //0 = NAME //1 = DATE
            //2 = TYPE //3 = FIELD

            Mname.InnerText = matchInfo[0];
            Mdate.InnerText = date;
            Mtime.InnerText = time.Substring(0, time.LastIndexOf(" ") - 3) + " " + ampm;


            string domain = System.Web.HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + "/";
            string src = domain + "upMatchIframe?match_id=" + match_id;
            string href = domain + "MatchRoom?match_id=" + match_id;


        }

        public void Goto_Click(object sender, EventArgs e)
        {
            string match_id = Request.QueryString[0];
            string domain = System.Web.HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + "/";
            string href = "MatchRoom?match_id=" + match_id;

            //https://localhost:44317/MatchRoom?match_id=21

            ClientScript.RegisterStartupScript(this.GetType(), "scriptid", "window.parent.location.href='" + href + "'", true);


        }
    }
}