using Core.Models;
using Infrastructure.EntitiesConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class AssetManagmentContext : DbContext
{
    public DbSet<MachineTool> MachineTool {get; set;}
    public DbSet<Sensor> Sensor {get; set;}
    public DbSet<SensorMovement>SensorMovements {get; set;}
    public DbSet<MeasureType> MeasureTypes {get; set;}
    public DbSet<MachineToolType> MachineToolTypes {get; set;}
    public AssetManagmentContext(DbContextOptions<AssetManagmentContext> context): base(context){}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MachineToolConfiguration());
        modelBuilder.ApplyConfiguration(new SensorConfiguration());
    }
}