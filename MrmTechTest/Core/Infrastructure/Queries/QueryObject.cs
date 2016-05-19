using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MrmTechTest.Core.Infrastructure.Queries
{
    public abstract class QueryObject<TResult>
    {
        public abstract TResult Execute(DbContext context);
    }
}