using EvaluationServices.DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineServices.Common.EvaluationServices.Interfaces.Repositories;
using OnlineServices.Common.EvaluationServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EvaluationServices.DataLayerTests.RepositoriesTests.SubmissionRepositoryTest
{
    [TestClass]
    public class AddSubmissionRepositoryTest
    {
        [TestMethod]
        public void ThrowsExceptionWhenANonExistingSubmissionIsProvided()
        {
            var options = new DbContextOptionsBuilder<EvaluationContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;

            using (var memoryContext = new EvaluationContext(options))
            {
                //Arrange - Act
                ISubmissionRepository submissionRepository = new SubmissionRepository(memoryContext);

                //Assert
                Assert.ThrowsException<ArgumentNullException>(() => submissionRepository.Add(null));
            }
        }

        [TestMethod]
        public void ShouldInsertInDbWhenValidSubmissionIsSupplied()
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
                    Responses = new List<ResponseTO>()
                };
                var submission2 = new SubmissionTO
                {
                    SessionId = 31,
                    AttendeeId = 2607,
                    Date = DateTime.Today,
                    Responses = new List<ResponseTO>()
                };

                var submissionAdded1 = submissionRepository.Add(submission1);
                var submissionAdded2 = submissionRepository.Add(submission2);
                memoryContext.SaveChanges();

                #endregion

                var result = submissionRepository.GetAll().FirstOrDefault(s => s.SessionId == 30);

                //Assert
                Assert.AreEqual(1012, result.AttendeeId);
            }

        }
    }
}
