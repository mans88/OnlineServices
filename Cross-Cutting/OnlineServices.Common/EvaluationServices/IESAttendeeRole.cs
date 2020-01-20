using OnlineServices.Common.EvaluationServices.TransfertObjects;

namespace OnlineServices.Common.EvaluationServices
{
    public interface IESAttendeeRole
    {
        FormQuestionTO GetFormById(int sessionID, int FormModelID);
        bool SetResponse(FormResponseTO FormResponses);
    }

    public interface IESAttendeeRole_QuelleGuarder
    {
        FormTO GetForm(int sessionID, int FormModelID);
        //bool SetResponse<T>(int sessionID, ResponseFormTO<T> response);
    }
}
