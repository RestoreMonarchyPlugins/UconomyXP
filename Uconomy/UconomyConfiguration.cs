using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fr34kyn01535.Uconomy
{
    public class UconomyConfiguration : IRocketPluginConfiguration
    {
        public decimal InitialBalance { get; set; }
        public string MoneyName { get; set; }

        public void LoadDefaults()
        {
            InitialBalance = 30;
            MoneyName = "Credits";
        }
    }
}
