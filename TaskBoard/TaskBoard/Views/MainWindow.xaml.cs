using System.Windows;
using System.Windows.Controls;
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

            var stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Horizontal;

            foreach (var workStatus in model.Statuses)
            {
                var workStatusPanel = new StackPanel();
                workStatusPanel.Orientation = Orientation.Vertical;

                var workStatusLabel = new Label();
                workStatusLabel.Content = workStatus.Name;
                workStatusPanel.Children.Add(workStatusLabel);

                var assignmentsDataGrid = new DataGrid();
                assignmentsDataGrid.ItemsSource = workStatus.Assignments;
                workStatusPanel.Children.Add(assignmentsDataGrid);

                stackPanel.Children.Add(workStatusPanel);
            }

            MainGrid.Children.Add(stackPanel);
        }
    }
}
