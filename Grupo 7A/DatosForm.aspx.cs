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

            //if (dni.Length < 7)
            //{
                //txtDni.Text = "";
                //txtNombre.Text = "";
                //txtApellido.Text = "";
                //txtEmail.Text = "";
                //txtDireccion.Text = "";
                //txtCiudad.Text = "";
                //txtCp.Text = "";

                //string script = @"
                //        Swal.fire({
                //            icon: 'warning',
                //            title: 'DNI invalido',
                //            text: 'El DNI no puede tener menos de 7 números. Por favor, ingrese un DNI valido.',
                //            confirmButtonText: 'Aceptar'
                //        });";

                //ClientScript.RegisterStartupScript(this.GetType(), "alerta", script, true);
                //txtNombre.ReadOnly = false;
                //txtApellido.ReadOnly = false;
                //txtEmail.ReadOnly = false;
                //txtDireccion.ReadOnly = false;
                //txtCiudad.ReadOnly = false;
                //txtCp.ReadOnly = false;
            //}
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
            //else
            //{
            //    txtNombre.Text = "";
            //    txtApellido.Text = "";
            //    txtEmail.Text = "";
            //    txtDireccion.Text = "";
            //    txtCiudad.Text = "";
            //    txtCp.Text = "";

            //    string script = @"
            //            Swal.fire({
            //                icon: 'warning',
            //                title: 'DNI no registrado',
            //                text: 'El DNI ingresado no está registrado. Por favor, registrate ingresando tus datos.',
            //                confirmButtonText: 'Aceptar'
            //            });";

            //    ClientScript.RegisterStartupScript(this.GetType(), "alerta", script, true);
            //    txtNombre.ReadOnly = false;
            //    txtApellido.ReadOnly = false;
            //    txtEmail.ReadOnly = false;
            //    txtDireccion.ReadOnly = false;
            //    txtCiudad.ReadOnly = false;
            //    txtCp.ReadOnly = false;
            //}

        }

        protected void btnParticipar_Click(object sender, EventArgs e)
        {
            ClienteNegocio negocio = new ClienteNegocio();
            string dni = txtDni.Text.Trim();

            List<Cliente> lista = negocio.listar();
            Cliente clienteEncontrado = lista.FirstOrDefault(Cliente => Cliente.Documento == dni);

            if (clienteEncontrado != null)
            {

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
        }
    }
}