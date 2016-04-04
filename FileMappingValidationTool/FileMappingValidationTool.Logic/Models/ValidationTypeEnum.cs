using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMappingValidationTool.Logic.Models
{
    public enum ValidationTypeEnum
    {
        NullCheck,
        ZeroCheck,
        ReferenceDataTypeCheck,
        PossibleValueCheck,
        ReferenceValueCheck,
        ConditionalCheck,
        GroupCheck,
        DateTypeCheck
    }
}
