using Microsoft.EntityFrameworkCore;
using EmploymentSystem.Domain.Entities;

namespace EmploymentSystem.Infrastructure.Seed
{
    public static class LookupSeeder
    {
        public static void SeedLookUps(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
                new City { Id = Guid.Parse("c14d826b-ce78-4c02-a45e-ade4ffa89d64"), Code = "01",ArabicDescription="شرم الشيخ", EnglishDescription = "Sharm" },
                new City { Id = Guid.Parse("45b79a7b-f9a6-4263-b421-ac34a588114e"), Code = "02", ArabicDescription = "الغردقة", EnglishDescription = "Hurghada" },
                new City { Id = Guid.Parse("6af46bf4-84d4-42d2-8c18-ee61e6ee884c"), Code = "03", ArabicDescription = "دهب", EnglishDescription = "Dahab" },
                new City { Id = Guid.Parse("76b6ea88-9ec6-403c-a29c-166ae4e4be3b"), Code = "04", ArabicDescription = "واحة الفيوم", EnglishDescription = "Fayoum Oasis" },
                new City { Id = Guid.Parse("0e72dfe1-3273-49b0-9115-a6a37ed864cb"), Code = "05", ArabicDescription = "رأس البر", EnglishDescription = "Ras El Bar" }
            );

            //migrationBuilder.Sql("ALTER TABLE `LegalTrackingDB`.`users` CHANGE COLUMN `IdNo` `IdNo` INT NOT NULL AUTO_INCREMENT ,ADD UNIQUE INDEX `IdNo_UNIQUE` (`IdNo` ASC) VISIBLE;");
            //migrationBuilder.Sql("ALTER TABLE `LegalTrackingDB`.`cases` CHANGE COLUMN `IdNo` `IdNo` INT NOT NULL AUTO_INCREMENT ,ADD UNIQUE INDEX `IdNo_UNIQUE` (`IdNo` ASC) VISIBLE;");
        }
    }
}
