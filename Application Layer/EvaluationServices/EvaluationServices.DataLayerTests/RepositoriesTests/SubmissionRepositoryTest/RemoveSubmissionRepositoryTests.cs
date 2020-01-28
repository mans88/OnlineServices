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
    public class RemoveSubmissionRepositoryTests
    {
        [TestMethod]
        public void RemoveSubmissionAddNewFormThenRemoveItReturnsTrue()
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
                var submissionAdded3 = submissionRepository.Add(submission3);
                memoryContext.SaveChanges();

                #endregion

                //Act
                var result1 = submissionRepository.Remove(submissionAdded1);
                var result2 = submissionRepository.Remove(submissionAdded2.Id);
                memoryContext.SaveChanges();

                var total = submissionRepository.GetAll().Count();

                //Assert
                Assert.IsTrue(result1);
                Assert.IsTrue(result2);
                Assert.AreEqual(1, total);
            }
        }
    }
}
