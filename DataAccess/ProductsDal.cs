namespace ActiveRecord.DataAccess
{
    // Just for the sake of this sample code:
    public static class ProductsDal
    {
        private static readonly ProductDTO[] Products =
        {
            new ProductDTO { Name = "Egg", Price = 0.11M },
            new ProductDTO { Name = "Bread", Price = 0.89M },
            new ProductDTO { Name = "Butter", Price = 0.39M },
            new ProductDTO { Name = "Grape", Price = 1.00M },
            new ProductDTO { Name = "Orange", Price = 1.12M },
            new ProductDTO { Name = "Milk", Price = 0.65M },
            new ProductDTO { Name = "Sugar", Price = 0.43M },
            new ProductDTO { Name = "Cucumber", Price = 0.25M },
            new ProductDTO { Name = "Crescent", Price = 0.2M }
        };

        public static ProductDTO GetProduct(long code)
        {
            code %= Products.Length;
            ProductDTO product = Products[code];
            product.Code = (int)code;

            return product;
        }
    }
}
