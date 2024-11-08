namespace LibraryCorner.BorrowedMenu
{
    public class LibraryModel
    {
        public LibraryModel(string iSBN)
        {
            ISBN = iSBN;
        }

        public LibraryModel(string name, string surname, string libraryName, string title, int year)
        {
            Name = name;
            Surname = surname;
            LibraryName = libraryName;
            Title = title;
            Year = year;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string LibraryName {  get; set; }
        public string Title {  get; set; }
        public int Year { get; set; }
        public string ISBN { get; set; }

    }
}
