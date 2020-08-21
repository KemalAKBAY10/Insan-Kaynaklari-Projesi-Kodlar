using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRProject.Entities
{
    [Table("HRProfessions")]
    public class HRProfessions
    {
        [Key, StringLength(50)]
        public string PROFESSIONID { get; set; }

        [Required,StringLength(50)]
        public string PROFESSIONNAME { get; set; }
    }
}
