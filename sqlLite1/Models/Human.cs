using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqlLite1.Models
{
    internal class Human
    {
        public int HumanId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? SecondName { get; set; }
        public ICollection<ToDo>? CreatedTasks { get; set; }
        public ICollection<ToDo>? AssignedTasks { get; set; }
    }
}
