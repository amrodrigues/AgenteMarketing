using Projeto.Business;
using Projeto.Business.Contracts;
using Projeto.Business.Percistence;
using Projeto.Repository;
using Projeto.Repository.Contracts;
using Projeto.Repository.Percistence;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System;
using System.Web;
using System.Web.Http;

namespace Projeto.Services
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            // Create the container as usual.
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            // Register your types, for instance using the scoped lifestyle:
            container.Register<IContatoBusiness, ContatoBusiness>(Lifestyle.Scoped);
            container.Register<IProdutoBusiness, ProdutoBusiness>(Lifestyle.Scoped);
            container.Register<IVendaContatoBusiness, VendaContatoBusiness>(Lifestyle.Scoped);
            container.Register<IVendaDetalheContatoBusiness, VendaDetalheContatoBusiness>(Lifestyle.Scoped);

            container.Register<IContatoRepository, ContatoRepository>(Lifestyle.Scoped);
            container.Register<IProdutoRepository, ProdutoRepository>(Lifestyle.Scoped);
            container.Register<IVendaContatoRepository, VendaContatoRepository>(Lifestyle.Scoped);
            container.Register<IVendaDetalheContatoRepository, VendaDetalheContatoRepository>(Lifestyle.Scoped);

            // This is an extension method from the integration package.
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);

            // Here your usual Web API configuration stuff.
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");

            if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            {
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE");
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept, Authorization");
                HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "1728000");
                HttpContext.Current.Response.End();
            }
        }
    }
}
