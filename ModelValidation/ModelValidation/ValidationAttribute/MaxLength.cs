using System;
using System.Collections.Generic;
using System.Text;
using ModelValidation.ValidationAttribute.Base;

namespace ModelValidation.ValidationAttribute
{
    /// <summary>
    /// specific a max length of a value type
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple=false)]
    public class MaxLength : ValidationAttributeBase 
    {
        /// <summary>
        /// max length
        /// </summary>
        private int length;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="length"></param>
        /// <param name="message"></param>
        public MaxLength(int length, string message) : base(message)
        {
            try
            {
                this.length = length;
            }
            catch (Exception)
            {
                
                throw;
            }            
        }

        /// <summary>
        /// validate item
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="PropertyName"></param>
        /// <returns></returns>
        internal protected override ValidationResult isValid(object Value, string PropertyName)
        {
            try
            {
                ValidationResult result = new ValidationResult();

                if (Value.ToString().Length > this.length)
                {
                    result.ErrorMessage = this.message;
                    result.PropertyName = PropertyName;
                }

                return result;
            }
            catch (Exception)
            {                
                throw;
            }
        }
    }
}
