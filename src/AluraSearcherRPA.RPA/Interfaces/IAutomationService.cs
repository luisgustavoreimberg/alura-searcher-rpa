using AluraSearcherRPA.RPA.DTOs;

namespace AluraSearcherRPA.RPA.Interfaces
{
    public interface IAutomationService
    {
        AutomationSearchResponseDTO ExecuteAutomationProcess(string valueToSearch);
    }
}
