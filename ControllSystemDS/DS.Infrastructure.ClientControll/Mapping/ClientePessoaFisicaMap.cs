using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DS.Domain.ClientControll;

namespace DS.Infrastructure.ClientControll.Mapping
{
    class ClientePessoaFisicaMap : MapBase<ClientePessoaFisica>
    {
        public override void Configure(EntityTypeBuilder<ClientePessoaFisica> builder)
        {
            builder.ToTable("CLIENTE_PESSOA_FISICA");
            base.Configure(builder);
        }
    }
}
