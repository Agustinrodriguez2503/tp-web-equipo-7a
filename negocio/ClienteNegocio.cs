using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using dominio;

namespace negocio
{
    public class ClienteNegocio
    {
        public List<Cliente> listar()
        {
            List<Cliente> lista = new List<Cliente>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select Id, Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP From Clientes");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Cliente aux = new Cliente();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Documento = (string)datos.Lector["Documento"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Direccion = (string)datos.Lector["Direccion"];
                    aux.Ciudad = (string)datos.Lector["Ciudad"];
                    aux.CodigoPostal = (int)datos.Lector["CP"];

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

        public void registrar(Cliente nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Insert into Clientes(Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP) values (@Documento, @Nombre, @Apellido, @Email, @Direccion, @Ciudad, @CP)");
                datos.setearParametro("@Documento", nuevo.Documento);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Apellido", nuevo.Apellido);
                datos.setearParametro("@Email", nuevo.Email);
                datos.setearParametro("@Direccion", nuevo.Direccion);
                datos.setearParametro("@Ciudad", nuevo.Ciudad);
                datos.setearParametro("@CP", nuevo.CodigoPostal);
                datos.ejecutarAccion();


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

        public void modificar(Cliente modificar)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                // Modifica en tabla Vouchers
                datos.setearConsulta("Update Clientes set Documento = @docu, Nombre = @nombre, Apellido = @apellido, Email = @email, Direccion = @dire, Ciudad = @ciudad, CP = @cp Where Id = @id");
                datos.setearParametro("@docu", modificar.Documento);
                datos.setearParametro("@nombre", modificar.Nombre);
                datos.setearParametro("@apellido", modificar.Apellido);
                datos.setearParametro("@email", modificar.Email);
                datos.setearParametro("@dire", modificar.Direccion);
                datos.setearParametro("@ciudad", modificar.Ciudad);
                datos.setearParametro("@cp", modificar.CodigoPostal);
                datos.setearParametro("@id", modificar.Id);
                datos.ejecutarAccion();

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



        //PARTE DEL REGISTRO DEL MAIL, SE EJECUTA AL APRETAR PARTICIPAR (SI ESTAN TODOS BIEN LOS DATOS)
        public void enviarMail(string correo, string nombre, string premio)
        {
            string remitente = "promoweb253@gmail.com";
            string clave = "kszu sdax pynw sxop";

            MailMessage mensaje = new MailMessage();
            mensaje.From = new MailAddress(remitente, "Promo WEB");
            mensaje.To.Add(correo);
            mensaje.Subject = "Confirmación de participación en Promo WEB";
            mensaje.IsBodyHtml = true;
            mensaje.Body = $@"
                <h3>Hola {nombre}, </h3>
                <p>Su registro fue exitoso. Estas participando por el premio: <strong>{premio}</strong> </p>
                <br/>
                <p>¡Gracias por participar!
                <br/>
                Promo WEB</p>";

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential(remitente, clave);
            smtp.EnableSsl = true;

            try
            {
                smtp.Send(mensaje);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
