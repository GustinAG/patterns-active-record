using System;
using System.Collections.Generic;
using ActiveRecord.CheckOut.Contracts;
using ActiveRecord.DataAccess;

namespace ActiveRecord.BusinessLogic
{
    /// <summary>
    /// Represents a product that a customer buys.
    /// </summary>
    public class Product : IProduct, IEquatable<Product>, IEqualityComparer<Product>
    {
        private const int MinimumBoughtCount = 1;

        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class based on a data transfer object. 
        /// Prevents a default instance of the <see cref="Product"/> class from being created.
        /// </summary>
        /// <param name="dto">
        /// The data transfer object.
        /// </param>
        public Product(ProductDTO dto)
        {
            Code = dto.Code;
            Name = dto.Name;
            UnitPrice = dto.Price;
            Count = Math.Max(dto.BoughtCount, MinimumBoughtCount);
        }

        /// <summary>
        /// Gets the product's code.
        /// </summary>
        public int Code { get; }

        /// <inheritdoc />
        public string Name { get; }

        /// <inheritdoc />
        public decimal UnitPrice { get; }

        /// <inheritdoc />
        public int Count { get; set; }

        /// <inheritdoc />
        public decimal TotalPrice => Count * UnitPrice;

        #region IEquatable<Product>, IEqualityComparer<Product>
        public bool Equals(Product other) => Code == other?.Code;

        public bool Equals(Product x, Product y) => x?.Code == y?.Code;

        public int GetHashCode(Product obj) => Code.GetHashCode();
        #endregion

        /// <summary>
        /// Finds a product based on the specified code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>The product found.</returns>
        internal static Product Find(long code)
        {
            ProductDTO dto = ProductsDal.GetProduct(code);
            return new Product(dto);
        }

        /// <summary>
        /// Converts this instance to a DTO.
        /// </summary>
        /// <returns>The DTO.</returns>
        internal ProductDTO ToDTO() => new ProductDTO { Code = Code, Name = Name, Price = UnitPrice, BoughtCount = Count };
    }
}
