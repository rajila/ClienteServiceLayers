using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Validations
{
    public class TelefonoAttribute : ValidationAttribute
    {
        private KonectaNet.Funciones _bridgeValidationKonecta = new KonectaNet.Funciones();

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return ( _bridgeValidationKonecta.ValidaTelefono(Convert.ToString(value))) ? ValidationResult.Success: new ValidationResult(FormatErrorMessage((validationContext.DisplayName)));
            //return new ValidationResult(this.ErrorMessage, new[] { validationContext.MemberName });
            //return new ValidationResult("Something went wrong");
        }

        //public override bool IsValid(object value)
        //{
        //    string valueToTest = Convert.ToString(value);
        //    return false;
        //}
    }
}
