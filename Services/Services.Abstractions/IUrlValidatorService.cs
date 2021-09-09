using BusinessLayer.Models;

namespace BusinessLayer.Services.Abstraction
{
    /// <summary>
    /// Holds validation methods for URL
    /// </summary>
    public interface IUrlValidatorService
    {
        /// <summary>
        /// Validates the URl
        /// </summary>
        /// <param name="url">URL to validate</param>
        /// <returns>Validation result</returns>
        IValidationResult ValidateUrl(string url);
    }
}
