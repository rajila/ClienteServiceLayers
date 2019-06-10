﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Entidades.Entidades
{
    public class AseguradoForm
    {
        public long id_asegurado { get; set; }

        [Required]
        [Display(Name = "lbl_nombre_asegurado")]
        public string nombre { get; set; }

        [Required]
        [Display(Name = "lbl_dni_asegurado")]
        public string dni { get; set; }

        [Required]
        [Display( Name = "lbl_telefono_asegurado")]
        public long telefono { get; set; }

        [Required]
        [Display(Name = "lbl_llamar_asegurado")]
        public string llamar_asegurado { get; set; }

        [Required]
        [Display(Name = "lbl_fechahora")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public string fecha_hora { get; set; }
    }
}