namespace Sep6_API.Models
{
    public class Movie
    {
        public string original_title { get; set; }

        public string title { get; set; }

        public int id { get; set; }

        public List<Genre> genre { get; set; }

        public string overview { get;set; }

        public string PosterRoute { get; set; }

        public string releaseDate { get; set; }

        public float? Rating { get; set; }

        public int? NrOfVotes { get; set; }


        
    }
}
