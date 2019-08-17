using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymmetricDS_Config_Generator.models
{
    public class Router
    {
        public string RouterID { get; set; }
        public string SourceNodeGroup { get; set; }
        public string TargetNodeGroup { get; set; }
    }
}
