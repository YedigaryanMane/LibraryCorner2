namespace LibraryCorner.Models.RequestModels
{
    public class RequestAuthor
    {
        public RequestAuthor(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public string Name {  get; set; }
        public string Surname {  get; set; }
    }
}
