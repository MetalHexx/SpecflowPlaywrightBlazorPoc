using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowBlaztorTest.Tests.Common
{
    public abstract class AbstractPageContext
    {
        public abstract string PagePath { get; }
        public IPage Page { get; set; }
        public IBrowser Browser { get; set; }

        public async Task NavigateAsync()
        {
            Page = Page ?? await Browser.NewPageAsync();

            await Page.GotoAsync(PagePath);
        }

        public async Task NavigateHomeAsync()
        {
            Page = Page ?? await Browser.NewPageAsync();
            await Page.GotoAsync("https://localhost:7264/");
        }

        public ILocator GetByDataAttribute(string dataAttributeValue, string dataAttributeKey= "data-test-id")
        {
            return Page.Locator($"{dataAttributeKey}={dataAttributeValue}");
        }

        public async Task ClickByDataAttributeAsync(string dataAttributeValue)
        {
            await GetByDataAttribute(dataAttributeValue).ClickAsync();
        }
    }
}
