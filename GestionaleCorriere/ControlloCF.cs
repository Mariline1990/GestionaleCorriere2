using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace GestionaleCorriere
{
    public class ControlloCF : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string codiceFiscale = value.ToString();

          if (!Regex.IsMatch(codiceFiscale, "^[a-zA-Z]{6}[0-9]{2}[a-zA-Z][0-9]{2}[a-zA-Z][0-9]{3}[a-zA-Z]$"))
            {
                return new ValidationResult("Codice Fiscale non valido");
            }

            // Add a default return statement to handle all code paths
            return ValidationResult.Success;
        }
    }
}
