using System.Windows;
using System.Windows.Controls;

namespace TodoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void addTaskButton_Click(object sender, RoutedEventArgs e)
        {
            var todoItem = new CheckBox();
            todoItem.Content = TaskInput.Text;
            todoItem.Width = 200;
            todoItem.Height = 24;
            tasksPanel.Children.Add(todoItem);
            TaskInput.Clear();

        }

        private void TaskInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            var taskIsEmpty = string.IsNullOrWhiteSpace(TaskInput.Text);
            this.addTaskButton.IsEnabled = !taskIsEmpty;
            // Якщо текст не введено
            if (taskIsEmpty)
            {
                // показуємо пейсхолдер "Введіть завдання"
                this.PlaceHolder.Visibility = Visibility.Visible;
            } else
            {
                // скриваємо пейсхолдер "Введіть завдання"
                this.PlaceHolder.Visibility = Visibility.Hidden;
            }
        }

        private void TextBlock_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // оскільки плейсхолдер розташований поверх текстового поля за допомогою властивості Panel.ZIndex="1"
            // то перехватуємо клік мишки на плейсхолдері та фокусуємо текстове поле
            TaskInput.Focus();
        }
    }
}

