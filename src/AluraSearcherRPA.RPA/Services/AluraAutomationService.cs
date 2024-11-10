using AluraSearcherRPA.Domain.ValueObjects;
using AluraSearcherRPA.RPA.Extensions;
using AluraSearcherRPA.RPA.Interfaces;
using AluraSearcherRPA.RPA.Utils;
using OpenQA.Selenium;

namespace AluraSearcherRPA.RPA.Services
{
    public class AluraAutomationService : IAutomationService
    {
        private IWebDriver? driver;

        public IEnumerable<CourseInfo> ExecuteAutomationProcess(string valueToSearch)
        {
            var response = new List<CourseInfo>();

            using (driver = DriverUtils.StartChromeDriver(@"C:\_WORKSPACE\_DRIVER"))
            {
                FillSearchField(valueToSearch);

                if (CountResults() > 0)
                {
                    FilterResults();

                    response = GetResults();
                }
            }

            return response;
        }

        private void FillSearchField(string valueToSearch)
        {
            driver.Navigate().GoToUrl("https://www.alura.com.br/");
            driver.WaitPageLoad();

            driver.GetElement(AluraHomePageElements.SearchField).SendKeys(valueToSearch + Keys.Enter);
            driver.WaitPageLoad();
            driver.WaitPageLoadByLoadingElement(AluraResultsPageElements.SearchLoadingElement);
        }
        private int CountResults()
        {
            return driver.FindElements(AluraResultsPageElements.ResultCard).Count();
        }
        private void FilterResults()
        {
            try
            {
                driver.GetElement(AluraResultsPageElements.CourseFilterItem, 0).Click();
            }
            catch
            {
                driver.GetElement(AluraResultsPageElements.FilterOpener).Click();
                driver.GetElement(AluraResultsPageElements.CourseFilterItem).Click();
            }

            driver.GetElement(AluraResultsPageElements.FilterResultsButton).Click();
            driver.WaitPageLoad();
            driver.WaitPageLoadByLoadingElement(AluraResultsPageElements.SearchLoadingElement);
        }
        private List<CourseInfo> GetResults()
        {
            var results = new List<SearchResult>();

            foreach (var resultCard in driver.FindElements(AluraResultsPageElements.ResultCard))
            {
                var searchResult = GetResultInfo(resultCard);

                if (searchResult != null)
                    results.Add(searchResult);

                driver.Navigate().Back();
                driver.WaitPageLoad();
            }

            return results;
        }
        private CourseInfo GetResultInfo(IWebElement resultCard)
        {
            var title = resultCard.FindElement(AluraResultDetailPageElements.CourseTitle).Text;
            var description = resultCard.FindElement(AluraResultDetailPageElements.CourseDescription).Text;

            resultCard.Click();
            driver.WaitPageLoad();

            var instructor = driver.GetElement(AluraResultDetailPageElements.MainInstructorName).Text;
            var duration = driver.GetElement(AluraResultDetailPageElements.CourseDuration).Text;

            return new SearchResult
            {
                Title = title,
                Description = description,
                Instructor = instructor,
                Duration = duration
            };
        }
        private bool NavigateToNextPage()
        {
            try
            {
                var lastPageResultText = driver.FindElements(AluraResultsPageElements.ResultCard).FirstOrDefault()?.Text;
                var lastPageURL = driver.Url;

                driver.GetEnabledElement(AluraResultsPageElements.NextPageButton).Click();

                var currentPageResultText = driver.FindElements(AluraResultsPageElements.ResultCard).FirstOrDefault()?.Text;

                if (!lastPageResultText.Equals(currentPageResultText))
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
