//using Google.Apis.Auth.OAuth2;
//using Google.Cloud.Translation.V2;
using OnlineServices.Common.Exceptions;
using OnlineServices.Common.Extensions;
using OnlineServices.Common.TranslationServices.Extensions;
using Serilog;

using System;
using System.Threading.Tasks;

using TranslationServices.DataLayer.ServiceAgents.Extensions;
using TranslationServices.DataLayer.ServiceAgents.Interfaces;

using Language = OnlineServices.Common.Enumerations.Language;

namespace TranslationServices.DataLayer.ServiceAgents.TranslationAgents
{
    public class GoogleTranslationAgent : ITRSTranslationService
    {
        private readonly string apiKey;
        private readonly ILogger iLogger;

        public GoogleTranslationAgent(ILogger iLogger, string apiKey = @"C:\TFS\OnlineServices-d9921f8e5f21.json")
        {
            this.iLogger = iLogger ?? throw new ArgumentNullException($"{nameof(apiKey)} @ CTOR in GoogleTranslationAgent");

            if (apiKey.IsNullOrWhiteSpace())
            {
                var exceptionMSG = $"You should provide a valid Google APIKey. {nameof(apiKey)} @ CTOR in GoogleTranslationAgent";
                iLogger.Error(exceptionMSG);
                throw new IsNullOrWhiteSpaceException(exceptionMSG);
            }
            else
                this.apiKey = apiKey;
        }

        //Tuple<Language, string>[] Translate(Tuple<Language, string> OriginalText)
        //{
        //    //CHECKS
        //    OriginalText.IsValidWithThrow();

        //    //IMPLEMENTATION
        //    throw new NotImplementedException("Depends on a current Google Cloud Account with Credit Card");


        //    #region This Region depends on a current Google Cloud Account with Credit Card entered on it.
        //    //DOC Students should create a service account https://cloud.google.com/docs/authentication/getting-started
        //    var credential = GoogleCredential.FromFile(apiKey);

        //    var result = new List<Tuple<Language, string>> { OriginalText };
        //    using (var client = TranslationClient.Create(credential, TranslationModel.NeuralMachineTranslation))
        //    {

        //        foreach (var item in Enum.GetValues(typeof(Language)))
        //        {
        //            if ((Language)item != OriginalText.Item1)
        //            result.Add(new Tuple<Language, string>((Language)item, client.TranslateText(OriginalText.Item2, ((Language)item).ToGoogleLanguage(), OriginalText.Item1.ToGoogleLanguage()).TranslatedText));
        //        }
        //    }

        //    return result.ToArray();
        //    #endregion
        //}

        Task<Tuple<Language, string>[]> ITRSTranslationService.TranslateAsync(Tuple<Language, string> OriginalText)
        {
            //CHECKS
            OriginalText.IsValidWithThrow();

            //IMPLEMENTATION
            throw new NotImplementedException("Not Implemented as Async @ GoogleTranslationAgent.Translate(Tuple<Language, string> OriginalText)");
        }
    }
}
