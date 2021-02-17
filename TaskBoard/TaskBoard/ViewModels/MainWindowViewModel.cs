using System.Collections.Generic;
using TaskBoard.Data;
using TaskBoard.Data.Entities;
using TaskBoard.Infrastructure.Concrete;

namespace TaskBoard.ViewModels
{
    public class MainWindowViewModel
    {
        public IEnumerable<Status> Statuses { get; set; }

        public MainWindowViewModel()
        {
            using (var context = new TaskBoardDbContext())
            {
                var statusRepository = new Repository<Status>(context);
                Statuses = statusRepository.GetAll(x => x.Assignments);
            }
        }
    }
}
