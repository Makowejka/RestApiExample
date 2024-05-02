using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApiExample.Web.Entity
{
    [Table("order")]
    public class Order
    {
        [Key, Required]

        public int Id { get; set; }

        public virtual List<Product>? Products { get; set; }

        public string? Name { get; set; }

        public string? Address { get; set; }

        public string? Phone { get; set; }
        public int ProductId { get; set; }
    }
}
