using FluentAssertions;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace MySolution.RegressionTests
{
    public class GoogleSearchTests
    {
        [Fact(DisplayName = "GIVEN the google homepage is open WHEN searching for new york times THEN results should appear")]
        public void NewYorkTimesSearch()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("headless");

            using (var driver = new ChromeDriver(@".\", chromeOptions))
            {
                driver.Navigate().GoToUrl("https://www.google.co.uk/");
                driver.FindElementById("lst-ib").SendKeys("new york times");
                driver.FindElementById("lst-ib").Submit();

                var nytLink = driver.FindElementByLinkText("The New York Times - Breaking News, World News & Multimedia");
                driver.SaveScreenshot("TestSearchResults");
                nytLink.Should().NotBeNull();

                driver.Quit();
            }
        }
    }
}
