using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace WarframeDataParser.Business.Selectors {
    class MissionSelector : ISelector<IMissionSelection> {
        public string XPath { get; } = @"html/body/h3[@id='missionRewards']/following-sibling::table[1]/tbody/tr[1]/th" +
                                       @"|html/body/h3[@id='missionRewards']/following-sibling::table[1]/tbody/tr[@class='blank-row']/following-sibling::tr[1]/th";

        public Regex PlanetRegex { get; } = new Regex(@"(?<=^Event: |^)[a-zA-Zö ]+(?=\/.+)");
        public Regex NameRegex { get; } = new Regex(@"(?<=/)[a-zA-Z ]+(?= \(.+\))");
        public Regex TypeRegex { get; } = new Regex(@"(?<=\()[a-zA-Z ]+(?=\))");

        /// <inheritdoc />
        public IEnumerable<IMissionSelection> Select(HtmlDocument document) {
            var nodes = document.DocumentNode.SelectNodes(XPath).Select(n => n.InnerText);
            var result = nodes.Select(t => new MissionSelection() {
                Name = NameRegex.Match(t).Value,
                MissionType = TypeRegex.Match(t).Value,
                Planet = PlanetRegex.Match(t).Value
            });
            return result;
        }
    }
}