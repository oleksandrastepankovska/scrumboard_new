using AutoMapper;
using TaskBoard.Data.Entities;
using TaskBoard.ViewModels.Entities;

namespace TaskBoard.Core
{
    public class MapperFactory
    {
        public static IMapper CreateMapper()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Assignment, AssignmentViewModel>()
                    .ForMember(x => x.Assignee, opts => opts.MapFrom(x => $"{x.Assignee.FirstName} {x.Assignee.LastName}"))
                    .ForMember(x => x.Project, opts => opts.MapFrom(x => x.Project.Name))
                    .ForMember(x => x.StatusId, opts => opts.MapFrom(x => x.StatusId));

                cfg.CreateMap<CreateAssignmentViewModel, Assignment>();

                cfg.CreateMap<Status, StatusViewModel>();

                cfg.CreateMap<StatusViewModel, Status>();
                
                cfg.CreateMap<Project, ProjectViewModel>();

                cfg.CreateMap<Person, PersonViewModel>();
            });
            return mapperConfig.CreateMapper();
        }
    }
}
