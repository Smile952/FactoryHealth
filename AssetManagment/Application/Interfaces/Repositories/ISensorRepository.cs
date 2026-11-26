using Core.Models;

namespace Application.Interfaces.Repository;

public interface ISensorRepository
{
    public Task<Sensor?> GetSensorAsync(int Id);
    public Task<List<Sensor>> GetSensorsAsync();
    public Task SaveSensorAsync(Sensor sensor);
    public Task<Sensor?> GetSensorByNameAsync(string name);
    
    public Task<List<SensorMovement>> GetSensorMovmentsAsync(int Id);
    public Task AddSensorMovmentAsync(SensorMovement sensorMovement);
}