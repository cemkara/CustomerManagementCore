using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public bool Status { get; set; }
        public string? Phone { get; set; }
        public string? Mail { get; set; }

        public List<Mail> Mails { get; set; }
        public List<Phone> Phones { get; set; }
    }
}
