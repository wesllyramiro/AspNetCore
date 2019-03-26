using Web.Api.Core.Domain;
using System;
using System.Collections.Generic;

namespace Web.Api.Core.Interface
{
    public interface ITicketsService
    {
         dynamic GetAll();
         dynamic GetByCondition(string tql);
    }
}