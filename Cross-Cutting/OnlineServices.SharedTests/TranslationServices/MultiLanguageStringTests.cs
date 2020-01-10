using OnlineServices.Common.Enumerations;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineServices.Common.Exceptions;
using OnlineServices.Common.TranslationServices.TransfertObjects;
using OnlineServices.CommonTests;
using Moq;
using System;

namespace OnlineServices.Common.TranslationServicesTests
{
    [TestClass]
    public class MultiLanguageStringTests
    {
        [TestMethod()]
        public void CTOR_ShouldInitTranslatedFields_WhenValidTranslationIsProvided()
        {
            //Arrange & Act
            var sut = new MultiLanguageString("English", "French", "Dutch");

            //Assert
            Assert.AreEqual("English", sut.English);
            Assert.AreEqual("French", sut.French);
            Assert.AreEqual("Dutch", sut.Dutch);
        }

        [TestMethod()]
        public void ToString_ShouldReturnTranslatedFields_WhenValidLanguageIsProvided()
        {
            //Arrange & Act
            var sut = new MultiLanguageString("English", "French", "Dutch");

            //Assert
            Assert.AreEqual("English", sut.ToString(Language.English));
            Assert.AreEqual("French", sut.ToString(Language.French));
            Assert.AreEqual("Dutch", sut.ToString(Language.Dutch));
        }

        [TestMethod()]
        public void ToString_ThrowsLanguageNotSupportedException_WhenUnknownLanguageIsProvided()
        {
            //Arrange
            var mockILogger = TestHelper.MockILogger();
            LoggedException.Logger = mockILogger.Object;

            //Act
            var sut = new MultiLanguageString("English", "French", "Dutch");

            //Assert
            Assert.ThrowsException<LanguageNotSupportedException>(() => sut.ToString((Language)50));
            mockILogger.Verify(x => x.Error(It.IsAny<string>()), Times.Once);
        }

        [TestMethod()]
        public void ToString_Throws_WhenInsufficientLanguagesIsProvided()
        {
            //Arrange
            var mockILogger = TestHelper.MockILogger();
            LoggedException.Logger = mockILogger.Object;
            var TupleToUse = new Tuple<Language, string>[]
            {

            };

            //Assert
            Assert.ThrowsException<LoggedException>(() => new MultiLanguageString(TupleToUse));
            mockILogger.Verify(x => x.Error(It.IsAny<string>()), Times.Once);
        }
    }
}
