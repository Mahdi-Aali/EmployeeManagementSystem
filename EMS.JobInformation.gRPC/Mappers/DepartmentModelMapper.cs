using Google.Protobuf.WellKnownTypes;

namespace EMS.JobInformation.gRPC.Mappers
{
    public static class DepartmentModelMapper
    {
        public static DepartmentReply ToReply(this DepartmentModel model)
        {
            return new DepartmentReply()
            { 
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                ManagerId = model.ManagerId,
                CreateDate = Timestamp.FromDateTime(DateTime.SpecifyKind(model.CreateDate, DateTimeKind.Utc)),
                UpdateDate = Timestamp.FromDateTime(DateTime.SpecifyKind(model.UpdateDate ?? DateTime.MinValue, DateTimeKind.Utc))
            };
        }

    }
}
