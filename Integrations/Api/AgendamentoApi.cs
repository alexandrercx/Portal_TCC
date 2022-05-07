using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using RestSharp;
using ServicoAssociadoWeb.Integrations.Client;
using ServicoAssociadoWeb.Integrations.Client.APIServicosAssociado;
using ServicoAssociadoWeb.Integrations.Models.APIServicosAssociado;

namespace ServicoAssociadoWeb.Integrations.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IAgendamentoApi
    {
        void SetBasePath(String basePath);
        /// <summary>
        /// Consultar agendamento(s) do associado: Este endpoint deve ser utilizado para  consultar um agendamento específico   utilizando o identificador do associado como filtro. 
        /// </summary>
        /// <param name="token">Chave para autenticação</param>
        /// <param name="idAssociado">Identificador do associado</param>
        /// <returns>ResponseAgendamentoViewModel</returns>
        List<ResponseAgendamentoViewModel> ApiAgendamentoGet(string token, int? idAssociado);
        /// <summary>
        /// Cancelar agendamento: Este endpoint deve ser utilizado para cancelar um agendamento. 
        /// </summary>
        /// <param name="token">Chave para autenticação</param>
        /// <param name="id">Identificador do agendamento</param>
        /// <returns>string</returns>
        string ApiAgendamentoIdDelete(string token, int? id);
        /// <summary>
        /// Consultar agendamento: Este endpoint deve ser utilizado para  consultar um agendamento específico   utilizando o identificador do agendamento como filtro. 
        /// </summary>
        /// <param name="token">Chave para autenticação</param>
        /// <param name="id">Identificador do agendamento</param>
        /// <returns>ResponseAgendamentoViewModel</returns>
        ResponseAgendamentoViewModel ApiAgendamentoIdGet(string token, int? id);
        /// <summary>
        /// Alterar agendamento: Este endpoint deve ser utilizado para altear um agendamento. 
        /// </summary>
        /// <param name="body">Dados do agendamento</param>
        /// <param name="token">Chave para autenticação</param>
        /// <param name="id">Identificador do agendamento</param>
        /// <returns>string</returns>
        string ApiAgendamentoIdPut(RequestAgendamentoViewModel body, string token, int? id);
        /// <summary>
        /// Cadastrar agendamento: Este endpoint deve ser utilizado para registrar agendamentos para os associados. 
        /// </summary>
        /// <param name="body">Dados do agendamento</param>
        /// <param name="token">Chave para autenticação</param>
        /// <returns>ResponseAgendamentoViewModel</returns>
        ResponseAgendamentoViewModel ApiAgendamentoPost(RequestAgendamentoViewModel body, string token);
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class AgendamentoApi : IAgendamentoApi
    {
        private readonly IConfiguration _IConfiguration;

        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public void SetBasePath(String basePath)
        {
            this.ApiClient.BasePath = basePath;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AgendamentoApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public AgendamentoApi(IConfiguration configuration)
        {
            _IConfiguration = configuration;
            //if (apiClient == null) // use the default one in Configuration
            //    this.ApiClient = ConfigurationServicoAssociado.DefaultApiClient;
            //else
            this.ApiClient = new ApiClientServicoAssociado( _IConfiguration.GetSection("Settings:ApiAgendamento:BasePath").Value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AgendamentoApi"/> class.
        /// </summary>
        /// <returns></returns>
        public AgendamentoApi(String basePath)
        {
            this.ApiClient = new ApiClientServicoAssociado(basePath);
        }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public String GetBasePath(String basePath)
        {
            return this.ApiClient.BasePath;
        }

        /// <summary>
        /// Gets or sets the API client.
        /// </summary>
        /// <value>An instance of the ApiClient</value>
        public ApiClientServicoAssociado ApiClient { get; set; }

        /// <summary>
        /// Consultar agendamento(s) do associado: Este endpoint deve ser utilizado para  consultar um agendamento específico   utilizando o identificador do associado como filtro. 
        /// </summary>
        /// <param name="token">Chave para autenticação</param>
        /// <param name="idAssociado">Identificador do associado</param>
        /// <returns>ResponseAgendamentoViewModel</returns>
        public List<ResponseAgendamentoViewModel> ApiAgendamentoGet(string token, int? idAssociado)
        {
            // verify the required parameter 'token' is set
            if (token == null) throw new ApiException(400, "Missing required parameter 'token' when calling ApiAgendamentoGet");
            // verify the required parameter 'idAssociado' is set
            if (idAssociado == null) throw new ApiException(400, "Missing required parameter 'idAssociado' when calling ApiAgendamentoGet");

            var path = "/api/Agendamento";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            if (idAssociado != null) queryParams.Add("idAssociado", ApiClient.ParameterToString(idAssociado)); // query parameter
            if (token != null) headerParams.Add("token", ApiClient.ParameterToString(token)); // header parameter

            // authentication setting, if any
            String[] authSettings = new String[] { };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling ApiAgendamentoGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling ApiAgendamentoGet: " + response.ErrorMessage, response.ErrorMessage);

            return (List<ResponseAgendamentoViewModel>)ApiClient.Deserialize(response.Content, typeof(List<ResponseAgendamentoViewModel>), response.Headers);
        }

        /// <summary>
        /// Cancelar agendamento: Este endpoint deve ser utilizado para cancelar um agendamento. 
        /// </summary>
        /// <param name="token">Chave para autenticação</param>
        /// <param name="id">Identificador do agendamento</param>
        /// <returns>string</returns>
        public string ApiAgendamentoIdDelete(string token, int? id)
        {
            // verify the required parameter 'token' is set
            if (token == null) throw new ApiException(400, "Missing required parameter 'token' when calling ApiAgendamentoIdDelete");
            // verify the required parameter 'id' is set
            if (id == null) throw new ApiException(400, "Missing required parameter 'id' when calling ApiAgendamentoIdDelete");

            var path = "/api/Agendamento/{id}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "id" + "}", ApiClient.ParameterToString(id));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            if (token != null) headerParams.Add("token", ApiClient.ParameterToString(token)); // header parameter

            // authentication setting, if any
            String[] authSettings = new String[] { };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling ApiAgendamentoIdDelete: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling ApiAgendamentoIdDelete: " + response.ErrorMessage, response.ErrorMessage);

            return (string)ApiClient.Deserialize(response.Content, typeof(string), response.Headers);
        }

        /// <summary>
        /// Consultar agendamento: Este endpoint deve ser utilizado para  consultar um agendamento específico   utilizando o identificador do agendamento como filtro. 
        /// </summary>
        /// <param name="token">Chave para autenticação</param>
        /// <param name="id">Identificador do agendamento</param>
        /// <returns>ResponseAgendamentoViewModel</returns>
        public ResponseAgendamentoViewModel ApiAgendamentoIdGet(string token, int? id)
        {
            // verify the required parameter 'token' is set
            if (token == null) throw new ApiException(400, "Missing required parameter 'token' when calling ApiAgendamentoIdGet");
            // verify the required parameter 'id' is set
            if (id == null) throw new ApiException(400, "Missing required parameter 'id' when calling ApiAgendamentoIdGet");

            var path = "/api/Agendamento/{id}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "id" + "}", ApiClient.ParameterToString(id));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            if (token != null) headerParams.Add("token", ApiClient.ParameterToString(token)); // header parameter

            // authentication setting, if any
            String[] authSettings = new String[] { };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling ApiAgendamentoIdGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling ApiAgendamentoIdGet: " + response.ErrorMessage, response.ErrorMessage);

            return (ResponseAgendamentoViewModel)ApiClient.Deserialize(response.Content, typeof(ResponseAgendamentoViewModel), response.Headers);
        }

        /// <summary>
        /// Alterar agendamento: Este endpoint deve ser utilizado para altear um agendamento. 
        /// </summary>
        /// <param name="body">Dados do agendamento</param>
        /// <param name="token">Chave para autenticação</param>
        /// <param name="id">Identificador do agendamento</param>
        /// <returns>string</returns>
        public string ApiAgendamentoIdPut(RequestAgendamentoViewModel body, string token, int? id)
        {
            // verify the required parameter 'body' is set
            if (body == null) throw new ApiException(400, "Missing required parameter 'body' when calling ApiAgendamentoIdPut");
            // verify the required parameter 'token' is set
            if (token == null) throw new ApiException(400, "Missing required parameter 'token' when calling ApiAgendamentoIdPut");
            // verify the required parameter 'id' is set
            if (id == null) throw new ApiException(400, "Missing required parameter 'id' when calling ApiAgendamentoIdPut");

            var path = "/api/Agendamento/{id}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "id" + "}", ApiClient.ParameterToString(id));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            if (token != null) headerParams.Add("token", ApiClient.ParameterToString(token)); // header parameter
            postBody = ApiClient.Serialize(body); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling ApiAgendamentoIdPut: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling ApiAgendamentoIdPut: " + response.ErrorMessage, response.ErrorMessage);

            return (string)ApiClient.Deserialize(response.Content, typeof(string), response.Headers);
        }

        /// <summary>
        /// Cadastrar agendamento: Este endpoint deve ser utilizado para registrar agendamentos para os associados. 
        /// </summary>
        /// <param name="body">Dados do agendamento</param>
        /// <param name="token">Chave para autenticação</param>
        /// <returns>ResponseAgendamentoViewModel</returns>
        public ResponseAgendamentoViewModel ApiAgendamentoPost(RequestAgendamentoViewModel body, string token)
        {
            // verify the required parameter 'body' is set
            if (body == null) throw new ApiException(400, "Missing required parameter 'body' when calling ApiAgendamentoPost");
            // verify the required parameter 'token' is set
            if (token == null) throw new ApiException(400, "Missing required parameter 'token' when calling ApiAgendamentoPost");

            var path = "/api/Agendamento";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            if (token != null) headerParams.Add("token", ApiClient.ParameterToString(token)); // header parameter
            postBody = ApiClient.Serialize(body); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling ApiAgendamentoPost: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling ApiAgendamentoPost: " + response.ErrorMessage, response.ErrorMessage);

            return (ResponseAgendamentoViewModel)ApiClient.Deserialize(response.Content, typeof(ResponseAgendamentoViewModel), response.Headers);
        }

    }
}
