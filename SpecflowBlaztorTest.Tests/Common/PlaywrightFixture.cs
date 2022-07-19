using Microsoft.Playwright;
namespace SpecflowBlaztorTest.Tests.Common
{
    /// <summary>
    /// Provides some base utility for creating a test
    /// fixture using playright centered around a certain page/feature
    /// under test
    /// </summary>
    public abstract class PlaywrightFixture
    {
        /// <summary>
        /// PagePath refers to the path of the main page under test.
        /// Use as the default page testing a feature.
        /// </summary>
        public abstract string PagePath { get; }
        /// <summary>
        /// Current Page context
        /// </summary>
        public IPage Page { get; private set; }
        /// <summary>
        /// Browser Context
        /// </summary>
        public IBrowser Browser { get; set; }

        /// <summary>
        /// Navigate to the default page for the test
        /// </summary>
        /// <returns></returns>
        public async Task NavigateAsync()
        {
            await NavigateToPathAsync(PagePath);
        }
        
        /// <summary>
        /// Navigate to some other page
        /// </summary>
        /// <param name="path">Path to another page</param>
        public async Task NavigateToPathAsync(string path)
        {
            Page = Page ?? await Browser.NewPageAsync();
            await Page.GotoAsync(path);
        }

        /// <summary>
        /// Gets a locator (selector) that you can use to find an element on the page
        /// </summary>
        /// <param name="dataAttributeValue">The value of the data attribute you're looking for</param>
        /// <param name="dataAttributeKey">they key to look for. defaults to data-test-id as a standard</param>
        /// <returns>A locator</returns>
        public ILocator GetSelectorByDataAttribute(string dataAttributeValue, string dataAttributeKey= "data-test-id")
        {
            return Page.Locator($"{dataAttributeKey}={dataAttributeValue}");
        }

        /// <summary>
        /// Finds a page element by data attribute and clicks it 
        /// </summary>
        /// <param name="dataAttributeValue"></param>
        /// <returns></returns>
        public async Task ClickByDataAttributeAsync(string dataAttributeValue, string dataAttributeKey = "data-test-id")
        {
            await GetSelectorByDataAttribute(dataAttributeValue, dataAttributeKey).ClickAsync();
        }
    }
}
