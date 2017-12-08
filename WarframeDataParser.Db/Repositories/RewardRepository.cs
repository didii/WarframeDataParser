using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarframeDataParser.Db.Entities;

namespace WarframeDataParser.Db.Repositories {
    interface IRewardRepository : IReadWriteRepository<Reward> {

    }
    class RewardRepository : ReadWriteRepository<Reward> {
        /// <inheritdoc />
        public RewardRepository(IReadRepository<Reward> readRepo, IWriteRepository<Reward> writeRepo) : base(readRepo, writeRepo) { }
    }
}
