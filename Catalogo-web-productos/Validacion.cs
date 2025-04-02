using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Negocio
{
    public static class Validacion
    {
        public static bool validarVacio(object control)
        {
            if(control is TextBox texto)
            {
                return string.IsNullOrEmpty(texto.Text);
            }
            return false;
        }
    }
}
