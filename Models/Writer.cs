using System;
namespace IndyBooks.Models
{
	public class Writer
	{
		public long id { get; set; }
		public string Name { get; set; }
		public string Bio { get; set; }
		public ICollection<Book> Books { get; set; }
	}
}

