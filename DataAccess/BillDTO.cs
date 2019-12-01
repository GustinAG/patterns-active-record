using System.Collections.Generic;

namespace ActiveRecord.DataAccess
{
    public class BillDTO
    {
        /// <summary>
        /// Gets or sets the unique ID of the bill.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the list of products on the bill.
        /// </summary>
        public IList<ProductDTO> Products { get; set; }
    }
}
