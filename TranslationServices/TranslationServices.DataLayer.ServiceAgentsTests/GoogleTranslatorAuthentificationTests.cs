//VERIFIED V3
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Translation.V2;
using System;
using TranslationServices.DataLayer.ServiceAgents.Interfaces;
using TranslationServices.DataLayer.ServiceAgents.TranslationAgents;
using Xunit;
using Language = OnlineServices.Common.Enumerations.Language;

namespace TranslationServices.DataLayer.ServiceAgentsTests
{
    public class GoogleTranslatorAuthentificationTests
    {
        [Theory(Skip ="Run ONLY to Test Google Credentials")]
        [InlineData(@"C:\TFS\OnlineServices-d9921f8e5f21.json")]//TODO Students: Put your projectIdHere
        public void GoogleTranslatorCredentialsTest(string JSONFile)
        {
            // If you don't specify credentials when constructing the client, the
            // client library will look for credentials in the environment.
            var credential = GoogleCredential.FromFile(JSONFile);

            using (var client = TranslationClient.Create(credential, TranslationModel.NeuralMachineTranslation))
            {

                var ReturnedValue = client.DetectLanguage("Bonjour Google!").Language;
                Console.WriteLine(ReturnedValue);
                Assert.Equal("fr", ReturnedValue);
            }
        }

        [Fact(Skip = "Code as Demo to Google Translation services")]
        public void DemoOfGeneralUseOfGoogleTranslator()
        {
            var OriginalText = new Tuple<Language, string>(Language.English, "Hello World!");

            ITRSTranslationService Translator = new GoogleTranslationAgent(TestHelper.MockILogger().Object);

            var Translations = Translator.TranslateAsync(OriginalText);

            Translations.Wait();

            var r = Translations.Result;

            Assert.Equal(Enum.GetNames(typeof(Language)).Length, r.Length);
        }
    }
}
