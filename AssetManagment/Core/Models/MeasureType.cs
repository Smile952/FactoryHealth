namespace Core.Models;

public class MeasureType
{
    public int Id {get; set;}
    public string Name {get; set;}
    
    public List<Sensor> Sensors {get; set;}
    
}