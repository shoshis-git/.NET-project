namespace bakery.API.Models
{
    public class OrdersPutModel
    {
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public EnumStatuses Status { get; set; }
    }
}
