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
    [Table("League")]
    public class League
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int League_ID { get; set; }
        public string League_Name { get; set; }
        public string Nation { get; set; }
        public int CL_Places { get; set; }

        [JsonIgnore]
        public virtual ICollection<Club> Clubs { get; set; }

        public League()
        {
            Clubs = new HashSet<Club>();
        }
    }
}
