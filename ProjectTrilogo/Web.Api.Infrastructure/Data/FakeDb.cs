
using System.Data.SQLite;
using System;
using System.Text;
using Dapper;
using System.Collections;

namespace Web.Api.Infrastructure.Data
{
    public class FakeDb 
    {
        public FakeDb()
        {
            Data.FakeDb.DropTable();
            Data.FakeDb.CreateTables();
            Data.FakeDb.InserValue();
        }
        public static void ExecuteCommand(string commandText)
        {
            using(var con = SimpleDbConnection())
            {
                con.Open();
                con.Execute(commandText);
            }
        }
        public static SQLiteConnection SimpleDbConnection()
        {
            return new SQLiteConnection("Data Source=sharedmemdb; Mode=Memory; Cache=Shared");
        }
        public static void CreateTables()
        {
            var sql = new StringBuilder()
                .Append(DbResource.TICKETS_CREATE_SCRIPT)
                .ToString();
            ExecuteCommand(sql);
        }

        public static void DropTable()
        {
            var sql = new StringBuilder()
                .Append(DbResource.TICKETS_DROP_SCRIPT)
                .ToString();
            ExecuteCommand(sql);
        }

        public static void InserValue()
        {
            var tickets = DbResource.GetDataSet();
            foreach(var item in tickets)
            {
                using(var con = SimpleDbConnection())
                {
                    con.Open();
                    con.Execute(DbResource.TICKETS_INSERT_SCRIPT,
                        new {   id = item.id,
                                description = item.description,
                                author = item.author,
                                creationDate = item.creationDate,
                                updated = item.creationDate
                            });
                }
            }
        }

    }
}