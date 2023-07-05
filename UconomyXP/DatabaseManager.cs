using fr34kyn01535.Uconomy.Models;
using fr34kyn01535.Uconomy.Storage;
using Rocket.Core.Logging;
using SDG.Unturned;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace fr34kyn01535.Uconomy
{
    public class DatabaseManager
    {
        private Uconomy pluginInstance => Uconomy.Instance;

        private DataStorage<List<PlayerBalance>> dataStorage;

        private List<PlayerBalance> data;

        internal DatabaseManager(string directory, string fileName)
        {
            dataStorage = new DataStorage<List<PlayerBalance>>(directory, fileName);
        }

        internal void LoadData()
        {
            data = dataStorage.Read();
            if (data == null)
            {
                data = new List<PlayerBalance>();
                dataStorage.Save(data);
            }
        }

        internal void SaveData()
        {
            dataStorage.Save(data);
        }

        internal PlayerBalance GetPlayerBalance(string id)
        {
            return data.FirstOrDefault(x => x.SteamID == id);
        }

        /// <summary>
        /// returns the current balance of an account
        /// </summary>
        /// <param name="steamId"></param>
        /// <returns></returns>
        public decimal GetBalance(string id)
        {
            PlayerBalance bal = GetPlayerBalance(id);
            return bal?.Balance ?? 0;
        }

        /// <summary>
        /// Increasing balance to increaseBy (can be negative)
        /// </summary>
        /// <param name="steamId">steamid of the accountowner</param>
        /// <param name="increaseBy">amount to change</param>
        /// <returns>the new balance</returns>
        public decimal IncreaseBalance(string id, decimal increaseBy)
        {
            PlayerBalance bal = GetPlayerBalance(id);
            bal.IncreaseBalance(increaseBy);

            bal.SetExperience(new CSteamID(ulong.Parse(id)));
            
            return bal.Experience;
        }
        
        public void CheckSetupAccount(CSteamID id)
        {
            PlayerBalance bal = GetPlayerBalance(id.ToString());
            if (bal == null)
            {
                bal = new PlayerBalance()
                {
                    SteamID = id.ToString(),
                    Balance = pluginInstance.Configuration.Instance.InitialBalance,
                    LastUpdate = DateTime.Now
                };
                data.Add(bal);
            }

            bal.SetExperience(id);
        }

        public void CheckSetupAccount(CSteamID id, uint experience)
        {
            PlayerBalance bal = GetPlayerBalance(id.ToString());
            if (bal == null)
            {
                decimal balance = experience <= 0 ? pluginInstance.Configuration.Instance.InitialBalance : experience;
                bal = new PlayerBalance()
                {
                    SteamID = id.ToString(),
                    Balance = balance,
                    LastUpdate = DateTime.Now
                };
                data.Add(bal);
            }

            bal.SetExperience(id);
        }
    }
}
