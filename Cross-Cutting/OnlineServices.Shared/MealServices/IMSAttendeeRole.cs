using OnlineServices.Common.MealServices.TransfertObjects;

using System.Collections.Generic;

namespace OnlineServices.Common.MealServices
{
    public interface IMSAttendeeRole
    {
        List<MealTO> GetMenu();
    }
}