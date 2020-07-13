namespace ClanWork.v1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bank")]
    public partial class Bank
    {
        public int id { get; set; }

        [Column(TypeName = "money")]
        public decimal? Money { get; set; }
    }
}
