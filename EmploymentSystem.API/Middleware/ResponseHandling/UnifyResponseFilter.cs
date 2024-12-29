using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace EmploymentSystem.API.Middleware.ResponseHandling
{
    public class UnifyResponseFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result.GetType() == typeof(Microsoft.AspNetCore.Mvc.FileStreamResult))

            {
                return;
            }
            if (((IStatusCodeActionResult)context.Result) == null)
                return;
            var ActionResultStatusCode = ((IStatusCodeActionResult)context.Result).StatusCode;
            var SuccessCodes = new List<int?> { 200, 201 };

            if (SuccessCodes.Contains(ActionResultStatusCode))
            {
                var returnObj = ((ObjectResult)context.Result);
                context.Result = new ResponseActionResult(new ResultResponse() { Content = returnObj.Value, IsSuccess = true, StatusCode = returnObj.StatusCode });
            }
            else
            {
                var returnObj = ((ObjectResult)context.Result);
                context.Result = new ResponseActionResult(new ResultResponse() { Content = null, IsSuccess = false, StatusCode = returnObj.StatusCode, ResponseMessage = returnObj.Value.ToString() });
            }


        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }


    public class ResultResponse
    {
        public bool IsSuccess { get; set; }
        public int? StatusCode { get; set; }
        public string ResponseMessage { get; set; }
        public Object Content { get; set; }

    }
    public class ResponseActionResult : IActionResult
    {
        private readonly ResultResponse _responseMessage;
        public ResponseActionResult()
        {

        }
        public ResponseActionResult(ResultResponse responseMessage)
        {
            _responseMessage = responseMessage; // could add throw if null
        }
        public async Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new ObjectResult(_responseMessage);

            await objectResult.ExecuteResultAsync(context);
        }

    }

}

   



