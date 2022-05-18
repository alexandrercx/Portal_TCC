using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Extensions;
using Microsoft.Extensions.Configuration;
using ServicoAssociadoWeb.Integrations.Client;

namespace ServicoGatewayWeb.Integrations.Client.APIGateway
{
   public class ApiClientGateway
    {
        private readonly Dictionary<String, String> _defaultHeaderMap = new Dictionary<String, String>();
        private readonly IConfiguration _IConfiguration;

        public ApiClientGateway(String basePath)
        {
            BasePath = basePath;
            RestClient = new RestClient(BasePath);
        }

        public string BasePath { get; set; }

        public RestClient RestClient { get; set; }

        public Dictionary<String, String> DefaultHeader
        {
            get { return _defaultHeaderMap; }
        }

        public Object CallApi(String path, RestSharp.Method method, Dictionary<String, String> queryParams, String postBody,
            Dictionary<String, String> headerParams, Dictionary<String, String> formParams,
            Dictionary<String, FileParameter> fileParams, String[] authSettings)
        {

            var request = new RestRequest(path, method);

            UpdateParamsForAuth(queryParams, headerParams, authSettings);

            // add default header, if any
            foreach (var defaultHeader in _defaultHeaderMap)
                request.AddHeader(defaultHeader.Key, defaultHeader.Value);

            // add header parameter, if any
            foreach (var param in headerParams)
                request.AddHeader(param.Key, param.Value);

            // add query parameter, if any
            foreach (var param in queryParams)
                request.AddParameter(param.Key, param.Value, ParameterType.GetOrPost);

            // add form parameter, if any
            foreach (var param in formParams)
                request.AddParameter(param.Key, param.Value, ParameterType.GetOrPost);

            // add file parameter, if any
            foreach (var param in fileParams)
                request.AddFile(param.Value.Name, param.Value.FileName, param.Value.ContentType);

            if (postBody != null) // http body (model) parameter
                request.AddParameter("application/json", postBody, ParameterType.RequestBody);

            return (Object)RestClient.Execute(request);

        }

        public void AddDefaultHeader(string key, string value)
        {
            _defaultHeaderMap.Add(key, value);
        }

        public string EscapeString(string str)
        {
            return System.Web.HttpUtility.UrlEncode(str);
        }

        public FileParameter ParameterToFile(string name, Stream stream)
        {
            if (stream is FileStream)
                return FileParameter.Create(name, stream.ReadAsBytes(), Path.GetFileName(((FileStream)stream).Name));
            else
                return FileParameter.Create(name, stream.ReadAsBytes(), "no_file_name_provided");
        }

        public string ParameterToString(object obj)
        {
            if (obj is DateTime)
                // Return a formatted date string - Can be customized with Configuration.DateTimeFormat
                // Defaults to an ISO 8601, using the known as a Round-trip date/time pattern ("o")
                // https://msdn.microsoft.com/en-us/library/az4se3k1(v=vs.110).aspx#Anchor_8
                // For example: 2009-06-15T13:45:30.0000000
                return ((DateTime)obj).ToString(ConfigurationGateway.DateTimeFormat);
            else if (obj is List<string>)
                return String.Join(",", (obj as List<string>).ToArray());
            else
                return Convert.ToString(obj);
        }

        public object Deserialize(string content, Type type, IList<Parameter> headers = null)
        {
            if (type == typeof(Object)) // return an object
            {
                return content;
            }

            if (type == typeof(Stream))
            {
                var filePath = String.IsNullOrEmpty(ConfigurationGateway.TempFolderPath)
                    ? Path.GetTempPath()
                    : ConfigurationGateway.TempFolderPath;

                var fileName = filePath + Guid.NewGuid();
                if (headers != null)
                {
                    var regex = new Regex(@"Content-Disposition:.*filename=['""]?([^'""\s]+)['""]?$");
                    var match = regex.Match(headers.ToString());
                    if (match.Success)
                        fileName = filePath + match.Value.Replace("\"", "").Replace("'", "");
                }
                File.WriteAllText(fileName, content);
                return new FileStream(fileName, FileMode.Open);

            }

            if (type.Name.StartsWith("System.Nullable`1[[System.DateTime")) // return a datetime object
            {
                return DateTime.Parse(content, null, System.Globalization.DateTimeStyles.RoundtripKind);
            }

            if (type == typeof(String) || type.Name.StartsWith("System.Nullable")) // return primitive type
            {
                return ConvertType(content, type);
            }

            // at this point, it must be a model (json)
            try
            {
                return JsonConvert.DeserializeObject(content, type);
            }
            catch (IOException e)
            {
                throw new ApiException(500, e.Message);
            }
        }

        public string Serialize(object obj)
        {
            try
            {
                return obj != null ? JsonConvert.SerializeObject(obj) : null;
            }
            catch (Exception e)
            {
                throw new ApiException(500, e.Message);
            }
        }

        public string GetApiKeyWithPrefix(string apiKeyIdentifier)
        {
            var apiKeyValue = "";
            ConfigurationGateway.ApiKey.TryGetValue(apiKeyIdentifier, out apiKeyValue);
            var apiKeyPrefix = "";
            if (ConfigurationGateway.ApiKeyPrefix.TryGetValue(apiKeyIdentifier, out apiKeyPrefix))
                return apiKeyPrefix + " " + apiKeyValue;
            else
                return apiKeyValue;
        }

        public void UpdateParamsForAuth(Dictionary<String, String> queryParams, Dictionary<String, String> headerParams, string[] authSettings)
        {
            if (authSettings == null || authSettings.Length == 0)
                return;

            foreach (string auth in authSettings)
            {
                // determine which one to use
                switch (auth)
                {
                    default:
                        //TODO show warning about security definition not found
                        break;
                }
            }
        }

        public static string Base64Encode(string text)
        {
            var textByte = System.Text.Encoding.UTF8.GetBytes(text);
            return System.Convert.ToBase64String(textByte);
        }

        public static Object ConvertType(Object fromObject, Type toObject)
        {
            return Convert.ChangeType(fromObject, toObject);
        }

    }
}
