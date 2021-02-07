namespace SSETechnicalTest.API.Models
{
    public sealed class ProductsModel
    {
        public string SKU { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryID { get; set; }
    }
}
