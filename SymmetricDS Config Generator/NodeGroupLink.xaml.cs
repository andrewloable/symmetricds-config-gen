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
using System.Windows.Shapes;

namespace SymmetricDS_Config_Generator
{
    public partial class NodeGroupLink : Window
    {
        private models.GroupLink obj { get; set; }
        public NodeGroupLink()
        {
            InitializeComponent();
            obj = new models.GroupLink();
            Load();
        }

        public NodeGroupLink(models.GroupLink lnk)
        {
            InitializeComponent();
            obj = lnk;
            Load();
            var o1 = (from r in models.AppState.State.NodeGroups where r == obj.SourceNodeGroup select r).FirstOrDefault();
            if (o1 != null)
                cmbSourceNodeGroup.SelectedItem = o1;
            var o2 = (from r in models.AppState.State.NodeGroups where r == obj.TargetNodeGroup select r).FirstOrDefault();
            if (o2 != null)
                cmbTargetNodeGroup.SelectedItem = o2;
            if (obj.DataEventAction == models.GroupLink.Action.P)
                cmbAction.SelectedIndex = 0;
            else
                cmbAction.SelectedIndex = 1;
        }

        private void Load()
        {
            cmbSourceNodeGroup.Items.Clear();
            cmbTargetNodeGroup.Items.Clear();            
            if (models.AppState.State.NodeGroups.Count > 0)
            {
                models.AppState.State.NodeGroups = (from r in models.AppState.State.NodeGroups select r).OrderBy(r => r).ToList();
                foreach (var o in models.AppState.State.NodeGroups)
                {
                    cmbSourceNodeGroup.Items.Add(o);
                    cmbTargetNodeGroup.Items.Add(o);
                }
                cmbSourceNodeGroup.SelectedIndex = 0;
                cmbTargetNodeGroup.SelectedIndex = 0;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (cmbAction.SelectedIndex >= 0
                && cmbSourceNodeGroup.SelectedIndex >= 0
                && cmbTargetNodeGroup.SelectedIndex >= 0)
            {
                var grplnk = new models.GroupLink()
                {
                    SourceNodeGroup = cmbSourceNodeGroup.SelectedItem.ToString(),
                    TargetNodeGroup = cmbTargetNodeGroup.SelectedItem.ToString(),
                    DataEventAction = (cmbAction.SelectedItem.ToString() == "PUSH" ? models.GroupLink.Action.P : models.GroupLink.Action.W)
                };
                var exists = (from r in models.AppState.State.GroupLinks where r.Hash == grplnk.Hash select r).FirstOrDefault();
                if (exists != null)
                {
                    MessageBox.Show("Node Group Link Already Exists", "Already Exists", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    models.AppState.State.GroupLinks.Add(grplnk);
                    this.Close();
                }
            }            
        }
    }
}
