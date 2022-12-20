using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSchoolAppUI.Models
{
    public class DateValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var anio = DateTime.Now;
            anio.AddYears(-3);

            DateTime a = (DateTime)value;
            
            if(a.Year < anio.Year)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult( ErrorMessage);
        }
    }
}
