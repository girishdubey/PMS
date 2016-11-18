namespace PMSEntity.Model.Master
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Holiday
    {
        [Key]
        [Column(Order = 0)]
        public int Holiday_Id { get; set; }
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }
        [StringLength(50)]
        public string Holiday_Name { get; set; }
        [StringLength(50)]
        public string Adjusted_Against { get; set; }
        [Column(TypeName = "date")]
        public DateTime Adjusted_Date { get; set; }
        public bool Optional { get; set; }
    }
}
