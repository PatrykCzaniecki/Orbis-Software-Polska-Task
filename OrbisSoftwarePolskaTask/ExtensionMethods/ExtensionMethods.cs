using System.Text.Json;
using RestSharp;

namespace OrbisSoftwarePolskaTask.ExtensionMethods
{
    public class ExtensionMethods
    {
        public RestRequest CreateRequest(string method, object parameter)
        {
            var request = new RestRequest("https://api.baselinker.com/connector.php")
            {
                Method = Method.Post
            };
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("X-BLToken", "4002315-4008150-Q78SFGJ40LO7NTXUITU9SONZDVFPENU075HM4IS656JUEG3ZORSQ0GF4M05OEBIG");
            request.AddParameter("method", method);
            request.AddParameter("parameter", JsonSerializer.Serialize(parameter));
            return request;
        }

        public string CharReplacement(string inputValue)
        {
            var newString = inputValue.Replace("+", "%2B");
            return newString;
        }
    }
}
