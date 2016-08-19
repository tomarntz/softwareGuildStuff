using System.Collections.Generic;

namespace HeroSaga.Models
{
    public class Monster
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Characters> Characters { get; set; }
    }
}