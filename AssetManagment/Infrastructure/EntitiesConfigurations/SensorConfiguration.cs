using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntitiesConfigurations;

public class SensorConfiguration : IEntityTypeConfiguration<Sensor>
{
    public void Configure(EntityTypeBuilder<Sensor> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.MeasureType)
            .WithMany(x => x.Sensors);

        builder.ComplexProperty(x => x.Activity);
    }
}