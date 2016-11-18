namespace PMSEntity.Model.Master
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Employee
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }
        [Key]
        [Column(Order = 1)]
        [StringLength(80)]
        public string Employee_Code { get; set; }
        [StringLength(20)]
        public string First_Name { get; set; }
        [StringLength(20)]
        public string Middle_Name { get; set; }
        [StringLength(20)]
        public string Last_Name { get; set; }
        public int? Title_Id { get; set; }
        public DateTime? Date_Of_Birth { get; set; }
        public DateTime? Appointment_Letter_Date { get; set; }
        public bool? IsActivated { get; set; }
        public DateTime? ActivatedOn { get; set; }
    }
}
