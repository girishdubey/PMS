namespace PMS_Entity.Model.Master
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Shift
    {
        [Key]
        [Column(Order = 0)]
        public int Shift_Id { get; set; }
        [Key]
        [Column(Order = 1)]
        [StringLength(80)]
        public string Name { get; set; }
        public bool Is_General_Shift { get; set; }
    }
}
