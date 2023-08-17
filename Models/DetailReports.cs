using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;
using AppOwnsData.Models;

namespace AppOwnsData.ViewModels
{
    public class DetailReports
    {
        public Reports Reports { get; set; }
        public Roles Roles { get; set; }
    }
}
