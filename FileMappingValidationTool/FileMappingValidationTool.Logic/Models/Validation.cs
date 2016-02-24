using FileMappingValidationTool.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FileMappingValidationTool.Logic.Models
{
    [XmlRoot("Validation")]
    public class Validation
    {
        public Validation()
        {
            Values = new List<string>();
        }

        [XmlAttribute("Field")]
        public string Field { get; set; }

        [XmlAttribute("ReferenceTable")]
        public string ReferenceTable { get; set; }

        [XmlAttribute("DataType")]
        public DataTypeEnum DataType { get; set; }

        [XmlAttribute("DataTypeField")]
        public string DataTypeField { get; set; }
        
        [XmlAttribute("ReferenceField")]
        public string ReferenceField { get; set; }

        [XmlAttribute("ReferenceDataTypeField")]
        public string ReferenceDataTypeField { get; set; }

        [XmlAttribute("ReferenceCompareField")]
        public string ReferenceCompareField { get; set; }
        
        [XmlAttribute("Type")]
        public ValidationTypeEnum Type { get; set; }

        [XmlArray("Values")]
        [XmlArrayItem("Value")]
        public List<string> Values { get; set; }

        [XmlArray("IgnoreFields")]
        [XmlArrayItem("Field")]
        public List<string> IgnoreFields { get; set; }

        [XmlArray("Fields")]
        [XmlArrayItem("Field")]
        public List<KeyValue> ConditionBasedKeyValues { get; set; }
    }
}
