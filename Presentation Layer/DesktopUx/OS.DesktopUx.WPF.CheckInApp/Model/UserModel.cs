using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;

namespace OS.DesktopUx.WPF.CheckInApp.Model
{
    public class UserModel : INotifyPropertyChanged
    {
        private string email;
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        public UserModel()
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                this.Email = "christian@gyssels.com";
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
