using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using TaskBoard.Core;
using TaskBoard.Data;
using TaskBoard.Data.Entities;
using TaskBoard.Infrastructure.Concrete;
using TaskBoard.ViewModels;
using TaskBoard.ViewModels.Entities;

namespace TaskBoard.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IMapper _mapper { get; set; }
        private MainWindowViewModel Model { get; set; }
        public MainWindow(MainWindowViewModel model)
        {
            _mapper = MapperFactory.CreateMapper();
            Model = model;
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var mainPanel = new StackPanel() { Orientation = Orientation.Vertical };

            var controlPanel = new StackPanel();
            var createAssignmentButton = new Button()
            {
                Name = "CreateAssignmentButton",
                Content = "Create Asignment",
                Width = 150
            };
            createAssignmentButton.Click += CreateAssignmentButton_Click;
            controlPanel.Children.Add(createAssignmentButton);
            mainPanel.Children.Add(controlPanel);

            var assignmentsPanel = new StackPanel() { Orientation = Orientation.Horizontal };
            foreach (var workStatus in Model.Statuses)
            {
                var workStatusLabel = new Label();
                workStatusLabel.Content = workStatus.Name;
                mainPanel.Children.Add(workStatusLabel);

                var assignmentsDataGrid = new DataGrid();
                assignmentsDataGrid.AutoGenerateColumns = false;
                assignmentsDataGrid.ItemsSource = Model.Assignments.Where(x => x.StatusId == workStatus.Id);
                assignmentsDataGrid.Columns.Add(new DataGridTextColumn()
                {
                    Binding = new Binding(nameof(Assignment.Name)),
                    Header = "Name",
                    Width = 175,
                    IsReadOnly = true
                });
                assignmentsDataGrid.Columns.Add(new DataGridTextColumn()
                {
                    Binding = new Binding(nameof(Assignment.Description)),
                    Header = "Description",
                    Width = 250,
                    IsReadOnly = true
                });
                assignmentsDataGrid.Columns.Add(new DataGridTextColumn()
                {
                    Binding = new Binding(nameof(Assignment.Assignee)),
                    Header = "Assignee",
                    Width = 250,
                    IsReadOnly = true
                });
                assignmentsDataGrid.Columns.Add(new DataGridTextColumn()
                {
                    Binding = new Binding(nameof(Assignment.Project)),
                    Header = "Project",
                    Width = 175,
                    IsReadOnly = true
                });
                var rowStyle = new Style(typeof(DataGridRow));
                rowStyle.Setters.Add(new EventSetter(DataGridRow.MouseDoubleClickEvent,
                                         new MouseButtonEventHandler(AssignmentsGridRow_DoubleClick)));
                assignmentsDataGrid.RowStyle = rowStyle;
                mainPanel.Children.Add(assignmentsDataGrid);
            }

            mainPanel.Children.Add(assignmentsPanel);

            mainGrid.Children.Add(mainPanel);
        }

        private void CreateAssignmentButton_Click(object sender, RoutedEventArgs e)
        {
            var createAssignmentWindowModel = new CreateAssignmentWindowViewModel();
            using (var context = new TaskBoardDbContext())
            {
                var statusRepository = new Repository<Status>(context);
                var statuses = statusRepository.GetAll();
                createAssignmentWindowModel.Statuses = _mapper.Map<IEnumerable<Status>, IEnumerable<StatusViewModel>>(statuses);
                var projectsRepository = new Repository<Project>(context);
                var projects = projectsRepository.GetAll();
                createAssignmentWindowModel.Projects = _mapper.Map<IEnumerable<Project>, IEnumerable<ProjectViewModel>>(projects);
                var personRepository = new Repository<Person>(context);
                var persons = personRepository.GetAll();
                createAssignmentWindowModel.Persons = _mapper.Map<IEnumerable<Person>, IEnumerable<PersonViewModel>>(persons);
            }

            CreateAssignmentWindow createAssignmentWindow = new CreateAssignmentWindow(createAssignmentWindowModel);
            createAssignmentWindow.Show();
        }

        private void AssignmentsGridRow_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            var row = sender as DataGridRow;

            var editAssignmentWindow = new EditAssignmentWindow();
            editAssignmentWindow.Show();
        }
    }
}
