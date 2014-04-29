using System;
using System.Collections.Generic;
using System.Text;

namespace ModelValidation
{
    /// <summary>
    /// result for validation proccess
    /// </summary>
    public class ValidationResult
    {
        /// <summary>
        /// Property Name
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// Error Message
        /// will be empty if validation success
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
