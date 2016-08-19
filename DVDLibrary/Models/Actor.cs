using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Actor
    {
        public int MovieId { get; set; }
        public int ActorId { get; set; }
        public string ActorName { get; set; }
        public string CharacterRole { get; set; }
    }
}
