namespace ASPAPI_mongo.Models
{
    public partial class Backlog
    {
        public int backlogID { get; set; }
        public string Title { get; set; } = null!;
        public string Platform { get; set; } = null!;
        public bool Finished { get; set; }
        public int publisherID { get; set; }
        public int genreID { get; set; }
        public virtual Publisher Publisher { get; set; } = null!;
        public virtual Genre Genre { get; set; } = null!;
    }
}