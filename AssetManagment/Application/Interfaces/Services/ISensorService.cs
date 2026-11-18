namespace Application.Interfaces.Service;

public interface ISensorService
{
    
    public Task MoveSensorAsync(int sensorId, int fromMachineToolId, int toMachineToolId);
}