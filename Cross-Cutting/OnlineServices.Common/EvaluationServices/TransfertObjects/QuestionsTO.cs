using OnlineServices.Common.DataAccessHelpers;
using OnlineServices.Common.EvaluationServices.Enumerations;
using OnlineServices.Common.TranslationServices.TransfertObjects;

namespace OnlineServices.Common.EvaluationServices.TransfertObjects
{
    public class QuestionsTO : IEntity<int>
    {
        public int Id { get; set; }
        public QuestionsType Type { get; set; }
        public int Position { get; set; }
        public MultiLanguageString Libelle { get; set; }
    }
}