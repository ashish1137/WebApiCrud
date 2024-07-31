namespace ecommerce.Model
{
    public class Order
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Description { get; set; }
        public int Quantity { get; set; }
    }
}
