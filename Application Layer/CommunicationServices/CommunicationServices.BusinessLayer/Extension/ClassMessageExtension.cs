using CommunicationServices.BusinessLayer.Domain;
using OnlineServices.Common.CommunicationServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommunicationServices.BusinessLayer.Extension
{
	public static class ClassMessageExtension
	{
		public static ClassMessage ToDomain(this ClassMessageTO classMessageTO)
		{
			return new ClassMessage(0);
		}

		public static ClassMessageTO toTO(this ClassMessage classMessage)
		{
			return new ClassMessageTO();
		}
	}
}
