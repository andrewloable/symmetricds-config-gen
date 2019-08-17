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
        private string obj { get; set; }
        public Channel()
        {
            InitializeComponent();
            obj = "";
        }

        public Channel(string chan)
        {
            InitializeComponent();
            obj = chan;
            txtChannelName.Text = obj;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtChannelName.Text))
            {
                var chan = txtChannelName.Text;
                var exists = (from r in models.AppState.State.Channels where r.ToLower() == chan.ToLower() select r).FirstOrDefault();
                if (exists != null)
                {
                    MessageBox.Show("Channel Already Exists", "Already Exists", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    models.AppState.State.Channels.Add(chan);
                    this.Close();
                }
            }            
        }
    }
}
