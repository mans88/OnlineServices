using OnlineServices.Common.EvaluationServices.TransfertObjects;
using OnlineServices.Common.RegistrationServices.TransferObject;
using System.Collections.Generic;

namespace OnlineServices.Common.EvaluationServices
{
    public interface IESAttendeeRole
    {
        FormTO2 GetActiveForm(int sessionId, int attendeeId);


        //bool SetResponse(ICollection<ResponseTO> responses);
    }
}
