using ServerServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
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
using ThreeDigitServer.General;
using ThreeDigitServer.Services;

namespace ThreeDigitServer
{
    
    public partial class MainWindow : Window
    {
        WebServiceHost host = new WebServiceHost(typeof(Services.UserLoginService), new Uri("http://localhost:9000"));
        public MainWindow()
        {
            InitializeComponent();

            ServiceEndpoint sep = host.AddServiceEndpoint(typeof(IUserLogin), new WebHttpBinding(), "");
            ServiceDebugBehavior stp = host.Description.Behaviors.Find<ServiceDebugBehavior>();
            stp.HttpHelpPageEnabled = false;




            Console.WriteLine("Services are started and running");
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            //Closing the service hoster
            host.Close();

            Console.WriteLine("Services are stopped");
        }
    }
}
