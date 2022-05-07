using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace EntityLayer.Concrete
{
    public class Issue
    {
        [Key]
        public int IssueId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public bool Status { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime? EstimatedDeliveryDate { get; set; }

        public int PaymentStatusId { get; set; }
        public PaymentStatus PaymentStatus { get; set; }

        public int? ProductId { get; set; }
        public Product? Product { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int? EmployeId { get; set; }
        public Employe? Employe { get; set; }
    }
}
