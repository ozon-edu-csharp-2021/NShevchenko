using FluentMigrator;

namespace OzonEdu.StockApi.Migrator.Migrations
{
    [Migration(7, TransactionBehavior.None)]
    public class RequestEmployeeIdx: ForwardOnlyMigration 
    {
        public override void Up()
        {
            Execute.Sql(@"
                CREATE INDEX CONCURRENTLY request_employee_id_idx ON merch_request (employee_id)"
            );
        }
    }
}