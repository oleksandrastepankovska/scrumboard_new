using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TaskBoard.ViewModels;

namespace TaskBoard.Views
{
    /// <summary>
    /// Interaction logic for CreateAssignmentView.xaml
    /// </summary>
    public partial class CreateAssignmentWindow : Window
    {
        private CreateAssignmentWindowViewModel Model { get; set; }

        public CreateAssignmentWindow(CreateAssignmentWindowViewModel model)
        {
            Model = model;
            DataContext = Model;
            InitializeComponent();
            Loaded += CreateAssignmentWindow_Loaded;
        }

        private void CreateAssignmentWindow_Loaded(object sender, RoutedEventArgs e)
        {
            assignmentStatusComboBox.SelectedValuePath = ComboBoxItem.TagProperty.Name;
            foreach (var item in Model.Statuses)
            {
                assignmentStatusComboBox.Items.Add(new ComboBoxItem()
                {
                    Content = item.Name,
                    Tag = item.Id
                });
            }
        }

        private void createAssignmentButton_Click(object sender, RoutedEventArgs e)
        {
            Model.CreatedAssignment.Name = assignmentNameTextBox.Text;
            Model.CreatedAssignment.Description = assignmentDescriptionTextBox.Text;
            Model.CreatedAssignment.StatusId = Int32.TryParse(assignmentStatusComboBox.SelectedValue.ToString(), out var statusId)
                ? statusId
                : Model.Statuses.FirstOrDefault().Id;
        }
    }
}
