namespace ClanWork.v1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NewMembTab")]
    public partial class NewMembTab
    {
        public int id { get; set; }

        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        [Required]
        [StringLength(20)]
        public string WantedPosition { get; set; }

        [Required]
        [StringLength(20)]
        public string Log { get; set; }

        [Required]
        [StringLength(20)]
        public string Pass { get; set; }
    }
}
