using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(3)]
    public class ItemTypeTable : Migration
    {
        public override void Up()
        {
            Execute.Sql(@"
                 CREATE TABLE if not exists item_types(
                    id BIGSERIAL PRIMARY KEY,
                    item_type_name TEXT NOT NULL,
                    description TEXT NOT NULL);"
            );
        }

        public override void Down()
        {
            Execute.Sql("DROP TABLE if exists item_types;");
        }
    }
}