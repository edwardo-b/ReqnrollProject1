using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject1.Resources.Models
{
    public enum Franchise
    {
        OddsKingAndBetfred,

    [Description("oddsking")]
        OddsKing,

    [Description("betfred")]
        Betfred,

    [Description("retail")]
        Retail,

    [Description("betfredsa")]
        BetfredSa,

    [Description("betfreduae")]
        BetfredUae
    }
}
