using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(6)]
    public class MerchRequestTable : Migration
    {
        public override void Up()
        {
            Execute.Sql(@"
                   CREATE TABLE if not exists merch_request(
                      id BIGSERIAL PRIMARY KEY,
                      merch_pack_id INT NOT NULL,
                      employee_id INT NOT NULL,
                      email TEXT NOT NULL,
                      request_status INT NOT NULL,
                      request_datetime timestamp NOT NULL,
                      done_datetime timestamp NOT NULL,
                      email_datetime timestamp NOT NULL);"
            );
        }

        public override void Down()
        {
            Execute.Sql("DROP TABLE if exists merch_request;");
        }
    }
}