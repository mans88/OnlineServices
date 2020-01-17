using System;
using System.Collections.Generic;
using System.Text;

namespace CommunicationServices.BusinessLayer
{
    public class ClassMessage
    {
        int IDMessage;
        int IDSender;
        int IDReceiver;
        int TypeOfMessage;
        string Title;
        string Message;
        string Date;
        string Time;
        bool IsSent;
    }
}
