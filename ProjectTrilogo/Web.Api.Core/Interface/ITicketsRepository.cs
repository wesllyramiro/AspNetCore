using System;
using System.Collections.Generic;
using Web.Api.Core.Domain;

namespace Web.Api.Core.Interface
{
    public interface ITicketsRepository
    {
        dynamic GetAll();
        dynamic GetByCondition(string tql);
    }
}