using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public bool Login(Usuario usuario)
        {
            AcessoDatos datos = new AcessoDatos();
            try
            {
                datos.setearConsulta("select Id, email,pass,admin,nombre, apellido, urlImagenPerfil from USERS where email = @email and pass = @pass");
                datos.setearParametro("@email", usuario.email);
                datos.setearParametro("@pass", usuario.pass);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    usuario.Id = (int)datos.Lector["Id"];
                    
                    usuario.admin = (bool)datos.Lector["admin"];
                    if (!(datos.Lector["nombre"] is DBNull))
                        usuario.nombre = (string)datos.Lector["nombre"];
                    if (!(datos.Lector["apellido"] is DBNull))
                        usuario.apellido = (string)datos.Lector["apellido"];
                    if (!(datos.Lector["urlImagenPerfil"] is DBNull))
                        usuario.urlImagenPerfil = (string)datos.Lector["urlImagenPerfil"];

                    

                    return true;
                }
                
                return false;
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
        public void actualizar(Usuario usuario)
        {
            AcessoDatos datos = new AcessoDatos();
            try
            {
                datos.setearConsulta("update USERS set email=@email,nombre=@name,apellido=@apellido,urlImagenPerfil=@img where Id= @id");
                datos.setearParametro("@email",usuario.email);
                datos.setearParametro("@name",usuario.nombre);
                datos.setearParametro("@apellido",usuario.apellido);
                datos.setearParametro("@img",(object)usuario.urlImagenPerfil ?? DBNull.Value);
                datos.setearParametro("@id",usuario.Id);
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

        //public int insertarNuevoSP(Usuario usuario)
        //{
        //    AcessoDatos datos = new AcessoDatos();
        //    try
        //    {
        //        datos.setearProcedimiento("insertarNuevo");
        //        datos.setearParametro("@email", usuario.email);
        //        datos.setearParametro("@pass", usuario.pass);
        //        return datos.ejecutarAccionScalar();
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //    finally
        //    {
        //        datos.cerrarConexion();
        //    }
        //}

        public int insertarNuevo(Usuario user)
        {
            AcessoDatos datos = new AcessoDatos();
            try
            {
                datos.setearConsulta("insert into USERS(email,Pass, admin) output inserted.Id values (@email,@pass,0)");
                datos.setearParametro("@email", user.email);
                datos.setearParametro("@pass", user.pass);
                return datos.ejecutarAccionScalar();
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
        public bool ExisteEmail(string email)
        {
           AcessoDatos datos =new AcessoDatos();

            try
            {
                datos.setearConsulta("select COUNT(*) from USERS where email= @email");
                datos.setearParametro("@email", email);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    int count = (int)datos.Lector[0];
                    return count > 0;
                }

                return false;
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
