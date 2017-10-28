using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Innsending1Admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void LoggInnBrukerButton_Click(object sender, EventArgs e)
        {
            using (NyhetDataContext dbkobling = new NyhetDataContext())
            {
                var loggetInnBruker = (from bruker in dbkobling.Journalists
                                       where bruker.Epost == BrukernavnTextBox.Text && bruker.Passord == PassordTextBox.Text
                                       select bruker).SingleOrDefault();

                if (loggetInnBruker != null)
                {
                    Session["Id"] = loggetInnBruker.Id;
                    Session["Brukernavn"] = loggetInnBruker.Epost;
                    Response.Redirect("MineArtikler.aspx");
                }
                else
                {
                    LoggInnStatus.Text = "Feil brukernavn og/eller passord";
                }
            }
        }
    }
}