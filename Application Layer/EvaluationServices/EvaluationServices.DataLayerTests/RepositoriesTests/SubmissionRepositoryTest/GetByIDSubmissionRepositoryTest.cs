using EvaluationServices.DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineServices.Common.EvaluationServices.Interfaces.Repositories;
using OnlineServices.Common.EvaluationServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace EvaluationServices.DataLayerTests.RepositoriesTests.SubmissionRepositoryTest
{
    [TestClass]
    public class GetByIDSubmissionRepositoryTest
    {
        [TestMethod]
        public void AdddNewSubmissionThenRetrieveItIsNotNull()
        {
            var options = new DbContextOptionsBuilder<EvaluationContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;

            using (var memoryContext = new EvaluationContext(options))
            {
                //Arrange
                ISubmissionRepository submissionRepository = new SubmissionRepository(memoryContext);

                //Act
                #region Submission
                var submission1 = new SubmissionTO
                {
                    SessionId = 30,
                    AttendeeId = 1012,
                    Date = DateTime.Today,
                };
                var submission2 = new SubmissionTO
                {
                    SessionId = 31,
                    AttendeeId = 2607,
                    Date = DateTime.Today,
                };

                var submissionAdded1 = submissionRepository.Add(submission1);
                var submissionAdded2 = submissionRepository.Add(submission2);
                memoryContext.SaveChanges();

                #endregion

                var result = submissionRepository.GetById(submissionAdded2.Id);

                //Assert
                Assert.IsNotNull(result);
                Assert.AreEqual(2607, result.AttendeeId);
            }
        }
    }
}
