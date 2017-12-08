using System.Data.Entity;
using WarframeDataParser.Db.EntityTypes;

namespace WarframeDataParser.Db.Contexts {
    public class UserContextInitializer : CreateDatabaseIfNotExists<UserContext2> {
        /// <inheritdoc />
        protected override void Seed(UserContext2 context) {
            base.Seed(context);
            var adminRole = new Role() {Name = "admin"};
            var userRole = new Role() {Name = "user"};
            var admin = new User() {
                Name = "admin",
                Role = adminRole,
                PasswordHash = new byte[] {
                    87, 117, 126, 120, 201, 14, 106, 13, 118, 223, 31, 134, 193, 37, 87, 79, 255, 94, 163, 119, 83, 255,
                    177, 186, 42, 17, 161, 32, 33, 125, 170, 81
                },
                PasswordSalt = new byte[] {103, 97, 3, 248, 244, 114, 155, 22, 192, 254, 67, 234, 11, 160, 75, 5}
            };
            var user = new User() {
                Name = "user",
                Role = userRole,
                PasswordHash =
                    new byte[] {
                        168, 248, 4, 178, 228, 140, 87, 213, 131, 169, 40, 146, 55, 138, 251, 72, 124, 162, 234, 163,
                        89, 125, 123, 138, 56, 126, 4, 209, 124, 223, 151, 229
                    },
                PasswordSalt = new byte[] {152, 231, 115, 37, 68, 173, 92, 106, 35, 54, 82, 232, 72, 166, 84, 35}
            };
            context.Users.Add(admin);
            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}