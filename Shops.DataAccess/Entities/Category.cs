namespace Shops.DataAccess.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public List<Shop> Shops { get; set; } = new List<Shop>();
    }
}