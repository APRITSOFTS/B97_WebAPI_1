using Microsoft.AspNetCore.Mvc.Filters;

namespace B97_WebAPI.Models.Filters
{
    public class B97ActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("Action is Executed");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("Action is Executing");
        }
    }
}
