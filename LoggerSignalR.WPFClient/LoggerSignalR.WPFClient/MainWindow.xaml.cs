using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace LoggerSignalR.WPFClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<string> _messages = new ObservableCollection<string>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lstMessages.ItemsSource = _messages;       
        }

        private async Task Connect()
        {
            HubConnection hubConnection = new HubConnection("http://localhost:12218/signalr");

            IHubProxy logHubProxy = hubConnection.CreateHubProxy("LoggerHub");

            //method LogEvent to be invoke from server
            logHubProxy.On<string>("Write", logMessage =>
            {
                Application.Current.Dispatcher.Invoke(() => _messages.Add(logMessage));
            });

            hubConnection.StateChanged += change =>
                {
                    Application.Current.Dispatcher.Invoke(()=>txtSate.Text = change.NewState.ToString());            
                };

            //connect
            await hubConnection.Start();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await Connect();
        }
    }
}
