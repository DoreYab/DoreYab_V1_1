using System.ComponentModel.DataAnnotations.Schema;

namespace _0_Framework.Domain
{
    public class EntityBase
    {
        public long Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreationDate { get; set; }
    }
}
