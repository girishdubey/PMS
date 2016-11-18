namespace PMSEntity.Model.Master
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ClientRegistration
    {
        public long RegistrationID { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Mobileno { get; set; }
        public string EmailID { get; set; }
        public Nullable<System.DateTime> Createddate { get; set; }
        public string Token { get; set; }
        public string EncryKey { get; set; }
        public string IVKey { get; set; }
        public string UniqueID { get; set; }
    }

    public class KeysValues
    {
        public string EncryKey { get; set; }
        public string IVKey { get; set; }
    }
}
