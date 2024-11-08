namespace LibraryCorner.Models.RequestModels
{
    public class RequestLibrary
    {
        public RequestLibrary(string name)
        {
            Name = name;
        }

        public string Name {  get; set; }
    }
}
