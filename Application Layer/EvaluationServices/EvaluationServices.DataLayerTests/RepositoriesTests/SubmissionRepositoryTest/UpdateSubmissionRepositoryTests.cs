using EvaluationServices.DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using OnlineServices.Common.EvaluationServices.TransfertObjects;
using OnlineServices.Common.EvaluationServices.Interfaces.Repositories;
using System.Linq;

namespace EvaluationServices.DataLayerTests.RepositoriesTests.SubmissionRepositoryTest
{
    [TestClass]
    public class UpdateSubmissionRepositoryTests
    {
        [TestMethod]
        public void UpdateSubmissiontReturnsNewSubmission()
        {
            var options = new DbContextOptionsBuilder<EvaluationContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;

            using (var memoryContext = new EvaluationContext(options))
            {
                //Arrange
                ISubmissionRepository submissionRepository = new SubmissionRepository(memoryContext);
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
                var submission3 = new SubmissionTO
                {
                    SessionId = 2,
                    AttendeeId = 1612,
                    Date = DateTime.Today,
                };

                var submissionAdded1 = submissionRepository.Add(submission1);
                var submissionAdded2 = submissionRepository.Add(submission2);
                
                memoryContext.SaveChanges();

                #endregion

                //Act
                var idSub = submissionAdded1.Id;
                var submissionToUpdate = new SubmissionTO { Id = idSub, Date = DateTime.Today, AttendeeId = 132, SessionId = 456 };
                
                var updatedSubmission = submissionRepository.Update(submissionToUpdate);
                memoryContext.SaveChanges();

                var result = submissionRepository.GetById(updatedSubmission.Id);

                //Assert
                Assert.AreEqual(456, result.SessionId);
            }
        }
    }
}
