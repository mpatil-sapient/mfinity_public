using FileMappingValidationTool.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMappingValidationTool.Logic.Validation
{
    public interface IValidationHelper
    {
        void Load(string sourceFile, string validationTemplateFile);
        List<LogData> ValidateRules();
    }
}
