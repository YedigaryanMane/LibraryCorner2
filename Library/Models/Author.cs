using System.Text.Json.Serialization;

namespace LibraryCorner.Models
{
    public class Author
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string AuthorSurname { get; set; }
        public List<Book> Books { get; set; }
    }
}
