namespace ATR.Common.Models.Validators
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;
    using System.Web.Mvc;

    public class FileTypeAttribute : ValidationAttribute, IClientValidatable
    {
        private string[] authorizedFileFormats;

        public FileTypeAttribute(string[] authorizedFileFormats)
        {
            this.authorizedFileFormats = authorizedFileFormats;
        }

        public override bool IsValid(object value)
        {
            var file = value as HttpPostedFileBase;
            if (file == null)
            {
                return true;
            }

            foreach (string authorizedFileFormat in this.authorizedFileFormats)
            {
                if (file.ContentType == authorizedFileFormat)
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
                ValidationType = "filetype",
                ErrorMessage = this.FormatErrorMessage(metadata.DisplayName)
            };
            rule.ValidationParameters["authorizedfileformats"] = string.Join(",", this.authorizedFileFormats);
            yield return rule;
        }
    }
}
