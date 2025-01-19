
namespace CleanArchitecture.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }

        public Product(string name, string description, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty", nameof(name));
            if (price <= 0)
                throw new ArgumentException("Price must be greater than zero", nameof(price));

            Name = name;
            Description = description ?? "";
            Price = price;
        }

        public void UpdateDetails(string name, string description, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty", nameof(name));
            if (price <= 0)
                throw new ArgumentException("Price must be greater than zero", nameof(price));

            Name = name;
            Description = description ?? "";
            Price = price;
        }
    }
}
