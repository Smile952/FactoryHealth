using Core.ValueObjects;

namespace Core.Models;

public class MachineTool
{
    public int Id {get; set;}
    public string Name {get; set;} = string.Empty;
    public int MachineToolTypeId {get; set;}
    public Activity Activity {get; set;}

    public MachineToolType ToolType {get; set;}
    public List<Sensor> Sensors {get; set;}
}