using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrder.DAL.Models
{
    public class Window
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WindowId { get; set; }
        [Required]
        public string Name { get; set; }
        public int Quantity { get; set; }
        [Required]
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public virtual ICollection<Element> Elements { get; set; }
    }
}
