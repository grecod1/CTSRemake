using Helpline.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Helpline.Objects.CustomValidators
{
    public class ImageValidator : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            UpdateTicketViewModel model = (UpdateTicketViewModel)validationContext.ObjectInstance;
            
            

            if (model.TicketImage.ContentType ==  "image/png" || model.TicketImage.ContentType == "image/jpeg")
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Invalid photo");
            }
        }
    }
}