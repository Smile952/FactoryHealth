using Core.Models;

namespace Application.Interfaces.Repository;

public interface IMachineToolRepository
{
    public Task<MachineTool> GetMachineToolAsync(int id);
    public Task<List<MachineTool>> GetMachineToolsAsync();
    public Task SaveMachineTool(MachineTool machineTool);
    
}