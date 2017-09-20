using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightManagement.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FlightManagement.Web.Infrastructure
{
    public class UnitOfWorkFilter : IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            var goNoGoContext = context.HttpContext.RequestServices.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
            if (goNoGoContext == null) return;
            if (context.HttpContext.Request.Method == "POST" || context.HttpContext.Request.Method == "PUT" ||
                context.HttpContext.Request.Method == "DELETE")
            {
                if (context.Exception == null)
                {
                    if (context.HttpContext.Response.StatusCode < 400)
                    {
                        bool hasChanges = goNoGoContext.HasChanges();
                        if (hasChanges)
                        {
                            goNoGoContext.SaveChangesAsync();
                        }
                    }
                }
                else
                {
                    // can add some logging here
                }
            }

        }
    }
}
