using static EMS.TrafficRecordService.gRPC.Protos.V1.TrafficService;

namespace EMS.TrafficRecordService.gRPC.Services
{
    public class TrafficService : TrafficServiceBase
    {
        private readonly ITrafficRecordService _service;

        public TrafficService(ITrafficRecordService service)
        {
            _service = service;
        }

        public override async Task GetAll(EmptyMessage request, IServerStreamWriter<GetAllReply> responseStream, ServerCallContext context)
        {
            foreach(var item in await _service.GetAllAsync())
            {
                await responseStream.WriteAsync(new GetAllReply()
                {
                    Date = Timestamp.FromDateTime(DateTime.SpecifyKind(item.Key, DateTimeKind.Utc)),
                    Count = item.Value
                });
            }
            await Task.CompletedTask;
        }
        public override async Task GetSpecifyDayTraffic(GetSpecifyDayTrafficRequest request, IServerStreamWriter<GetSpecifyDayReply> responseStream, ServerCallContext context)
        {
            foreach(var item in await _service.GetTrafficByDay(request.Date.ToDateTime()))
            {
                await responseStream.WriteAsync(new GetSpecifyDayReply()
                {
                    Date = Timestamp.FromDateTime(DateTime.SpecifyKind(item.Key, DateTimeKind.Utc)),
                    Count = item.Value
                });
            }
            await Task.CompletedTask;
        }

        public override async Task<EmptyMessage> Create(CreateTrafficRequest request, ServerCallContext context)
        {
            await _service.CreateTraffic(request.Date.ToDateTime());
            return new EmptyMessage();
        }
    }
}
