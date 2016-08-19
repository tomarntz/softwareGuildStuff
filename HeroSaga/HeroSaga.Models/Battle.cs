using System;

namespace HeroSaga.Models
{
    public class Battle
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public int MonsterId { get; set; }
        public DateTime? Date { get; set; }
        public bool IsMonsterDefeated { get; set; }
        public virtual Characters Character { get; set; }
        public virtual Monster Monster { get; set; }
    }
}