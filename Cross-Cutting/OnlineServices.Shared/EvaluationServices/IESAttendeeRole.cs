using OnlineServices.Common.EvaluationServices.TransfertObjects;

namespace OnlineServices.Common.EvaluationServices
{
    public interface IESAttendeeRole
    {
        FormTO GetForm(int sessionID, int FormModelID);
        //bool SetResponse<T>(int sessionID, ResponseFormTO<T> response);
    }
}
