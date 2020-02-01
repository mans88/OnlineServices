using Moq;
using OnlineServices.Common.Enumerations;
using OnlineServices.Common.TranslationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using TranslationServices.BusinessLayer.UseCases;
using TranslationServices.DataLayer.ServiceAgents.TranslationAgents;
using Serilog;
using TranslationServices.DataLayer.ServiceAgents.Domain;
using OnlineServices.Common.SecurityServices.TransfertObjects;
using OnlineServices.Common.Logging;

namespace OnlineServices.Pwsh5.Cmdlets.TRS
{
    [Cmdlet(VerbsCommon.Get, "OSTranslation")]
    public class GetOSTranslation : Cmdlet
    {
        private OnlineServicesRole OSService;

        [Parameter(Position = 1, Mandatory = true, ValueFromPipeline = true)]
        public string Source { get; set; }

        [Parameter(Position = 2, ValueFromPipeline = false)]
        private Language LanguageName { get; set; } = Language.English;

        protected override void BeginProcessing()
        {

            OSService = new OnlineServicesRole(OnlineServicesLogger.LoggerConfigurator(), new AzureCognitiveAgent(OnlineServicesLogger.LoggerConfigurator(), AzCognitiveArgs));

            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            if (string.IsNullOrWhiteSpace(Source))
                WriteObject("");

            var translations =
                OSService.GetTranslations(new ServiceAuthorization(), new Tuple<Language, string>(LanguageName, Source));

            foreach (var t in translations.ToTuplesLanguage())
            {
                WriteObject($"{Enum.GetName(typeof(Language), t.Item1)} - {t.Item2}");
            }

            base.ProcessRecord();
        }

        #region Refactor it!
        public static AzureCognitiveArgs AzCognitiveArgs
            => new AzureCognitiveArgs(SubscriptionKey: "66b23505dc864928a25661c03ba0c7b0", Endpoint: @"https://api.cognitive.microsofttranslator.com/translate?api-version=3.0");
        #endregion

    }
}
