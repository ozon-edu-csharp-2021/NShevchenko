using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(4)]
    public class MerchPackTable : Migration
    {
        public override void Up()
        {
            Execute.Sql(@"
                 CREATE TABLE if not exists merch_packs(
                    id BIGSERIAL PRIMARY KEY,
                    merch_pack_name TEXT NOT NULL,
                    description TEXT NOT NULL,
                    is_repeatable INT NOT NULL);"
            );
        }

        public override void Down()
        {
            Execute.Sql("DROP TABLE if exists merch_packs;");
        }
    }
}