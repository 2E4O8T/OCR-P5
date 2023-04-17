using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace EVSec.Models
{
    public class Inventaire
    {
        [Key]
        public int CodeVin { get; set; }
        [Required]
        [Range(1990,int.MaxValue)]
        [DisplayName("Année")]
        public int Annee { get; set; }
        [Required]
        [DisplayName("Marque")]
        public string Marque { get; set; }
        [Required]
        [DisplayName("Modèle")]
        public string Modele { get; set; }
        [Required]
        [DisplayName("Finition")]
        public string Finition { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Date d'achat")]
        public DateTime DateAchat { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [DisplayName("Prix d'achat")]
        public float PrixAchat { get; set; }
        [DataType(DataType.Currency)]
        [DisplayName("Prix de vente")]
        public float PrixVente { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Date de vente")]
        public DateTime DateVente { get; set; }
        [DisplayName("Véhicule disponible")]
        public bool IsVente { get; set; }
        public string? Description { get; set; }
        public byte[]? Photo { get; set; }
        public ICollection<Reparations>? Reparations { get; set; }
    }
}
