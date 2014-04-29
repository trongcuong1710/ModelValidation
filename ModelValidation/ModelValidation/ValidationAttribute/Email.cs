using System;
using System.Collections.Generic;
using System.Text;
using ModelValidation.ValidationAttribute.Base;
using System.Text.RegularExpressions;

namespace ModelValidation.ValidationAttribute
{
    /// <summary>
    /// validation email
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple=false)]
    public class Email : ValidationAttributeBase 
    {
        /// <summary>
        /// pattern to validate email
        /// </summary>
        private string pattern = @"^\s*[\w\-\+_']+(\.[\w\-\+_']+)*\@[a-z0-9]([\w\.-]*[a-z0-9])?\.[a-z][a-z\.]*[a-z]$";

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="message"></param>
        public Email(string message)
            : base(message)
        {

        }

        /// <summary>
        /// validate item value
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="PropertyName"></param>
        /// <returns></returns>
        protected internal override ValidationResult isValid(object Value, string PropertyName)
        {
            try
            {
                ValidationResult result = new ValidationResult();

                Regex reg = new Regex(this.pattern, RegexOptions.IgnoreCase);

                if (!reg.IsMatch(Value.ToString()))
                {
                    result.ErrorMessage = message;
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
