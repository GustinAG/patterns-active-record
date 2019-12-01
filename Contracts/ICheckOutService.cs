namespace ActiveRecord.CheckOut.Contracts
{
    public interface ICheckOutService
    {
        IBill CurrentBill { get; }

        void Resume(int billId);
        void Scan(long productCode);
    }
}
