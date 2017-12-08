using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarframeDataParser.Db.Entities;
using WarframeDataParser.Db.Repositories;

namespace WarframeDataParser.Business.Parsers {
    class RewardParser {
        private readonly IReadWriteRepository<Reward> _repo;

        public RewardParser(IReadWriteRepository<Reward> repo) {
            _repo = repo;
        }

        public Reward Parse(/*HtmlNode rowNode,*/ RewardParserContext context) {
            //if (rowNode.Name != "tr" || rowNode.ChildNodes.Count >= 1 || rowNode.ChildNodes.First().Name != "td")
            //    throw new ArgumentException("Node must be of type 'tr' and must have a minimum of 1 childs of type 'td'", nameof(rowNode));
            //string name = rowNode.ChildNodes.First().InnerText.Trim();
            //var existing = _repo.Query(q => q.FirstOrDefault(r => r.Name == name));
            //if (existing == null) {
            //    var create = new Reward() {Name = name};
            //    existing = _repo.Add(create);
            //}

            throw new NotImplementedException();
        }

        private string GetBetween(string value, char left, char right) {
            var leftIdx = value.IndexOf(left);
            var rightIdx = value.IndexOf(right, leftIdx + 1);
            return value.Substring(leftIdx, rightIdx - leftIdx);
        }
    }

    class RewardParserContext {
        public RewardParserContext(string rewardTypeName, bool isCertain) {
            RewardTypeName = rewardTypeName;
            RewardTypeNameIsCertain = isCertain;
        }

        public string RewardTypeName { get; }
        public bool RewardTypeNameIsCertain { get; }
    }
}