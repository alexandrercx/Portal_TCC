using System;
using System.Collections.Generic;
using RestSharp;
using ServicoAssociadoWeb.Integrations.Client;
using Microsoft.Extensions.Configuration;
using ServicoAssociadoWeb.Integrations.Models.APIToken;
using ServicoTokenWeb.Integrations.Client.APIToken;

namespace ServicoAssociadoWeb.Integrations.Api
{
   public interface ITokenApi
   {
      void SetBasePath(String basePath);

      ResponseTokenModel ApiTokenPost(PostTokenModel body);
   }

   public class TokenApi : ITokenApi
   {
      private readonly IConfiguration _IConfiguration;

      public TokenApi(IConfiguration configuration)
      {
         _IConfiguration = configuration;
         this.ApiClient = this.ApiClient = new ApiClientToken(_IConfiguration.GetSection("Settings:ApiToken:BasePath").Value);
      }

      public TokenApi(String basePath)
      {
         this.ApiClient = new ApiClientToken(basePath);
      }

      public void SetBasePath(String basePath)
      {
         this.ApiClient.BasePath = basePath;
      }

      public String GetBasePath(String basePath)
      {
         return this.ApiClient.BasePath;
      }

      public ApiClientToken ApiClient { get; set; }

      public ResponseTokenModel ApiTokenPost(PostTokenModel body)
      {
         // verify the required parameter 'body' is set
         if (body == null) throw new ApiException(400, "Missing required parameter 'body' when calling ApiTokenPost");

         var path = "/oauth/token";
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
            throw new ApiException((int)response.StatusCode, "Error calling ApiTokenPost: " + response.Content, response.Content);
         else if (((int)response.StatusCode) == 0)
            throw new ApiException((int)response.StatusCode, "Error calling ApiTokenPost: " + response.ErrorMessage, response.ErrorMessage);

         return (ResponseTokenModel)ApiClient.Deserialize(response.Content, typeof(ResponseTokenModel), response.Headers);
      }

   }
}
