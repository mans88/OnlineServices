using OnlineServices.Common.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;
using TranslationServices.DataLayer.ServiceAgents.Domain;
using TranslationServices.DataLayer.ServiceAgents.Extensions;
using Xunit;

namespace TranslationServices.DataLayer.ServiceAgents.ExtensionsTests
{
    public class TupleLanguageExtensions
    {
        [Theory]
        [InlineData(Language.English, "&from=en&to=fr&to=nl")]
        [InlineData(Language.French, "&from=fr&to=en&to=nl")]
        [InlineData(Language.Dutch, "&from=nl&to=en&to=fr")]
        public void ComposeRoute_ReturnsAWellFormatedRoute_WhenValidTupleIsProvided(Language OriginalTupleLanguage, string ExpectedRoute)
        {
            //ARRANGE
            var tupleLanguage = new Tuple<Language, string>(OriginalTupleLanguage, "Valid string to translate");

            var composedRouteToAssert = tupleLanguage.ComposeRoute();

            Assert.Equal(ExpectedRoute, composedRouteToAssert);
        }
    }
}
