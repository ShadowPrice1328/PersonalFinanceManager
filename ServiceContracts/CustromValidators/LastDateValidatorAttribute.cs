using System.ComponentModel.DataAnnotations;

namespace ServiceContracts.CustromValidators
{
    public class LastDateValidatorAttribute : ValidationAttribute
    {
        public string DefaultErrorMessage { get; set; } = "Last Date cannot sonner then Today's day.";

        private readonly DateTime LastDate = DateTime.Today;
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime enteredDate = (DateTime)value;

                if (enteredDate > LastDate)
                {
                    return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage, LastDate.ToString("yyyy-MM-dd")));
                }

                return ValidationResult.Success;
            }

            return null;
        }
    }
}
