namespace EducationalCenter.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EvaluationAndUser")]
    public partial class EvaluationAndUser
    {
        public int Id { get; set; }

        public int IdUser { get; set; }

        public int IdSubject { get; set; }

        public int? IdDay { get; set; }

        public int ValueEvaluation { get; set; }

        public DateTime Time { get; set; }

        public virtual Day Day { get; set; }

        public virtual Subject Subject { get; set; }

        public virtual User User { get; set; }
    }
}
