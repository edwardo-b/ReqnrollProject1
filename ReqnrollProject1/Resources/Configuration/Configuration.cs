using ReqnrollProject1.Resources.Models;
using ReqnrollProject1.Utils;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject1.Resources.Configuration
{
    public static partial class Configuration
    {
        [ThreadStatic]
        private static string company;
        private static string oddskingFranchise;
        private static string betfredFranchise;
        private static string retailFranchise;
        private static string betfredSaFranchise;
        private static string betfredUaeFranchise;

        private static string oddskingCompany;
        private static string betfredCompany;
        private static string retailCompany;
        private static string betfredSaCompany;
        private static string betfredUaeCompany;
        public static string CompanyId => CompanyInfo;
        public static string FranchiseId => FrachiseInfo;
        public static string GetBrowser => ConfigReader.GetConfigAppSettingValue("browser:Browser") ?? "chrome";
        public static string Team => ConfigReader.GetConfigAppSettingValue("env:Team").ToLower();
        private static string BusinessUnit => ConfigReader.GetConfigAppSettingValue("env:BusinessUnit").ToLower();
        public static string Company
        {
            get => string.IsNullOrEmpty(company) ? ConfigReader.GetConfigAppSettingValue("env:Company") : company;
            set => company = value;
        }

        public static string FrachiseInfo
        {
            get
            {
                if ((!Company.ToLower().Equals(Franchise.OddsKing.GetDescription())
                    && !Company.ToLower().Equals(Franchise.Betfred.GetDescription())
                    && !Company.ToLower().Equals(Franchise.BetfredSa.GetDescription())
                    && !Company.ToLower().Equals(Franchise.BetfredUae.GetDescription())
                    && !Company.ToLower().Equals(Franchise.Retail.GetDescription()))) return null;
                if (Company.ToLower().Equals(Franchise.OddsKing.GetDescription())) return oddskingFranchise;
                if (Company.ToLower().Equals(Franchise.Betfred.GetDescription())) return betfredFranchise;
                if (Company.ToLower().Equals(Franchise.Retail.GetDescription())) return retailFranchise;
                if (Company.ToLower().Equals(Franchise.BetfredSa.GetDescription())) return betfredSaFranchise;
                if (Company.ToLower().Equals(Franchise.BetfredUae.GetDescription())) return betfredUaeFranchise;
                return betfredFranchise;
            }
        }

        public static string CompanyInfo
        {
            get
            {
                if (Company.Equals(Franchise.Betfred.GetDescription())) return betfredCompany;
                if (Company.Equals(Franchise.OddsKing.GetDescription())) return oddskingCompany;
                if (Company.Equals(Franchise.Retail.GetDescription())) return retailCompany;
                if (Company.Equals(Franchise.BetfredSa.GetDescription())) return betfredSaCompany;
                if (Company.Equals(Franchise.BetfredUae.GetDescription())) return betfredUaeCompany;

                return null;
            }
        }

        private static string TopLevelDomain
        {
            get
            {
                if (Team.Contains("load") || Team.Contains("staging") || Team.Contains("prod")) return "ltd";
                return "net";
            }
        }

    }
}
