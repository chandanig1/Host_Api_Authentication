﻿using Hostapiauthentication.Provider;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Threading.Tasks;
using System.Web.Http;

[assembly: OwinStartup(typeof(Hostapiauthentication.Startup))]

namespace Hostapiauthentication
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            OAuthAuthorizationServerOptions option = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp= true,
                TokenEndpointPath=new PathString("/token"),
                AccessTokenExpireTimeSpan=TimeSpan.FromMinutes(30),
                Provider=new ApplicationAuthorizationServerProvider()
            };
            app.UseOAuthAuthorizationServer(option);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            HttpConfiguration config= new HttpConfiguration();
            WebApiConfig.Register(config);
        }
    }
}
