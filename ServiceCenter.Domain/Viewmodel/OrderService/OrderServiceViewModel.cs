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
        [Display(Name = "Наименование")]
        public string Name { get; set; }
        [Display(Name = "Цена")]
        public double Price { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; }
    }
}
