using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplicationGrupp13.Models {
    public class CalenderViewModel {
        [Key]
        public int EventId { get; set; }
        public string Creator { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime Start { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime End { get; set; }

    }
}