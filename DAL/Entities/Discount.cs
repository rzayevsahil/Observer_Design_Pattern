namespace Observer_Design_Pattern.DAL.Entities
{
    public class Discount
    {
        public int DiscountID { get; set; }
        public int UserID { get; set; }
        public int Rate { get; set; }
        public string Description { get; set; }
    }
}
