using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(5)]
    public class MerchPackItemTable : Migration
    {
        public override void Up()
        {
            Execute.Sql(@"
                  CREATE TABLE if not exists merch_pack_items(
                    id BIGSERIAL PRIMARY KEY,
                    merch_pack_id INT NOT NULL,
                    item_type_id INT NOT NULL,
                    quantity INT NOT NULL);"
            );
        }

        public override void Down()
        {
            Execute.Sql("DROP TABLE if exists merch_pack_items;");
        }
    }
}