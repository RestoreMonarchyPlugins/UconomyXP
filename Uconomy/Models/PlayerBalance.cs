using Newtonsoft.Json;
using SDG.Unturned;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fr34kyn01535.Uconomy.Models
{
    public class PlayerBalance
    {
        public string SteamID { get; set; }
        public decimal Balance { get; set; }
        public DateTime LastUpdate { get; set; }

        [JsonIgnore]
        public bool IsPositive => Balance > 0;
        [JsonIgnore]
        public uint Experience => (uint)Balance;

        internal void IncreaseBalance(decimal increaseBy)
        {
            SetBalance(Balance + increaseBy);
        }

        internal void SetBalance(decimal balance)
        {
            Balance = balance;
            LastUpdate = DateTime.Now;
        }

        internal void SetExperience(CSteamID steamID)
        {
            Player player = PlayerTool.getPlayer(steamID);
            if (player == null)
                return;

            if (IsPositive)
                player.skills.ServerSetExperience(Experience);
            else
                player.skills.ServerSetExperience(0);
        }
    }
}
