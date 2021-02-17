using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using TaskBoard.Data.Entities;
using TaskBoard.ViewModels;

namespace TaskBoard.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var model = new MainWindowViewModel();

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
            foreach (var workStatus in model.Statuses)
            {
                var assignmentsByWorkStatusPanel = new StackPanel();
                assignmentsByWorkStatusPanel.Orientation = Orientation.Vertical;

                var workStatusLabel = new Label();
                workStatusLabel.Content = workStatus.Name;
                assignmentsByWorkStatusPanel.Children.Add(workStatusLabel);

                var assignmentsDataGrid = new DataGrid();
                assignmentsDataGrid.AutoGenerateColumns = false;
                assignmentsDataGrid.ItemsSource = workStatus.Assignments;
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
                assignmentsByWorkStatusPanel.Children.Add(assignmentsDataGrid);

                assignmentsPanel.Children.Add(assignmentsByWorkStatusPanel);
            }

            mainPanel.Children.Add(assignmentsPanel);

            mainGrid.Children.Add(mainPanel);
        }

        private void CreateAssignmentButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
