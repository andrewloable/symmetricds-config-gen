using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymmetricDS_Config_Generator.models
{
    public class AppState
    {
        public static AppState State { get; set; }
        public Engine RootEngine { get; set; }
        public List<Engine> ClientEngines { get; set; }
        public List<string> NodeGroups { get; set; }
        public List<string> Channels { get; set; }
        public List<GroupLink> GroupLinks { get; set; }
        public List<Trigger> Triggers { get; set; }
        public List<Router> Routers { get; set; }

        public List<DBDriver> Drivers { get; set; }
    }
}
