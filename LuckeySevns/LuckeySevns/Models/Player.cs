using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LuckeySevns.Models
{
    public class Player
    {
        [DataType((DataType.Currency))]
        public decimal StartingBet { get; set; }
        public int TimesRolled { get; set; }

        [DataType((DataType.Currency))]
        public decimal MaxWinnings { get; set; }
        public int MaxWinningsRolled { get; set; }
    }
}