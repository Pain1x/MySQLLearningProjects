namespace ClanWork.v1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Login
    {
        public int id { get; set; }

        [Required]
        [StringLength(20)]
        public string Log { get; set; }

        [Required]
        [StringLength(20)]
        public string Pass { get; set; }

        public int? Memberid { get; set; }

        public virtual Member Member { get; set; }
    }
}
