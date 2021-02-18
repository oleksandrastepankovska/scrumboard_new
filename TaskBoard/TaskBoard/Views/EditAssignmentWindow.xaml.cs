using AutoMapper;
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
using TaskBoard.Core;

namespace TaskBoard.Views
{
    /// <summary>
    /// Interaction logic for EditAssignmentWindow.xaml
    /// </summary>
    public partial class EditAssignmentWindow : Window
    {
        private IMapper _mapper { get; set; }

        public EditAssignmentWindow()
        {
            _mapper = MapperFactory.CreateMapper();
            //Model = model;
            //DataContext = Model;
            InitializeComponent();
            Loaded += CreateAssignmentWindow_Loaded;
        }

        private void CreateAssignmentWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //assignmentStatusComboBox.SelectedValuePath = ComboBoxItem.TagProperty.Name;
            //foreach (var item in Model.Statuses)
            //{
            //    assignmentStatusComboBox.Items.Add(new ComboBoxItem()
            //    {
            //        Content = item.Name,
            //        Tag = item.Id
            //    });
            //}
            //projectComboBox.SelectedValuePath = ComboBoxItem.TagProperty.Name;
            //foreach (var item in Model.Projects)
            //{
            //    projectComboBox.Items.Add(new ComboBoxItem()
            //    {
            //        Content = item.Name,
            //        Tag = item.Id
            //    });
            //}
            //assigneeComboBox.SelectedValuePath = ComboBoxItem.TagProperty.Name;
            //foreach (var item in Model.Persons)
            //{
            //    assigneeComboBox.Items.Add(new ComboBoxItem()
            //    {
            //        Content = $"{item.FirstName} {item.LastName}",
            //        Tag = item.Id
            //    });
            //}
        }

        private void createAssignmentButton_Click(object sender, RoutedEventArgs e)
        {
            //Model.CreatedAssignment.Name = assignmentNameTextBox.Text;
            //Model.CreatedAssignment.Description = assignmentDescriptionTextBox.Text;
            //Model.CreatedAssignment.StatusId = Int32.TryParse(assignmentStatusComboBox.SelectedValue.ToString(), out var statusId)
            //    ? statusId
            //    : Model.Statuses.FirstOrDefault().Id;
            //Model.CreatedAssignment.ProjectId = Int32.TryParse(projectComboBox.SelectedValue.ToString(), out var projectId)
            //    ? projectId
            //    : Model.Projects.FirstOrDefault().Id;
            //Model.CreatedAssignment.AssigneeId = Int32.TryParse(assigneeComboBox.SelectedValue.ToString(), out var assigneeId)
            //    ? assigneeId
            //    : Model.Persons.FirstOrDefault().Id;
            //using (var context = new TaskBoardDbContext())
            //{
            //    var assignmentRepository = new Repository<Assignment>(context);
            //    var assignment = _mapper.Map<Assignment>(Model.CreatedAssignment);
            //    assignment = assignmentRepository.Add(assignment);
            //    context.SaveChanges();
            //}
            //this.Close();
        }
    }
}
