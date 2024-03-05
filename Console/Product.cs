using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManager
{

    [Table("products")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required decimal Price { get; set; }
    }

}
