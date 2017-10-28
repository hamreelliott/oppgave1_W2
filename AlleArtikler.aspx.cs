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
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            {
                if (!IsPostBack)
                {
                    if (Session["Id"] != null)
                    {
                        VisAlleArtikler();
                    }
                    else
                    {
                        AlleArtiklerLiteral.Text = "<span>Du må være pålogget for å se alle artikler</span>";
                    }
                }            //Hvordan skal jeg få til å vise kun tittel og kanskje litt brødtekst fra artikkel, og klikke videre til hele artikkelen?

            }

            protected void VisAlleArtikler()
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

                        AlleArtiklerLiteral.Text = artikkellisteHTML.ToString();
                    }
                    else
                    {
                        AlleArtiklerLiteral.Text = "<p>Det er ingen artikler lagret</p>";
                    }
                }
            }
        }
    }
}