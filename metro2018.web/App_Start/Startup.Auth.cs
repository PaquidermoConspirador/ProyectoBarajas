using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;

namespace Metro2018.Web
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "Metro2018.Web.AuthType",
                LoginPath = new PathString("/Login"),
                Provider = new CookieAuthenticationProvider(),
                CookieName = "metro2018.auth",
                CookieHttpOnly = true,
                ExpireTimeSpan = TimeSpan.FromMinutes(SessionDurationInMinutes())
            });
        }

        private static int SessionDurationInMinutes()
        {
            return Int32.MaxValue;
        }
    }
}