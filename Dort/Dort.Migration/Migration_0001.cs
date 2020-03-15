using FluentMigrator;

namespace Dort.Migrations
{
    [Migration(202002290001)]
    public class migration_0001 : Migration
    {
        public override void Up()
        {
            Execute.Sql(@"
                CREATE TABLE IF NOT EXISTS userapp (
                Id SERIAL PRIMARY KEY NOT NULL,
                Name VARCHAR(120) NOT NULL,
                Email VARCHAR(120) NOT NULL,
                IsEmailValidated BOOLEAN NOT NULL,
                IsActive BOOLEAN NOT NULL,
                Password VARCHAR(30) NOT NULL,
                Level INT NOT NULL,
                Exp SERIAL NOT NULL,
                LevelMaxExp SERIAL NOT NULL,
                ProfileImgUrl VARCHAR(200) NOT
                );

                CREATE TABLE IF NOT EXISTS UserBook (
                Id SERIAL PRIMARY KEY NOT NULL,
                GoogleBookId VARCHAR(120) NOT NULL,
                UserId SERIAL NOT NULL,
                Status INT NOT NULL,
                FOREIGN KEY (UserId) REFERENCES UserApp (Id)
                );
         ");
        }

        public override void Down()
        {
            Delete.Table("UserApp");
            Delete.Table("UserBook");
        }
    }
}
