using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TaskBoard.Core;
using TaskBoard.Data;
using TaskBoard.Data.Entities;
using TaskBoard.Infrastructure.Concrete;
using TaskBoard.ViewModels;
using TaskBoard.ViewModels.Entities;

namespace TaskBoard.Views
{
    /// <summary>
    /// Interaction logic for EditAssignmentWindow.xaml
    /// </summary>
    public partial class EditAssignmentWindow : Window
    {
        private IMapper _mapper { get; set; }
        private EditAssignmentWindowViewModel Model { get; set; }
        public EditAssignmentWindow(EditAssignmentWindowViewModel model)
        {
            _mapper = MapperFactory.CreateMapper();
            Model = model;
            DataContext = Model;
            InitializeComponent();
            Loaded += EditAssignmentWindow_Loaded;
            Closing += EditAssignmentWindow_Closed;
        }

        private void EditAssignmentWindow_Loaded(object sender, RoutedEventArgs e)
        {
            assignmentNameTextBox.Text = Model.Assignment.Name;
            assignmentDescriptionTextBox.Text = Model.Assignment.Description;
            assignmentStatusComboBox.SelectedValuePath = ComboBoxItem.TagProperty.Name;
            foreach (var item in Model.Statuses)
            {
                assignmentStatusComboBox.Items.Add(new ComboBoxItem()
                {
                    Content = item.Name,
                    Tag = item.Id,
                    IsSelected = item.Id == Model.Assignment.StatusId
                });
            }
            assigneeComboBox.SelectedValuePath = ComboBoxItem.TagProperty.Name;
            foreach (var item in Model.Persons)
            {
                assigneeComboBox.Items.Add(new ComboBoxItem()
                {
                    Content = $"{item.FirstName} {item.LastName}",
                    Tag = item.Id,
                    IsSelected = item.Id == Model.Assignment.AssigneeId
                });
            }
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            Model.EditedAssignment.Name = assignmentNameTextBox.Text;
            Model.EditedAssignment.Description = assignmentDescriptionTextBox.Text;
            Model.EditedAssignment.StatusId = Int32.TryParse(assignmentStatusComboBox.SelectedValue.ToString(), out var statusId)
                ? statusId
                : Model.Statuses.FirstOrDefault().Id;            
            Model.EditedAssignment.AssigneeId = Int32.TryParse(assigneeComboBox.SelectedValue.ToString(), out var assigneeId)
                ? assigneeId
                : Model.Persons.FirstOrDefault().Id;
            using (var context = new TaskBoardDbContext())
            {
                var assignmentsRepository = new Repository<Assignment>(context);
                var assignment = assignmentsRepository.GetSingle(x => x.Id == Model.Assignment.Id);
                _mapper.Map(Model.EditedAssignment, assignment);
                assignment = assignmentsRepository.Update(assignment);
                context.SaveChanges();
            }
            this.Close();
        }

        private void deleteAssignmentButton_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new TaskBoardDbContext())
            {
                var assignmentsRepository = new Repository<Assignment>(context);
                var assignment = assignmentsRepository.GetSingle(x => x.Id == Model.Assignment.Id);
                assignmentsRepository.Delete(assignment);
                context.SaveChanges();
            }
            this.Close();
        }

        private void EditAssignmentWindow_Closed(object sender, EventArgs e)
        {
            var mainWindowViewModel = new MainWindowViewModel();
            using (var context = new TaskBoardDbContext())
            {
                var assignmentsRepository = new Repository<Assignment>(context);
                var statusRepository = new Repository<Status>(context);
                var statuses = statusRepository.GetAll(x => x.Assignments);
                mainWindowViewModel.Statuses = _mapper.Map<IEnumerable<Status>, IEnumerable<StatusViewModel>>(statuses);
                var assignments = assignmentsRepository.GetAll(x => x.Project, x => x.Assignee);
                mainWindowViewModel.Assignments = _mapper.Map<IEnumerable<Assignment>, IEnumerable<AssignmentViewModel>>(assignments);
            }

            var mainWindow = new MainWindow(mainWindowViewModel);
            mainWindow.Show();
        }
    }
}
