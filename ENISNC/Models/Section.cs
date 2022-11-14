namespace ENISNC.Models
{
    public class Section
    {
            public int Id { get; set; }
            public string sectionName { get; set; }

            public string Grade { get; set; }
            public string schoolYear { get; set; }
            public Departement Departement { get; set; }
        
    }
}
