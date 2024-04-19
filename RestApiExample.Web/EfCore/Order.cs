using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApiExample.Web.EfCore
{
    [Table("other")]
    public class Order
    {
        [Key, Required]

        public int Id { get; set; }

        public virtual Product? Product { get; set; }

        public string? Name { get; set; }

        public string? Address { get; set; }

        public string? Phone { get; set; }
    }
}
