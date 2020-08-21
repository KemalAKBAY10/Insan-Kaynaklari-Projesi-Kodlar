using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRProject.Entities
{
    [Table("HRUsersDetails")]
    public class HRUsersDetails
    {
        [Key, StringLength(50)]
        public string USERID { get; set; }

        public string SUBCOMPANY { get; set; }
        public string COLLAR { get; set; }
        public string SEX { get; set; }
        public string MARITALSTATUS { get; set; }
        public string CHILD { get; set; }
        public string LOCATION { get; set; }
        public string PAYROLL { get; set; }
        public string DATEOFWORK { get; set; }
        public string DATEOFBIRTH { get; set; }
        public string PLACEOFBIRTH { get; set; }
        public string ADUSERNAME { get; set; }
        public string PASSWORD { get; set; }
        public string EMAIL { get; set; }
        public string ADDRESS { get; set; }
        public string BANKSWITCH { get; set; }
        public string BANKACCOUNT { get; set; }
        public string IBAN { get; set; }
        public string TCNO { get; set; }
        public string LANGUAGE { get; set; }
        public string BLOODGROUP { get; set; }
        public string PHONENUMBER { get; set; }        

    }
}
