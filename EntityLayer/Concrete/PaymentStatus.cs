using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class PaymentStatus
    {
        [Key]
        public int PaymentStatusId { get; set; }
        public string Name { get; set; }

        public List<Issue> Issues { get; set; }
    }
}
