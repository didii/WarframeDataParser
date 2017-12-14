using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using WarframeDataParser.Business.Selectors;
using WarframeDataParser.Db.Entities;
using WarframeDataParser.Db.Repositories;

namespace WarframeDataParser.Business.Parsers {
    class RewardParser : IRewardParser {
        private readonly IReadWriteRepository<Reward> _rewardRepository;
        private readonly IReadWriteRepository<RewardType> _rewardTypeRepository;

        public Regex CreditRegex { get; } = new Regex(@"^(\dX )?\d+ Credits Cache$");
        public Regex EndoRegex { get; } = new Regex(@"^(\d+ )?Endo$");
        public Regex RelicRegex { get; } = new Regex(@"^(Lith|Meso|Neo|Axi) [A-Z]\d Relic$");
        public Regex ResourceRegex { get; } = new Regex(@"^\d+X [a-zA-Z ]+$");
        public Regex ArcaneRegex { get; } = new Regex(@"^Arcane [a-zA-Z ]+$");

        public Regex PrimePartRegex { get; } = new Regex(@" Prime ");
        //public Regex WarframePartRegex { get; } = new Regex(@"Ash|Atlas|Equinox|Ember|Excalibur|Frost|Loki|Mirage|Volt|Zephyr");

        public RewardParser(IReadWriteRepository<Reward> rewardRepository, IReadWriteRepository<RewardType> rewardTypeRepository) {
            _rewardRepository = rewardRepository;
            _rewardTypeRepository = rewardTypeRepository;
        }

        public bool Parse(IRewardSelection selection) {
            if (string.IsNullOrWhiteSpace(selection.Name))
                return false;

            // If type not yet known
            var reward = new Reward() {Name = selection.Name};
            if (CreditRegex.IsMatch(reward.Name)) {
                reward.Name = "Credits";
                reward.RewardType = GetOrCreateRewardType("Credits");
            } else if (EndoRegex.IsMatch(reward.Name)) {
                reward.Name = "Endo";
                reward.RewardType = GetOrCreateRewardType("Endo");
            } else if (RelicRegex.IsMatch(reward.Name)) {
                reward.Name = new Regex(@"^(Lith|Meso|Neo|Axi) [A-Z]\d").Match(reward.Name).Value;
                reward.RewardType = GetOrCreateRewardType("Relic");
            } else if (ResourceRegex.IsMatch(reward.Name)) {
                reward.Name = new Regex(@"(?<=X )[a-zA-Z ]+$").Match(reward.Name).Value;
                reward.RewardType = GetOrCreateRewardType("Resource");
            } else if (PrimePartRegex.IsMatch(reward.Name)) {
                reward.RewardType = GetOrCreateRewardType("Prime part");
            } else if (ArcaneRegex.IsMatch(reward.Name)) {
                //reward.Name = new Regex(@"(?<=^Arcane )[a-zA-Z ]+$").Match(reward.Name).Value;
                reward.RewardType = GetOrCreateRewardType("Arcane");
            }else {
                // No idea: use hint if available
                if (selection.TypeName != null) {
                    reward.RewardType = GetOrCreateRewardType(selection.TypeName);
                } else {
                    reward.RewardType = GetOrCreateRewardType("Unknown");
                }
            }
            reward.RewardTypeId = reward.RewardType.Id;

            CreateOrUpdate(reward, out var _);
            _rewardRepository.SaveChanges();
            return true;
        }

        public bool CreateOrUpdate(Reward reward, out Reward newReward) {
            var existing = _rewardRepository.Query(q => q.FirstOrDefault(r => r.Name == reward.Name));
            if (existing == null) {
                newReward = _rewardRepository.Add(reward);
                return true;
            }
            existing.Name = reward.Name;
            if (existing.RewardType != null && existing.RewardType.Name == "Unknown") {
                existing.RewardTypeId = reward.RewardTypeId;
                existing.RewardType = reward.RewardType;
            }
            newReward = _rewardRepository.Update(existing);
            return false;
        }

        public RewardType GetOrCreateRewardType(string typeName) {
            var result = _rewardTypeRepository.Query(q => q.FirstOrDefault(t => t.Name == typeName));
            if (result == null) {
                result = _rewardTypeRepository.Add(new RewardType() {Name = typeName});
                _rewardTypeRepository.SaveChanges();
            }
            return result;
        }
    }

    class RewardContext {
        public ICollection<RewardTypeGuess> Guesses { get; } = new List<RewardTypeGuess>();
    }

    class RewardTypeGuess {
        public string RewardTypeName { get; set; }
        public float Probability { get; set; }

        public RewardTypeGuess(string rewardTypeName, float probablility) {
            if (probablility < 0 || probablility > 1)
                throw new ArgumentException("Value in [0,1] expected", nameof(probablility));
            RewardTypeName = rewardTypeName;
            Probability = probablility;
        }
    }
}