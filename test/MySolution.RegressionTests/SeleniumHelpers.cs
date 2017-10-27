using OpenQA.Selenium;
using System.IO;

namespace MySolution.RegressionTests
{
    internal static class SeleniumHelpers
    {
        public static void SaveScreenshot(this ITakesScreenshot driver, string screenshotName)
        {
            var screenshotFolder = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "..", "artifacts", "screenshots");
            Directory.CreateDirectory(screenshotFolder);

            driver
                .GetScreenshot()
                .SaveAsFile(
                    Path.Combine(screenshotFolder, screenshotName + ".png"),
                    ScreenshotImageFormat.Png);
        }
    }
}
