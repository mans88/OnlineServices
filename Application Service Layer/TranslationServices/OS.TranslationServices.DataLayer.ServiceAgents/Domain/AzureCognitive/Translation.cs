namespace TranslationServices.DataLayer.ServiceAgents.Domain.AzureCognitive
{
    public class Translation
    {
        public string text { get; set; }
        public TextResult Transliteration { get; set; }
        public string to { get; set; }
        public Alignment Alignment { get; set; }
        public SentenceLength SentLen { get; set; }
    }
}
