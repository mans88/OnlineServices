//VERIFIED V3
using OnlineServices.Common.Enumerations;
using System;
using System.Threading.Tasks;
using TranslationServices.DataLayer.ServiceAgents.Domain;

namespace TranslationServices.DataLayer.ServiceAgents.Interfaces
{
    public interface ITRSTranslationService
    {
        Task<Tuple<Language, string>[]> TranslateAsync(Tuple<Language, string> OriginalText);
    }
}