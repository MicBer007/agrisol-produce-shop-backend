namespace shop.api.Dto
{
    public class TransactionDto
    {
        public Guid? TransactionId { get; set; }
        public string TransactionName { get; set; }
        public decimal TransactionValue { get; set; }
        public Guid CustomerId { get; set; }
    }
}
