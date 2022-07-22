namespace ATR.Common.Models.Validators
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;
    using System.Web.Mvc;

    class NotEmptyString : ValidationAttribute, IClientValidatable
    {
        public NotEmptyString()
        {
        }

        public override bool IsValid(object value)
        {
            if (value.GetType().Equals(typeof(string)))
            {
                string testedString = Regex.Replace(value.ToString(), @"\t|\n|\r", string.Empty);
                if (testedString.Trim().Length > 0)
                {
                    return true;
                }
            }

            return false;
        }

        IEnumerable<ModelClientValidationRule> IClientValidatable.GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ValidationType = "notemptystring",
                ErrorMessage = this.FormatErrorMessage(metadata.DisplayName)
            };
            yield return rule;
        }
    }
}
