using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrder.DAL.Models
{
    public class Element
    {
        [Key]
        public int ElementId { get; set; }
        public int Number { get; set; }
        public string Type { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int WindowId { get; set; }
        public virtual Window Window { get; set; }
    }
}
