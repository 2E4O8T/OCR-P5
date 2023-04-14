using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EVSec.Models
{
    public class Interventions
    {
        [Key]
        public int InterventionId { get; set; }
        [ForeignKey(nameof(Interventions))]
        [Required]
        public string TypeIntervention { get; set; }
        public ICollection<InterventionsReparations>? InterventionsReparations { get; set; }
    }
}
