using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class MarcaNegocio
    {
        public List<Marcas> listarMarca() 
        {
            List<Marcas> listamarca = new List<Marcas>();
            AcessoDatos datos = new AcessoDatos();
            try
            {
                datos.setearConsulta("select Id, Descripcion Marca from MARCAS");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Marcas aux = new Marcas();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Marca = (string)datos.Lector["Marca"];

                    listamarca.Add(aux);

                }
                return listamarca;
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
