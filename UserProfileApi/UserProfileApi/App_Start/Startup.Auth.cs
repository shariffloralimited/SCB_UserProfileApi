using System;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.OAuth;
using UserProfileApi.Provider;
using System.Configuration;

namespace UserProfileApi
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            var oAuthOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true, // need set to false in PROD
                TokenEndpointPath = new PathString("/oauth2/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromSeconds(int.Parse(ConfigurationManager.AppSettings["TokenExpiryInSeconds"])), //token expiration time
                Provider = new OAuthProvider(),
            };
            app.UseOAuthBearerTokens(oAuthOptions);
            app.UseOAuthAuthorizationServer(oAuthOptions);
        }
    }
}
