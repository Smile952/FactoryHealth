using Core.ValueObjects;

namespace Application.DTOs.MachineTool;

public sealed record MachineToolResponse(int Id, string Name, int MachineToolTypeId, Activity Activity);

public sealed record CreateMachineTool(string Name, int MachineToolTypeId);