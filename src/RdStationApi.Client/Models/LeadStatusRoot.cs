﻿using Newtonsoft.Json;

namespace RdStationApi.Client
{
    public sealed class LeadStatusRoot
    {
        /// <summary>
        /// Objeto para alteração do status do Lead
        /// </summary>
        /// <param name="authToken">Token privado da sua empresa no RD Station. 
        /// <br/>
        /// Acesse <a href="https://www.rdstation.com.br/integracoes">https://www.rdstation.com.br/integracoes</a> para descobrir qual usar para sua empresa.</param>
        /// <param name="leadStatus">Objeto para alteração do estágio do Lead</param>
        public LeadStatusRoot(string authToken, LeadStatus leadStatus)
        {
            AuthToken = authToken;
            LeadStatus = leadStatus;
        }
        /// <summary>
        /// Token privado da sua empresa no RD Station. Acesse <see href="https://www.rdstation.com.br/integracoes">este link</see> para descobrir qual usar para sua empresa.
        /// </summary>
        [JsonProperty("auth_token")]
        public string AuthToken { get; set; }
        /// <summary>
        /// Objeto para alteração do estágio do Lead
        /// </summary>
        [JsonProperty("lead")]
        public LeadStatus LeadStatus { get; set; }
    }
}