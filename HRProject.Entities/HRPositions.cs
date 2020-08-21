using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRProject.Entities
{
    [Table("HRPositions")]
    public class HRPositions
    {
        [Key, StringLength(50)]
        public string POSITIONID { get; set; }

        [Required,StringLength(50)]
        public string POSITIONNAME { get; set; }
    }
}
