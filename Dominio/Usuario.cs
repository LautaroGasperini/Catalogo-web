﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        public int Id { get; set; }
        public string email { get; set; }
        public string pass { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string urlImagenPerfil { get; set; }
        public bool admin {  get; set; }


    }
}
