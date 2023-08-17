using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace AppOwnsData.Models
{
    public class Reports
    {
        [Key]
        public long id { get; set; }
        public string name { get; set; }
        public string reportId { get; set; }
        public string datasetId { get; set; }
    }
}
