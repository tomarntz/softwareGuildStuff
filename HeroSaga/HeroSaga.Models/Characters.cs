using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroSaga.Models
{
    public class Characters
    {
        public int Id { get; set; }
        public int RaceId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Discription { get; set; }
        public Alignment Alignment { get; set; }

        public virtual Race Race {get; set; }
        public virtual List<Battle> Battles { get; set; }
    }
}
