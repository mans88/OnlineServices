//VERIFIED V3
using Microsoft.Extensions.Logging;
using Moq;
using OnlineServices.Common.Enumerations;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TranslationServices.DataLayer.ServiceAgents.Domain;
using TranslationServices.DataLayer.ServiceAgents.Extensions;
using TranslationServices.DataLayer.ServiceAgents.Interfaces;
using TranslationServices.DataLayer.ServiceAgents.TranslationAgents;
using Xunit;

namespace TranslationServices.DataLayer.ServiceAgentsTests
{
    public class AzureCognitiveAuthenticationTests
    {
        [Fact(Skip = "Run ONLY to Test Azure Cognitive Credentials")]
        public async void AzureCognitiveCredentialsTest()
        {
            var tupleToTranslate = new Tuple<Language, string>(Language.French, "Hello world!");

            string route = tupleToTranslate.ComposeRoute();

            //IMPLEMENTATION

            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                // In the next few sections you'll add code to construct the request.
                // Build the request.
                // Set the method to Post.
                request.Method = HttpMethod.Post;
                // Construct the URI and add headers.
                request.RequestUri = new Uri(TestHelper.AzCognitiveArgs.Endpoint + route);
                request.Content = new StringContent(tupleToTranslate.ToJsonObject(), Encoding.UTF8, "application/json");
                request.Headers.Add("Ocp-Apim-Subscription-Key", TestHelper.AzCognitiveArgs.SubscriptionKey);

                // Send the request and get response.
                HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);
                // Read response as a string.
                string result = await response.Content.ReadAsStringAsync();
                // Deserialize the response using the classes created earlier.
                Console.WriteLine(result);
                Assert.Equal("[{\"translations\":[{\"text\":\"Hello world!\",\"to\":\"en\"},{\"text\":\"Hallo mensen!\",\"to\":\"nl\"}]}]", result);
            }
        }

        [Fact(Skip = "Run ONLY to Test Azure Cognitive Credentials")]
        public void AzCogniveWellSetupInWorkstation()
        {
            //DOC https://docs.microsoft.com/en-us/azure/cognitive-services/translator/quickstart-translate?pivots=programming-language-csharp#set-up
            //DOC "Please set/export the environment variable: " + key_var);
            //DOC "Please set/export the environment variable: " + endpoint_var);
            
            const string key_var = "TRANSLATOR_TEXT_SUBSCRIPTION_KEY";
            var subscriptionKey = Environment.GetEnvironmentVariable(key_var);

            const string endpoint_var = "TRANSLATOR_TEXT_ENDPOINT";
            var endpoint = Environment.GetEnvironmentVariable(endpoint_var);

            Assert.NotNull(subscriptionKey);
            Assert.NotNull(endpoint);
        }

        [Fact(Skip = "Code as Demo to Azure Cognitive")]
        public void DemoOfGeneralUseOfAzureCognitive()
        {
            var OriginalText = new Tuple<Language, string>(Language.English, "Hello World!");

            ITRSTranslationService Translator = new AzureCognitiveAgent(TestHelper.MockILogger().Object, TestHelper.AzCognitiveArgs);

            var Translations = Translator.TranslateAsync(OriginalText);

            Translations.Wait();

            var r = Translations.Result;

            Assert.Equal(Enum.GetNames(typeof(Language)).Length, r.Length);
        }
    }
}
