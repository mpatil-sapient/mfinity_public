using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMappingValidationTool.Logic.Mapping
{
    public interface IMappingLogic
    {
        void Load(string sourceFile, string destinationFile);
        string ValidateSource();
        void Map();
    }
}
