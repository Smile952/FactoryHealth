namespace Core.Models;

public class MachineToolType
{
    public int Id {get; set;}
    public string Name {get; set;} = string.Empty;
    public string Group {get; set;} = string.Empty;
    
    public List<MachineTool> MachineTools {get; set;}
}