
using Application.DTOs.Sensor;
using Core.Models;

namespace Application.Extensions;

public static class SensorExtensions
{
    public static SensorResponse ToResponseDto(this Sensor sensor) 
        => new(sensor.Id, sensor.Name, sensor.MeasureTypeId, sensor.Activity);
}