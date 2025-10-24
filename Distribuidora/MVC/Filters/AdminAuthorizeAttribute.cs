using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace MVC.Filters
{
    public class AdminAuthorizeAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var esAdmin = context.HttpContext.Session.GetString("EsAdmin")?.ToLower() == "true";
            if (!esAdmin)
            {
                // Guardamos el mensaje en TempData para que se muestre tras la redirección
                if (context.Controller is Controller controller)
                {
                    controller.TempData["ErrorAdmin"] = "Necesita permisos de administrador";
                }

                // Redirigimos a la página de inicio de empleados
                context.Result = new RedirectToActionResult("PaginaInicioEmpleados", "Empleados", null);
                return;
            }

            await next();
        }
    }
}
