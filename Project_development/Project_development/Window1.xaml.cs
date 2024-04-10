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

namespace Project_development
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private DevelopmentEntities db = new DevelopmentEntities();
        Employee NSP = new Employee();

        public Window1()
        {
            InitializeComponent();
            lstw_SelectTask.ItemsSource = db.Task.Where(x => x.Designation == Main.designation).ToList();

        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Close();
        }
        private void AddCommentButton_Click(object sender, RoutedEventArgs e)
        {

            var task = db.Task.FirstOrDefault(x => x.Designation == Main.designation);

            Comment comment = new Comment();
            comment.DescriptionComment = YourMethod();
            comment.Id_Employee = MainWindow.idempl;
            comment.Id_Task = task.Id_Task;


            db.Comment.Add(comment);


            db.SaveChanges();
            lstw_SelectTask.ItemsSource = db.Task.Where(x => x.Designation == Main.designation).ToList();

        }


        private string YourMethod()
        {
            // Получаем первый элемент из ItemsControl (получить 1 элемент)
            var firstItem = lstw_SelectTask.Items[0];

            // Получаем контейнер элемента списка для первого элемента
            ListBoxItem firstListBoxItem = (ListBoxItem)lstw_SelectTask.ItemContainerGenerator.ContainerFromItem(firstItem);

            if (firstListBoxItem != null)
            {
                // Находим ContentPresenter для первого элемента
                ContentPresenter firstContentPresenter = FindVisualChild<ContentPresenter>(firstListBoxItem);

                if (firstContentPresenter != null)
                {
                    // Получаем DataTemplate для первого элемента
                    DataTemplate firstDataTemplate = firstContentPresenter.ContentTemplate;

                    // Находим TextBox с именем CommentTextBox для первого элемента
                    TextBox firstCommentTextBox = (TextBox)firstDataTemplate.FindName("CommentTextBox", firstContentPresenter);

                    if (firstCommentTextBox != null)
                    {
                        string commentFromFirstItem = firstCommentTextBox.Text;
                        return commentFromFirstItem;
                    }
                }
            }
            return null;
        }

        public static T FindVisualChild<T>(DependencyObject obj) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);

                if (child != null && child is T)
                {
                    return (T)child;
                }
                else
                {
                    T childOfChild = FindVisualChild<T>(child);
                    if (childOfChild != null)
                    {
                        return childOfChild;
                    }
                }
            }

            return null;
        }
    }
}
