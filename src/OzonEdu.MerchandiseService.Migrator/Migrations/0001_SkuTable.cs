using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(1)]
    public class SkuTable: Migration
    {
        public override void Up()
        {
            Execute.Sql(@"
                CREATE TABLE if not exists skus(
                    id BIGSERIAL PRIMARY KEY,
                    item_type_id INT NOT NULL,
                    clothing_size_id INT);"
            );
        }

        public override void Down()
        {
            Execute.Sql("DROP TABLE if exists skus;");
        }
    }
}