using Application.DTOs.Sensor;

namespace Application.Interfaces.Service;

public interface ISensorService
{
    public Task<IEnumerable<SensorResponse>> GetSensorsAsync();
    public Task<SensorResponse> GetSensorAsync(int id);
    public Task<int> CreateSensorAsync(CreateSensor dto); 
    Task EquipSensorToMachienToolAsync(CreateSensorMovement movement);
    Task UnequipSensorFromMachineToolAsync(CreateSensorMovement movement);
    public Task MoveSensorAsync(CreateSensorMovement movement);
}