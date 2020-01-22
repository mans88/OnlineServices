using EvaluationServices.DataLayer;
using EvaluationServices.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineServices.Common.EvaluationServices;
using System;
using System.Reflection;

namespace EvaluationServices.DataLayerTests
{
    [TestClass]
    public class AddResponseTests
    {
        [TestMethod]
        public void AddResponse_AddANewResponse_ReturnFormResponseNotNull()
        {
            var options = new DbContextOptionsBuilder<EvaluationContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name).Options;

            using (var context = new EvaluationContext(options))
            {
                var repository = new ResponseRepository(context);

                var formResponse = new FormResponseTO { Date = DateTime.Now };

                var result = repository.Add(formResponse);

                Assert.IsNotNull(result);
                Assert.AreNotEqual(0, result.Id);
            }            
        }
    }
}