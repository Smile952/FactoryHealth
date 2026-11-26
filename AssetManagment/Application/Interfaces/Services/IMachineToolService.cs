using Application.DTOs.MachineTool;
using Core.Models;

namespace Application.Interfaces.Service;

public interface IMachineToolService
{
    public Task<IEnumerable<MachineToolResponse>> GetMachineToolsAsync();
    public Task<MachineToolResponse> GetMachineToolAsync(int? id);
    public Task<int> CreateMachineToolAsync(CreateMachineTool dto);
    
}