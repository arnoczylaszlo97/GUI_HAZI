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
    [Table("Club")]
    public class Club
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Club_ID { get; set; }

        public string Club_Name { get; set; }
        public uint Value { get; set; }
        public string Owner { get; set; }
        public string Manager { get; set; }

        [ForeignKey(nameof(Models.League))]
        public int League_ID { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual League League { get; set; }

        [JsonIgnore]
        public virtual ICollection<Player> Players { get; set; }

        public Club()
        {
            Players = new HashSet<Player>();
        }
    }
}
