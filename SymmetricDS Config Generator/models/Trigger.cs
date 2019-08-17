using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymmetricDS_Config_Generator.models
{
    public class Trigger
    {
        public string TriggerID { get; set; }
        public string SourceTableName { get; set; }
        public string Channel { get; set; }
    }
}
