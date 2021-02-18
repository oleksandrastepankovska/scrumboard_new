﻿using AutoMapper;
using System.Windows;
using System.Windows.Controls;
using TaskBoard.Core;
using TaskBoard.ViewModels;

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
