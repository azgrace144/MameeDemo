using System.ComponentModel.DataAnnotations;

namespace AppOwnsData.Models
{
    public class RoleReports
    {
        [Key]
        public long id { get; set; }

        public long role_id { get; set; }
        public string report_id { get; set; }
    }
}
