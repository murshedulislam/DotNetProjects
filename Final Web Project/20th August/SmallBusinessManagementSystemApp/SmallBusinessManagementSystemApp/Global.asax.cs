using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using SmallBusinessManagementSystemApp.Models;
using SmallBusinessManagementSystemApp.Models.Models;

namespace SmallBusinessManagementSystemApp
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
