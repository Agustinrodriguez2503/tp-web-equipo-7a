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

                txtNombre.ReadOnly = true;
                txtApellido.ReadOnly = true;
                txtEmail.ReadOnly = true;
                txtDireccion.ReadOnly = true;
                txtCiudad.ReadOnly = true;
                txtCp.ReadOnly = true;
            }

        }

        protected void btnParticipar_Click(object sender, EventArgs e)
        {
            ClienteNegocio negocio = new ClienteNegocio();
            string dni = txtDni.Text.Trim();

            List<Cliente> lista = negocio.listar();
            Cliente clienteEncontrado = lista.FirstOrDefault(Cliente => Cliente.Documento == dni);

            if (clienteEncontrado == null)
            {
                clienteEncontrado = new Cliente();

                clienteEncontrado.Documento = txtDni.Text;
                clienteEncontrado.Nombre = txtNombre.Text;
                clienteEncontrado.Apellido = txtApellido.Text;
                clienteEncontrado.Email = txtEmail.Text;
                clienteEncontrado.Direccion = txtDireccion.Text;
                clienteEncontrado.Ciudad = txtCiudad.Text;
                clienteEncontrado.CodigoPostal = int.Parse(txtCp.Text);

                negocio.registrar(clienteEncontrado);

                string script = @"
                        Swal.fire({
                            icon: 'success',
                            title: 'Ya estás participando!',
                            text: 'Tus datos han sido registrados correctamente y ya estás participando.',
                            confirmButtonText: 'Aceptar'
                        });";

                ClientScript.RegisterStartupScript(this.GetType(), "alerta", script, true);
            }
            else
            {
                string script = @"
                        Swal.fire({
                            icon: 'success',
                            title: 'Ya estás participando!',
                            //text: 'Tus datos han sido registrados correctamente y ya estás participando.',
                            confirmButtonText: 'Aceptar'
                        });";

                ClientScript.RegisterStartupScript(this.GetType(), "alerta", script, true);

                //Registro datos en el obj voucher
                VoucherNegocio vouchernegocio = new VoucherNegocio();
                Voucher voucher = new Voucher();
                Articulo articulo = Session["Articulo"] as Articulo;

                string codigoVoucher = Session["codigoVoucher"].ToString();


                voucher.CodVoucher = codigoVoucher;
                voucher.Cliente = clienteEncontrado;
                voucher.FechaCanje = DateTime.Today;
                voucher.Articulo = articulo;

                vouchernegocio.modificar(voucher);

            }







            //ESTO ES PARA EL MAIL, TIENE QUE IR DEBAJO DEL REGISTRO DEL CLIENTE.
            /*
            string correo = cliente.Email;
            string nombre = cliente.Nombre;
            string premioSeleccionado = "EL PREMIO";

            try
            {
                negocio.enviarMail(correo, nombre, premioSeleccionado);
            }
            catch (Exception ex)
            {

                throw ex;
            }*/

            //Response.Redirect("Default.aspx", false);
        }
    }
}