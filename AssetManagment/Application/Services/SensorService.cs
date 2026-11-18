using Application.Interfaces.Service;

namespace Application.Services;

public class SensorService : ISensorService
{
    public Task MoveSensorAsync(int sensorId, int fromMachineToolId, int toMachineToolId)
    {
        throw new NotImplementedException();
    }
}