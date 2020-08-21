using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRProject.Entities
{
    [Table("HRUsers")]
   public class HRUsers
    {
        [Key,StringLength(50)]
        public string USERID { get; set; }

        [Required,StringLength(50)]
        public string FIRSTNAME { get; set; }

        [Required, StringLength(50)]
        public string LASTNAME { get; set; }

        [Required, StringLength(50)]
        public string MANAGERUSERID { get; set; }

        [Required, StringLength(50)]
        public string COSTCENTER { get; set; }

        [Required, StringLength(50)]
        public string COMPANY { get; set; }

        [Required, StringLength(50)]
        public string STATUS { get; set; }

        //Foreign keys
        [Required, StringLength(50)]
        public string DEPARTMENTID  { get; set; }
        [Required, StringLength(50)]
        public string  PROFESSIONID { get; set; }
        [Required, StringLength(50)]
        public string  POSITIONID { get; set; }
    }

}
