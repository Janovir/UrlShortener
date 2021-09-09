using System;
using BusinessLayer.Models;

namespace BusinessLayer.Services.Abstraction
{
    public class UrlValidatorService : IUrlValidatorService
    {
        public const string GeneralError = "URI not valid";

        /// <summary>
        /// Validates the URl
        /// </summary>
        /// <param name="uri">URL to validate</param>
        /// <returns>Validation result</returns>
        public IValidationResult ValidateUrl(string uri)
        {
            var validationResult = new ValidationResult();

            if (!Uri.TryCreate(uri, UriKind.Absolute, out Uri validatedUri))
            {
                validationResult.AddError("uri", "URL is invalid");
            }

            return validationResult;
        }
    }
}
