using System.IO;
using System;
using System.Collections;
using System.Collections.Generic;
using Web.Api.Core.Domain;
using Newtonsoft.Json;

namespace Web.Api.Infrastructure.Data
{
    public class DbResource
    {
        
         public static readonly string TICKETS_CREATE_SCRIPT =
            @"CREATE TABLE IF NOT EXISTS [TICKETS]
                (
                    [id]              INTEGER PRIMARY KEY AUTOINCREMENT,
                    [description]     VARCHAR(100) NOT NULL,
                    [author]          VARCHAR(100) NOT NULL,
                    [creationDate]    DATETIME NOT NULL,
                    [updated]         DATETIME NOT NULL
                );
            ";
        public static readonly string TICKETS_DROP_SCRIPT =
                "DROP TABLE IF EXISTS [TICKETS]";

        public static readonly string TICKETS_INSERT_SCRIPT =
                @"
                INSERT INTO TICKETS
                (
                    id,
                    description,
                    author,
                    creationDate,
                    updated
                )
                VALUES
                ( 
                    @id,
                    @description,
                    @author,
                    @creationDate,
                    @updated
                )";

        public static List<Tickets> GetDataSet(){
            var json = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory+@"DataSet.json");

            var Tickets = JsonConvert.DeserializeObject<List<Tickets>>(json);

            return Tickets;
        }
    }
}