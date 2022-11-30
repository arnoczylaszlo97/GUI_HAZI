using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FZZOC7_HFT_2021221.Models
{
    [Table("Player")]
    public class Player
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Player_ID { get; set; }

        public string Player_Name { get; set; }
        public int Wage { get; set; }
        public string Nationality { get; set; }
        public string Position { get; set; }

        [ForeignKey(nameof(Models.Player))]
        public int Club_ID { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Club Club { get; set; }
    }
}
