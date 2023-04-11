using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrder.BLL.Models
{
    public class Window
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public int ElementsCount { get; set; }
    }
}
