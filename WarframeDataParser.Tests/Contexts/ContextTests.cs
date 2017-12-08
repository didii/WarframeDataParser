using System;
using WarframeDataParser.Db.Contexts;
using WarframeDataParser.Db.Entities;
using Moq;
using NUnit.Framework;

namespace WarframeDataParser.Tests.Contexts {
    public class WarframeDataParserContextTests {
        private Context _context;

        [OneTimeSetUp]
        public void OneTimeSetUp() {
            _context = new Context("local");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown() {
            _context.Database.Delete();
            _context.Dispose();
        }

        [Test]
        [TestCase(typeof(Reward))]
        public void RecipeContext_Initialize_TableExists(Type entityType) {
            //Act
            _context.Database.Initialize(true);

            //Assert
            Assert.That(() => _context.Set(entityType).Local.Count, Throws.Nothing);
        }
    }
}
