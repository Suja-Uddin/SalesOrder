using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrder.BLL.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public int WindowsCount { get; set; }
    }
}
