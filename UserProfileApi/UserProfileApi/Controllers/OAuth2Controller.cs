using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace UserProfileApi.Controllers
{
    public class OAuth2Controller : ApiController
    {
        [Route("getToken")]
        [HttpPost]
        public HttpResponseMessage GetToken(string clientId, string clientSecret)
        {
            string baseAddress = "http://localhost:32825";
            var client = new HttpClient();
            var form = new Dictionary<string, string>
            {
                {
                    "grant_type",
                    "client_credentials"
                },
                {
                    "client_id",
                    clientId
                },
                {
                    "client_secret",
                    clientSecret
                },
            };

            var tokenResponse = client.PostAsync(baseAddress + "/oauth2/token", new FormUrlEncodedContent(form)).Result;
            var token = tokenResponse.Content.ReadAsAsync<dynamic>(new[] {
            new JsonMediaTypeFormatter()}).Result;
            /* client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
             var authorizedResponse = client.GetAsync(baseAddress + "/account").Result;*/
            return Request.CreateResponse(HttpStatusCode.OK, new { token });
        }
    }
}
