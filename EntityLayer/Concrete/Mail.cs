using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Mail
    {
        [Key]
        public int MailId { get; set; }
        public string Address { get; set; }
        public bool Status { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
