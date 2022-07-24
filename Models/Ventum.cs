using System;
using System.Collections.Generic;

namespace WSventas.Models
{
    public partial class Ventum
    {
        public Ventum()
        {
            Conceptos = new HashSet<Concepto>();
        }

        public int Id { get; set; }
        public DateTime? Fecha { get; set; }
        public decimal? Total { get; set; }
        public int? ClienteId { get; set; }

        public virtual Cliente? Cliente { get; set; }
        public virtual ICollection<Concepto> Conceptos { get; set; }
    }
}
