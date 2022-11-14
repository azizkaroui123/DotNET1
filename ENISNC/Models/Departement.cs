namespace ENISNC.Models
{
    public class Departement
    {
        public int Id { get; set; }
        public string spacialitée { get; set; }
        public IList<Section>? sections { get; set; }
    }
}
