using Core.Models;

namespace Application.Interfaces.Repository;

public interface IMachineToolRepository
{
    Task<MachineTool?> GetMachineToolAsync(int? id);
    Task<List<MachineTool>> GetMachineToolsAsync();
    Task SaveMachineTool(MachineTool machineTool);
    Task<MachineTool?> GetMachineToolByNameAsync(string name);
    
}