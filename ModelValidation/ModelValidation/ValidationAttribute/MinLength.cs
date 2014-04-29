using System;
using System.Collections.Generic;
using System.Text;
using ModelValidation.ValidationAttribute.Base;

namespace ModelValidation.ValidationAttribute
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple=false)]
    public class MinLength : ValidationAttributeBase
    {
        /// <summary>
        /// minium length
        /// </summary>
        private int length;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="message"></param>
        /// <param name="length"></param>
        public MinLength(string message, int length)
            : base(message)
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
        /// validating item
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="PropertyName"></param>
        /// <returns></returns>
        internal protected override ValidationResult isValid(object Value, string PropertyName)
        {
            try
            {
                ValidationResult result = new ValidationResult();

                if (Value.ToString().Length < this.length)
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
