using System.ComponentModel.DataAnnotations;

namespace Educational_Medical_platform.Helpers
{
    public class ValidDateAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateTime dateValue)
            {
                if (dateValue > DateTime.Now)
                {
                    return new ValidationResult(ErrorMessage ?? "Date must be in the past.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
