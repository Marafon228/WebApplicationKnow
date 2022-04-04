namespace EducationalCenter.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserAndSubject")]
    public partial class UserAndSubject
    {
        public int Id { get; set; }

        public int IdUser { get; set; }

        public int IdSubject { get; set; }

        public virtual Subject Subject { get; set; }

        public virtual User User { get; set; }
    }
}
