using System.Collections.Generic;
using System.Windows;
using TaskBoard.Core;
using TaskBoard.Data;
using TaskBoard.Data.Entities;
using TaskBoard.Infrastructure.Concrete;
using TaskBoard.ViewModels;
using TaskBoard.ViewModels.Entities;
using TaskBoard.Views;

namespace TaskBoard
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mapper = MapperFactory.CreateMapper();

            var mainWindowViewModel = new MainWindowViewModel();
            using (var context = new TaskBoardDbContext())
            {
                var statusRepository = new Repository<Status>(context);
                var statuses = statusRepository.GetAll(x => x.Assignments);
                mainWindowViewModel.Statuses = mapper.Map<IEnumerable<Status>, IEnumerable<StatusViewModel>>(statuses);
                var assignmentRepository = new Repository<Assignment>(context);
                var assignments = assignmentRepository.GetAll(x => x.Project, x => x.Assignee);
                mainWindowViewModel.Assignments = mapper.Map<IEnumerable<Assignment>, IEnumerable<AssignmentViewModel>>(assignments);
            }

            var mainWindow = new MainWindow(mainWindowViewModel);
            mainWindow.Show();
        }
    }
}
