using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OS.DesktopUx.WPF.CheckInApp.Model;

namespace OS.DesktopUx.WPF.CheckInApp.Services
{
    public class CheckInAPI
    {
        public static bool SetPresence(string UserEmail)
        {
            //TODO Registration Web API appel to get user ID

            //TODO Attendance Web API call to set presence and get the answer if sucessfull done

            return (new Random().Next(0, 9) % 2) == 0 ? true : false;
        }
    }
}
