namespace ASPAPI_mongo.Models
{
    public partial class Genre
    {
        public int genreID { get; set; }
        public string genreDesc { get; set; } = null!;
        public virtual ICollection<Backlog> Backlogs { get; } = new List<Backlog>();
    }
}