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
        private models.GroupLink obj;
        private bool isEditMode;
        public NodeGroupLink()
        {
            InitializeComponent();
            obj = new models.GroupLink();
            isEditMode = false;
            Load();
        }

        public NodeGroupLink(models.GroupLink lnk)
        {
            InitializeComponent();
            obj = lnk;
            isEditMode = true;
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

                obj.SourceNodeGroup = cmbSourceNodeGroup.SelectedItem.ToString();
                obj.TargetNodeGroup = cmbTargetNodeGroup.SelectedItem.ToString();
                obj.DataEventAction = (cmbAction.SelectedItem.ToString() == "PUSH" ? models.GroupLink.Action.P : models.GroupLink.Action.W);

                var exists = (from r in models.AppState.State.GroupLinks where r.Hash == obj.Hash select r).FirstOrDefault();
                if (exists != null)
                {
                    MessageBox.Show("Node Group Link Already Exists", "Already Exists", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                if (!isEditMode)
                    models.AppState.State.GroupLinks.Add(obj);
                this.Close();
            }
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            cmbSourceNodeGroup.Focus();
        }
    }
}
