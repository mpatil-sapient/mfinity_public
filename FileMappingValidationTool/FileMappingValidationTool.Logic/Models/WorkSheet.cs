using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FileMappingValidationTool.Logic.Models
{
    public class Worksheet
    {
        public Worksheet()
        {
            Validations = new List<Validation>();
        }

        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlArray("Validations")]
        public List<Validation> Validations { get; set; }
    }
}
