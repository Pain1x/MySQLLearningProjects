namespace ClanWork.v1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Position
    {
        public int id { get; set; }

        [Required]
        [StringLength(20)]
        public string PositionName { get; set; }

        [Required]
        [StringLength(20)]
        public string Invite { get; set; }

        [Required]
        [StringLength(20)]
        public string Kick { get; set; }

        [Required]
        [StringLength(20)]
        public string ChangePosition { get; set; }

        [Required]
        [StringLength(20)]
        public string PutMoney { get; set; }

        [Required]
        [StringLength(20)]
        public string WithdrawMoney { get; set; }

        [Required]
        [StringLength(20)]
        public string WatchLogs { get; set; }
    }
}
