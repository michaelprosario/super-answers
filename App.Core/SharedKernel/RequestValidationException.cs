using App.Core.Handlers;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.SharedKernel
{
    public class RequestValidationException : Exception
    {
        public RequestValidationException(List<RequestValidationError> validationErrors)
        {
            this.ValidationErrors = validationErrors;
        }

        public List<RequestValidationError> ValidationErrors { get; }
    }
}
