using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FileMappingValidationTool.Logic.Models
{
    [XmlRoot("Worksheets")]
    public class BusinessValidations
    {
        public BusinessValidations()
        {
            Worksheets = new List<Worksheet>();
        }

        [XmlElement("Worksheet")]
        public List<Worksheet> Worksheets { get; set; }
    }
}
