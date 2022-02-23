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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using System.Collections.ObjectModel;
using WpfAppB.Models;

namespace WpfAppB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private async Task Button_Click_1Async(object sender, RoutedEventArgs e)
        {
            ViewModels.RecieveMessageModel rec = new ViewModels.RecieveMessageModel();
            ObservableCollection<RecieveMessage> list = await rec.GetSendMessagesAsync();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
