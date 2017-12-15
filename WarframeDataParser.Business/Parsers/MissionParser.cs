using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarframeDataParser.Business.Selectors;
using WarframeDataParser.Db.Entities;
using WarframeDataParser.Db.Repositories;

namespace WarframeDataParser.Business.Parsers {
    public class MissionParser : IParser<IMissionSelection> {
        private readonly IReadWriteRepository<Mission> _repo;
        private readonly IReadWriteRepository<DropSourceType> _dropSourceType;
        private readonly IReadWriteRepository<MissionType> _missionTypeRepo;
        private readonly IReadWriteRepository<Planet> _planetRepo;

        public MissionParser(IReadWriteRepository<Mission> repo, IReadWriteRepository<DropSourceType> dropSourceType, IReadWriteRepository<MissionType> missionTypeRepo, IReadWriteRepository<Planet> planetRepo) {
            _repo = repo;
            _dropSourceType = dropSourceType;
            _missionTypeRepo = missionTypeRepo;
            _planetRepo = planetRepo;
        }

        /// <inheritdoc />
        public EParseResult Parse(IMissionSelection selection) {
            bool toAdd;
            var existing = _repo.Query(q => q.FirstOrDefault(m => m.Name == selection.Name));
            toAdd = existing == null;
            if (existing == null)
                existing = new Mission() {Name = selection.Name};

            var existingDropSourceType = _dropSourceType.Query(q => q.FirstOrDefault(t => t.Name == "Mission"));
            if (existingDropSourceType == null) {
                existingDropSourceType = new DropSourceType() {Name = "Mission"};
                existingDropSourceType = _dropSourceType.Add(existingDropSourceType);
            } else {
                existingDropSourceType = _dropSourceType.Update(existingDropSourceType);
            }
            existing.DropSourceTypeId = existingDropSourceType.Id;
            existing.DropSourceType = existingDropSourceType;

            var existingType = _missionTypeRepo.Query(q => q.FirstOrDefault(t => t.Name == selection.MissionType));
            if (existingType == null) {
                existingType = new MissionType() {Name = selection.MissionType};
                existingType = _missionTypeRepo.Add(existingType);
            } else {
                existingType = _missionTypeRepo.Update(existingType);
            }
            existing.MissionTypeId = existingType.Id;
            existing.MissionType = existingType;

            var existingPlanet = _planetRepo.Query(q => q.FirstOrDefault(p => p.Name == selection.Planet));
            if (existingPlanet == null) {
                existingPlanet = new Planet() {Name = selection.Planet};
                existingPlanet = _planetRepo.Add(existingPlanet);
            } else {
                existingPlanet = _planetRepo.Update(existingPlanet);
            }
            existing.PlanetId = existingPlanet.Id;
            existing.Planet = existingPlanet;

            if (toAdd) {
                _repo.Add(existing);
                _repo.SaveChanges();
                return EParseResult.Inserted;
            } else {
                _repo.Update(existing);
                _repo.SaveChanges();
                return EParseResult.Updated;
            }
        }
    }
}
