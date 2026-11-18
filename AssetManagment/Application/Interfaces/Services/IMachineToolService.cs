using Application.DTOs.MachineTool;
using Core.Models;

namespace Application.Interfaces.Service;

public interface IMachineToolService
{
    public Task<List<MachineToolResponse>> GetMachineToolsAsync();
    public Task<MachineTool> EquipSensorAsync(int sensorId, int machineToolId);
    public Task<MachineTool> UnequipSensorAsync(int sensorId, int machineToolId);
}