using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskListADO.Models
{
    public class Task
    {
        public int TasKId { get; set; }
        public string Discription { get; set; }
        public DateTime DateEntered { get; set; }
        public DateTime? DueDate { get; set; }
        public string Notes { get; set; }
    }
}
