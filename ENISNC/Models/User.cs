using static System.Collections.Specialized.BitVector32;
namespace ENISNC.Models
{


    public class User
    {
        public int UserId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int phoneNumber { get; set; }

        public string role { get; set; }
        public string password { get; set; }

        public Section section { get; set; }
        public IList<DemandePFE>? demandePFE { get; set; }
        public IList<Paper>? papers { get; set; }


    }
}


