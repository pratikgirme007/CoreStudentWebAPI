using Microsoft.AspNetCore.Mvc.Filters;

namespace CoreStudentWebAPI.Filters
{
    public class LogFilterAttribute : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("Action method execution started...");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("Action method execution completed...");
        }
    }
}









































