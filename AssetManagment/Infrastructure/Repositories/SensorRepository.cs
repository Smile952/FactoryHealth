using Application.Interfaces.Repository;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class SensorRepository : ISensorRepository
{
    private readonly AssetManagmentContext _context;
    public SensorRepository(AssetManagmentContext context)
    {
        this._context = context;
    }
    public async Task<Sensor?> GetSensorAsync(int Id)
        => await _context.Sensor
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == Id);
        

    public async Task<List<Sensor>> GetSensorsAsync() 
        => await _context.Sensor
            .AsNoTracking()
            .ToListAsync();

    public async Task SaveSensorAsync(Sensor sensor)
    {
        await _context.SaveChangesAsync();
    }

    public async Task<List<SensorMovement>> GetSensorMovmentsAsync(int sensorId) 
        => await _context.SensorMovements
            .AsNoTracking()
            .Where(x => x.SensorId == sensorId)
            .ToListAsync();

    public async Task AddSensorMovmentAsync(SensorMovement sensorMovement)
        => await _context.SensorMovements
            .AddAsync(sensorMovement);
}