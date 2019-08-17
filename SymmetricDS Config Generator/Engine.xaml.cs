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
    }
}
