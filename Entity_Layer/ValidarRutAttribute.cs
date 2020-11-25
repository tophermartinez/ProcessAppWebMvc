using DataAcces;
using System;
using System.ComponentModel.DataAnnotations;
 
namespace Entity_Layer
{
    public class ValidarRutAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)  
        {
            if(value != null)
            { 
                if(RUT_UTILS.ValidaRut(value.ToString()))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Rut inválido");
                }
            }
            else
            {
                return new ValidationResult("" + validationContext.DisplayName + " is required");
            }
        } 
    }
}
