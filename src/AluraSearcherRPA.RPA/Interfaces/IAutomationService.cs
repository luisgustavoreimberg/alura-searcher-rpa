using AluraSearcherRPA.Domain.ValueObjects;

namespace AluraSearcherRPA.RPA.Interfaces
{
    public interface IAutomationService
    {
        IEnumerable<CourseInfo> ExecuteAutomationProcess(string valueToSearch);
    }
}
