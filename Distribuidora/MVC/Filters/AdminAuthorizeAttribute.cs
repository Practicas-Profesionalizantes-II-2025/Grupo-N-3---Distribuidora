using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using API.Metricas;

namespace MVC.Filters
{
    public class AdminAuthorizeAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var esAdmin = context.HttpContext.Session.GetString("EsAdmin")?.ToLower() == "true";
            if (!esAdmin)
            {
                LoginMetrics.AccesosDenegados.Inc(); // 👈 sumamos 1 intento fallido de admin
                if (context.Controller is Controller controller)
                {
                    controller.TempData["ErrorAdmin"] = "Necesita permisos de administrador";
                }
                context.Result = new RedirectToActionResult("PaginaInicioEmpleados", "Empleados", null);
                return;
            }

            await next();
        }
    }
}
