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
    public partial class Engine : Window
    {
        private models.Engine obj { get; set; }
        public Engine()
        {
            InitializeComponent();
            obj = new models.Engine();
            Load();
        }

        public Engine(models.Engine engine)
        {
            InitializeComponent();
            obj = engine;
            Load();
        }

        private void Load()
        {
            cmbDatabase.Items.Clear();
            foreach (var o in models.AppState.State.Drivers)
                cmbDatabase.Items.Add(o.Name);
            cmbDatabase.SelectedIndex = 0;

            cmbNodeGroup.Items.Clear();
            foreach (var o in models.AppState.State.NodeGroups)
                cmbNodeGroup.Items.Add(o);
            cmbNodeGroup.SelectedIndex = 0;
        }

        private void CmbDatabase_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbDatabase.SelectedIndex >= 0)
            {
                var o = models.AppState.State.Drivers[cmbDatabase.SelectedIndex];
                txtJDBCURL.Text = o.URL;
            }            
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEngineName.Text)
                && !string.IsNullOrEmpty(txtJDBCURL.Text)
                && !string.IsNullOrEmpty(txtDBUserName.Text)
                && !string.IsNullOrEmpty(txtDBPassword.Password)
                && !string.IsNullOrEmpty(txtExternalID.Text)
                && cmbDatabase.SelectedIndex >= 0
                && cmbNodeGroup.SelectedIndex >= 0)
            {
                if ((bool)chkIsRootNode.IsChecked && !string.IsNullOrEmpty(txtSyncURL.Text))
                {
                    //process root node
                    if (!string.IsNullOrEmpty(models.AppState.State.RootEngine.EngineName))
                        if (MessageBox.Show("Root Node Engine Already Defined. Replace?", "Replace Root Node", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                            return;

                    models.AppState.State.RootEngine = new models.Engine()
                    {
                        EngineName = txtEngineName.Text,
                        DBDriver = cmbDatabase.SelectedItem.ToString(),
                        JDBCURL = txtJDBCURL.Text,
                        DBUserName = txtDBUserName.Text,
                        DBPassword = txtDBPassword.Password,
                        SyncURL = txtSyncURL.Text,
                        Group = cmbNodeGroup.SelectedItem.ToString(),
                        ExternalID = txtExternalID.Text
                    };
                    this.Close();
                } else if (!(bool)chkIsRootNode.IsChecked && !string.IsNullOrEmpty(txtRegURL.Text))
                {
                    //process not root nodes
                    var eng = new models.Engine()
                    {
                        EngineName = txtEngineName.Text,
                        DBDriver = cmbDatabase.SelectedItem.ToString(),
                        JDBCURL = txtJDBCURL.Text,
                        DBUserName = txtDBUserName.Text,
                        DBPassword = txtDBPassword.Password,
                        RegistrationURL = txtRegURL.Text,
                        Group = cmbNodeGroup.SelectedItem.ToString(),
                        ExternalID = txtExternalID.Text
                    };
                    var exists = (from r in models.AppState.State.ClientEngines where r.EngineName == eng.EngineName select r).FirstOrDefault();
                    if (exists != null)
                    {
                        MessageBox.Show("Engine Already Exists", "Already Exists", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        models.AppState.State.ClientEngines.Add(eng);
                        this.Close();
                    }
                }
            }
        }

        private void root_node_checkbox(object sender, RoutedEventArgs e)
        {
            if ((bool)chkIsRootNode.IsChecked)
            {
                txtRegURL.Visibility = lblRegURL.Visibility = Visibility.Collapsed;
                txtSyncURL.Visibility = lblSyncURL.Visibility = Visibility.Visible;
            } else
            {
                txtRegURL.Visibility = lblRegURL.Visibility = Visibility.Visible;
                txtSyncURL.Visibility = lblSyncURL.Visibility = Visibility.Collapsed;
            }
        }
    }
}
