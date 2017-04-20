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
using System.ComponentModel;

namespace Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            BackgroundWorker _bw = new BackgroundWorker();
            _bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);


            void bw_DoWork(object sender, DoWorkEventArgs e)
            {
                long number = (long)e.Argument;
                e.Result = Factorial(number);
            }

            void btnCompute_Click(object sender, RoutedEventArgs e)
            {
                long arg = long.Parse(txtArg.Text);
                lblStatus.Content = "Calculating...";
                _bw.RunWorkerAsync(arg);
            }

            void _bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                lblResult.Content = e.Result;
                lblStatus.Content = "Completed";
            }
        }
    }
}
