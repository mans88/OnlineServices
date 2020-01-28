using OnlineServices.Common.EvaluationServices.TransfertObjects;
using OnlineServices.Common.RegistrationServices.TransferObject;
using System.Collections.Generic;

namespace OnlineServices.Common.EvaluationServices
{
    public interface IESAssistantRole
    {
        List<ResponseTO> GetActiveForm(int sessionId, int userId);


        //bool SetResponse(ICollection<ResponseTO> responses);
    }
}
