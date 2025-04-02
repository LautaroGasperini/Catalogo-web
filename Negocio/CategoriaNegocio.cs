using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CategoriaNegocio
    {
        public List<Categorias> listarcategoria()
        {
            List<Categorias>listacategoria = new List<Categorias>();
            AcessoDatos datos = new AcessoDatos();
            try
            {
                datos.setearConsulta("select Id, Descripcion Categoria from CATEGORIAS");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Categorias aux = new Categorias();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Categoria = (string)datos.Lector["Categoria"];
                    listacategoria.Add(aux);
                }
                return listacategoria;
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
