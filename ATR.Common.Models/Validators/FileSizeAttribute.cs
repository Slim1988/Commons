namespace ATR.Common.Models.Validators
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;
    using System.Web.Mvc;

    class FileSizeAttribute : ValidationAttribute, IClientValidatable
    {
        private int maxBytes;

        public FileSizeAttribute(int maxBytes)
        {
            this.maxBytes = maxBytes;
        }

        public override bool IsValid(object value)
        {
            var file = value as HttpPostedFileBase;
            if (file == null)
            {
                return true;
            }

            if (file.ContentLength > this.maxBytes)
            {
                return false;
            }

            return true;
        }

        IEnumerable<ModelClientValidationRule> IClientValidatable.GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ValidationType = "filesize",
                ErrorMessage = this.FormatErrorMessage(metadata.DisplayName)
            };
            rule.ValidationParameters["maxbytes"] = this.maxBytes;
            yield return rule;
        }
    }
}
