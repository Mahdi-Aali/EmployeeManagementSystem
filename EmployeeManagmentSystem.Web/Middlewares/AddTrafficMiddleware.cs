namespace EmployeeManagementSystem.Web.Middlewares
{
    public class AddTrafficMiddleware
    {
        private RequestDelegate _delegate;
        public AddTrafficMiddleware(RequestDelegate d)
        {
            _delegate = d;
        }

        public async Task Invoke(HttpContext context, ITrafficRecordService service)
        {
            await service.CreateTrafficAsync(DateTime.Now);

            await _delegate(context);
        }
    }
}
