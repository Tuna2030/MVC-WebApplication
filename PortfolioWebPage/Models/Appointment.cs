namespace PortfolioWebPage.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Appointment")]
    public partial class Appointment
    {
        public int id { get; set; }

        public int doc_id { get; set; }

        [StringLength(50)]
        public string userID { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime date { get; set; }

        [Required]
        [StringLength(50)]
        public string time { get; set; }

        public virtual Doctor Doctor { get; set; }
    }
}
