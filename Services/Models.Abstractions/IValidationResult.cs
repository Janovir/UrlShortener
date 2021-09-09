namespace BusinessLayer.Models
{
    /// <summary>
    /// Validation result
    /// </summary>
    public interface IValidationResult
    {
        void AddError(string key, string errorMessage);
        bool IsValid { get; }
    }
}
