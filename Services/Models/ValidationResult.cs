using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Models
{
    /// <summary>
    /// Validation model 
    /// </summary>
    public class ValidationResult : IValidationResult
    {
        public bool IsValid => !ErrorMessages.Any();
        private Dictionary<string, string> ErrorMessages { get; set; } = new Dictionary<string, string>();

        public void AddError(string key, string errorMessage)
        {
            ErrorMessages.Add(key, errorMessage);
        }

        public override string ToString() => string.Join('\n', ErrorMessages.Select(x => x.Value));
    }
}
