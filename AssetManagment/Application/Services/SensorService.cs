using Application.DTOs.Sensor;
using Application.Extensions;
using Application.Interfaces.Repository;
using Application.Interfaces.Service;
using Core.Models;

namespace Application.Services;

public class SensorService(ISensorRepository _repository, IMachineToolRepository _machineToolRepository, IUnitOfWork _unitOfWork) : ISensorService
{
    public async Task<int> CreateSensorAsync(CreateSensor dto)
    {
        var availableSensors = await _repository.GetSensorsAsync();
        if(availableSensors.Select(x => x.Name).Contains(dto.Name))
        {
            throw new Exception("Sensor already exists");
        }

        Sensor sensor = new Sensor(){Name = dto.Name, MeasureTypeId = dto.MeasureTypeId};
        await _repository.SaveSensorAsync(sensor);
        var newSensor = await _repository.GetSensorByNameAsync(dto.Name);
        return newSensor.Id;
    }

    public async Task<IEnumerable<SensorResponse>> GetSensorsAsync()
    {
        var sensors = await _repository.GetSensorsAsync();
        return sensors.Select(x => x.ToResponseDto());
    }
    public async Task UnequipSensorFromMachineToolAsync(CreateSensorMovement movement)
    {
        var sensor = await _repository.GetSensorAsync(movement.SensorId);
        if(sensor == null) throw new Exception($"Sensor was not found. Id={movement.SensorId}");

        var machineTool = await _machineToolRepository.GetMachineToolAsync(movement.FromMachineToolId);
        if(machineTool == null) throw new Exception($"Machinetool was not found. Id={movement.ToMachineToolId}");

        if(sensor.MachineToolId != movement.FromMachineToolId) throw new Exception($"Sensor {sensor.Name} does not equpted to machinetool {machineTool.Name}");

        await _unitOfWork.BeginTransactionAsync();
        try
        {
            await _repository.AddSensorMovmentAsync(movement.ToModel());
            
            if(sensor.MachineTool == null)
            {
                throw new Exception();
            }
            
            sensor.MachineTool = null;
            sensor.MachineToolId = null;

            await _unitOfWork.CommitTrainsactionAsync();
        }
        catch(Exception ex)
        {
            await _unitOfWork.RollbackTransactionAsync();
            throw new Exception(ex.Message);
        }
        finally
        {
            await _unitOfWork.DisposeTransactionAsync();
        }
    }
    public async Task EquipSensorToMachienToolAsync(CreateSensorMovement movement)
    {
        var sensor = await _repository.GetSensorAsync(movement.SensorId);
        if(sensor == null) throw new Exception($"Sensor was not found. Id={movement.SensorId}");

        var machineTool = await _machineToolRepository.GetMachineToolAsync(movement.ToMachineToolId);
        if(machineTool == null) throw new Exception($"Machinetool was not found. Id={movement.ToMachineToolId}");

        await _unitOfWork.BeginTransactionAsync();
        try
        {
            if(sensor.MachineToolId != null) throw new Exception($"Sensor {sensor.Name} already equpted");
            await _repository.AddSensorMovmentAsync(movement.ToModel());
            
            sensor.MachineTool = machineTool;
            await _unitOfWork.CommitTrainsactionAsync();
        }
        catch(Exception ex)
        {
            await _unitOfWork.RollbackTransactionAsync();
            throw new Exception(ex.Message);
        }finally
        {
            await _unitOfWork.DisposeTransactionAsync();
        }
    }

    public async Task MoveSensorAsync(CreateSensorMovement movement)
    {
        var sensor = await _repository.GetSensorAsync(movement.SensorId);
        if(sensor == null) throw new Exception();
        if(sensor.MachineToolId != movement.FromMachineToolId) 
            throw new Exception($"Sensor {sensor.Name} equipted to another machinetool");

        var fromMachineTool = await _machineToolRepository.GetMachineToolAsync(movement.FromMachineToolId);
        if(fromMachineTool == null) 
            throw new Exception($"Machinetool was not found. Id={movement.FromMachineToolId}");
        if (!fromMachineTool.Sensors!.Contains(sensor)) 
            throw new Exception($"Sensor {sensor.Name} does not equpted to machinetool {fromMachineTool.Name}");

        var toMachineTool = await _machineToolRepository.GetMachineToolAsync(movement.ToMachineToolId);
        if(toMachineTool == null) 
            throw new Exception($"Machinetool was not found. Id={movement.ToMachineToolId}");
        if(toMachineTool.Sensors!.Contains(sensor)) 
            throw new Exception($"Machinetool {toMachineTool.Name} already contains sensor {sensor.Name} ");
    
        await _unitOfWork.BeginTransactionAsync();
        try
        {
            await _repository.AddSensorMovmentAsync(movement.ToModel());

            sensor.MachineTool = toMachineTool;
            if (!fromMachineTool.Sensors.Remove(sensor))
            {
                throw new Exception();
            }
            await _unitOfWork.CommitTrainsactionAsync();
        }
        catch(Exception ex)
        {
            await _unitOfWork.RollbackTransactionAsync();
            throw new Exception(ex.Message);
        }finally
        {
            await _unitOfWork.DisposeTransactionAsync();
        }
    }

    public async Task<SensorResponse> GetSensorAsync(int id)
    {
        try
        {
            var sensor = await _repository.GetSensorAsync(id);
            if(sensor != null)
                return sensor.ToResponseDto();
            else throw new Exception($"Sensor with id: {id} does not exists");
        }catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}