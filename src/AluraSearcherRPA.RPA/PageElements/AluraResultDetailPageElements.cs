using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluraSearcherRPA.RPA.PageElements
{
    internal class AluraResultDetailPageElements
    {
        public static By CourseTitle = By.XPath("//section[@id='busca-resultados']//*[@class='busca-resultado-nome']");
        public static By CourseDescription = By.ClassName("busca-resultado-descricao");
        public static By MainInstructorName = By.ClassName("instructor-title--name");
        public static By CourseDuration = By.XPath("//p[contains(@class, 'courseInfo')][contains(text(), 'Para conclusão')]/preceding-sibling::p[contains(text(), 'h')]");
    }
}
