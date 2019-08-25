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
        private string obj, old;
        private bool isEditMode;
        public NodeGroup()
        {
            InitializeComponent();
            obj = "";
            isEditMode = false;
        }

        public NodeGroup(string grp)
        {
            InitializeComponent();
            obj = grp;
            old = grp;
            isEditMode = true;
            txtGroup.Text = obj;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            txtGroup.Focus();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtGroup.Text))
            {
                obj = txtGroup.Text;
                var exists = (from r in models.AppState.State.NodeGroups where r.ToLower() == obj.ToLower() select r).FirstOrDefault();
                if (exists != null)
                {
                    MessageBox.Show("Node Group Already Exists", "Already Exists", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    if (isEditMode)
                        models.AppState.State.NodeGroups.Remove(old);
                    models.AppState.State.NodeGroups.Add(obj);
                    this.Close();
                }
            }
        }
    }
}
