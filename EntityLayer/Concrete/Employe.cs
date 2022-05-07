using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Employe
    {
        [Key]
        public int EmployeId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }

        public int EmployeTypeId { get; set; }
        public EmployeType EmployeType { get; set; }
    }
}
