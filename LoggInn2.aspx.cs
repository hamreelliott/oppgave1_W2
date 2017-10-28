using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LoggInn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void LoggInnBrukerButton_Click(object sender, EventArgs e)
    {
        using (JournalisterDataContext db = new JournalisterDataContext())
        {
            var loggetInnBruker = (from bruker in db.Brukers
                                   where bruker.Brukernavn == BrukernavnTextBox.Text && bruker.Passord == PassordTextbox.Text
                                   select bruker).SingleOrDefault();

            if (loggetInnBruker != null)
            {
                Session["Id"] = loggetInnBruker.Id;
                Session["Brukernavn"] = loggetInnBruker.Brukernavn;
                Response.Redirect("EgneNyheter.aspx");
            }
            else
            {
                LoggInnStatus.Text = "Feil brukernavn og/eller passord";
            }
        }
    }
}