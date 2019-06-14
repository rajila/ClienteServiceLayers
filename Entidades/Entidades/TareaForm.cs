using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Entidades.Entidades
{
    public class TareaForm
    {
        [Required]
        [Display(Name = "lbl_id_tarea")]
        public long id_tarea { get; set; }

        [Display(Name = "lbl_status_ini")]
        [DisplayFormat(ConvertEmptyStringToNull = false)] // Para permitir Null
        public string status_ini { get; set; }

        [Required]
        [Display(Name = "lbl_status_ini_id")]
        public long id_status_ini { get; set; }

        [Display(Name = "lbl_status_now")]
        [DisplayFormat(ConvertEmptyStringToNull = false)] // Para permitir Null
        public string status_now { get; set; }

        [Required]
        [Display(Name = "lbl_status_fin")]
        public long id_status_fin { get; set; }

        [Required]
        [Display(Name = "lbl_nombre_tomador")]
        public string nombre_tomador { get; set; }

        [Required(ErrorMessage = "El DNI del tomador es obligatorio")]
        [Display(Name = "lbl_dni_tomador")]
        [StringLength(maximumLength: 5, ErrorMessage = "Prueba de error, maximo 5 caracteres")]
        public string dni_tomador { get; set; }

        [Required(ErrorMessage = "Ingresar telefono")]
        [Display(Name = "lbl_telefono_tomador")]
        [Validations.Telefono(ErrorMessage ="Telefono no valido")]
        public long? telefono_tomador { get; set; }

        [Display(Name = "lbl_id_tomador")]
        public long? id_tomador { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public string fecha { get; set; }

        public List<AseguradoForm> asegurados { get; set; }
    }
}
