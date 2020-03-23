namespace dotnet.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
