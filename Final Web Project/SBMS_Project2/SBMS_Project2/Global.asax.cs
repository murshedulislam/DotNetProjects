using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using SBMS_Project2.Models;
using SBMS_Project2.Models.Models;

namespace SBMS_Project2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Mapper.Initialize(config: cfg =>
            {
                cfg.CreateMap<PurchaseViewModel, PurchaseSupplier>();
                cfg.CreateMap<PurchaseSupplier, PurchaseViewModel>();
                cfg.CreateMap<CustomerSale, SalesViewModel>();
                cfg.CreateMap<SalesViewModel, CustomerSale>();
            });
        }
    }
}
