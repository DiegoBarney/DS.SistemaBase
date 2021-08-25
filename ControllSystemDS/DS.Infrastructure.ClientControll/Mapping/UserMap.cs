using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DS.Domain.ClientControll;

namespace DS.Infrastructure.ClientControll.Mapping
{
    public class UserMap : MapBase<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("USUARIO_SISTEMA");
            base.Configure(builder);
        }
    }
}
