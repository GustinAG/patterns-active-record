namespace ActiveRecord.CheckOutWeb.Models
{
    public class ContactInfo
    {
        private const string Email = "gustinn@gmail.com";

        public string Name { get; } = "Gustin";
        public string SupportEmail { get; } = Email;
        public string MarketingEmail { get; } = Email;
    }
}