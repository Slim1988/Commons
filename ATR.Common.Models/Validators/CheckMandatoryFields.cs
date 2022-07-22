namespace ATR.Common.Models.Validators
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Web.Mvc;

    /// <summary>
    /// Extend ValidationAttribute to add custom validation
    /// </summary>
    public class CheckMandatoryFields : ValidationAttribute, IClientValidatable
    {
        /// <summary>
        /// The property name to be checked
        /// </summary>
        private string propertyName;

        /// <summary>
        /// The property wanted value
        /// </summary>
        private object propertyValue;

        /// <summary>
        /// The list of model fields to check
        /// </summary>
        private List<string> listFieldToCheck;

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckMandatoryFields"/> class.
        /// </summary>
        /// <param name="propertyName">The property name to be checked</param>
        /// <param name="propertyValue">The property wanted value</param>
        /// <param name="listFieldToCheck">List of model fields to check</param>
        public CheckMandatoryFields(string propertyName, object propertyValue, string[] listFieldToCheck)
        {
            this.propertyName = propertyName;
            this.propertyValue = propertyValue;
            this.listFieldToCheck = new List<string>(listFieldToCheck);
        }

        /// <summary>
        /// Validation rule set for client part
        /// </summary>
        /// <param name="metadata">The model metadata</param>
        /// <param name="context">The controller context</param>
        /// <returns>The rule(s) set for client part</returns>
        IEnumerable<ModelClientValidationRule> IClientValidatable.GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            ModelClientValidationRule rule = new ModelClientValidationRule();
            rule.ErrorMessage = this.FormatErrorMessage(metadata.DisplayName);
            rule.ValidationType = "checkmandatoryfields";
            rule.ValidationParameters.Add("fieldstocheck", this.listFieldToCheck);
            rule.ValidationParameters.Add("propertyname", this.propertyName);
            rule.ValidationParameters.Add("propertyvalue", this.propertyValue);
            yield return rule;
        }

        /// <summary>
        /// Get the property value
        /// </summary>
        /// <param name="src">The object containing the property</param>
        /// <param name="propertyName">The property to be retrieved</param>
        /// <returns>The property value as Object</returns>
        private object GetPropertyValue(object src, string propertyName)
        {
            return src.GetType().GetProperty(propertyName).GetValue(src, null);
        }

        /// <summary>
        /// Check if the object to be checked matches the validation rule(s)
        /// </summary>
        /// <param name="value">The current object to be checked</param>
        /// <param name="validationContext">The current context during validation</param>
        /// <returns>Either a ValidationResult containing an error message or a ValidationResult returning true if the validation succeeded</returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is IList && value.GetType().IsGenericType)
            {
                // The validation rule is applied to a list of objects

                // True if the list of fields' value has to be checked
                bool checkToDo = false;
                IList valueList = (IList)value;
                foreach (object item in valueList)
                {
                    // To compare the two objects the provided propertyValue has to be converted to the same type as the retrieved itemPropertyValue
                    object itemPropertyValue = this.GetPropertyValue(item, this.propertyName);
                    object convertedItemPropertyValue = Convert.ChangeType(this.propertyValue, itemPropertyValue.GetType());
                    if (object.Equals(itemPropertyValue, convertedItemPropertyValue))
                    {
                        checkToDo = true;
                        break;
                    }
                }

                if (checkToDo)
                {
                    foreach (string fieldToCheck in this.listFieldToCheck)
                    {
                        // Get the field from the context
                        var field = validationContext.ObjectType.GetProperty(fieldToCheck);
                        if (field == null)
                        {
                            return new ValidationResult(string.Format(CultureInfo.CurrentCulture, "Unknown field {0}", new[] { fieldToCheck }));
                        }

                        // Get the field value from the context
                        var fieldValue = field.GetValue(validationContext.ObjectInstance);
                        if (fieldValue == null)
                        {
                            return new ValidationResult(string.Format(CultureInfo.CurrentCulture, "Field {0} value cannot be null", new[] { fieldToCheck }));
                        }
                        else if (fieldValue.GetType().Equals(typeof(string)) && !fieldValue.ToString().Equals(string.Empty))
                        {
                            return new ValidationResult(string.Format(CultureInfo.CurrentCulture, "Field {0} value cannot be empty", new[] { fieldToCheck }));
                        }
                        else if ((fieldValue.GetType().Equals(typeof(int)) && (int)fieldValue == 0) || (fieldValue.GetType().Equals(typeof(long)) && (long)fieldValue == 0))
                        {
                            return new ValidationResult(string.Format(CultureInfo.CurrentCulture, "Field {0} value cannot be empty", new[] { fieldToCheck }));
                        }
                    }
                }
            }

            return ValidationResult.Success;
        }
    }
}
