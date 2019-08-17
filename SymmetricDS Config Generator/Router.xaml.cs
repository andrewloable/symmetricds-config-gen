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
    public partial class Router : Window
    {
        private models.Router obj { get; set; }
        public Router()
        {
            InitializeComponent();
            obj = new models.Router();
            Load();
        }

        public Router(models.Router lnk)
        {
            InitializeComponent();
            obj = lnk;
            Load();
            txtRoute.Text = obj.RouterID;
            var o1 = (from r in models.AppState.State.NodeGroups where r == obj.SourceNodeGroup select r).FirstOrDefault();
            if (o1 != null)
                cmbSourceNode.SelectedItem = o1;
            var o2 = (from r in models.AppState.State.NodeGroups where r == obj.TargetNodeGroup select r).FirstOrDefault();
            if (o1 != null)
                cmbTargetNode.SelectedItem = o1;
        }

        private void Load()
        {
            cmbSourceNode.Items.Clear();
            cmbTargetNode.Items.Clear();
            if (models.AppState.State.NodeGroups.Count > 0)
            {
                models.AppState.State.NodeGroups = (from r in models.AppState.State.NodeGroups select r).OrderBy(r => r).ToList();
                foreach (var o in models.AppState.State.NodeGroups)
                {
                    cmbSourceNode.Items.Add(o);
                    cmbTargetNode.Items.Add(o);
                }
                cmbSourceNode.SelectedIndex = 0;
                cmbTargetNode.SelectedIndex = 0;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtRoute.Text)
                && cmbSourceNode.SelectedIndex >= 0
                && cmbTargetNode.SelectedIndex >= 0)
            {
                var trg = new models.Router()
                {
                    RouterID = txtRoute.Text,
                    SourceNodeGroup = cmbSourceNode.SelectedItem.ToString(),
                    TargetNodeGroup = cmbTargetNode.SelectedItem.ToString()
                };
                var exists = (from r in models.AppState.State.Routers where r.RouterID == trg.RouterID select r).FirstOrDefault();
                if (exists != null)
                {
                    MessageBox.Show("Router Already Exists", "Already Exists", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    models.AppState.State.Routers.Add(trg);
                    this.Close();
                }
            }
        }
    }
}
