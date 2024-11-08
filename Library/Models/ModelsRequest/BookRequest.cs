namespace LibraryCorner.Models.ModelsRequest
{
    public class BookRequest
    {
        public int BookId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorSurname { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public bool IsReserved { get; set; }
        public int Quanitity { get; set; }
        public string ISBN { get; set; }
    }
}
