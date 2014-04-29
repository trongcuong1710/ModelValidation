using System;
using System.Collections.Generic;
using System.Text;

namespace ModelValidation.Controls.EventArg
{
    /// <summary>
    /// event argument indicate when form finish validated
    /// </summary>
    public class FormValidatedEventArg : System.EventArgs 
    {
        /// <summary>
        /// determine whether form's data is valid
        /// </summary>
        private bool isValid;

        /// <summary>
        /// list of validation result
        /// not contain any item if form's data valid
        /// </summary>
        private List<ValidationResult> validationResult;

        /// <summary>
        /// determine whether form's data is valid
        /// </summary>
        public bool IsValid
        {
            get
            {
                return this.isValid;
            }
        }

        /// <summary>
        /// list of validation result
        /// not contain any item if form's data valid
        /// </summary>
        public List<ValidationResult> ValidationResult
        {
            get
            {
                return this.validationResult;
            }
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="isValid"></param>
        /// <param name="validationResult"></param>
        public FormValidatedEventArg(bool isValid, List<ValidationResult> validationResult)
            : base()
        {
            try
            {
                this.isValid = isValid;
                this.validationResult = validationResult;
            }
            catch (Exception)
            {                
                throw;
            }
        }        
    }
}
