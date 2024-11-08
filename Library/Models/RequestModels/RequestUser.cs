namespace LibraryCorner.Models.RequestModels
{
    public class RequestUser
    {
        public RequestUser(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email {  get; set; }
        public string Password { get; set; }
    }
}
