namespace Application.DTOs.Sensor;

public sealed record CreateSensorMovement(int SensorId, DateTime MoveDateTime, int? FromMachineToolId, int? ToMachineToolId);