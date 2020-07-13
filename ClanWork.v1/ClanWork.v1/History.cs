namespace ClanWork.v1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("History")]
    public partial class History
    {
        public int id { get; set; }

        [Required]
        [StringLength(20)]
        public string Action { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfAction { get; set; }
    }
}
