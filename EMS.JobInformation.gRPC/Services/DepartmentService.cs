using static EMS.JobInformation.gRPC.Protos.V1.DepartmentService;

namespace EMS.JobInformation.gRPC.Services
{
    public class DepartmentService : DepartmentServiceBase
    {
        private readonly IDepartmentService _service;

        public DepartmentService(IDepartmentService service)
        {
            _service = service;
        }

        public override async Task GetAll(EmptyMessage request, IServerStreamWriter<DepartmentReply> responseStream, ServerCallContext context)
        {
            foreach(var item in await _service.GetAllAsync())
            {
                await responseStream.WriteAsync(item.ToReply());
            }
            await Task.CompletedTask;
        }

        public override async Task<DepartmentReply> Get(DepartmentIdRequest request, ServerCallContext context) =>
            (await _service.GetAsync(request.Id)).ToReply();


        public override async Task Create(IAsyncStreamReader<CreateDepartmentRequest> requestStream, IServerStreamWriter<CreateDepartmentReply> responseStream, ServerCallContext context)
        {
            await foreach(var item in requestStream.ReadAllAsync())
            {
                int departmentId = await _service.CreateAsync(new CreateDepartmentModel()
                {
                    Name = item.Name,
                    Description = item.Description,
                    ManagerId = item.ManagerId
                });

                await responseStream.WriteAsync(new CreateDepartmentReply()
                {
                    Id = departmentId,
                    Name = item.Name
                });
            }

            await Task.CompletedTask;
        }


        public override async Task<EmptyMessage> Update(UpdateDepartmentRequest request, ServerCallContext context)
        {
            await _service.UpdateAsync(new UpdateDepartmentModel()
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                ManagerId = request.ManagerId
            });

            return new EmptyMessage();
        }

        public override async Task<EmptyMessage> Delete(DepartmentIdRequest request, ServerCallContext context)
        {
            await _service.DeleteAsync(request.Id);
            return new EmptyMessage();
        }
    }
}
