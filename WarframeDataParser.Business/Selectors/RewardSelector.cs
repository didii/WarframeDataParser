using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace WarframeDataParser.Business.Selectors {
    class RewardSelector : IRewardSelector {
        public static string XPath { get; } =
            @"html/body/h3[@id='missionRewards' or @id='relicRewards' or @id='keyRewards' or @id='sortieRewards']/following-sibling::table[1]/tbody/tr/td[1]" +
            @"|html/body/h3[@id='cetusRewards' or @id='enemyModTables' or @id='enemyBlueprintTables' or @id='miscItems']/following-sibling::table[1]/tbody/tr/td[2]" +
            @"|html/body/h3[@id='modLocations' or @id='blueprintLocations']/following-sibling::table[1]/tbody/tr/th[@colspan='3']";

        public IEnumerable<string> Select(HtmlDocument document) {
            var missionRewards = document.DocumentNode.SelectNodes(XPath);
            return missionRewards?.Select(n => n.InnerText);
        }
    }
}