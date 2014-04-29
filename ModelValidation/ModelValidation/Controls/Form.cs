using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using ModelValidation.Controls.EventArg;

namespace ModelValidation.Controls
{
    /// <summary>
    /// Custom form
    /// Support model validating
    /// </summary>
    public class Form : System.Windows.Forms.Form 
    {
        /// <summary>
        /// model which will bind to control inside this form
        /// </summary>
        public object Model { get; set; }

        /// <summary>
        /// form validated
        /// fired when form finish validated its data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void FormValidatedEventHandler(object sender, FormValidatedEventArg e);

        /// <summary>
        /// form validated event handler
        /// </summary>
        public event FormValidatedEventHandler Form_Validated;

        /// <summary>
        /// submit form data
        /// </summary>
        public void Submit()
        {
            try
            {

            }
            catch (Exception)
            {                
                throw;
            }
        }

        /// <summary>
        /// validating model
        /// </summary>
        public bool Validate()
        {
            try
            {
                //validate form model
                List<ValidationResult> validationResult = Validator.Validate(this.Model);

                bool isValid = validationResult.Count > 0;

                FormValidatedEventArg arg = new FormValidatedEventArg(isValid, validationResult);

                //raised form validated event handler
                this.Form_Validated(this, arg);

                if (validationResult.Count > 0)
                    return false;

                return true;
            }
            catch (Exception)
            {                
                throw;
            }
        }
    }
}
