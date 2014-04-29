using System;
using System.Collections.Generic;
using System.Text;

namespace ModelValidation.ValidationAttribute
{
    /// <summary>
    /// determine a reference type need to be validate
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class Validate : Attribute 
    {
    }
}
