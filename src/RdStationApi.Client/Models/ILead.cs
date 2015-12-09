using System;

namespace RdStationApi.Client
{
    public interface ILead
    {
        /// <summary>
        /// Token da sua conta do RD Station. Você deve utilizar o valor numérico encontrado dentro da sua conta da RD, neste https://www.rdstation.com.br/integracoes
        /// </summary>
        string TokenRdStation { get; }

        /// <summary>
        /// Campo utilizado para identificar o evento de entrada do Lead no RD. Ex: form-contato, pedido-de-demo, pedido-de-trial, form-site
        /// </summary>
        string Identificador { get; }

        /// <summary>
        /// O email do Lead
        /// </summary>
        string Email { get; }

        /// <summary>
        /// Nome do Lead
        /// </summary>
        string Nome { get; set; }

        /// <summary>
        /// Cargo do Lead
        /// </summary>
        string Cargo { get; set; }

        /// <summary>
        /// Empresa do Lead
        /// </summary>
        string Empresa { get; set; }

        /// <summary>
        /// Telefone do Lead
        /// </summary>
        string Telefone { get; set; }

        /// <summary>
        /// Celular do Lead
        /// </summary>
        string Celular { get; set; }

        /// <summary>
        /// Estado do Lead
        /// </summary>
        string Estado { get; set; }

        /// <summary>
        /// Cidade do Lead
        /// </summary>
        string Cidade { get; set; }

        /// <summary>
        /// Website do Lead
        /// </summary>
        string Website { get; set; }

        /// <summary>
        /// Twitter do Lead
        /// </summary>
        string Twitter { get; set; }

        /// <summary>
        /// Origem do Lead
        /// </summary>
        string CUtmz { get; set; }

        /// <summary>
        /// Origem do Lead
        /// </summary>
        string TrafficSource { get; set; }

        /// <summary>
        /// Tag do Lead
        /// </summary>
        string Tags { get; set; }

        /// <summary>
        /// Data da conversão do Lead
        /// </summary>
        DateTime? CreatedAt { get; set; }
    }
}