using System.IO;

namespace OnlineServices.Common.RegistrationServices.Interfaces
{
    public interface IRSAssistant
    {
        bool CreateUser();

        void DeleteUser();

        //void ReadExcel(Workbook excelFile);
    }
}