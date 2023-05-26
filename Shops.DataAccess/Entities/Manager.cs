namespace Shops.DataAccess.Entities
{
    public class Manager
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int ShopId { get; set; }
        public Shop Shop { get; set; }
    }
}