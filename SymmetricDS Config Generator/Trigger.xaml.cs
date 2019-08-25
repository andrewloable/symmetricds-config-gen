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
        private models.Trigger obj;
        private bool isEditMode;
        public Trigger()
        {
            InitializeComponent();
            obj = new models.Trigger();
            isEditMode = false;
            Load();
        }

        public Trigger(models.Trigger lnk)
        {
            InitializeComponent();
            obj = lnk;
            isEditMode = true;
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

                obj.TriggerID = txtTrigger.Text;
                obj.SourceTableName = txtTableName.Text;
                obj.Channel = cmbChannel.SelectedItem.ToString();
                
                var exists = (from r in models.AppState.State.Triggers where r.TriggerID == obj.TriggerID select r).FirstOrDefault();
                if (exists != null)
                {
                    MessageBox.Show("Trigger Already Exists", "Already Exists", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    if (!isEditMode)
                        models.AppState.State.Triggers.Add(obj);
                    this.Close();
                }
            }            
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            txtTableName.Focus();
        }
    }
}
