using Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listarCatalogo(string id = "")
        {
            List<Articulo> listacatalogo = new List<Articulo>();
            AcessoDatos datos = new AcessoDatos();
            SqlCommand comando = new SqlCommand();
            SqlConnection conexion = new SqlConnection();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.; database=CATALOGO_WEB_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select a.Id, Codigo,Nombre,a.Descripcion,c.Id,c.Descripcion Categoria,m.Id, m.Descripcion Marca, ImagenUrl, Precio from ARTICULOS a, CATEGORIAS c, MARCAS m where m.Id = a.IdMarca and c.Id= a.IdCategoria ";
                if (id != "")
                {
                    comando.CommandText += " and a.Id = @Id";
                    comando.Parameters.AddWithValue("@Id", id);
                }
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)lector["Id"];
                    aux.Codigo = (string)lector["Codigo"];
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = (string)lector["Descripcion"];
                    aux.Categoria = new Categorias();
                    aux.Categoria.Id = (int)lector["Id"];
                    aux.Categoria.Categoria = (string)lector["Categoria"];
                    aux.Marca = new Marcas();
                    aux.Marca.Id = (int)lector["Id"];
                    aux.Marca.Marca = (string)lector["Marca"];
                    if (!(lector["ImagenUrl"] is DBNull))
                        aux.UrlImagen = (string)lector["ImagenUrl"];
                    aux.Precio = (decimal)lector["Precio"];




                    listacatalogo.Add(aux);
                }
                conexion.Close();
                return listacatalogo;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<Articulo> listarConSP()
        {
            List<Articulo> lista = new List<Articulo>();
            AcessoDatos datos = new AcessoDatos();
            try
            {
                datos.setearProcedimiento("storedListar");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Categoria = new Categorias();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Categoria = (string)datos.Lector["Categoria"];
                    aux.Marca = new Marcas();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Marca = (string)datos.Lector["Marca"];
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.UrlImagen = (string)datos.Lector["ImagenUrl"];
                    aux.Precio = (decimal)datos.Lector["Precio"];


                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public void agregar(Articulo nuevo)
        {
            AcessoDatos datos = new AcessoDatos();
            try
            {
                datos.setearConsulta("insert into ARTICULOS(Codigo,Nombre,Descripcion,IdMarca,IdCategoria,ImagenUrl,Precio) values(@Codigo,@Nombre,@Descripcion,@IdMarca,@IdCategoria,@ImagenUrl,@Precio)");
                datos.setearParametro("@Codigo", nuevo.Codigo);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@IdMarca", nuevo.Marca.Id);
                datos.setearParametro("@IdCategoria", nuevo.Categoria.Id);
                datos.setearParametro("@ImagenUrl", nuevo.UrlImagen);
                datos.setearParametro("@Precio", nuevo.Precio);
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

        public void agregarConSP(Articulo nuevo)
        {
            AcessoDatos datos = new AcessoDatos();
            try
            {
                datos.setearProcedimiento("storedAltaArticulo");
                datos.setearParametro("@codigo", nuevo.Codigo);
                datos.setearParametro("@nombre", nuevo.Nombre);
                datos.setearParametro("@desc", nuevo.Descripcion);
                datos.setearParametro("@IdMarca", nuevo.Marca.Id);
                datos.setearParametro("@IdCategoria", nuevo.Categoria.Id);
                datos.setearParametro("@img", nuevo.UrlImagen);
                datos.setearParametro("@precio", nuevo.Precio);
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
        public void modificar(Articulo modificar)
        {
            AcessoDatos datos = new AcessoDatos();
            try
            {
                datos.setearConsulta("update ARTICULOS set Codigo = @Codigo,Nombre = @Nombre,Descripcion = @Descripcion, IdCategoria = @IdCategoria, IdMarca = @IdMarca, ImagenUrl = @ImagenUrl, Precio= @Precio where Id = @Id");
                datos.setearParametro("@Codigo", modificar.Codigo);
                datos.setearParametro("@Nombre", modificar.Nombre);
                datos.setearParametro("@Descripcion", modificar.Descripcion);
                datos.setearParametro("@IdMarca", modificar.Marca.Id);
                datos.setearParametro("@IdCategoria", modificar.Categoria.Id);
                datos.setearParametro("@ImagenUrl", modificar.UrlImagen);
                datos.setearParametro("@Precio", modificar.Precio);
                datos.setearParametro("@Id", modificar.Id);
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

        public void modificarConSP(Articulo modificado)
        {
            AcessoDatos datos = new AcessoDatos();
            try
            {
                datos.setearProcedimiento("modificarConSP");
                datos.setearParametro("@codigo", modificado.Codigo);
                datos.setearParametro("@nombre", modificado.Nombre);
                datos.setearParametro("@desc", modificado.Descripcion);
                datos.setearParametro("@idMarca", modificado.Marca.Id);
                datos.setearParametro("@idCategoria", modificado.Categoria.Id);
                datos.setearParametro("@img", modificado.UrlImagen);
                datos.setearParametro("@precio", modificado.Precio);
                datos.setearParametro("@id", modificado.Id);
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

        public void eliminar(int id)
        {
            try
            {
                AcessoDatos datos = new AcessoDatos();
                datos.setearConsulta("delete from ARTICULOS where Id = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public void VerDetalles(string id)
        {

            AcessoDatos datos = new AcessoDatos();

            try
            {
                datos.setearConsulta("select Codigo, Nombre,a.Descripcion,c.Descripcion Categoria, m.Descripcion Marca,Precio from ARTICULOS a, CATEGORIAS c, MARCAS m  where a.Id = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo catalogo = new Articulo();
                    catalogo.Codigo = (string)datos.Lector["Codigo"];
                    catalogo.Nombre = (string)datos.Lector["Nombre"];
                    catalogo.Descripcion = (string)datos.Lector["Descripcion"];
                    catalogo.Categoria = new Categorias();
                    catalogo.Categoria.Categoria = (string)datos.Lector["Categoria"];
                    catalogo.Marca = new Marcas();
                    catalogo.Marca.Marca = (string)datos.Lector["Marca"];
                }


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AcessoDatos datos = new AcessoDatos();
            try
            {
                string consulta = "select a.Id, Codigo,Nombre,a.Descripcion,c.Id,c.Descripcion Categoria,m.Id, m.Descripcion Marca, ImagenUrl, Precio from ARTICULOS a inner join CATEGORIAS c on a.IdCategoria = c.Id inner join MARCAS m on a.IdMarca = m.Id where  ";
                if (campo == "Precio")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "Precio > " + filtro;
                            break;
                        case "Menor a":
                            consulta += "Precio < " + filtro;
                            break;
                        default:
                            consulta += "Precio = " + filtro;
                            break;
                    }

                }
                else if (campo == "Categoria")
                {
                    switch (criterio)
                    {
                        case "Empieza con":
                            consulta += "c.Descripcion like '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += "c.Descripcion like '%" + filtro + "'";
                            break;
                        case "Contiene":
                            consulta += "c.Descripcion like '%" + filtro + "%'";
                            break;
                    }
                }
                else if (campo == "Marca")
                {
                    switch (criterio)
                    {
                        case "Empieza con":
                            consulta += "m.Descripcion like '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += "m.Descripcion like '%" + filtro + "'";
                            break;
                        case "Contiene":
                            consulta += "m.Descripcion like '%" + filtro + "%'";
                            break;
                    }
                }
                else
                {
                    switch (criterio)
                    {
                        case "Empieza con":
                            consulta += "Nombre like '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += "Nombre like '%" + filtro + "'";
                            break;
                        case "Contiene":
                            consulta += "Nombre like '%" + filtro + "%'";
                            break;
                    }
                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Categoria = new Categorias();
                    aux.Categoria.Id = (int)datos.Lector["Id"];
                    aux.Categoria.Categoria = (string)datos.Lector["Categoria"];
                    aux.Marca = new Marcas();
                    aux.Marca.Id = (int)datos.Lector["Id"];
                    aux.Marca.Marca = (string)datos.Lector["Marca"];
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.UrlImagen = (string)datos.Lector["ImagenUrl"];
                    aux.Precio = (decimal)datos.Lector["Precio"];




                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        
    }
}
