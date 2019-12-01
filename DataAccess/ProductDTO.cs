namespace ActiveRecord.DataAccess
{
	public class ProductDTO
	{
		/// <summary>
		/// Gets or sets the product's code.
		/// </summary>
		public int Code { get; set; }

		/// <summary>
		/// Gets or sets the name of the product.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the product's price.
		/// </summary>
		public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the bough count of the product - if applicable.
        /// </summary>
	    public int BoughtCount { get; set; }
	}
}
