using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace WarframeDataParser.Business.Selectors {
    class RewardSelector : IRewardSelector {
        public static string AllXPath { get; } =
            @"html/body/h3[@id='missionRewards' or @id='relicRewards' or @id='keyRewards' or @id='sortieRewards']/following-sibling::table[1]/tbody/tr/td[1]" +
            @"|html/body/h3[@id='cetusRewards' or @id='enemyBlueprintTables' or @id='miscItems']/following-sibling::table[1]/tbody/tr/td[2]" +
            @"|html/body/h3[@id='blueprintLocations']/following-sibling::table[1]/tbody/tr/th[@colspan='3']";

        public static string ModXPath { get; } = @"html/body/h3[@id='enemyModTables']/following-sibling::table[1]/tbody/tr/td[2]" +
                                                 @"|html/body/h3[@id='modLocations']/following-sibling::table[1]/tbody/tr/th[@colspan='3']";

        public IEnumerable<IRewardSelection> Select(HtmlDocument document) {
            var result = ToRewardSelection(document.DocumentNode.SelectNodes(ModXPath), "Mod");
            result = result.Union(ToRewardSelection(document.DocumentNode.SelectNodes(AllXPath), "Unknown"));
            return result;
        }

        private static IEnumerable<IRewardSelection> ToRewardSelection(IEnumerable<HtmlNode> nodes, string typeName) {
            return nodes.Select(n => n.InnerText)
                        .Where(t => !string.IsNullOrWhiteSpace(t))
                        .Distinct()
                        .Select(t => new RewardSelection() {Name = t, TypeName = typeName});
        }
    }
}