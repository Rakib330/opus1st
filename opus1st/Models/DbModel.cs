namespace opus1st.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
    }
    public class Customer
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
    }
    public class Order
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public Customer Customer { get; set; }
    }
}
