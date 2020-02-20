using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using OS.DesktopUx.WPF.CheckInApp.Services;

namespace OS.DesktopUx.WPF.CheckInApp
{
    /// <summary>
    /// Interaction logic for CheckInWindow.xaml
    /// </summary>
    public partial class CheckInWindow : Window
    {
        public CheckInWindow()
        {
            InitializeComponent();
        }

        private void DoCheckIn_Click(object sender, RoutedEventArgs e)
        {
            var result = CheckInAPI.SetPresence(email.Text.Trim());
            if (result)
            {
                MessageBox.Show("Merci!");
            }
            else
            {
                MessageBox.Show("Vous ete pas registré à une formation aujourd'hui...");

            }
            this.Close();
        }
    }
}
