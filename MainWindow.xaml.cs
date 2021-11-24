using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shell;
using System.Windows.Threading;

namespace MaveryLoader
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

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Minimize(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Load(object sender, RoutedEventArgs e)
        {
            string contents = File.ReadAllText("C:\\Windows\\System32\\drivers\\etc\\hosts");
            if (contents.Contains("185.229.236.109 s.optifine.net"))
            {

                MessageBox.Show("You already have Mavery Cloaks", "Error", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
            else
            {

                using (StreamWriter hosts = File.AppendText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "drivers/etc/hosts")))
                { 
                    hosts.WriteLine("\n185.229.236.109 s.optifine.net");
                    this.Activate();
                    MessageBox.Show("Mavery Cloaks successfully installed!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    

                }
            }
        }

        private void Unload(object sender, RoutedEventArgs e)
        {
            string contents = File.ReadAllText("C:\\Windows\\System32\\drivers\\etc\\hosts");
            if (contents.Contains("185.229.236.109 s.optifine.net"))
            {

                var fileName = "C:\\Windows\\System32\\drivers\\etc\\hosts";
                File.WriteAllLines(fileName, File.ReadLines(fileName).Where(l => l != "185.229.236.109 s.optifine.net").ToList());
                MessageBox.Show("Mavery Cloaks successfully uninstalled!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {

                MessageBox.Show("Mavery cloaks not detected!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
