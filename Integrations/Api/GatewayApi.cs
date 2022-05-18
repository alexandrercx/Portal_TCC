using Microsoft.Extensions.Configuration;
using RestSharp;
using ServicoAssociadoWeb.Integrations.Client;
using ServicoAssociadoWeb.Integrations.Models.APIAssociado;
using ServicoAssociadoWeb.Integrations.Models.APIServicosAssociado;
using ServicoAssociadoWeb.Integrations.Models.APIToken;
using ServicoGatewayWeb.Integrations.Client.APIGateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIAssociado = ServicoAssociadoWeb.Integrations.Models.APIAssociado;
using APIServicosAssociado = ServicoAssociadoWeb.Integrations.Models.APIServicosAssociado;

namespace ServicoAssociadoWeb.Integrations.Api
{
   public interface IGatewayApi
   {
      void SetBasePath(String basePath);

      APIAssociado.ResponseAssociadoViewModel ApiAssociadoGet(string email);

      APIAssociado.ResponseAssociadoViewModel ApiAssociadoIdGet(long? id);

      APIAssociado.ResponseAssociadoViewModel ApiAssociadoPost(APIAssociado.PostAssociadoViewModel body);

      List<APIServicosAssociado.ResponseAgendamentoViewModel> ApiAgendamentoGet(string token, int? idAssociado);

      string ApiAgendamentoIdDelete(string token, int? id);

      APIServicosAssociado.ResponseAgendamentoViewModel ApiAgendamentoIdGet(string token, int? id);

      string ApiAgendamentoIdPut(APIServicosAssociado.RequestAgendamentoViewModel body, string token, int? id);

      APIServicosAssociado.ResponseAgendamentoViewModel ApiAgendamentoPost(APIServicosAssociado.RequestAgendamentoViewModel body, string token);
   }

   public class GatewayApi : IGatewayApi
   {
      private readonly IConfiguration _IConfiguration;
      private readonly ITokenApi _ITokenApi;
      private TokenModel _localToken;

      public GatewayApi(ITokenApi tokenApi, IConfiguration configuration)
      {
         _IConfiguration = configuration;
         _ITokenApi = tokenApi;

         this.ApiClient = this.ApiClient = new ApiClientGateway(_IConfiguration.GetSection("Settings:ApiGateway:BasePath").Value);

         if (!this.ApiClient.DefaultHeader.ContainsKey("authorization"))
            this.ApiClient.AddDefaultHeader("authorization", $"{Token.Response.TokenType} {Token.Response.AccessToken}");
         else
            this.ApiClient.DefaultHeader["authorization"] = $"{Token.Response.TokenType} {Token.Response.AccessToken}";
      }      

      public TokenModel Token
      {
         get
         {
            if (_localToken == null || _localToken.ExpiresIn <= DateTime.Now)
            {
               DateTime start = DateTime.Now;

               var tokenResponse = _ITokenApi.ApiTokenPost(new PostTokenModel());

               _localToken = new TokenModel() { Response = tokenResponse, ExpiresIn = start.AddSeconds((double)tokenResponse.ExpiresIn) }; 
            }

            return _localToken;
         }
      }

      //public GatewayApi(String basePath)
      //{
      //   this.ApiClient = new ApiClientGateway(basePath);
      //}


      //public void SetAuthorization(string authorization)
      //{
      //   if (!this.ApiClient.DefaultHeader.ContainsKey("Authorization"))
      //      this.ApiClient.AddDefaultHeader("Authorization", authorization);
      //   else
      //      this.ApiClient.DefaultHeader["Authorization"] = authorization;
      //}

      public void SetBasePath(String basePath)
      {
         this.ApiClient.BasePath = basePath;
      }

      public String GetBasePath(String basePath)
      {
         return this.ApiClient.BasePath;
      }

      public ApiClientGateway ApiClient { get; set; }

      public APIAssociado.ResponseAssociadoViewModel ApiAssociadoGet(string email)
      {
         // verify the required parameter 'email' is set
         if (email == null) throw new ApiException(400, "Missing required parameter 'email' when calling ApiAssociadoGet");

         var path = "/Associado";
         path = path.Replace("{format}", "json");

         var queryParams = new Dictionary<String, String>();
         var headerParams = new Dictionary<String, String>();
         var formParams = new Dictionary<String, String>();
         var fileParams = new Dictionary<String, FileParameter>();
         String postBody = null;

         if (email != null) queryParams.Add("email", ApiClient.ParameterToString(email)); // query parameter

         // authentication setting, if any
         String[] authSettings = new String[] { };

         // make the HTTP request
         IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

         if (((int)response.StatusCode) >= 400)
            throw new ApiException((int)response.StatusCode, "Error calling ApiAssociadoGet: " + response.Content, response.Content);
         else if (((int)response.StatusCode) == 0)
            throw new ApiException((int)response.StatusCode, "Error calling ApiAssociadoGet: " + response.ErrorMessage, response.ErrorMessage);

         return (APIAssociado.ResponseAssociadoViewModel)ApiClient.Deserialize(response.Content, typeof(APIAssociado.ResponseAssociadoViewModel), response.Headers);

      }

      public APIAssociado.ResponseAssociadoViewModel ApiAssociadoIdGet(long? id)
      {
         // verify the required parameter 'id' is set
         if (id == null) throw new ApiException(400, "Missing required parameter 'id' when calling ApiAssociadoIdGet");

         var path = "/Associado/{id}";
         path = path.Replace("{format}", "json");
         path = path.Replace("{" + "id" + "}", ApiClient.ParameterToString(id));

         var queryParams = new Dictionary<String, String>();
         var headerParams = new Dictionary<String, String>();
         var formParams = new Dictionary<String, String>();
         var fileParams = new Dictionary<String, FileParameter>();
         String postBody = null;


         // authentication setting, if any
         String[] authSettings = new String[] { };

         // make the HTTP request
         IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

         if (((int)response.StatusCode) >= 400)
            throw new ApiException((int)response.StatusCode, "Error calling ApiAssociadoIdGet: " + response.Content, response.Content);
         else if (((int)response.StatusCode) == 0)
            throw new ApiException((int)response.StatusCode, "Error calling ApiAssociadoIdGet: " + response.ErrorMessage, response.ErrorMessage);

         return (APIAssociado.ResponseAssociadoViewModel)ApiClient.Deserialize(response.Content, typeof(APIAssociado.ResponseAssociadoViewModel), response.Headers);

      }

      public APIAssociado.ResponseAssociadoViewModel ApiAssociadoPost(PostAssociadoViewModel body)
      {
         // verify the required parameter 'body' is set
         if (body == null) throw new ApiException(400, "Missing required parameter 'body' when calling ApiAssociadoPost");

         var path = "/Associado";
         path = path.Replace("{format}", "json");

         var queryParams = new Dictionary<String, String>();
         var headerParams = new Dictionary<String, String>();
         var formParams = new Dictionary<String, String>();
         var fileParams = new Dictionary<String, FileParameter>();
         String postBody = null;

         postBody = ApiClient.Serialize(body); // http body (model) parameter

         // authentication setting, if any
         String[] authSettings = new String[] { };

         // make the HTTP request
         IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

         if (((int)response.StatusCode) >= 400)
            throw new ApiException((int)response.StatusCode, "Error calling ApiAssociadoPost: " + response.Content, response.Content);
         else if (((int)response.StatusCode) == 0)
            throw new ApiException((int)response.StatusCode, "Error calling ApiAssociadoPost: " + response.ErrorMessage, response.ErrorMessage);

         return (APIAssociado.ResponseAssociadoViewModel)ApiClient.Deserialize(response.Content, typeof(APIAssociado.ResponseAssociadoViewModel), response.Headers);

      }

      public List<ResponseAgendamentoViewModel> ApiAgendamentoGet(string token, int? idAssociado)
      {
         // verify the required parameter 'token' is set
         if (token == null) throw new ApiException(400, "Missing required parameter 'token' when calling ApiAgendamentoGet");
         // verify the required parameter 'idAssociado' is set
         if (idAssociado == null) throw new ApiException(400, "Missing required parameter 'idAssociado' when calling ApiAgendamentoGet");

         var path = "/Agendamento";
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
            throw new ApiException((int)response.StatusCode, $"Error calling ApiAgendamentoGet {response.StatusCode}: {response.Content}");
         else if (((int)response.StatusCode) == 0)
            throw new ApiException((int)response.StatusCode, $"Error calling ApiAgendamentoGet 0: {response.ErrorMessage}");

         return (List<ResponseAgendamentoViewModel>)ApiClient.Deserialize(response.Content, typeof(List<ResponseAgendamentoViewModel>), response.Headers);

      }

      public string ApiAgendamentoIdDelete(string token, int? id)
      {
         // verify the required parameter 'token' is set
         if (token == null) throw new ApiException(400, "Missing required parameter 'token' when calling ApiAgendamentoIdDelete");
         // verify the required parameter 'id' is set
         if (id == null) throw new ApiException(400, "Missing required parameter 'id' when calling ApiAgendamentoIdDelete");

         var path = "/Agendamento/{id}";
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

      public ResponseAgendamentoViewModel ApiAgendamentoIdGet(string token, int? id)
      {
         // verify the required parameter 'token' is set
         if (token == null) throw new ApiException(400, "Missing required parameter 'token' when calling ApiAgendamentoIdGet");
         // verify the required parameter 'id' is set
         if (id == null) throw new ApiException(400, "Missing required parameter 'id' when calling ApiAgendamentoIdGet");

         var path = "/Agendamento/{id}";
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

      public string ApiAgendamentoIdPut(RequestAgendamentoViewModel body, string token, int? id)
      {
         // verify the required parameter 'body' is set
         if (body == null) throw new ApiException(400, "Missing required parameter 'body' when calling ApiAgendamentoIdPut");
         // verify the required parameter 'token' is set
         if (token == null) throw new ApiException(400, "Missing required parameter 'token' when calling ApiAgendamentoIdPut");
         // verify the required parameter 'id' is set
         if (id == null) throw new ApiException(400, "Missing required parameter 'id' when calling ApiAgendamentoIdPut");

         var path = "/Agendamento/{id}";
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

      public ResponseAgendamentoViewModel ApiAgendamentoPost(RequestAgendamentoViewModel body, string token)
      {
         // verify the required parameter 'body' is set
         if (body == null) throw new ApiException(400, "Missing required parameter 'body' when calling ApiAgendamentoPost");
         // verify the required parameter 'token' is set
         if (token == null) throw new ApiException(400, "Missing required parameter 'token' when calling ApiAgendamentoPost");

         var path = "/Agendamento";
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
