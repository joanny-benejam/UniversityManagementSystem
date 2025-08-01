using System.ComponentModel.DataAnnotations;

public class NotEmptyGuidAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is Guid guid && guid == Guid.Empty)
        {
            return new ValidationResult($"{validationContext.MemberName} cannot be an empty GUID.");
        }

        return ValidationResult.Success;
    }
}