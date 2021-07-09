using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace OMC.Libs
{
    public static class ResponseExtention
    {
        public static IActionResult ToResult(this Controller controller)
        {
            IRequestContext service = controller.HttpContext.RequestServices.GetService<IRequestContext>();
            if (service.IsError)
            {
                string message = service.Errors.Select(m => m.Value).Aggregate((a, b) => a + ", " + b);
                dynamic code = service.Errors.Select(m => m.Key).Aggregate((a, b) => a + ", " + b);
                return controller.Json(ApiResponse.Create(true, code, message));
            }
            return controller.Json(ApiResponse.Create());
        }

        public static IActionResult ToResult<T>(this Controller controller, T data = null) where T : class
        {
            IRequestContext service = controller.HttpContext.RequestServices.GetService<IRequestContext>();
            if (service.IsError)
            {
                string message = service.Errors.Select(m => m.Value).Aggregate((a, b) => a + ", " + b);
                dynamic code = service.Errors.Select(m => m.Key).Aggregate((a, b) => a + ", " + b);
                return controller.Json(ApiResponse.Create(true, code, message));
            }
            return controller.Json(ApiResponse.Create<T>(data));
        }

        public static IActionResult ToErrorResult(
          this Controller controller, dynamic code,
          string message = "unknown") => controller.Json((object)ApiResponse.Create(true, code, message));

        public static OkObjectResult ToResult(this ControllerBase controller)
        {
            IRequestContext service = controller.HttpContext.RequestServices.GetService<IRequestContext>();
            if (service.IsError)
            {
                string message = service.Errors.Select(m => m.Value).Aggregate((a, b) => a + ", " + b);
                dynamic code = service.Errors.Select(m => m.Key).Aggregate((a, b) => a + ", " + b);
                return controller.Ok(ApiResponse.Create(true, code, message));
            }
            return controller.Ok(ApiResponse.Create());
        }

        public static OkObjectResult ToResult<T>(this ControllerBase controller, T data = null) where T : class
        {
            IRequestContext service = controller.HttpContext.RequestServices.GetService<IRequestContext>();
            if (service.IsError)
            {
                string message = service.Errors.Select(m => m.Value).Aggregate((a, b) => a + ", " + b);
                dynamic code = service.Errors.Select(m => m.Key).Aggregate((a, b) => a + ", " + b);
                return controller.Ok(ApiResponse.Create(true, code, message));
            }
            return controller.Ok(ApiResponse.Create<T>(data));
        }

        public static OkObjectResult ToErrorResult(
          this ControllerBase controller, dynamic code,
          string message = "unknown") => controller.Ok(ApiResponse.Create(true, code, message));
    }
}
