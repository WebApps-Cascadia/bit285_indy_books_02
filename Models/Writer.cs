namespace IndyBooks.Models
{
    public class Writer
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<Book> Books { get; set;}
        public string Bio { get; set; }
    }
}
