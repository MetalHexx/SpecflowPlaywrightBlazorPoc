using Microsoft.Playwright;
namespace SpecflowBlaztorTest.Tests.Common
{
    public abstract class AbstractPageContext
    {
        public abstract string PagePath { get; }
        public IPage Page { get; private set; }
        public IBrowser Browser { get; set; }

        public async Task NavigateAsync()
        {
            await NavigateToPathAsync(PagePath);
        }
        
        public async Task NavigateToPathAsync(string path)
        {
            Page = Page ?? await Browser.NewPageAsync();
            await Page.GotoAsync(path);
        }

        public ILocator GetSelectorByDataAttribute(string dataAttributeValue, string dataAttributeKey= "data-test-id")
        {
            return Page.Locator($"{dataAttributeKey}={dataAttributeValue}");
        }

        public async Task ClickByDataAttributeAsync(string dataAttributeValue)
        {
            await GetSelectorByDataAttribute(dataAttributeValue).ClickAsync();
        }
    }
}
