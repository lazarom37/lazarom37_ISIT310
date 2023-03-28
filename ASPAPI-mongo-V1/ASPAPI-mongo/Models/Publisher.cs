namespace ASPAPI_mongo.Models
{
    public partial class Publisher
    {
        public int publisherID { get; set; }
        public string Country { get; set; } = null!;
        public string NamePub { get; set; } = null!;
        public virtual ICollection<Backlog> Backlogs { get; } = new List<Backlog>();
    }
}