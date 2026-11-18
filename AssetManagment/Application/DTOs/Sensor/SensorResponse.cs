using Core.ValueObjects;

namespace Application.DTOs.Sensor;

public sealed record SensorResponse(int Id, string Name, int MeasureTypeId, Activity Activity);