using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.IdentityModel.Tokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using Microsoft.Owin.Security.Notifications;
using System.Text;
using System.Security.Claims;
using System.Collections.Generic;

namespace OpenIdConnect_Test1
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {            
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);

            app.UseCookieAuthentication(new CookieAuthenticationOptions { });

            //ConfigurationManager.AppSettings["oidc:ClienteID"],
            var oidcOptions = new OpenIdConnectAuthenticationOptions
            {
                MetadataAddress = "https://adfsdev40.everis.com/adfs/.well-known/openid-configuration",
                ClientId = "f15e417a-6741-4b05-874b-92677e279f17", 
                //Authority = "https://adfsdev40.everis.com/adfs/oauth2/authorize/",
                //ResponseType = OpenIdConnectResponseType.Code,
                //Scope = OpenIdConnectScope.OpenIdProfile,
                //PostLogoutRedirectUri = "https://adfsdev40.everis.com/adfs/ls/?wa=wsignout1.0",
                RedirectUri = "http://localhost:4200",
                Notifications = new OpenIdConnectAuthenticationNotifications
                {

                    AuthenticationFailed = context =>
                    {
                        System.Console.WriteLine(context.Response);                        
                        return Task.FromResult(0);
                    },
                    //RedirectToIdentityProvider = OnRedirectToIdentityProvider,
                    //SecurityTokenReceived = OnSecurityTokenReceived,
                    AuthorizationCodeReceived = async n =>
                    {
                        System.Console.WriteLine(n.JwtSecurityToken.RawData);                                                                                                                                  
                    }
                    //SecurityTokenValidated = OnSecurityTokenValidated,
                    //MessageReceived = OnMessageReceived
                }
            };
            app.UseOpenIdConnectAuthentication(oidcOptions);
        }

        private Task AuthenticationFailed(SecurityTokenValidatedNotification<OpenIdConnectMessage, OpenIdConnectAuthenticationOptions> arg)
        {
            System.Console.WriteLine(arg);
            return Task.FromResult(0);
        }        
    }
}