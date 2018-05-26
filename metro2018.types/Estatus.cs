﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro2018.Types
{
    public class Estatus
    {
        [Required]
        public int Idestatus { get; set; }

        [Required]
        public string Nombre { get; set; }
    }
}
