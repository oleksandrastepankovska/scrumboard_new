using AutoMapper;
using TaskBoard.Data.Entities;
using TaskBoard.ViewModels.Assignments;

namespace TaskBoard.Core
{
    public class MapperFactory
    {
        public static IMapper CreateMapper()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Status, StatusViewModel>();
                cfg.CreateMap<StatusViewModel, Status>();

                cfg.CreateMap<CreateAssignmentViewModel, Assignment>();
            });
            return mapperConfig.CreateMapper();
        }
    }
}
