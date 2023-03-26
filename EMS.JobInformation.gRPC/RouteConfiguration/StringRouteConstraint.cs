namespace EMS.JobInformation.gRPC.RouteConfiguration;

public class StringRouteConstraint : IRouteConstraint
{
    public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
    {
        if (string.IsNullOrEmpty(values[routeKey]!.ToString()))
        {
            return false;
        }
        values[routeKey] = values[routeKey]!.ToString();
        return true;
    }
}
