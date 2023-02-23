using System.ComponentModel.DataAnnotations;

namespace Airbnb.ModelsValidations
{
    public class DateValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is DateOnly date && date > DateOnly.FromDateTime(DateTime.Now))
            {
                return true;
            }
            return false;
        }
    }
}
