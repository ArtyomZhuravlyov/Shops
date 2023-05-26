namespace Shops.DataAccess.Entities
{
    public class Stock
    {
        public int Id { get; set; }

        public long Backstore { get; set; }

        public long Frontstore { get; set; }

        public int ShoppingWindow { get; set; }

        public float Accuracy { get; set; }

        public float OnFloorAvailability { get; set; }

        public int MeanAge { get; set; }

        public int ShopId { get; set; }
        public Shop Shop { get; set; }

    }
}