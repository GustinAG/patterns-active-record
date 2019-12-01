namespace ActiveRecord.CheckOut.Contracts
{
    public interface IProduct
    {
        /// <summary>
        /// Gets the name of the product.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the unit price of the product.
        /// </summary>
        decimal UnitPrice { get; }

        /// <summary>
        /// Gets or sets the bought count of this product.
        /// </summary>
        int Count { get; set; }

        /// <summary>
        /// Gets the total price of the product.
        /// </summary>
        decimal TotalPrice { get; }
    }
}
