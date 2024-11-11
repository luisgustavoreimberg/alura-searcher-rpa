using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluraSearcherRPA.RPA.PageElements
{
    internal class AluraResultsPageElements
    {
        public static By SearchField = By.Id("busca-form-input");
        public static By SearchLoadingElement = By.XPath("//ul[contains(@class, 'paginacao-pagina--loading')]");
        public static By FilterOpener = By.ClassName("show-filter-options");
        public static By CourseFilterItem = By.XPath("//ul[@id='busca--filtros--tipos']//input[contains(@value, 'COURSE')]/parent::li");
        public static By FilterResultsButton = By.Id("busca--filtrar-resultados");
        public static By ResultCard = By.ClassName("busca-resultado-link");
        public static By NextPageButton = By.XPath("//a[contains(@class, 'paginacao')][contains(text(), 'Próximo')]");
    }
}
