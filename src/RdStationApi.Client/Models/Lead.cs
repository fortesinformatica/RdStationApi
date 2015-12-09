using System;
using Newtonsoft.Json;

namespace RdStationApi.Client
{
    public class Lead : ILead
    {
        /// <summary>
        /// Cria Lead
        /// </summary>
        /// <param name="tokenRdStation">Token da sua conta do RD Station. Você deve utilizar o valor numérico encontrado dentro da sua conta da RD, neste https://www.rdstation.com.br/integracoes</param>
        /// <param name="identificador">Campo utilizado para identificar o evento de entrada do Lead no RD. Ex: form-contato, pedido-de-demo, pedido-de-trial, form-site</param>
        /// <param name="email">O email do Lead</param>
        public Lead(string tokenRdStation, string identificador, string email)
        {
            TokenRdStation = tokenRdStation;
            Identificador = identificador;
            Email = email;
            CreatedAt = DateTime.Now;
        }

        /// <summary>
        /// Token da sua conta do RD Station. Você deve utilizar o valor numérico encontrado dentro da sua conta da RD, neste https://www.rdstation.com.br/integracoes
        /// </summary>
        [JsonProperty("token_rdstation")]
        public string TokenRdStation { get; }

        /// <summary>
        /// Campo utilizado para identificar o evento de entrada do Lead no RD. Ex: form-contato, pedido-de-demo, pedido-de-trial, form-site
        /// </summary>
        [JsonProperty("identificador")]
        public string Identificador { get; }

        /// <summary>
        /// O email do Lead
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; }

        /// <summary>
        /// Nome do Lead
        /// </summary>
        [JsonProperty("nome")]
        public string Nome { get; set; }

        /// <summary>
        /// Cargo do Lead
        /// </summary>
        [JsonProperty("cargo")]
        public string Cargo { get; set; }

        /// <summary>
        /// Empresa do Lead
        /// </summary>
        [JsonProperty("empresa")]
        public string Empresa { get; set; }

        /// <summary>
        /// Telefone do Lead
        /// </summary>
        [JsonProperty("telefone")]
        public string Telefone { get; set; }

        /// <summary>
        /// Celular do Lead
        /// </summary>
        [JsonProperty("celular")]
        public string Celular { get; set; }

        /// <summary>
        /// Estado do Lead
        /// </summary>
        [JsonProperty("estado")]
        public string Estado { get; set; }

        /// <summary>
        /// Cidade do Lead
        /// </summary>
        [JsonProperty("cidade")]
        public string Cidade { get; set; }

        /// <summary>
        /// Website do Lead
        /// </summary>
        [JsonProperty("website")]
        public string Website { get; set; }

        /// <summary>
        /// Twitter do Lead
        /// </summary>
        [JsonProperty("twitter")]
        public string Twitter { get; set; }

        /// <summary>
        /// Origem do Lead
        /// </summary>
        [JsonProperty("c_utmz")]
        public string CUtmz { get; set; }

        /// <summary>
        /// Origem do Lead
        /// </summary>
        [JsonProperty("traffic_source")]
        public string TrafficSource { get; set; }

        /// <summary>
        /// Tag do Lead
        /// </summary>
        [JsonProperty("tags")]
        public string Tags { get; set; }

        /// <summary>
        /// Data da conversão do Lead
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }
    }
}
