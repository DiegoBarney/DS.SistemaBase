using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DS.Domain.ClientControll
{
    public abstract class EntityBase
    {
        [Column("CODIGO")]
        public int codigo { get; set; }
    }
}
