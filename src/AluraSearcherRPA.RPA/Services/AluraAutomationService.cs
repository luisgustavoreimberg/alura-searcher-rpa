using AluraSearcherRPA.Domain.DTOs;
using AluraSearcherRPA.Domain.Entities;
using AluraSearcherRPA.Infrastructure.Logger;
using AluraSearcherRPA.RPA.DTOs;
using AluraSearcherRPA.RPA.Extensions;
using AluraSearcherRPA.RPA.Interfaces;
using AluraSearcherRPA.RPA.PageElements;
using AluraSearcherRPA.RPA.Utils;
using OpenQA.Selenium;
using Serilog.Core;

namespace AluraSearcherRPA.RPA.Services
{
    public class AluraAutomationService : IAutomationService
    {
        private readonly string _chromeDriverPath;
        private IWebDriver? driver;

        private string _currentProcess = "Inicialização do processo";
        private string currentProcess
        {
            get
            {
                return _currentProcess;
            }
            set
            {
                Log.Debug($"Processo atual: {value}");
                _currentProcess = value;
            }
        }

        public AluraAutomationService(string chromeDriverPath)
        {
            _chromeDriverPath = chromeDriverPath;
        }

        public AutomationSearchResponseDTO ExecuteAutomationProcess(string valueToSearch)
        {
            var response = new AutomationSearchResponseDTO();

            try
            {
                using (driver = DriverUtils.StartChromeDriver(_chromeDriverPath))
                {
                    if (driver is null)
                        throw new Exception("Error to initialize driver");

                    FillSearchField(valueToSearch);

                    if (CountResults() > 0)
                    {
                        FilterResults();

                        var courseData = GetResults();
                        response.FoundData = courseData;
                    }
                }
            }
            catch (Exception ex) when (ex is NoSuchElementException || ex is WebDriverTimeoutException)
            {
                Log.Error("Elemento não encontrado no site", ex);
                driver.TakeScreenshot();

                response.Error = true;
                response.Message = $"Erro no processo da automação: {ex.Message}";
            }
            catch (Exception ex)
            {
                Log.Error("Erro fatal no processo da automação", ex);
                driver.TakeScreenshot();

                response.Error = true;
                response.Message = $"Erro no processo da automação: {ex.Message}";
            }

            return response;
        }

        private void FillSearchField(string valueToSearch)
        {
            currentProcess = "Navegação para busca do curso";

            driver.Navigate().GoToUrl("https://www.alura.com.br/");
            driver.WaitPageLoad();

            try
            {
                driver.GetElement(AluraHomePageElements.SearchField).SendKeys(valueToSearch + Keys.Enter);
            }
            catch (Exception ex) when (ex is NoSuchElementException || ex is WebDriverTimeoutException)
            {
                Log.Warn("Search field not found on home page, trying to get field from results page");
                driver.GetElement(AluraResultsPageElements.SearchField).SendKeys(valueToSearch + Keys.Enter);
            }
            driver.WaitPageLoad();
            driver.WaitPageLoadByLoadingElement(AluraResultsPageElements.SearchLoadingElement);
        }
        private int CountResults()
        {
            currentProcess = "Contagem dos resultados";

            return driver.FindElements(AluraResultsPageElements.ResultCard).Count();
        }
        private void FilterResults()
        {
            currentProcess = "Filtragem dos resultados";

            try
            {
                driver.GetElement(AluraResultsPageElements.CourseFilterItem, 0).Click();
            }
            catch
            {
                driver.GetElement(AluraResultsPageElements.FilterOpener).Click();
                Thread.Sleep(2000);
                driver.GetElement(AluraResultsPageElements.CourseFilterItem).Click();
            }

            driver.GetElement(AluraResultsPageElements.FilterResultsButton).Click();
            driver.WaitPageLoad();
            driver.WaitPageLoadByLoadingElement(AluraResultsPageElements.SearchLoadingElement);
        }
        private List<CourseDataDTO> GetResults(bool justFirstPage = true)
        {
            currentProcess = "Captura dos resultados";

            var results = new List<CourseDataDTO>();

            do
            {
                var resultCards = driver.FindElements(AluraResultsPageElements.ResultCard);
                for (int i = 0; i < resultCards.Count; i++)
                {
                    try
                    {
                        var searchResult = GetResultInfo(resultCards[i]);

                        if (searchResult != null)
                            results.Add(searchResult);
                    }
                    catch (Exception ex)
                    {
                        Log.Error($"Error to get info detail: course {i}", ex);
                        driver.TakeScreenshot();
                    }
                    finally
                    {
                        driver.Navigate().Back();
                        driver.WaitPageLoad();
                    }
                }
            } while (!justFirstPage && NavigateToNextPage());

            return results;
        }
        private CourseDataDTO GetResultInfo(IWebElement resultCard)
        {
            currentProcess = "Captura dos detalhes do resultado";

            var title = TryGetCourseInfo(resultCard, AluraResultDetailPageElements.CourseTitle, "Course title", true);
            var description = TryGetCourseInfo(resultCard, AluraResultDetailPageElements.CourseDescription, "Course description");

            resultCard.Click();
            driver.WaitPageLoad();

            var instructor = TryGetCourseInfo(driver, AluraResultDetailPageElements.MainInstructorName, "Course instructor");
            var duration = TryGetCourseInfo(driver, AluraResultDetailPageElements.CourseDuration, "Course duration");

            return new CourseDataDTO
            {
                Title = title,
                Description = description,
                Instructor = instructor,
                Duration = duration
            };
        }
        private bool NavigateToNextPage()
        {
            currentProcess = "Navegação para a próxima página";

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
        private string TryGetCourseInfo<T>(T searchBaseElem, By infoElementIdentifier, string infoDescription = "", bool requiredInfo = false)
        {
            try
            {
                var courseInfo = string.Empty;

                if (searchBaseElem is IWebElement element)
                    courseInfo = element.FindElement(infoElementIdentifier).Text;
                else if (searchBaseElem is IWebDriver driver)
                    courseInfo = driver.FindElement(infoElementIdentifier).Text;

                ArgumentNullException.ThrowIfNull(courseInfo);
                return courseInfo;
            }
            catch (Exception ex)
            {
                Log.Warn($"Unable to get course info({infoDescription}): {ex.Message}");

                if (requiredInfo)
                    throw ex;
                else
                    return string.Empty;
            }
        }
    }
}
