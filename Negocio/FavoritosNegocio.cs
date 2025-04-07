using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class FavoritosNegocio
    {
        public void agregarFavoritos(Favorito favoritos)
        {
            AcessoDatos datos = new AcessoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO Favoritos (IdUser, IdArticulo) VALUES (@idUser, @idArticulo)");
                datos.setearParametro("@idUser", favoritos.idUser);
                datos.setearParametro("@idArticulo",favoritos.idArticulo);
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
        public List<Articulo> listarFavoritos(int idUser)
        {
            List<Articulo> lista = new List<Articulo>();
            AcessoDatos datos = new AcessoDatos();
            try
            {
                datos.setearConsulta("select a.Id, Codigo, Nombre, a.Descripcion, c.Id, c.Descripcion Categoria,m.Id, m.Descripcion Marca, ImagenUrl, Precio from FAVORITOS f inner join ARTICULOS a ON a.Id = f.IdArticulo inner join CATEGORIAS c ON c.Id = a.IdCategoria inner join MARCAS m ON m.Id = a.IdMarca where f.IdUser = @idUser");
                datos.setearParametro("@idUser",idUser);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo articulo = new Articulo();
                    articulo.Id = (int)datos.Lector["Id"];
                    articulo.Codigo = (string)datos.Lector["Codigo"];
                    articulo.Nombre = (string)datos.Lector["Nombre"];
                    articulo.Descripcion = (string)datos.Lector["Descripcion"];
                    articulo.Categoria = new Categorias();
                    articulo.Categoria.Id = (int)datos.Lector["Id"];
                    articulo.Categoria.Categoria = (string)datos.Lector["Categoria"];
                    articulo.Marca = new Marcas();
                    articulo.Marca.Id = (int)datos.Lector["Id"];
                    articulo.Marca.Marca = (string)datos.Lector["Marca"];
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        articulo.UrlImagen = (string)datos.Lector["ImagenUrl"];
                    articulo.Precio = (decimal)datos.Lector["Precio"];

                    lista.Add(articulo);
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
        public void eliminarFavoritos(int idUsuario, int idArticulo)
        {
            AcessoDatos datos = new AcessoDatos();
            try
            {
                datos.setearConsulta("delete from favoritos where IdUser = @idUsuario and IdArticulo = @idArticulo");
                datos.setearParametro("@idUsuario",idUsuario);
                datos.setearParametro("@idArticulo",idArticulo);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<int> obtenerFav(int idUsuario)
        {
            List<int> listaFavoritos = new List<int>();
            AcessoDatos datos = new AcessoDatos();
            Favorito favorito = new Favorito();

            try
            {
                datos.setearConsulta("select IdArticulo from favoritos where IdUser = @idUser");
                datos.setearParametro("@idUser", idUsuario);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    favorito.idArticulo = (int)datos.Lector["IdArticulo"];

                    listaFavoritos.Add(favorito.idArticulo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return listaFavoritos;
        }
    }
}
