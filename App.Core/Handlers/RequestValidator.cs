using App.Core.SharedKernel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

// https://www.codeproject.com/Articles/256183/DataAnnotations-Validation-for-Beginner

namespace App.Core.Handlers
{
    public class RequestValidationError{
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class RequestValidator
    {
        public static void ValidateAndThrowException<T>(T request)
        {
            var validationErrors = Validate(request);
            if (validationErrors.Count > 0)
            {
                throw new RequestValidationException(validationErrors);
            }
        }

        public static List<RequestValidationError> Validate<T>(T request)
        {
            List<ValidationResult> validationResults = new List<ValidationResult>();
            List<RequestValidationError> errors = new List<RequestValidationError>();

            var validationContext = new ValidationContext(request, null, null);
            var isValid = Validator.TryValidateObject(request, validationContext, validationResults, true);

            if(!isValid)
            {
                foreach(var result in validationResults)
                {
                    RequestValidationError error = new RequestValidationError
                    {
                        PropertyName = result.MemberNames.FirstOrDefault(),
                        ErrorMessage = result.ErrorMessage
                    };
                    errors.Add(error);
                }

            }

            return errors;
        }
    }
}
