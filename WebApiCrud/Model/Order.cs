using System.ComponentModel.DataAnnotations;

namespace ecommerce.Model
{
    public class Order
    {
        public int Id { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9''-'\s]{1,20}$", ErrorMessage = "Enter any alphanumeric character - maximum 20.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        [RegularExpression(@"^[a-zA-Z0-9''-'\s]{1,20}$", ErrorMessage = "Enter any alphanumeric character - maximum 20.")]
        public required string LastName { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [RegularExpression(@"^[a-zA-Z0-9''-'\s]{1,100}$", ErrorMessage = "Enter any alphanumeric character - maximum 100.")]
        public required string Description { get; set; }

        [Range(1, 20, ErrorMessage = "Quantity must be between 1 and 20")]
        public int Quantity { get; set; }
    }
}
