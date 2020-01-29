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

namespace OnlineServices.Pwsh5.Cmdlets.TRS
{
    [Cmdlet(VerbsCommon.Get, "OSTranslation")]
    public class GetOSTranslation : Cmdlet
    {
        [Parameter(Position = 1, Mandatory = true, ValueFromPipeline = true)]
        public string Source { get; set; }

        [Parameter(Position = 1, Mandatory = true, ValueFromPipeline = false)]
        public Language Name { get; set; } = Language.English;

        //public Language Language { get; set; }
        protected override void ProcessRecord()
        {
            if (string.IsNullOrWhiteSpace(Source))
                WriteObject("");

            ITRSServicesRole service = new OnlineServicesSystem(null, new AzureCognitiveAgent());

            service.Translate
            var hi = $"Hello, {Name}!";
            WriteObject(hi);
            
            base.ProcessRecord();
        }

    }
}
