using Prometheus;

namespace API.Metricas // ✅ Evitamos colisión con "Prometheus.Metrics"
{
    public static class LoginMetrics
    {
        public static readonly Counter LoginFallidos = Prometheus.Metrics.CreateCounter(
            "app_logins_fallidos_total",
            "Cantidad total de intentos de login fallidos");

        public static readonly Counter AccesosDenegados = Prometheus.Metrics.CreateCounter(
            "app_accesos_denegados_total",
            "Intentos de acceso a operaciones de admin sin permisos");

        public static readonly Counter EmpleadosCreados = Prometheus.Metrics.CreateCounter(
            "app_empleados_creados_total",
            "Cantidad total de empleados creados exitosamente");

    }
}
