using EntityFrameworkCore.CreatedUpdatedDate.Contracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupplyMngService.Domain.Model.Aggregates
{
    public partial class Supply : IEntityWithCreatedUpdatedDate
    {
        [Column("Created At")] public DateTimeOffset? CreatedDate { get; set; }

        [Column("Updated At")] public DateTimeOffset? UpdatedDate { get; set; }
    }
}
