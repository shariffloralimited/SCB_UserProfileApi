using Microsoft.Owin.Security.OAuth;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using UserProfileApi.DAC;

namespace UserProfileApi.Provider
{
    public class OAuthProvider : OAuthAuthorizationServerProvider
    {
        private bool _IsMatchedUserSecret;
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            _IsMatchedUserSecret = false;
            string clientId;
            string clientSecret;
            if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
            {
                context.TryGetFormCredentials(out clientId, out clientSecret);
            }
            if (context.ClientId == null || clientSecret == null)
            {
                context.SetError("invalid_credentials", "A valid client_Id and client_Secret must be provided.");
                context.Rejected();
                return;
            }

            string errorMsg;
            new OAuthCheckerDb().CheckClientSecret(clientId, clientSecret, out errorMsg);
            if (!string.IsNullOrEmpty(errorMsg))
            {
                context.SetError("invalid_credentials", "A valid client_Id and client_Secret must be provided.");
                context.Rejected();
                return;
            }
            else
            {
                _IsMatchedUserSecret = true;
            }
            await Task.Run(() => context.Validated(clientId));
        }
        public override async Task GrantClientCredentials(OAuthGrantClientCredentialsContext context)
        {
            // bool client = ConfigurationManager.AppSettings["ClientId"] == context.ClientId;
            if (!_IsMatchedUserSecret)
            {
                context.SetError("invalid_grant", "Invaild client.");
                context.Rejected();
                return;
            }
            var claimsIdentity = new ClaimsIdentity(context.Options.AuthenticationType);
            claimsIdentity.AddClaim(new Claim("LoggedOn", DateTime.Now.ToString()));
            await Task.Run(() => context.Validated(claimsIdentity));
        }
        /*public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            if (context.TokenIssued)
            {
                context.Properties.ExpiresUtc = DateTimeOffset.UtcNow.AddSeconds(3600); // commented, coz Expiry already set in Startup.Auth class
            }
            return Task.FromResult<object>(null);
        }*/
    }
}