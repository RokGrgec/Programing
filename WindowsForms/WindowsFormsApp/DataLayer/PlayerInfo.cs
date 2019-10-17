using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PlayerInfo
    {
        public string player_name { get; set; }
        public int player_number { get; set; }
        public string position { get; set; }
        public bool is_captain { get; set; }
        public bool is_fav_player { get; set; }

        public override string ToString() => $"{player_name} | {player_number} | {position} | {(is_captain ? "true" : "false")}";
        
    }
}
