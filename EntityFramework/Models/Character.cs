namespace EntityFramework.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Backpack Backpack { get; set; }

    }
}
