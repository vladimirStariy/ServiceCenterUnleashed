using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCenter.Domain.Viewmodel.OrderService
{
    public class OrderServiceViewModel
    {
        [Display(Name= "OrderService_ID")]
        public uint OrderService_ID { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Price")]
        public double Price { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}
