using System;
using System.Collections.Generic;
using System.Linq;
using ActiveRecord.CheckOut.Contracts;
using ActiveRecord.DataAccess;

namespace ActiveRecord.BusinessLogic
{
    /// <summary>
    /// Represents a bill of a customer.
    /// </summary>
    public class Bill : IBill
    {
        private IList<Product> _products;

        /// <summary>
        /// Initializes a new instance of the <see cref="Bill"/> class.
        /// </summary>
        public Bill() => InitNew();

        private Bill(BillDTO dto)
        {
            if (dto == null)
            {
                InitNew();
                return;
            }

            Id = dto.Id;
            _products = dto.Products.Select(p => new Product(p)).ToList();
        }

        public int Id { get; private set; }

        /// <summary>
        /// Gets the list of products on the bill.
        /// </summary>
        public IList<IProduct> Products => _products.Select(p => p as IProduct).ToList();

        /// <summary>
        /// Gets the total price of the bought products on the bill.
        /// </summary>
        public decimal TotalPrice => _products.Sum(p => p.TotalPrice);

        /// <summary>
        /// Adds one piece of the given product to the bill.
        /// </summary>
        /// <param name="product">The product to be added.</param>
        internal void AddProduct(Product product)
        {
            if (_products.Contains(product))
                _products.First(p => p.Code == product.Code).Count++;
            else
                _products.Add(product);
        }

        internal static Bill Find(int id)
        {
            var dto = BillsDal.GetBill(id);
            return new Bill(dto);
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        internal void Save()
        {
            var dto = new BillDTO { Id = Id, Products = _products.Select(p => p.ToDTO()).ToList() };
            BillsDal.SaveBill(dto);
        }

        private void InitNew()
        {
            _products = new List<Product>();
            Id = GenerateNewId();
        }

        // Just for the sake of this sample code:
        private static int GenerateNewId() => new Random((int)DateTime.Now.Ticks).Next(100);
    }
}
