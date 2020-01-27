using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace OnlineServices.Pwsh5.Cmdlets
{
    [Cmdlet(VerbsCommon.Get, "Hello")]
    public class GetHello : Cmdlet
    {
        [Parameter(Position = 1, Mandatory = true, ValueFromPipeline = true)]
        public string Name { get; set; } = "World";

        //public Language Language { get; set; }
        protected override void ProcessRecord()
        {
            if (string.IsNullOrWhiteSpace(Name))
                Name = "World";

            var hi = $"Hello, {Name}!";
            WriteObject(hi);
            
            base.ProcessRecord();
        }

    }
}
