using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace Grupo_7A
{
    public partial class Datos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void txtDni_TextChanged(object sender, EventArgs e)
        {
            ClienteNegocio negocio = new ClienteNegocio();
            string dni = txtDni.Text.Trim();

            List<Cliente> lista = negocio.listar();
            Cliente clienteEncontrado = lista.FirstOrDefault(Cliente => Cliente.Documento == dni);

            if (clienteEncontrado != null)
            {
                txtNombre.Text = clienteEncontrado.Nombre;
                txtApellido.Text = clienteEncontrado.Apellido;
                txtEmail.Text = clienteEncontrado.Email;
                txtDireccion.Text = clienteEncontrado.Direccion;
                txtCiudad.Text = clienteEncontrado.Ciudad;
                txtCp.Text = clienteEncontrado.CodigoPostal.ToString();

                //txtNombre.ReadOnly = true;
                //txtApellido.ReadOnly = true;
                //txtEmail.ReadOnly = true;
                //txtDireccion.ReadOnly = true;
                //txtCiudad.ReadOnly = true;
                //txtCp.ReadOnly = true;
            }

        }

        protected void btnParticipar_Click(object sender, EventArgs e)
        {
            ClienteNegocio negocio = new ClienteNegocio();
            string dni = txtDni.Text.Trim();

            List<Cliente> lista = negocio.listar();
            Cliente clienteEncontrado = lista.FirstOrDefault(Cliente => Cliente.Documento == dni);

            //ACA ESTA EL ARTICULO QUE NECESITAMOS PARA CARGAR EN EL VOUCHER
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            Articulo articulo;
            int idArticuloURL = int.Parse(Request.QueryString["id"]);
            List<Articulo> articulos = articuloNegocio.listar();

            //EL ARTICULO SELECCIONADO!
            articulo = articulos.Find(x => x.Id == idArticuloURL);

            if (clienteEncontrado == null)
            {
                clienteEncontrado = new Cliente();

                guardarDatosCliente(clienteEncontrado);

                negocio.registrar(clienteEncontrado);

                //Redirección a default una vez que se clickea en aceptar
                string urlDeRedireccion = ResolveUrl("~/Default.aspx");

                string script = $@"
                    Swal.fire({{
                        icon: 'success',
                        title: 'Ya estás participando!',
                        text: 'Tus datos han sido registrados correctamente y ya estás participando.',
                        confirmButtonText: 'Aceptar',
                        allowOutsideClick: false,
                        allowEscapeKey: false
                    }}).then((result) => {{
                        if (result.isConfirmed) {{
                            window.location.href = '{urlDeRedireccion}';
                        }}
                    }});";

                ClientScript.RegisterStartupScript(this.GetType(), "alertaConRedireccion", script, true);

                //busco el nuevo registro para saber el ID
                List<Cliente> listaAux = negocio.listar();
                Cliente clienteEncontradoAux = listaAux.FirstOrDefault(Cliente => Cliente.Documento == dni);

                //Registro datos en el obj voucher en nuevo cliente
                VoucherNegocio vouchernegocio = new VoucherNegocio();
                Voucher voucher = new Voucher();

                string codigoVoucher = Session["codigoVoucher"].ToString();

                voucher.CodVoucher = codigoVoucher;
                voucher.IdCliente = clienteEncontradoAux.Id;
                voucher.FechaCanje = DateTime.Today;
                voucher.IdArticulo = articulo.Id;

                vouchernegocio.modificar(voucher);
            }
            else
            {
                //Redirección a default una vez que se clickea en aceptar
                string urlDeRedireccion = ResolveUrl("~/Default.aspx");

                string script = $@"
                    Swal.fire({{
                        icon: 'success',
                        title: 'Ya estás participando!',
                        confirmButtonText: 'Aceptar',
                        allowOutsideClick: false,
                        allowEscapeKey: false
                    }}).then((result) => {{
                        if (result.isConfirmed) {{
                            window.location.href = '{urlDeRedireccion}';
                        }}
                    }});";

                ClientScript.RegisterStartupScript(this.GetType(), "alertaConRedireccion", script, true);

                //Registro datos en el obj voucher
                VoucherNegocio vouchernegocio = new VoucherNegocio();
                Voucher voucher = new Voucher();

                string codigoVoucher = Session["codigoVoucher"].ToString();


                voucher.CodVoucher = codigoVoucher;
                voucher.IdCliente = clienteEncontrado.Id;
                voucher.FechaCanje = DateTime.Today;
                voucher.IdArticulo = articulo.Id;

                vouchernegocio.modificar(voucher);

            }

            //ESTO ES PARA EL MAIL, TIENE QUE IR DEBAJO DEL REGISTRO DEL CLIENTE.
            string correo = txtEmail.Text;
            string nombre = txtNombre.Text;
            string premioSeleccionado = articulo.Nombre;

            try
            {
                negocio.enviarMail(correo, nombre, premioSeleccionado);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            

        }

        void guardarDatosCliente(Cliente clienteEncontrado)
        {
            clienteEncontrado.Documento = txtDni.Text;
            clienteEncontrado.Nombre = txtNombre.Text;
            clienteEncontrado.Apellido = txtApellido.Text;
            clienteEncontrado.Email = txtEmail.Text;
            clienteEncontrado.Direccion = txtDireccion.Text;
            clienteEncontrado.Ciudad = txtCiudad.Text;
            clienteEncontrado.CodigoPostal = int.Parse(txtCp.Text);
        }
    }
}