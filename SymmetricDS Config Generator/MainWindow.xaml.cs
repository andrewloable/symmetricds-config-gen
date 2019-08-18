using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SymmetricDS_Config_Generator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            models.AppState.State = new models.AppState();
            models.AppState.State.RootEngine = new models.Engine();
            models.AppState.State.GroupLinks = new List<models.GroupLink>();
            models.AppState.State.Channels = new List<string>();
            models.AppState.State.ClientEngines = new List<models.Engine>();
            models.AppState.State.NodeGroups = new List<string>();
            models.AppState.State.Routers = new List<models.Router>();
            models.AppState.State.Triggers = new List<models.Trigger>();
            models.AppState.State.Drivers = new List<models.DBDriver>();

            foreach (var s in Properties.Settings.Default.DBDrivers)
            {
                var temp = s.Split(new char[] { '|' });
                var driver = new models.DBDriver()
                {
                    Name = temp[0],
                    Driver = temp[1],
                    URL = temp[2]
                };
                models.AppState.State.Drivers.Add(driver);
            }
            models.AppState.State.Drivers = models.AppState.State.Drivers.OrderBy(r => r.Name).ToList();
        }

        private void BtnAddEngine_Click(object sender, RoutedEventArgs e)
        {
            var frm = new Engine();
            frm.ShowDialog();
            lstEngines.Items.Clear();
            if (!string.IsNullOrEmpty(models.AppState.State.RootEngine.EngineName))
                lstEngines.Items.Add(models.AppState.State.RootEngine.EngineName + " [ROOT]");
            models.AppState.State.ClientEngines = models.AppState.State.ClientEngines.OrderBy(r => r.EngineName).ToList();
            foreach(var o in models.AppState.State.ClientEngines)
            {
                lstEngines.Items.Add(o.EngineName);
            }
        }

        private void BtnAddRouter_Click(object sender, RoutedEventArgs e)
        {
            var frm = new Router();
            frm.ShowDialog();
            lstRouters.Items.Clear();
            models.AppState.State.Routers = models.AppState.State.Routers.OrderBy(r => r.RouterID).ToList();
            foreach(var o in models.AppState.State.Routers)
            {
                lstRouters.Items.Add(o.RouterID);
            }
        }

        private void BtnAddNodeGroup_Click(object sender, RoutedEventArgs e)
        {
            var frm = new NodeGroup();
            frm.ShowDialog();
            lstNodeGroups.Items.Clear();
            models.AppState.State.NodeGroups = models.AppState.State.NodeGroups.OrderBy(r => r).ToList();
            foreach (var o in models.AppState.State.NodeGroups)
            {
                lstNodeGroups.Items.Add(o);
            }
        }

        private void BtnNodeGroupLink_Click(object sender, RoutedEventArgs e)
        {
            var frm = new NodeGroupLink();
            frm.ShowDialog();
            lstNodeGroupLinks.Items.Clear();
            models.AppState.State.GroupLinks = models.AppState.State.GroupLinks.OrderBy(r => r.SourceNodeGroup).ToList();
            foreach (var o in models.AppState.State.GroupLinks)
            {
                lstNodeGroupLinks.Items.Add(o.SourceNodeGroup + " -> " + o.TargetNodeGroup + " : " + o.DataEventAction.ToString());
            }
        }

        private void BtnAddChannel_Click(object sender, RoutedEventArgs e)
        {
            var frm = new Channel();
            frm.ShowDialog();
            lstChannels.Items.Clear();
            models.AppState.State.Channels = models.AppState.State.Channels.OrderBy(r => r).ToList();
            foreach (var o in models.AppState.State.Channels)
            {
                lstChannels.Items.Add(o);
            }
        }

        private void BtnAddTrigger_Click(object sender, RoutedEventArgs e)
        {
            var frm = new Trigger();
            frm.ShowDialog();
            lstTriggers.Items.Clear();
            models.AppState.State.Triggers = models.AppState.State.Triggers.OrderBy(r => r.TriggerID).ToList();
            foreach (var o in models.AppState.State.Triggers)
            {
                lstTriggers.Items.Add(o.TriggerID);
            }
        }
    }
}
