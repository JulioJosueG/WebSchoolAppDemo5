using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSchoolAppUI.Models
{
    public class NombreValidation : ValidationAttribute
    {
        private readonly DWDistrito0503Context _context;


        public NombreValidation(DWDistrito0503Context context)
        {
            _context = context;
        }


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var oldusuario = _context.Usuarios.Where(x => x.Correo == (string)value || x.NombreUsuario == (string)value);

            if (oldusuario == null)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage);
        }
    }
}
