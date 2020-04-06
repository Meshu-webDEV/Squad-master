using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ssm_mvc_demo1
{
    public partial class FootballFields : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["username"] == null)
            {
                addFieldButton.Attributes["class"] = "btn btn-secondary";
                addFieldHref.Attributes["href"] = "/Login.aspx";
            }

        }



    }
}