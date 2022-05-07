using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class EmployeType
    {
        [Key]
        public int EmployeTypeId { get; set; }
        public string Type { get; set; }
        public bool Status { get; set; }

        public List<EmployeType> EmployeTypes { get; set; }
    }
}
