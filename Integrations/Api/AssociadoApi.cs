using System;
using System.Collections.Generic;
using RestSharp;
using ServicoAssociadoWeb.Integrations.Models.APIAssociado;
using ServicoAssociadoWeb.Integrations.Client;
using ServicoAssociadoWeb.Integrations.Client.APIAssociado;
using Microsoft.Extensions.Configuration;

namespace ServicoAssociadoWeb.Integrations.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IAssociadoApi
    {
        void SetBasePath(String basePath);
        /// <summary>
        ///  
        /// </summary>
        /// <param name="email"></param>
        /// <returns>ResponseAssociadoViewModel</returns>
        ResponseAssociadoViewModel ApiAssociadoGet (string email);
        /// <summary>
        ///  
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ResponseAssociadoViewModel</returns>
        ResponseAssociadoViewModel ApiAssociadoIdGet (long? id);
        /// <summary>
        ///  
        /// </summary>
        /// <param name="body"></param>
        /// <returns>ResponseAssociadoViewModel</returns>
        ResponseAssociadoViewModel ApiAssociadoPost (PostAssociadoViewModel body);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class AssociadoApi : IAssociadoApi
    {
        private readonly IConfiguration _IConfiguration;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssociadoApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public AssociadoApi(IConfiguration configuration)
        {
            _IConfiguration = configuration;
            //if (apiClient == null) // use the default one in Configuration
            //    this.ApiClient = ConfigurationAssociado.DefaultApiClient; 
            //else
            this.ApiClient = this.ApiClient = new ApiClientAssociado(_IConfiguration.GetSection("Settings:ApiAssociado:BasePath").Value); ;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="AssociadoApi"/> class.
        /// </summary>
        /// <returns></returns>
        public AssociadoApi(String basePath)
        {
            this.ApiClient = new ApiClientAssociado(basePath);
        }
    
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
        public ApiClientAssociado ApiClient {get; set;}
    
        /// <summary>
        ///  
        /// </summary>
        /// <param name="email"></param>
        /// <returns>ResponseAssociadoViewModel</returns>
        public ResponseAssociadoViewModel ApiAssociadoGet (string email)
        {
            // verify the required parameter 'email' is set
            if (email == null) throw new ApiException(400, "Missing required parameter 'email' when calling ApiAssociadoGet");
    
            var path = "/api/Associado";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (email != null) queryParams.Add("email", ApiClient.ParameterToString(email)); // query parameter
                        
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling ApiAssociadoGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ApiAssociadoGet: " + response.ErrorMessage, response.ErrorMessage);
    
            return (ResponseAssociadoViewModel) ApiClient.Deserialize(response.Content, typeof(ResponseAssociadoViewModel), response.Headers);
        }
    
        /// <summary>
        ///  
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ResponseAssociadoViewModel</returns>
        public ResponseAssociadoViewModel ApiAssociadoIdGet (long? id)
        {
            // verify the required parameter 'id' is set
            if (id == null) throw new ApiException(400, "Missing required parameter 'id' when calling ApiAssociadoIdGet");
    
            var path = "/api/Associado/{id}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "id" + "}", ApiClient.ParameterToString(id));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling ApiAssociadoIdGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ApiAssociadoIdGet: " + response.ErrorMessage, response.ErrorMessage);
    
            return (ResponseAssociadoViewModel) ApiClient.Deserialize(response.Content, typeof(ResponseAssociadoViewModel), response.Headers);
        }
    
        /// <summary>
        ///  
        /// </summary>
        /// <param name="body"></param>
        /// <returns>ResponseAssociadoViewModel</returns>
        public ResponseAssociadoViewModel ApiAssociadoPost (PostAssociadoViewModel body)
        {
            // verify the required parameter 'body' is set
            if (body == null) throw new ApiException(400, "Missing required parameter 'body' when calling ApiAssociadoPost");
    
            var path = "/api/Associado";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                    postBody = ApiClient.Serialize(body); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling ApiAssociadoPost: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ApiAssociadoPost: " + response.ErrorMessage, response.ErrorMessage);
    
            return (ResponseAssociadoViewModel) ApiClient.Deserialize(response.Content, typeof(ResponseAssociadoViewModel), response.Headers);
        }
    
    }
}
