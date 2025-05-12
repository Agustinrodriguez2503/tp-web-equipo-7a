using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace Grupo_7A
{
    public partial class PremiosForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AccesoPermitidoAPremiosForm"] == null || !(bool)Session["AccesoPermitidoAPremiosForm"])
            {
                // Redirigir a Default.aspx
                Response.Redirect("Default.aspx?error=acceso_no_autorizado", false);
                Context.ApplicationInstance.CompleteRequest();
                return;
            }
            if (!IsPostBack)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                List<Articulo> articulos = negocio.ObtenerArticulosConImagenes();

                if (articulos.Count > 0) CargarCarrusel(articulos[0], litCarouselUno, litTituloUno, litDescripcionUno);
                if (articulos.Count > 1) CargarCarrusel(articulos[1], litCarouselDos, litTituloDos, litDescripcionDos);
                if (articulos.Count > 2) CargarCarrusel(articulos[2], litCarouselTres, litTituloTres, litDescripcionTres);
            }
        }

        private void CargarCarrusel(Articulo articulo, Literal litCarousel, Literal litTitulo, Literal litDescripcion)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < articulo.Imagenes.Count; i++)
            {
                string activeClass = i == 0 ? " active" : "";
                sb.Append($@"
                <div class='carousel-item{activeClass}'>
                    <img src='{articulo.Imagenes[i].ImagenUrl}' class='carousel-img d-block mx-auto' alt='Imagen {i + 1}' />
                </div>");
            }
            litCarousel.Text = sb.ToString();
            litTitulo.Text = articulo.Nombre;
            litDescripcion.Text = articulo.Descripcion;

            //esto hay que sacarlo cuando se capture el articulo seleccionado pero lo dejo para que no se rompa el código
           // Session["Articulo"] = articulo;
        }


        protected void btnSeleccionarUno_Command(object sender, CommandEventArgs e)
        {
            int idArticulo = int.Parse(e.CommandArgument.ToString());
            Session["AccesoPermitidoADatosForm"] = true;
            Response.Redirect("DatosForm.aspx?id=" + idArticulo, false);
        }
    }
}
