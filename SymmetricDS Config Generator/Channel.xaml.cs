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
    public partial class Channel : Window
    {
        private string obj, old;
        private bool isEditMode;
        public Channel()
        {
            InitializeComponent();
            obj = "";
            isEditMode = false;
        }

        public Channel(string chan)
        {
            InitializeComponent();
            obj = chan;
            old = chan;
            isEditMode = true;
            txtChannelName.Text = obj;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            txtChannelName.Focus();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtChannelName.Text))
            {
                obj = txtChannelName.Text;
                var exists = (from r in models.AppState.State.Channels where r.ToLower() == obj.ToLower() select r).FirstOrDefault();
                if (exists != null)
                {
                    MessageBox.Show("Channel Already Exists", "Already Exists", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    if (isEditMode)
                        models.AppState.State.Channels.Remove(old);
                    models.AppState.State.Channels.Add(obj);
                    this.Close();
                }
            }            
        }
    }
}
