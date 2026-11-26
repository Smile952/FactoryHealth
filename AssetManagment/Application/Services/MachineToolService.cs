using Application.Interfaces.Repository;
using Application.Interfaces.Service;
using Application.Extensions;
using Application.DTOs.MachineTool;
using Core.Models;

namespace Application.Services;

public class MachineToolService : IMachineToolService
{
    private readonly IMachineToolRepository _repository;
    public MachineToolService(IMachineToolRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> CreateMachineToolAsync(CreateMachineTool dto)
    {
        try
        {
            var existedMachineTools = await _repository.GetMachineToolsAsync();
            if(existedMachineTools.Select(x => x.Name).Contains(dto.Name))
            {
                throw new Exception($"Machine tool {dto.Name} already exists");
            }
            MachineTool machineTool = new MachineTool(){Name = dto.Name, MachineToolTypeId=dto.MachineToolTypeId};
            await _repository.SaveMachineTool(machineTool);
            var result = await _repository.GetMachineToolByNameAsync(dto.Name);
            return result.Id;
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<MachineToolResponse> GetMachineToolAsync(int? id)
    {
        if(id == null) throw new Exception("Machinetool id cannot be null");
        try
        {
            var machineTool = await _repository.GetMachineToolAsync(id);
            if(machineTool != null)
                return machineTool.ToResponseDto();
            else throw new Exception($"Machinetool with id: {id} does not exists");
        }catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<IEnumerable<MachineToolResponse>> GetMachineToolsAsync()
    {
        try{
            var machineTools = await _repository.GetMachineToolsAsync();
            return machineTools.Select(x => x.ToResponseDto());
        }catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}