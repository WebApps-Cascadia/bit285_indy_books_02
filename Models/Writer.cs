using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndyBooks.Models
{
	public class Writer
	{

		public int Id { get; set; }

		public string Name { get; set; }

        public string Bio { get; set; }

        public ICollection<Book> Books { get; set; }

	}
}

