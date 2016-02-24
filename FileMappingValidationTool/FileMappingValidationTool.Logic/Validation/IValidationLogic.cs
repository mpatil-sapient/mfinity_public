using FileMappingValidationTool.Core.Models;
using System.Collections.Generic;

namespace FileMappingValidationTool.Logic.Validation
{
    public interface IValidationLogic
    {
        void Load(string sourceFile, string validationTemplate);
        List<LogData> ValidateSource();
    }
}
