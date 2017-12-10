using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using WarframeDataParser.Db.Entities;
using WarframeDataParser.Db.Repositories;

namespace WarframeDataParser.Business.Parsers {
    class RewardParser {
        private readonly IReadWriteRepository<Reward> _repo;
        private RewardParserInfo Info { get; } = new RewardParserInfo(new[] {
            new RewardParserInfoItem(new Regex(@"^(Lith|Meso|Neo|Axi) [A-Z]\d Relic$"), "Relic", new Regex(@"^(Lith|Meso|Neo|Axi)"), new Regex(@"[A-Z]\d(?= Relic$)")), 
            new RewardParserInfoItem(new Regex(@"^(\dX )?\d+ Credits Cache$"), "Credits", new Regex(@"^\d+")),
        });
        public Regex EndoRegex { get; } = new Regex(@"^(\d+ )?Endo$");
        public Regex RelicRegex { get; } = new Regex(@"^(Lith|Meso|Neo|Axi) [A-Z]\d Relic$");
        public Regex ResourceRegex { get; } = new Regex(@"^\d+X \D+$");

        public RewardParser(IReadWriteRepository<Reward> repo) {
            _repo = repo;
        }

        public Reward Parse(string name, RewardParserContext context) {
            
        }

        private string GetBetween(string value, char left, char right) {
            var leftIdx = value.IndexOf(left);
            var rightIdx = value.IndexOf(right, leftIdx + 1);
            return value.Substring(leftIdx, rightIdx - leftIdx);
        }
    }

    class RewardParserInfo {
        private readonly List<RewardParserInfoItem> _items;

        public IEnumerable<RewardParserInfoItem> Items => _items;

        public RewardParserInfo(IEnumerable<RewardParserInfoItem> items) {
            _items = items as List<RewardParserInfoItem> ?? items.ToList();
        }

        public RewardParserInfoResult Parse(string text) {
            foreach (var item in _items) {
                var result = item.Parse(text);
                if (result != null)
                    return result;
            }
            return null;
        }
    }

    class RewardParserInfoItem {
        public string Type { get; set; }
        public Regex Regex { get; }
        public Filter NameFilter { get; }
        public Filter Part1Filter { get; }
        public Filter Part2Filter { get; }

        public RewardParserInfoItem(Regex regex, Filter nameFilter, Filter part1Filter = null, Filter part2Filter = null) {
            Regex = regex;
            NameFilter = nameFilter;
            Part1Filter = part1Filter;
            Part2Filter = part2Filter;
        }

        public RewardParserInfoResult Parse(string text) {
            if (!Regex.IsMatch(text))
                return null;
            var result = new RewardParserInfoResult() {
                Type =  Type,
                Name = NameFilter.Select(text),
                Part1 = Part1Filter?.Select(text),
                Part2 = Part2Filter?.Select(text)
            };
            return result;
        }
    }

    class RewardParserInfoResult {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Part1 { get; set; }
        public string Part2 { get; set; }
    }

    class Filter {
        public Regex Regex { get; }
        public string Name { get; }

        public Filter(Regex regex) {
            Regex = regex;
        }

        public Filter(string name) {
            Name = name;
        }

        public string Select(string text) {
            return Name ?? Regex?.Match(text).Value;
        }

        public static implicit operator Filter(string name) {
            return new Filter(name);
        }

        public static implicit operator Filter(Regex regex) {
            return new Filter(regex);
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