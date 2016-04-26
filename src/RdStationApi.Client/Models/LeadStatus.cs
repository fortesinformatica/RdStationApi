using Newtonsoft.Json;

namespace RdStationApi.Client
{
    public sealed class LeadStatus
    {
        /// <summary>
        /// Objeto para alteração do estágio do Lead
        /// </summary>
        /// <param name="lifecycleStage">Estágio no funil de vendas</param>
        /// <param name="opportunity">Marcar lead como oportunidade: true ou false</param>
        public LeadStatus(LifeCycleLeadStage lifecycleStage, bool? opportunity = null)
        {
            LifecycleStage = lifecycleStage;
            Opportunity = opportunity;
        }

        /// <summary>
        /// Estágio no funil de vendas:
        /// 0 - Lead;
        /// 1 - Lead Qualificado; 
        /// 2 - Cliente
        /// </summary>
        [JsonProperty("lifecycle_stage")]
        public LifeCycleLeadStage LifecycleStage { get; }
        /// <summary>
        /// Marcar lead como oportunidade: true ou false
        /// </summary>
        [JsonProperty("opportunity", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Opportunity { get; }
    }
}