using BoDi;
using Microsoft.Playwright;
using TechTalk.SpecFlow;

namespace SpecflowBlaztorTest.Tests.Common
{
    /// <summary>
    /// Provides some generalized hook functionality for setting up a playwrite test.
    /// </summary>
    public abstract class PlaywrightHooks
    {
        /// <summary>
        /// Register Playwright in DI with a page context
        /// </summary>
        /// <typeparam name="T">Type of context to create</typeparam>
        /// <param name="container">DI Test container</param>
        public virtual async Task RegisterPlayWright<T>(IObjectContainer container) where T : PlaywrightFixture, new()
        {
            var playwright = await Playwright.CreateAsync();

            //TODO: Make playwright externally configurable
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

        /// <summary>
        /// Diposes the elements this class added during the RegisterPlayWright method
        /// </summary>
        /// <param name="container"></param>
        /// <returns></returns>
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
