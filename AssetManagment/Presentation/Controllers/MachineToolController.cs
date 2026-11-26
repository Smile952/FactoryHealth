using Application.DTOs.MachineTool;
using Application.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MachineToolController: Controller
{
    private readonly IMachineToolService _service;
    public MachineToolController(IMachineToolService machineToolService)
    {
        this._service = machineToolService;
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetMachineTool(int id)
    {
        try
        {
            var result = await _service.GetMachineToolAsync(id);
            return Ok(result);
        }   
        catch(Exception ex)
        {
            return Problem(statusCode: StatusCodes.Status500InternalServerError, title: ex.Message);
        }     
    }
    [HttpGet]
    public async Task<IActionResult> GetMachineTools()
    {
        try
        {
            var result = await _service.GetMachineToolsAsync();
            return Ok(result);
        }
        catch(Exception ex)
        {
            return Problem(statusCode: StatusCodes.Status500InternalServerError, title: ex.Message);
        }
    }
    [HttpPost]
    public async Task<IActionResult> CreateMachineToolAsync(CreateMachineTool dto)
    {
        try
        {
            var result = await _service.CreateMachineToolAsync(dto);
            return CreatedAtAction(nameof(GetMachineTool), new {id = result}, new {value = dto});
        }catch(Exception ex)
        {
            return Problem(statusCode: StatusCodes.Status500InternalServerError, title: ex.Message);
        }
    }
}