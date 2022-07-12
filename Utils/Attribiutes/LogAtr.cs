using Microsoft.AspNetCore.Mvc.Filters;
using NLog;

namespace Utils.Attribiutes
{
    public class LogAtr : Attribute, IActionFilter
    {
        private readonly string _message = string.Empty;

        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        public LogAtr()
        {
        }

        public LogAtr(string message)
        {
            _message = message;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            try
            {
                string controllerName = (string)context.RouteData.Values["controller"];
                string actionName = (string)context.RouteData.Values["action"];
                _logger.Info($"ACTION: {actionName} CONTROLLER: {controllerName} MESSAGE: {_message}");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Fail to get ControllerName/Action");
                throw;
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        { }
    }
}