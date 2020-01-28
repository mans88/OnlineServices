//using EvaluationServices.DataLayer;
//using OnlineServices.Common.EvaluationServices;
//using OnlineServices.Common.EvaluationServices.TransfertObjects;
//using System;
//using System.Collections.Generic;
//using System.Linq;


//namespace EvaluationServices.BusinessLayer.UseCases
//{
//    public partial class ESAttendeeRole : IESAttendeeRole
//    {
//        public bool SetResponse(ICollection<ResponseTO> responses)
//        {
//            try
//            {
//                responses.Select(r => iESUnitOfWork.ResponseRepository.Add(r));
//                return true;
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }
//    }
//}
