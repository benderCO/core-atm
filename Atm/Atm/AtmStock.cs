using Atm.Enums;
using System;

namespace Atm
{
    public class AtmStock
    {
        public Guid id { get; set; }
        public CurrencyType currency { get; set; }
        public int value { get; set; }
        public int count { get; set; }

    }
}
