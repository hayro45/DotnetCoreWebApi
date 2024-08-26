using Entities.LogModel;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ActionFilters
{
    public class LogFilterAttribute : ActionFilterAttribute
    {
        private readonly ILoggerService _logger;

        public LogFilterAttribute(ILoggerService logger)
        {
            _logger = logger;   
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInfo(Log("OnActionExecuting", context.RouteData);
        }

        private string Log(string modelName, RouteData routeData)
        {
            var logDetails = new LogDetails
            {
                ModelName = modelName,
                Controller = routeData.Values["controller"].ToString(),
                Action = routeData.Values["action"].ToString(),
            };

            if (routeData.Values.Count >= 4)
                logDetails.Id = routeData.Values["id"].ToString();

            return logDetails.ToString();
        }
    }
}
