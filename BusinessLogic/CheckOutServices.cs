using ActiveRecord.CheckOut.Contracts;

namespace ActiveRecord.BusinessLogic
{
    public class CheckOutServices : ICheckOutService
    {
        private Bill _currentBill;

        /// <summary>
        /// Gets the current bill of the current check-out process.
        /// </summary>
        public IBill CurrentBill => _currentBill;

        /// <summary>
        /// Starts a new bill.
        /// </summary>
        public void Start() => _currentBill = new Bill();

        /// <summary>
        /// Resumes an already saved bill.
        /// </summary>
        /// <param name="id">The unique ID of the bill.</param>
        public void Resume(int id) => _currentBill = Bill.Find(id);

        /// <summary>
        /// Scans the given product.
        /// </summary>
        /// <param name="productCode">The product's code.</param>
        public void Scan(long productCode)
        {
            if (CurrentBill == null) return;

            Product product = Product.Find(productCode);
            _currentBill.AddProduct(product);
            _currentBill?.Save();
        }
    }
}
