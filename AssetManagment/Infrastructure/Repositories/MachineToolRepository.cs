using Application.Interfaces.Repository;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class MachineToolRepository : IMachineToolRepository
{
    private readonly AssetManagmentContext _context;
    public MachineToolRepository(AssetManagmentContext context)
    {
        _context = context;
    }
    public async Task<MachineTool?> GetMachineToolAsync(int? id) 
        => await _context.MachineTool
            .Include(x => x.Sensors)
            .FirstOrDefaultAsync(x => x.Id == id);

    public async Task<MachineTool?> GetMachineToolByNameAsync(string name)
        => await _context.MachineTool
            .AsNoTracking()
            .FirstOrDefaultAsync(x=> x.Name == name);

    public async Task<List<MachineTool>> GetMachineToolsAsync() => 
        await _context.MachineTool
            .AsNoTracking()
            .ToListAsync();

    public async Task SaveMachineTool(MachineTool machineTool)
    {
        await _context.MachineTool.AddAsync(machineTool);
        await _context.SaveChangesAsync();
    }
        
}