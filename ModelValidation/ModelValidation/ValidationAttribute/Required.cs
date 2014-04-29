using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using ModelValidation.ValidationAttribute.Base;

namespace ModelValidation.ValidationAttribute
{
    /// <summary>
    /// required attribute, apply on a string property to make sure it does not euqal to null or empty
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class Required : ValidationAttributeBase
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="message"></param>
        public Required(string message) : base(message)
        {

        }

        #region Internal Method
        /// <summary>
        /// Validate Model's properties which are decorated with this attribute
        /// </summary>
        /// <returns>
        /// TRUE : if string is not null or empty
        /// FALSE : if string is null or emtpy
        /// </returns>
        internal protected  override ValidationResult isValid(object Value, string PropertyName)
        {
            try
            {
                if (Value != null && !string.IsNullOrEmpty(Value.ToString()))
                {
                    return null;
                }

                ValidationResult result = new ValidationResult();

                result.ErrorMessage = this.message;
                result.PropertyName = PropertyName;
                return result;
            }
            catch (Exception)
            {                
                throw;
            }
        }
        #endregion
    }
}
