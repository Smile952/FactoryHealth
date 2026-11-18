using Application.Interfaces.Repository;
using Application.Interfaces.Service;
using Core.Models;
using Application.Extensions;
using Application.DTOs.MachineTool;

namespace Application.Services;

public class MachineToolService : IMachineToolService
{
    private readonly IMachineToolRepository _repository;
    public MachineToolService(IMachineToolRepository repository)
    {
        _repository = repository;
    }
    public Task<MachineTool> EquipSensorAsync(int sensorId, int machineToolId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<MachineToolResponse>> GetMachineToolsAsync()
    {
        var machineTools = await _repository.GetMachineToolsAsync();
        var machineToolsResponse = machineTools.Select(x => x.ToResponseDto()).ToList();
        return machineToolsResponse;
    } 
       

    public Task<MachineTool> UnequipSensorAsync(int sensorId, int machineToolId)
    {
        throw new NotImplementedException();
    }
}