//VERIFIED V3
using OnlineServices.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace TranslationServices.DataLayer.ServiceAgents.Domain
{
    public class AzureCognitiveArgs
    {
        public AzureCognitiveArgs(string SubscriptionKey, string Endpoint)
        {
            SubscriptionKey.IsNullOrWhiteSpace(true);
            Endpoint.IsNullOrWhiteSpace(true);

            this.SubscriptionKey = SubscriptionKey;
            this.Endpoint = Endpoint;
        }
        public string SubscriptionKey { get; private set; }

        public string Endpoint { get; private set; }
    }
}
