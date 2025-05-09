using System;
using System.Collections.Generic;
using System.Linq;
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
            if (!IsPostBack)
            {
                
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                ImagenesNegocio imagenesNegocio = new ImagenesNegocio();

                List<Articulo> articulos = articuloNegocio.listar();
                List<Imagenes> imagenes = imagenesNegocio.listar();

                foreach (Articulo art in articulos)
                {
                    art.Imagenes = imagenes.Where(img => img.IdArticulo == art.Id).Select(img => img.ImagenUrl).ToList();
                }
                GenerarCarruseles(articulos);
            }
        }

        private void GenerarCarruseles(List<Articulo> articulos)
        {
            foreach (var articulo in articulos)
            {
                // Contenedor del carrusel
                Panel panel = new Panel();
                // panel.CssClass = "";

                // ID único para el carrusel
                string carouselId = "carousel_" + articulo.Id;

                //HTML del carrusel
                string html = $@"
                <div class='carrusel-item'>
                    <div id='{carouselId}' class='carousel slide' data-bs-ride='carousel'>
                        <div class='carousel-inner'>";
                            for (int i = 0; i < articulo.Imagenes.Count; i++)
                            {
                                var img = articulo.Imagenes[i];
                                string activeClass = i == 0 ? "active" : "";
                                html += $@"
                            <div class='carousel-item {activeClass}'>
                                <img src='{img}' class='d-block w-100 rounded' alt='Imagen {i + 1}' />
                            </div>";
                            }
                            html += $@"
                        </div>
                        <button class='carousel-control-prev' type='button' data-bs-target='#{carouselId}' data-bs-slide='prev'>
                            <span class='carousel-control-prev-icon'></span>
                            <span class='visually-hidden'>Anterior</span>
                        </button>
                        <button class='carousel-control-next' type='button' data-bs-target='#{carouselId}' data-bs-slide='next'>
                            <span class='carousel-control-next-icon'></span>
                            <span class='visually-hidden'>Siguiente</span>
                        </button>
                    </div>
                    <div class='text-center mt-3'>
                        <h6 class='articulo-nombre'>{articulo.Nombre}</h6>
                        <p class='articulo-descripcion'>{articulo.Descripcion}</p>
                        <button class='btn btn-primary btn-sm btn-seleccionar'>Seleccionar</button>
                    </div>
                </div>";

                panel.Controls.Add(new Literal { Text = html });

                // Agregar panel al placeholder
                phCarruseles.Controls.Add(panel);
            }
        }
    }
}
