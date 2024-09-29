using System.Collections.ObjectModel;
using System.Windows;

namespace ToDoApp
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<TaskItem> Tasks { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Tasks = new ObservableCollection<TaskItem>();
            TaskListView.ItemsSource = Tasks;

            // Set placeholder text
            TaskInput.Text = "Enter your task...";
            TaskInput.Foreground = System.Windows.Media.Brushes.Gray;
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TaskInput.Text == "Enter your task...")
            {
                TaskInput.Text = "";
                TaskInput.Foreground = System.Windows.Media.Brushes.Black;
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TaskInput.Text))
            {
                TaskInput.Text = "Enter your task...";
                TaskInput.Foreground = System.Windows.Media.Brushes.Gray;
            }
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            if (TaskInput.Text != "Enter your task..." && !string.IsNullOrWhiteSpace(TaskInput.Text))
            {
                Tasks.Add(new TaskItem { TaskName = TaskInput.Text });
                TaskInput.Text = "Enter your task...";
                TaskInput.Foreground = System.Windows.Media.Brushes.Gray;
            }
        }

        private void EditTask_Click(object sender, RoutedEventArgs e)
        {
            // Logic for editing the selected task
            if (TaskListView.SelectedItem is TaskItem selectedTask)
            {
                TaskInput.Text = selectedTask.TaskName;
                TaskInput.Foreground = System.Windows.Media.Brushes.Black;
                Tasks.Remove(selectedTask); // Optionally remove the task for re-entry
            }
        }

        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            // Logic for deleting the selected task
            if (TaskListView.SelectedItem is TaskItem selectedTask)
            {
                Tasks.Remove(selectedTask);
            }
        }

        private void ClearCompleted_Click(object sender, RoutedEventArgs e)
        {
            // Logic for clearing completed tasks (if you add a completed status)
        }
    }

    public class TaskItem
    {
        public string TaskName { get; set; }
    }
}
