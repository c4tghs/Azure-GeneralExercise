namespace AZGE.ProductApi.Domain.Products;

public sealed class Product
{
    public int Id { get; init; }
    public string Name { get; private set; }
    public string? ImageUrl { get; private set; }
    public decimal Price { get; private set; }

    public Product(string name, string? imageUrl, decimal price)
    {
        Name = name;
        ImageUrl = imageUrl;
        Price = price;
    }

    public void Update(string name, string? imageUrl, decimal price)
    {
        UpdateName(name);
        UpdateImageUrl(imageUrl);
        UpdatePrice(price);
    }

    private void UpdateName(string name) 
    {
        Name = name;
    }

    private void UpdateImageUrl(string? imageUrl)
    {
        ImageUrl = imageUrl;
    }

    private void UpdatePrice(decimal price)
    {
        Price = price;
    }
}