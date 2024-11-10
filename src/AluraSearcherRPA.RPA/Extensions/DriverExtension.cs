using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluraSearcherRPA.RPA.Extensions
{
    internal static class DriverExtension
    {
        public const int DEFAULT_TIMEOUT_IN_SECONDS = 30;

        public static void WaitPageLoad(this IWebDriver driver, int timeoutInSeconds = DEFAULT_TIMEOUT_IN_SECONDS)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds))
                .Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }
        public static void WaitPageLoadByLoadingElement(this IWebDriver driver, By loadingElementIdentifier, int timeoutInSeconds = DEFAULT_TIMEOUT_IN_SECONDS)
        {
            Thread.Sleep(1000);

            new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds))
                .Until(d => d.FindElements(loadingElementIdentifier)?.Count <= 0);
        }
        public static IWebElement GetElement(this IWebDriver driver, By elementIdentifier, int timeoutInSeconds = DEFAULT_TIMEOUT_IN_SECONDS)
        {
            if (timeoutInSeconds > 0)
                return new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds)).Until(d => d.FindElement(elementIdentifier));
            else
                return driver.FindElement(elementIdentifier);
        }
        public static IWebElement GetEnabledElement(this IWebDriver driver, By elementIdentifier, int timeoutInSeconds = DEFAULT_TIMEOUT_IN_SECONDS)
        {
            var foundElement = GetElement(driver, elementIdentifier, timeoutInSeconds);
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds)).Until(d => foundElement.Enabled);

            return foundElement;
        }
        public static IWebElement GetDisplayedElement(this IWebDriver driver, By elementIdentifier, int timeoutInSeconds = DEFAULT_TIMEOUT_IN_SECONDS)
        {
            var foundElement = GetElement(driver, elementIdentifier, timeoutInSeconds);
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds)).Until(d => foundElement.Displayed);

            return foundElement;
        }
        public static void Dispose(this IWebDriver driver)
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
