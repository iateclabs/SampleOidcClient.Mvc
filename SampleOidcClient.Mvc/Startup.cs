using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;

[assembly: OwinStartup(typeof(SampleOidcClient.Mvc.Startup))]

namespace SampleOidcClient.Mvc
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = CookieAuthenticationDefaults.AuthenticationType,
            });

            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions()
            {
                ResponseType = "id_token",
                UseTokenLifetime = false,
                SignInAsAuthenticationType = CookieAuthenticationDefaults.AuthenticationType,

                // Fill-in configuration below
                Authority = "<authority>",
                ClientId = "<client id>",
                RedirectUri = "<redirect uri>",
                Scope = "<scopes separated by space>"
            });
        }
    }
}
