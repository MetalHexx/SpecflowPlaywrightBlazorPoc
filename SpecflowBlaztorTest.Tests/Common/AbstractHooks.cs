using BoDi;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecflowBlaztorTest.Tests.Common
{
    public abstract class AbstractHooks
    {
        public virtual async Task RegisterPlayWright<T>(IObjectContainer container) where T : AbstractPageContext, new()
        {
            var playwright = await Playwright.CreateAsync();

            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                SlowMo = 0,
            });

            var context = new T();
            context.Browser = browser;

            container.RegisterInstanceAs(playwright);
            container.RegisterInstanceAs(browser);
            container.RegisterInstanceAs(context);
        }

        [AfterScenario]
        public virtual async Task AfterScenario(IObjectContainer container)
        {
            var browser = container.Resolve<IBrowser>();

            if (browser is not null)
            {
                await browser.CloseAsync();
            }
            var playwright = container.Resolve<IPlaywright>();
            playwright?.Dispose();
        }
    }
}
