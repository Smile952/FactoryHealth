
using Application.DTOs.Sensor;
using Core.Models;

namespace Application.Extensions;

public static class SensorExtensions
{
    public static SensorResponse ToResponseDto(this Sensor sensor) 
        => new(sensor.Id, sensor.Name, sensor.MeasureTypeId, sensor.Activity);
    
    public static SensorMovement ToModel(this CreateSensorMovement src)
    => new SensorMovement(){ SensorId=src.SensorId, FromMachineToolId = src.FromMachineToolId, ToMachineToolId = src.ToMachineToolId, MoveDateTime = src.MoveDateTime.ToUniversalTime()};
}