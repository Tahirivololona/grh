using GRH_BS.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace GRH_UI.App_Start
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            container.RegisterType<IBaseService, BaseService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}