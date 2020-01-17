using System;
using System.Collections.Generic;
using System.Text;
using OnlineServices.Common.CommunicationServices.Enumerations;

namespace CommunicationServices.BusinessLayer.Domain
{
	public class ClassMessage
	{
		int IdMessage;
		int IdSender;
		int IdReceiver;
		TypeOfMessage typeOfMessage;
		string Title;
		string Message;
		DateTime date;
		bool IsSent;

		public ClassMessage(int sender)
		{
		}

		public bool IsValid()
		{
			return false;
		}
	}
}
