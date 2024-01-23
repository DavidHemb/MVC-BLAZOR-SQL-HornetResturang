namespace DataAccess.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Liquid { get; set; }
        public int VatRate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
