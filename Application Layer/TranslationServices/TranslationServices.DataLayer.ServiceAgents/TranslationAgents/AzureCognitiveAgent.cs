using OnlineServices.Common.Exceptions;
using OnlineServices.Common.Extensions;
using OnlineServices.Common.TranslationServices.Extensions;
using Serilog;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using TranslationServices.DataLayer.ServiceAgents.Domain;
using TranslationServices.DataLayer.ServiceAgents.Domain.AzureCognitive;
using TranslationServices.DataLayer.ServiceAgents.Extensions;
using TranslationServices.DataLayer.ServiceAgents.Interfaces;

using Language = OnlineServices.Common.Enumerations.Language;

namespace TranslationServices.DataLayer.ServiceAgents.TranslationAgents
{
    /// <summary>
    /// Adapter pattern implementation for the Azure Cognitive Tranlaslation API.
    /// </summary>
    public class AzureCognitiveAgent : ITRSTranslationService
    {
        private readonly AzureCognitiveArgs cognitiveServiceConfig;
        private readonly ILogger iLogger;

        /// <summary>
        /// Logger for debuging purposes and azure subscription information for the Azure Cognitive services.
        /// </summary>
        /// <param name="iLogger"></param>
        /// <param name="SubscriptionConfig"></param>
        public AzureCognitiveAgent(ILogger iLogger, AzureCognitiveArgs SubscriptionConfig)
        {
            this.iLogger = iLogger ??
                throw new LoggedException(new ArgumentNullException($"{nameof(iLogger)} @ CTOR in AzureCognitiveAgent"));

            this.cognitiveServiceConfig = SubscriptionConfig ??
                throw new LoggedException(new ArgumentNullException($"{nameof(SubscriptionConfig)} @ CTOR in AzureCognitiveAgent"));
        }
        //TODO Imlement log of information and warning etc...

        //Tuple<Language, string>[] Translate(Tuple<Language, string> OriginalText)
        //{
        //    ITRSTranslationService iTranslator = this;

        //    var task = iTranslator.TranslateAsync(OriginalText);
        //    task.Wait();
        //    return task.Result;
        //}

        async Task<Tuple<Language, string>[]> ITRSTranslationService.TranslateAsync(Tuple<Language, string> OriginalText)
        {
            //DOC https://docs.microsoft.com/en-us/azure/cognitive-services/translator/quickstart-translate?pivots=programming-language-csharp#set-up

            //CHECKS
            OriginalText.IsValidWithThrow();

            string route = OriginalText.ComposeRoute();

            //IMPLEMENTATION
            List<Tuple<Language, string>> ReturnValue = new List<Tuple<Language, string>> { OriginalText };

            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                // Build the request.
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(cognitiveServiceConfig.Endpoint + route);
                request.Content = new StringContent(OriginalText.ToJsonObject(), Encoding.UTF8, "application/json");
                request.Headers.Add("Ocp-Apim-Subscription-Key", cognitiveServiceConfig.SubscriptionKey);

                // Send the request and get response.
                HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);
                string resultJSON = await response.Content.ReadAsStringAsync();
                
                TranslationResult[] deserializedOutput = JsonSerializer.Deserialize<TranslationResult[]>(resultJSON);

                // Iterate over the deserialized results.
                foreach (var o in deserializedOutput)
                {
                    foreach (var t in o.translations)
                    {
                        if (!(t is null))
                        {
                            ReturnValue.Add(new Tuple<Language, string>(t.to.ToLanguage(), t.text));
                            iLogger.Verbose($"Translated to {t.to}: {t.text}");
                        }
                    }
                }
            }

            return ReturnValue.ToArray();
        }
    }
}
