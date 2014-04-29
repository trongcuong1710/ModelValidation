using System;
using System.Collections.Generic;
using System.Text;

namespace ModelValidation.ValidationAttribute.Base
{
    public abstract class ValidationAttributeBase : Attribute
    {
        #region Field
        /// <summary>
        /// default message, used by message when its value is empty
        /// </summary>
        protected string defaultMessage = "Place your default message here.";

        /// <summary>
        /// message to be displayed
        /// when validation fail
        /// </summary>
        protected string message;
        #endregion

        #region Constructor
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="message">
        /// message will be displayed when validation failed
        /// </param>
        public ValidationAttributeBase(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                this.message = defaultMessage;
            }
            else
            {
                this.message = message;
            }
        }
        #endregion 

        #region Method
        /// <summary>
        /// Validate item which be attached
        /// </summary>
        /// <returns></returns>
        internal protected abstract ValidationResult isValid(object Value, string PropertyName);
        #endregion
    }
}
