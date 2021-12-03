using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(2)]
    public class ClothingSizeTable : Migration
    {
        public override void Up()
        {
            Execute.Sql(@"
                 CREATE TABLE if not exists clothing_sizes(
                    id BIGSERIAL PRIMARY KEY,
                    size_name TEXT NOT NULL,
                    item_type_id INT NOT NULL);"
            );
        }

        public override void Down()
        {
            Execute.Sql("DROP TABLE if exists clothing_sizes;");
        }
    }
}