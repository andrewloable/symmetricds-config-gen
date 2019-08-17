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
    /// <summary>
    /// Interaction logic for Engine.xaml
    /// </summary>
    public partial class NodeGroup : Window
    {
        private string obj { get; set; }
        public NodeGroup()
        {
            InitializeComponent();
            obj = "";
        }

        public NodeGroup(string grp)
        {
            InitializeComponent();
            obj = grp;
            txtGroup.Text = obj;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtGroup.Text))
            {
                var grp = txtGroup.Text;
                var exists = (from r in models.AppState.State.NodeGroups where r.ToLower() == grp.ToLower() select r).FirstOrDefault();
                if (exists != null)
                {
                    MessageBox.Show("Node Group Already Exists", "Already Exists", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    models.AppState.State.NodeGroups.Add(grp);
                    this.Close();
                }
            }            
        }
    }
}
