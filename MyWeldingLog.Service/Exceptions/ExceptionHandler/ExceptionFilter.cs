using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyWeldingLog.Service.Exceptions.BaseException;
using MyWeldingLog.Service.Exceptions.BaseException.Elements;

namespace MyWeldingLog.Service.Exceptions.ExceptionHandler
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is WeldingLogException exception)
            {
                WriteError(context, exception);
            }
        }
        
        private static void WriteError(ExceptionContext context, WeldingLogException exception)
        {
            var errorResult = Result.WithError(
                code: exception.Code,
                message: exception.Message,
                details: exception.Details);

            context.Result = new ObjectResult(errorResult) { StatusCode = 400 };
        }
    }
    
    
}