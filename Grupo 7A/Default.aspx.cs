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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {

            if (txtCodigo.Text == "")
            {
                divAlerta.Visible = true;
            }
            else
            {
                VoucherNegocio negocio = new VoucherNegocio();
                string codigo = txtCodigo.Text;
                Session["codigoVoucher"] = txtCodigo.Text;

                List<Voucher> vouchers = negocio.listar();

                foreach (Voucher voucher in vouchers)
                {

                    if (codigo == voucher.CodVoucher)
                    {
                        if (voucher.IdCliente <= 0)
                        {
                            Response.Redirect("PremiosForm.aspx", false);
                        }
                        else
                        {
                            string script = @"
                        Swal.fire({
                            icon: 'warning',
                            title: 'Código ya usado',
                            text: 'El código ingresado ya fue utilizado. Por favor, probá con otro.',
                            confirmButtonText: 'Aceptar'
                        });";

                            ClientScript.RegisterStartupScript(this.GetType(), "alerta", script, true);
                            txtCodigo.Text = "";
                            divAlerta.Visible = false;

                            break;
                        }
                    }
                }

                string script2 = @"
                    Swal.fire({
                        icon: 'error',
                        title: 'Código inexistente',
                        text: 'El código ingresado no existe. Por favor, probá con otro.',
                        confirmButtonText: 'Aceptar'
                    });";

                ClientScript.RegisterStartupScript(this.GetType(), "alerta", script2, true);

                txtCodigo.Text = "";

            }
        }
    }
}