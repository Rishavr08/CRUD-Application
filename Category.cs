using System.ComponentModel.DataAnnotations;

namespace bulkyweb.Models
{
    public class Category
    {
        [Key]
       public int? Id{ get; set; }
        [Required]
        [MaxLength(30)]
        [System.ComponentModel.DisplayName("Display Name")]
        public string? Name { get; set; }
        [Range(1,100)]
        [Required]
        [System.ComponentModel.DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
    }
}
