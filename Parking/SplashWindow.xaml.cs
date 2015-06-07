using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Parking
{
    /// <summary>
    /// Interaction logic for SplashWindow.xaml
    /// </summary>
    public partial class SplashWindow : Window
    {
        public SplashWindow()
        {
            InitializeComponent();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            MainWindow w = new MainWindow();
            w.Show();
           
            timer.Stop();
        }

        DispatcherTimer timer = new DispatcherTimer();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
            timer.Tick += timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 3);
            timer.Start();
            
        }

    }
}
