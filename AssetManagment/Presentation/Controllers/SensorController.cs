using Application.DTOs.Sensor;
using Application.Interfaces.Service;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SensorController : Controller
{
    private readonly ISensorService _sensorService;
    public SensorController(ISensorService sensorService)
    {
        this._sensorService = sensorService;
    }
    [HttpGet]
    public async Task<IActionResult> GetSensors()
    {
        try
        {
            var result = await _sensorService.GetSensorsAsync();
            return Ok(result);
        }catch(Exception ex)
        {
            return Problem(statusCode: StatusCodes.Status500InternalServerError, title: ex.Message);
        }
    }
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetSensor(int id)
    {
        try
        {
            var result = await _sensorService.GetSensorAsync(id);
            return Ok(result);
        }
        catch(Exception ex)
        {
            return Problem(statusCode: StatusCodes.Status500InternalServerError, title: ex.Message);    
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateSensor(CreateSensor request)
    {
        try
        {
            var result = await _sensorService.CreateSensorAsync(request);
            return CreatedAtAction(nameof(GetSensor), new {id = result}, new{value = request});
        }
        catch(Exception ex)
        {
            return Problem(statusCode: StatusCodes.Status500InternalServerError, title: ex.Message);
        }
    }
    [HttpGet("EquipSensor")]
    public async Task<IActionResult> EquipSensorToMachineTool(CreateSensorMovement request)
    {
        try
        {
            await _sensorService.EquipSensorToMachienToolAsync(request);
            return Ok();
        }
        catch(Exception ex)
        {
            return Problem(statusCode: StatusCodes.Status500InternalServerError, title: ex.Message);
        }
    }

    [HttpGet("UnequipSensor")]
    public async Task<IActionResult> UnequipSensorToMachineTool(CreateSensorMovement request)
    {
        try
        {
            await _sensorService.UnequipSensorFromMachineToolAsync(request);
            return Ok();
        }
        catch(Exception ex)
        {
            return Problem(statusCode: StatusCodes.Status500InternalServerError, title: ex.Message);
        }
    }

    [HttpGet("MoveSensor")]
    public async Task<IActionResult> MoveSensor(CreateSensorMovement request)
    {
        try
        {
            await _sensorService.MoveSensorAsync(request);
            return Ok();
        }
        catch(Exception ex)
        {
            return Problem(statusCode: StatusCodes.Status500InternalServerError, title: ex.Message);
        }
    }
}