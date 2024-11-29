using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace Sirbu_Iulia_Lab2.Models
{
    public class Author
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Computed property, not mapped to the database
        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
        public ICollection<Book>? Books { get; set; }
    }
}
