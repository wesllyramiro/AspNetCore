using System;
using System.Collections.Generic;
using System.Linq;
using Web.Api.Core.Interface;
using Web.Api.Core.Domain;
using Dapper;
using System.IO;
using Web.Api.Infrastructure.Scripts;
using System.Data;

namespace Web.Api.Infrastructure.Repositories
{
    public class TicketsRepository : Data.FakeDb,ITicketsRepository
    {
         public TicketsRepository()
        {
            
        }

        public dynamic GetByCondition(string Query)
        {
            using (var cnn = SimpleDbConnection())
            {
                cnn.Open();
                var Parameters = new DynamicParameters();
                Parameters.Add("@Query",Query,DbType.String,ParameterDirection.Input);
                return cnn.Query(TicketsScripts.getByCondition(Query));
            }
        }

        public dynamic GetAll()
        {
            using (var cnn = SimpleDbConnection())
            {
                cnn.Open();
                return cnn.Query(TicketsScripts.getAll());
            }
        } 
    }
}