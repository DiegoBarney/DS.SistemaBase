using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DS.Domain.ClientControll;

namespace DS.Infrastructure.ClientControll.Mapping
{
    public class MapBase<T> : IEntityTypeConfiguration<T> where T : EntityBase
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(c => c.codigo);

            builder.Property(c => c.codigo).IsRequired();

        }
    }
}
