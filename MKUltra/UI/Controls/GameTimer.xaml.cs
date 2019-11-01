using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Threading;

namespace MKUltra.UI.Controls
{
    /// <summary>
    /// Interaction logic for GameTimer.xaml
    /// </summary>
    public partial class GameTimer : UserControl
    {

        DispatcherTimer timer = new DispatcherTimer();
        Stopwatch stopWatch = new Stopwatch();
        string currentTime = string.Empty;

        public GameTimer()
        {
            InitializeComponent();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (stopWatch.IsRunning)
            {
                TimeSpan ts = stopWatch.Elapsed;
                currentTime = String.Format("{0:00}:{1:00}:{2:00}",
                ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                lblTimer.Content = currentTime;
            }
        }

        private void btnCommand_Click(object sender, RoutedEventArgs e)
        {
            if (btnCommand.Content.Equals("Start"))
            {
                stopWatch.Start();
                timer.Start();
                btnCommand.Content = "Stop";
            }
            else if (btnCommand.Content.Equals("Stop"))
            {
                if (stopWatch.IsRunning)
                {
                    stopWatch.Stop();
                }

                stopWatch.Reset();

                btnCommand.Content = "Start";

            }

        }
    }
}
