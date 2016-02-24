using FileMappingValidationTool.Core.Models;
using System.Collections.Generic;

namespace FileMappingValidationTool.Logic.Validation
{
    public class ValidationLogic : IValidationLogic
    {
        IValidationHelper _validationHelper = new ExcelValidationHelper();

        public void Load(string sourceFile, string validationTemplateFile)
        {
            _validationHelper.Load(sourceFile, validationTemplateFile);
        }

        public List<LogData> ValidateSource()
        {
            return _validationHelper.ValidateRules();
        }
    }
}
