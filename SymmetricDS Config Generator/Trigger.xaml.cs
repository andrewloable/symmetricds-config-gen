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
    public partial class Trigger : Window
    {
        private models.Trigger obj { get; set; }
        public Trigger()
        {
            InitializeComponent();
            obj = new models.Trigger();
            Load();
        }

        public Trigger(models.Trigger lnk)
        {
            InitializeComponent();
            obj = lnk;
            Load();
            txtTableName.Text = obj.SourceTableName;
            txtTrigger.Text = obj.TriggerID;
            var o1 = (from r in models.AppState.State.Channels where r == obj.Channel select r).FirstOrDefault();
            if (o1 != null)
                cmbChannel.SelectedItem = o1;
        }

        private void Load()
        {
            cmbChannel.Items.Clear();            
            if (models.AppState.State.Channels.Count > 0)
            {
                models.AppState.State.Channels = (from r in models.AppState.State.Channels select r).OrderBy(r => r).ToList();
                foreach (var o in models.AppState.State.Channels)
                {
                    cmbChannel.Items.Add(o);
                }
                cmbChannel.SelectedIndex = 0;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTrigger.Text)
                && !string.IsNullOrEmpty(txtTableName.Text)
                && cmbChannel.SelectedIndex >= 0)
            {
                var trg = new models.Trigger()
                {
                    TriggerID = txtTrigger.Text,
                    SourceTableName = txtTableName.Text,
                    Channel = cmbChannel.SelectedItem.ToString()
                };
                var exists = (from r in models.AppState.State.Triggers where r.TriggerID == trg.TriggerID select r).FirstOrDefault();
                if (exists != null)
                {
                    MessageBox.Show("Trigger Already Exists", "Already Exists", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    models.AppState.State.Triggers.Add(trg);
                    this.Close();
                }
            }            
        }
    }
}
