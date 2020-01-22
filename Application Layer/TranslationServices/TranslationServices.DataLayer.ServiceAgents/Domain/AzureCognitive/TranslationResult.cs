using System;
using System.Collections.Generic;
using System.Text;

namespace TranslationServices.DataLayer.ServiceAgents.Domain.AzureCognitive
{
    /// <summary>
    /// The C# classes that represents the JSON returned by the Translator Text API.
    /// </summary>
    public class TranslationResult
    {
        public DetectedLanguage DetectedLanguage { get; set; }
        public TextResult SourceText { get; set; }
        public Translation[] translations { get; set; }
    }
}
