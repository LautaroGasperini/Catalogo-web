﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Favorito
    {
        public int Id { get; set; }
        public int idUser { get; set; }
        public int idArticulo { get; set; }
    }
}
