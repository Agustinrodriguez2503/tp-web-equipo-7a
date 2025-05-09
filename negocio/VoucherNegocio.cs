using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class VoucherNegocio
    {
        public List<Voucher> listar()
        {
            List<Voucher> lista = new List<Voucher>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select CodigoVoucher, IdCliente, FechaCanje, IdArticulo From Imagenes");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Voucher aux = new Voucher();
                    aux.CodVoucher = (string)datos.Lector["CodigoVoucher"];
                    aux.Cliente = new Cliente();
                    aux.Cliente.Id = (int)datos.Lector["IdCliente"];
                    aux.FechaCanje = (DateTime)datos.Lector["FechaCanje"];
                    aux.Articulo = new Articulo();
                    aux.Articulo.Id = (int)datos.Lector["IdArticulo"];
        

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
