using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluraSearcherRPA.RPA.Utils
{
    internal class DriverUtils
    {
        internal static IWebDriver StartChromeDriver(string driverPath,
                                           BrowserWindowState windowState = BrowserWindowState.Maximized,
                                           bool isIncognitoMode = true,
                                           bool mustHideCommandPrompt = true)
        {
            var chromeDriverService = ChromeDriverService.CreateDefaultService(driverPath);
            var chromeOptions = new ChromeOptions();

            if (isIncognitoMode)
                chromeOptions.AddArgument("--incognito");
            if (windowState.Equals(BrowserWindowState.Headless))
                chromeOptions.AddArgument("--headless");

            chromeDriverService.HideCommandPromptWindow = mustHideCommandPrompt;

            IWebDriver driver = new ChromeDriver(chromeDriverService, chromeOptions);

            switch (windowState)
            {
                case BrowserWindowState.Maximized:
                    driver.Manage().Window.Maximize(); break;
                case BrowserWindowState.Minimized:
                    driver.Manage().Window.Minimize(); break;
            }

            return driver;
        }
    }
    internal enum BrowserWindowState
    {
        Default,
        Maximized,
        Minimized,
        Headless
    }
}
