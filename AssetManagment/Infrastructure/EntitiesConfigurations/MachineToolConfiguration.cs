using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntitiesConfigurations;

public class MachineToolConfiguration : IEntityTypeConfiguration<MachineTool>
{
    public void Configure(EntityTypeBuilder<MachineTool> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.HasMany(m => m.Sensors)
            .WithOne(x => x.MachineTool);
        
        builder.ComplexProperty(x => x.Activity);
    }
}