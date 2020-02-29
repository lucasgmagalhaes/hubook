using FluentMigrator;

namespace Dort.Migrations
{
    [Migration(202002290001)]
    public class AddUserBookAndUserLevelTable_0001 : Migration
    {
        public override void Up()
        {
            Execute.Sql(@"
            CREATE TABLE IF NOT EXISTS user_app (
              id SERIAL PRIMARY KEY NOT NULL,
              name VARCHAR(120) NOT NULL,
              email VARCHAR(120) NOT NULL,
              is_email_validated BOOLEAN NOT NULL,
              is_active BOOLEAN NOT NULL,
              password VARCHAR(30) NOT NULL,
              profile_img_url VARCHAR(200) NOT NULL
            );

            CREATE TABLE IF NOT EXISTS book(
              id SERIAL PRIMARY KEY NOT NULL,
              google_book_id VARCHAR(120) NOT NULL,
              user_id SERIAL NOT NULL,
              status INT NOT NULL,
              FOREIGN KEY(user_id) REFERENCES user_app(id)
            );

            CREATE TABLE IF NOT EXISTS user_level(
              id SERIAL PRIMARY KEY NOT NULL,
              user_id SERIAL NOT NULL,
              level INT NOT NULL,
              exp SERIAL NOT NULL,
              level_max_exp SERIAL NOT NULL,
              FOREIGN KEY (user_id) REFERENCES user_app(id)
            );
         ");
        }

        public override void Down()
        {
            Delete.Table("'user'");
            Delete.Table("book");
            Delete.Table("user_level");
        }
    }
}
