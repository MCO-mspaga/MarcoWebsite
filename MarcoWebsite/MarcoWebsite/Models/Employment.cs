using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace MarcoWebsite.Models
{
    public class Employment
    {

        public int Id { get; set; }
     
        public string Title { get; set;  }
        [Display(Name = "Date work commenced")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [Display(Name = "Date work ended")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
        public string Description { get; set;  }

        public string Industry { get; set; }
    }

    public class EmploymentDBContext : DbContext
    {
        public DbSet<Employment> Employment { get; set; }
    }
}