using System;
using System.Collections.Generic;
using System.Text;

namespace MAbileApp.Model
{
    public class Evaluation
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int? IdDay { get; set; }
        public int ValueEvaluation { get; set; }
        public DateTime Time { get; set; }
        public string SublectName { get; set; }

    }
}
