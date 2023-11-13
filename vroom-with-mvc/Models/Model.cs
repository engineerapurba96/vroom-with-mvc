using System.ComponentModel.DataAnnotations;

namespace vroom_with_mvc.Models
{
    public class Model
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public Make Make { get; set; } //Inverse property bcz Model is also associated with make

        public int MakeID { get; set; }
    }
}
