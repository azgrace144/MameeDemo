using System.ComponentModel.DataAnnotations;

namespace AppOwnsData.Models
{
    public class UserRole
    {
        [Key]
        public long urid { get; set; }
        public string user_id { get; set; }
        public long role_id { get; set; }
       
    }
}
