using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRProject.Entities
{
    [Table("HRDepartments")]
    public class HRDepartments
    {
        [Key, StringLength(50)]
        public string DEPARTMENTID { get; set; }

        [Required, StringLength(50)]
        public string DEPARTMENTNAME { get; set; }

        [Required,StringLength(50)]
        public string  MANAGERID { get; set; }
    }
}
