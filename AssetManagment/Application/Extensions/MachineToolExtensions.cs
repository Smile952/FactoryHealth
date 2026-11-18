using Application.DTOs.MachineTool;
using Core.Models;

namespace Application.Extensions;

public static class MachineToolExtensions
{
    public static MachineToolResponse ToResponseDto(this MachineTool machineTool) 
        => new(machineTool.Id, machineTool.Name, machineTool.MachineToolTypeId, machineTool.Activity); 
}