using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Innsending1Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                SjekkOmInnlogget();
        }

        protected void SjekkOmInnlogget()
        {
            if (Session["Epost"] != null)
            {
   
            }
        }
    }
}