using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.CompositeWeb;
using Microsoft.Practices.CompositeWeb.Services;
using Microsoft.Practices.CompositeWeb.Interfaces;
using Microsoft.Practices.CompositeWeb.Configuration;
using Microsoft.Practices.CompositeWeb.Authorization;
using Microsoft.Practices.CompositeWeb.EnterpriseLibrary.Services;

namespace SkiChair.Shell
{
    public class ShellModuleInitializer : ModuleInitializer
    {
        private const string AuthorizationSection = "compositeWeb/authorization";

        public override void Load(CompositionContainer container)
        {
            base.Load(container);

            AddGlobalServices(container.Parent.Services);
            AddModuleServices(container.Services);
            RegisterSiteMapInformation(container.Services.Get<ISiteMapBuilderService>(true));
        }

        protected virtual void AddGlobalServices(IServiceCollection globalServices)
        {
            globalServices.AddNew<EnterpriseLibraryAuthorizationService, IAuthorizationService>();
            globalServices.AddNew<SiteMapBuilderService, ISiteMapBuilderService>();
        }

        protected virtual void AddModuleServices(IServiceCollection moduleServices)
        {
            // TODO: register services that can be accesed only by the Shell module
        }

        protected virtual void RegisterSiteMapInformation(ISiteMapBuilderService siteMapBuilderService)
        {
            SiteMapNodeInfo moduleNode = new SiteMapNodeInfo("Home", "~/Default.aspx", "Home", "Home");
            siteMapBuilderService.AddNode(moduleNode);
            siteMapBuilderService.AddNode(new SiteMapNodeInfo("Snow Ski Chair", "~/Merchandise/ProductMenu.aspx?pid=1", "Snow Ski Chair", "Snow Ski Chair"));
            siteMapBuilderService.AddNode(new SiteMapNodeInfo("Water Ski Chair", "~/Merchandise/ProductMenu.aspx?pid=2", "Water Ski Chair", "Water Ski Chair"));
            siteMapBuilderService.AddNode(new SiteMapNodeInfo("Hockey Stick Chair", "~/Merchandise/ProductMenu.aspx?pid=3", "Hockey Stick Chair", "Hockey Stick Chair"));
            siteMapBuilderService.AddNode(new SiteMapNodeInfo("Golf Club Chair", "~/Merchandise/ProductMenu.aspx?pid=4", "Golf Club Chair", "Golf Club Chair"));
            siteMapBuilderService.AddNode(new SiteMapNodeInfo("Wakeboard Bench", "~/Merchandise/ProductMenu.aspx?pid=5", "Wakeboard Bench", "Wakeboard Bench"));
            siteMapBuilderService.AddNode(new SiteMapNodeInfo("Snowboard Bench", "~/Merchandise/ProductMenu.aspx?pid=6", "Snowboard Bench", "Snowboard Bench"));
            siteMapBuilderService.AddNode(new SiteMapNodeInfo("Skateboard Bench", "~/Merchandise/ProductMenu.aspx?pid=7", "Skateboard Bench", "Skateboard Bench"));
            siteMapBuilderService.AddNode(new SiteMapNodeInfo("Snow Ski Bench", "~/Merchandise/ProductMenu.aspx?pid=8", "Snow Ski Bench", "Snow Ski Bench"));
            siteMapBuilderService.AddNode(new SiteMapNodeInfo("Baseball Bat Chair", "~/Merchandise/ProductMenu.aspx?pid=9", "Baseball Bat Chair", "Baseball Bat Chair"));
            siteMapBuilderService.AddNode(new SiteMapNodeInfo("Snowboard Chair", "~/Merchandise/ProductMenu.aspx?pid=10", "Snowboard Chair", "Snowboard Chair"));
            siteMapBuilderService.AddNode(new SiteMapNodeInfo("Water Ski Bench", "~/Merchandise/ProductMenu.aspx?pid=11", "Water Ski Bench", "Water Ski Bench"));
            siteMapBuilderService.AddNode(new SiteMapNodeInfo("Wakeboard Chair", "~/Merchandise/ProductMenu.aspx?pid=12", "Wakeboard Chair", "Wakeboard Chair"));
            siteMapBuilderService.AddNode(new SiteMapNodeInfo("Skateboard Chair", "~/Merchandise/ProductMenu.aspx?pid=13", "Skateboard Chair", "Skateboard Chair"));
            siteMapBuilderService.AddNode(new SiteMapNodeInfo("Log Collection", "~/Merchandise/ProductMenu.aspx?pid=14", "Log Collection", "Log Collection"));
            siteMapBuilderService.AddNode(new SiteMapNodeInfo("Coat Rack", "~/Merchandise/ProductMenu.aspx?pid=15", "Coat Rack", "Coat Rack"));
            siteMapBuilderService.AddNode(new SiteMapNodeInfo("Wine Rack", "~/Merchandise/ProductMenu.aspx?pid=16", "Wine Rack", "Wine Rack"));
            siteMapBuilderService.AddNode(new SiteMapNodeInfo("Children's Chair", "~/Merchandise/ProductMenu.aspx?pid=17", "Children's Chair", "Children's Chair"));

            //bread crumb
            siteMapBuilderService.RootNode.Url = "~/Default.aspx";
            siteMapBuilderService.RootNode.Title = "SkiChair Home";

            // TODO: register other site map nodes for pages that belong to the website root
        }

        public override void Configure(IServiceCollection services, System.Configuration.Configuration moduleConfiguration)
        {
            IAuthorizationRulesService authorizationRuleService = services.Get<IAuthorizationRulesService>();
            if (authorizationRuleService != null)
            {
                AuthorizationConfigurationSection authorizationSection = moduleConfiguration.GetSection(AuthorizationSection) as AuthorizationConfigurationSection;
                if (authorizationSection != null)
                {
                    foreach (AuthorizationRuleElement ruleElement in authorizationSection.ModuleRules)
                    {
                        authorizationRuleService.RegisterAuthorizationRule(ruleElement.AbsolutePath, ruleElement.RuleName);
                    }
                }
            }
        }
    }
}
