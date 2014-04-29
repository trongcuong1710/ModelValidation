using System;
using System.Collections.Generic;
using System.Text;
using ModelValidation.ValidationAttribute.Base;

namespace ModelValidation.ValidationAttribute
{
    /// <summary>
    /// Validating range for integer property
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple=false)]
    public class Range : ValidationAttributeBase
    {
        /// <summary>
        /// lower cap
        /// </summary>
        private int from;

        /// <summary>
        /// upper cap
        /// </summary>
        private int to;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="message"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        public Range(string message, int from, int to)
            : base(message)
        {
            try
            {
                this.from = from;
                this.to = to;
            }
            catch (Exception)
            {                
                throw;
            }
        }

        /// <summary>
        /// validating property value
        /// </summary>
        /// <exception cref="ArgumentException">
        /// throw when object is not int
        /// </exception>
        /// <param name="Value"></param>
        /// <param name="PropertyName"></param>
        /// <returns></returns>
        internal protected override ValidationResult isValid(object Value, string PropertyName)
        {
            try
            {
                ValidationResult result = new ValidationResult();

                int value;

                try
                {
                    value = int.Parse(Value.ToString());
                }
                catch (Exception)
                {
                    throw new ArgumentException();
                }

                if (value < this.from || value > this.to)
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
