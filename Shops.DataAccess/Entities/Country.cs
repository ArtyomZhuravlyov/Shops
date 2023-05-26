namespace Shops.DataAccess.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public List<Shop> Shops { get; set; } = new List<Shop>();
    }
}