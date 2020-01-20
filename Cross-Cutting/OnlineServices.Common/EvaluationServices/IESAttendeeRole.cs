using OnlineServices.Common.EvaluationServices.TransfertObjects;

namespace OnlineServices.Common.EvaluationServices
{
    public interface IESAttendeeRole
    {
        FormQuestionTO GetFormById(int sessionID, int FormModelID);
        bool SetResponse(FormResponseTO FormResponses);
    }
}
