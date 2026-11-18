namespace Core.Models;

public class SensorMovement
{
    public int Id {get; set;}
    public int SensorId {get; set;}
    public DateTime MoveDateTime {get; set;}
    public int? FromMachineToolId {get; set;}
    public int? ToMachineToolId {get; set;}
    
    public Sensor Sensor {get; set;}
    public MachineTool FromMachineTool {get; set;}
    public MachineTool ToMachineTool {get; set;}
}