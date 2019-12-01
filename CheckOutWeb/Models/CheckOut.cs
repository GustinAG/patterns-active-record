using ActiveRecord.CheckOut.Contracts;

namespace ActiveRecord.CheckOutWeb.Models
{
    public class CheckOut
    {
        // ReSharper disable once UnusedMember.Global
        // Required by ASP.NET MVC
        public CheckOut()
        { }

        public CheckOut(IBill bill)
        {
            if (bill == null) return;

            Bill = bill;
            BillId = bill.Id;
        }

        public int ScannedCode { get; set; }
        public int BillId { get; set; }
        public IBill Bill { get; }
        public decimal TotalPrice => Bill?.TotalPrice ?? 0;
    }
}