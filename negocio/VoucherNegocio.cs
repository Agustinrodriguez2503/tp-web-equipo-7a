﻿using System;
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
                datos.setearConsulta("Select CodigoVoucher, IdCliente, FechaCanje, IdArticulo From Vouchers");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Voucher aux = new Voucher();
                    aux.CodVoucher = (string)datos.Lector["CodigoVoucher"];
                    if (!(datos.Lector["IdCliente"] is DBNull))
                    {
                        aux.Cliente = new Cliente();
                        aux.Cliente.Id = (int)datos.Lector["IdCliente"];
                    }
                    if (!(datos.Lector["FechaCanje"] is DBNull))
                    {
                        aux.FechaCanje = (DateTime)datos.Lector["FechaCanje"];
                    }
                    if (!(datos.Lector["IdArticulo"] is DBNull))
                    {
                        aux.Articulo = new Articulo();
                        aux.Articulo.Id = (int)datos.Lector["IdArticulo"];
                    }


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
