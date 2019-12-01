using System;

namespace ActiveRecord.DataAccess
{
    // Just for the sake of this sample code:
    public static class BillsDal
    {
        private static BillDTO _savedBill;

        public static BillDTO GetBill(int id) => _savedBill;

        public static void SaveBill(BillDTO bill)
        {
            _savedBill = bill;
            Console.WriteLine($"Bill #{bill.Id} with {bill.Products.Count} products saved.");
        }
    }
}
