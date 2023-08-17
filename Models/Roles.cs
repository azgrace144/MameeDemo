using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;
namespace AppOwnsData.Models
{
    public class Roles
    {
        [Key]
        public long rid { get; set; }
        public string name { get; set; }
    }
}
