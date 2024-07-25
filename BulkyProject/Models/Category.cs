using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyProject.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [DisplayName("Category Name")]
        public string Name { get; set; }

        [Range(1,100)]
        [DisplayName("Display Order")]
        public int CategoryOrder { get; set; }
    }
}
