using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.ServiceProcess;
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
using System.Windows.Threading;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool zap = false;
        public MainWindow()
        {
            InitializeComponent();
        }
        /*
                public static void StartService(string serviceName, int timeoutMilliseconds)
                {
                    ServiceController service = new ServiceController(serviceName);
                    try
                    {
                        TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds);

                        service.Start();
                        service.WaitForStatus(ServiceControllerStatus.Running, timeout);
                    }
                    catch
                    {
                        Console.WriteLine("Neviem preco to nejde..");
                    }
                }
         */         //tutu mam spustenie servisu (pre istotu..)
        /*
        public static void StopService(string servicName, int timeoutMilliseconds)
        {
            ServiceController service = new ServiceController(servicName);
            try
            {
                TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds);

                service.Stop();
                service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
            }
            catch
            {
                // ...
            }
        }
        */         //a toto zas pred stopnutie, neskusal som tak nwm.
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //  string kill = "svchost.exe";                                         //Pouzivam len ak chcem aby to bol VIRUS !
            //  System.Diagnostics.Process.Start("taskkill", " /f /im " + kill);     //vypnem vsetky notifikacie haha
            
            int lol1 = Convert.ToInt32(slider1.Value);
            label1.Content = slider2.Value.ToString();
            System.Diagnostics.Process.Start("shutdown", "/s /t " + slider1.Value.ToString());
            int res = Convert.ToInt32(slider1.Value);
            
            Countdown(lol1, TimeSpan.FromSeconds(1), cur => label3.Content = cur.ToString());
            
        }
      
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            System.Diagnostics.Process.Start("shutdown", "/a");
            zap = true;
            label3.Content = String.Empty;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int lol2 = Convert.ToInt32(slider2.Value);
            label1.Content = slider1.Value.ToString();
            System.Diagnostics.Process.Start("shutdown", "/r /t " + slider2.Value.ToString());

            Countdown(lol2, TimeSpan.FromSeconds(1), cur => label3.Content = cur.ToString());
        }

        private void Slider_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            label1.Content = slider1.Value.ToString();
        }
        private void Slider_ValueChanged_2(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            label2.Content = slider2.Value.ToString();
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Content = (int.Parse((string)label3.Content) - 1).ToString();
            if (int.Parse((string)label3.Content) == 0);
        }
 
      void Countdown(int count, TimeSpan interval, Action<int> ts)
      {
          var dt = new System.Windows.Threading.DispatcherTimer();
          dt.Interval = interval;
          dt.Tick += (_, a) =>
          {
              if (count-- == 0 || zap == true)
              {
                  dt.Stop();
              }
                 
              else
              {
                  ts(count);
              }
                  
          };
          ts(count);
          dt.Start();
      }
        
    }
}
