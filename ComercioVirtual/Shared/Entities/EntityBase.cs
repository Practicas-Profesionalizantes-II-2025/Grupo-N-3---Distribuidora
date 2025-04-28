using System.ComponentModel.DataAnnotations.Schema;
namespace Shared.Entities
{
    public class EntityBase
    {
        public int Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; } = null;
    }
}
