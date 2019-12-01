using System.Collections.Generic;

namespace ActiveRecord.CheckOut.Contracts
{
    public interface IBill
    {
        int Id { get; }
        IList<IProduct> Products { get; }
        decimal TotalPrice { get; }
    }
}