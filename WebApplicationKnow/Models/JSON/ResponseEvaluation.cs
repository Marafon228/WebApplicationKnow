using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationKnow.Models.JSON
{
    public class ResponseEvaluation
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int? IdDay { get; set; }
        public int ValueEvaluation { get; set; }
        public DateTime Time { get; set; }
        public string SublectName { get; set; }
    }
}