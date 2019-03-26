namespace Web.Api.Infrastructure.Scripts
{
    public static class TicketsScripts
    {
        public static string getAll(){
            return @"
                SELECT * FROM TICKETS
            ";
        }

        public static string getByCondition(string Query){
            var sql =  @"
                SELECT * FROM TICKETS
                WHERE
                ";

                sql += " " + Query;
            return sql.ToString();
        }
        
    }
}