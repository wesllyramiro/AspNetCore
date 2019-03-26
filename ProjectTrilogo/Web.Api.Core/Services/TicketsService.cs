using System;
using System.Collections.Generic;
using System.Linq;
using Web.Api.Core.Domain;
using Web.Api.Core.Interface;
using System.Text.RegularExpressions;

namespace Web.Api.Core.Services
{
    public class TicketsService : ITicketsService
    {
        readonly ITicketsRepository _Repository;
        public TicketsService(ITicketsRepository Repository)
        {
            _Repository = Repository;
        }

        public dynamic GetAll(){
            return _Repository.GetAll();
        }

        public dynamic GetByCondition(string tql){

            string QueryTreated = TreatmentQuery(tql);
            
            return _Repository.GetByCondition(QueryTreated);
        }

        public string TreatmentQuery(string tql){
            var Query = tql.Replace("\"","'");

            string[] QueryArray = Regex.Split(Query.ToUpper(),@"(\bAND\b)|(\bOR\b)");

            int count = 0; string QueryFull = " ";
            foreach(var Match in QueryArray){
                QueryArray[count] = Match.Trim();
                if(QueryArray[count].Contains("~")){
                    //Retira o ~ por LIKE
                    string QueryTreated = Regex.Replace(QueryArray[count],@"~\s*'","LIKE '%");
                    var match = Regex.Match(QueryTreated,@"LIKE\s+'%\w*");
                    QueryFull += Regex.Replace(QueryTreated,@"LIKE\s+'%\w*",match.Value+"%");
                    count += 1;
                    continue;
                }
                QueryFull += " "+QueryArray[count]+" ";
                count += 1;
            }

            return QueryFull;
        }
    }
}