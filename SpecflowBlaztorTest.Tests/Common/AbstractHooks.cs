using BoDi;
using Microsoft.Playwright;
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

            var context = new T
            {
                Browser = browser
            };

            container.RegisterInstanceAs(playwright);
            container.RegisterInstanceAs(browser);
            container.RegisterInstanceAs(context);
        }

        [AfterScenario]
        public virtual async Task AfterScenario(IObjectContainer container)
        {
            var playwright = container.Resolve<IPlaywright>();
            var browser = container.Resolve<IBrowser>();

            await browser?.CloseAsync();
            var _ = browser?.DisposeAsync();
            playwright?.Dispose();
        }
    }
}
