using System.Reflection;
using Microsoft.Owin.Security;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Metro2018.Web
{
    public partial class Startup
    {
        public void ConfigureDI(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            app.UseNinjectMiddleware(CreateKernel).UseNinjectWebApi(config);
        }

        private static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            kernel.Load(Assembly.GetExecutingAssembly());

            ControllerBuilder.Current.SetControllerFactory(new App_Start.NinjectControllerFactory(kernel));

            kernel.Bind<IAuthenticationManager>().ToMethod(c => HttpContext.Current.GetOwinContext().Authentication).InRequestScope();

            // Operational
            //kernel.Bind<OperationalManagement.ILogger>().To<OperationalManagement.WindowsEventLogger>();

            // Repositories
            kernel.Bind<DataInterfaces.IDepartamentosRepository>().To<DataLayer.DepartamentosRepository>();
            // Processors
            kernel.Bind<BusinessInterfaces.IDepartamentosProcessor>().To<BusinessLayer.DepartamentosProcessor>();
            
            // Utils
            

            // Filters
            

            //kernel.BindFilter<Filters.RefreshSessionFilter>(FilterScope.Controller, 0)
            //    .WhenControllerHas<Filters.RefreshSessionAttribute>()
            //    .InRequestScope();

            return kernel;
        }
    }
}