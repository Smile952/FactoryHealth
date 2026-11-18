using Core.ValueObjects;

namespace Core.Models;
public class Sensor
{
    public int Id {get; set;}
    public string Name {get; set;} = string.Empty;
    public int MeasureTypeId {get; set;}
    public Activity Activity {get; set;}

    public List<SensorMovement> SensorMovements {get; set;}
    public MachineTool MachineTool {get; set;}
    public MeasureType MeasureType {get; set;}
}