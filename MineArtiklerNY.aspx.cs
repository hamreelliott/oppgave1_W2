using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace Innsending1Admin
{
    public partial class MineArtiklerNY : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Id"] != null)
                {
                    VisMineArtikler();
                }
                else
                {
                    MineArtiklerLiteral.Text = "<span>Du må være pålogget for å se dine artikler</span>";
                }
            }
        }

        //Hvordan skal jeg få til å vise kun tittel og kanskje litt tekst fra artikkel, og klikke videre til hele artikkelen?
        protected void VisMineArtikler()
        {
            using (NyhetDataContext dbkobling = new NyhetDataContext())
            {
                var artikkelliste = from artikkel in dbkobling.Artikkels
                                    where artikkel.Id == (int)Session["Id"]
                                    select artikkel;


                StringBuilder artikkellisteHTML = new StringBuilder();
                if (artikkelliste.Count() > 0)
                {
                    foreach (var artikkel in artikkelliste)
                    {
                        artikkellisteHTML.AppendFormat("<article><h1>{0}</h1><img src='Bilder/{1}' alt='{0}' /><p>Tekst: {2}</p></artikle>", artikkel.Tittel, artikkel.BildeSrc, artikkel.Tekst);
                    }

                    MineArtiklerLiteral.Text = artikkellisteHTML.ToString();
                }
                else
                {
                    MineArtiklerLiteral.Text = "<p>Du har ingen artikler lagret</p>";
                }
            }
        }
        protected void RegistrerArtikkel_Click(object sender, EventArgs e)
        {
            using (NyhetDataContext dbkobling = new NyhetDataContext())
            {
                String bildeSrc = "Ikke satt";

                try

                {
                    if (BildeFileUpload.HasFile)
                    {
                        bildeSrc = BildeFileUpload.PostedFile.FileName;
                        BildeFileUpload.PostedFile.SaveAs(Server.MapPath("Bilder/" + BildeFileUpload.PostedFile.FileName));
                        RegistreringstatusLiteral.Text = String.Format("<p class='okmessage'>Filen {0} er lagret</p>", BildeFileUpload.PostedFile.FileName);
                    }
                }
                catch (Exception ex)
                {
                    RegistreringstatusLiteral.Text = String.Format("<p class='errormessage'>Feil ved lagring av fil: {0}</p>", ex.Message);
                }
            }


            string bildeSrc = null;
            Artikkel nyArtikkel = new Artikkel
            {
                Tittel = TittelTextBox.Text,
                Tekst = TekstTextBox.Text,
                BildeSrc = bildeSrc,
                Id = (int)Session["Id"]
            };


            {
                using (NyhetDataContext dbkobling = new NyhetDataContext())

                    try
                    {
                        dbkobling.Artikkels.InsertOnSubmit(nyArtikkel);
                        dbkobling.SubmitChanges();
                        RegistreringstatusLiteral.Text = "<span>Artikkel lagret</span>";
                    }
                    catch
                    {
                        //skrive ut om at feil er oppstått ved lagring artikkel
                        RegistreringstatusLiteral.Text = "<span>Feil ved lagring av artikkel</span>";
                    }

            }
        }
        protected void HentButton_Click(object sender, EventArgs e)
        {
            using (NyhetDataContext dbkobling = new NyhetDataContext())
            {
                var valgtArtikkel = (from Artikkel in dbkobling.Artikkels
                                     where Artikkel.Id == Convert.ToInt32(IdTextBox.Text)
                                     select Artikkel).SingleOrDefault();
                if (valgtArtikkel != null)
                {
                    RedigerTittelTextBox.Text = valgtArtikkel.Tittel;

                }
                else
                {
                    //beskjed om at artikkel ikke finnes
                    RegistreringstatusLiteral.Text = "<span>Artikkel finnes fra før</span>";
                }
            }
        }
        protected void OppdaterArtikkelButton_Click(object sender, EventArgs e)
        {
            using (NyhetDataContext dbkobling = new NyhetDataContext())
            {
                var valgtArtikkel = (from Artikkel in dbkobling.Artikkels
                                     where Artikkel.Id == Convert.ToInt32(IdTextBox.Text)
                                     select Artikkel).SingleOrDefault();
                if (valgtArtikkel != null)
                {
                    valgtArtikkel.Tittel = RedigerTittelTextBox.Text;
                    dbkobling.SubmitChanges();
                }
                else
                {
                    //beskjed om at artikkel ikke finnes
                    OppdaterstatusLiteral.Text = "<span>Artikkel finnes ikke</span>";
                }
            }
        }
        protected void SlettArtikkelButton_Click(object sender, EventArgs e)
        {
            using (NyhetDataContext dbkobling = new NyhetDataContext())
            {
                var valgtArtikkel = (from Artikkel in dbkobling.Artikkels
                                     where Artikkel.Id == Convert.ToInt32(IdTextBox.Text)
                                     select Artikkel).SingleOrDefault();
                if (valgtArtikkel != null)
                {
                    dbkobling.Artikkels.DeleteOnSubmit(valgtArtikkel);
                    dbkobling.SubmitChanges();
                }
                else
                {
                    //beskjed om at artikkel ikke finnes
                    OppdaterstatusLiteral.Text = "<span>Artikkel finnes ikke</span>";
                }
            }
        }
    }
}
