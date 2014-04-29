using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using ModelValidation.ValidationAttribute;
using ModelValidation.ValidationAttribute.Base;
using System.Collections;

namespace ModelValidation
{
    /// <summary>
    /// validator class
    /// perform validation on model which has properties which are decorated with model validation attribute
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// validating model object
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static List<ValidationResult> Validate(object model)
        {
            try
            {
                List<ValidationResult> lstResult = new List<ValidationResult>();                                

                PropertyInfo[] props = model.GetType().GetProperties();

                foreach (PropertyInfo prop in props)
                {
                    lstResult.AddRange(Validate(model, prop));
                }

                return lstResult;
            }
            catch (Exception)
            {                
                throw;
            }
        }

        /// <summary>
        /// validate a property
        /// </summary>
        /// <param name="model"></param>
        /// <param name="prop"></param>
        /// <returns></returns>
        private static List<ValidationResult> Validate(object model, PropertyInfo prop)
        {
            try
            {
                //get property value
                object value = prop.GetValue(model, null);

                if (model.GetType().IsGenericType || model.GetType().IsArray)
                {
                    if (Attribute.IsDefined(prop, typeof(Validate)))
                    {
                        //validate array/list object
                        return ValidateArray(prop.GetValue(model, null));
                    }                    
                }

                if (!value.GetType().IsValueType && value.GetType() != typeof(string))
                {
                    //if reference type property need validate
                    if (Attribute.IsDefined(prop, typeof(Validate)))
                    {
                        //call validate on value object                        
                        return Validate(value);
                    }
                }

                //list validation result to return
                List<ValidationResult> lstResult = new List<ValidationResult>();

                //get all attributes associate with property
                object[] attributes = prop.GetCustomAttributes(true);

                foreach (object attr in attributes)
                {
                    //try cast attribute to type of validation attribute base
                    ValidationAttributeBase attribute = attr as ValidationAttributeBase;

                    if (attribute == null)
                    {
                        //if attribute is not a validation attribute base
                        //ignore it
                        continue;
                    }

                    ValidationResult result = attribute.isValid(value, prop.Name);

                    if (result != null)
                    {
                        lstResult.Add(result);
                    }
                }

                return lstResult;
            }
            catch (Exception)
            {                
                throw;
            }
        }

        /// <summary>
        /// validating array/list object
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="prop"></param>
        /// <returns></returns>
        private static List<ValidationResult> ValidateArray(object Value)
        {
            try
            {
                List<ValidationResult> results = new List<ValidationResult>();

                IEnumerable lst = Value as IEnumerable;

                if (lst != null)
                {
                    foreach (object obj in lst)
                    {
                        results.AddRange(Validate(obj));
                    }
                }

                return results;
            }
            catch (Exception)
            {                
                throw;
            }
        }
    }
}
