using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymmetricDS_Config_Generator.models
{
    public class Engine
    {
        public string EngineName { get; set; }
        public string DBDriver { get; set; }
        public string JDBCURL { get; set; }
        public string DBUserName { get; set; }
        public string DBPassword { get; set; }
        public string RegistrationURL { get; set; }
        public string SyncURL { get; set; }
        public string Group { get; set; }
        public string ExternalID { get; set; }
    }
}
