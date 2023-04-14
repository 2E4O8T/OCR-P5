using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVSec.Models
{
    public class InterventionsReparations
    {
        [Key]
        public int IntervetionsReparationsId { get; set; }
        [ForeignKey(nameof(Interventions))]
        public int IntervetionsId { get; set;}
        [ForeignKey(nameof(Reparations))]
        public int ReparationsId { get; set; }
    }
}
