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
    /// Логика взаимодействия для Main.xaml
    /// </summary>

    public partial class Main : Window
    {
        private DevelopmentEntities db = new DevelopmentEntities();
        private List_Task _task = new List_Task();
        Employee NSP = new Employee();
        Employee dev = new Employee();
        Employee test = new Employee();
        public static string fullname;
        public static List<Task> list;
        private bool isDragging = false;
        private object draggedData = null;

        public static string designation;

        public Main()
        {
            InitializeComponent();

            CreateTask.Visibility = Visibility.Hidden;
            var users = db.Employee;



            int id_p = 0;
            int id_e = 0;
            foreach (var h in User._user)
            {
                id_p = h.IdPost;
                id_e = h.Id_employee;
                SNP.Content = h.FullName;
            }

            var typeos = db.TypeOS;
            SearchTypeOS.Items.Add("Все ОС");
            foreach (var type in typeos)
            {
                SearchTypeOS.Items.Add(type.NameTypeOS);
            }

            var assemtype = db.AssemblyType;
            SearchAssemblyType.Items.Add("Все типы разработки");
            foreach (var assembl in assemtype)
            {
                SearchAssemblyType.Items.Add(assembl.NameAssemblyType);
            }

            var release = db.Release;
            SearchRelease.Items.Add("Все версии");
            foreach (var rel in release)
            {
                SearchRelease.Items.Add(rel.NameRelease);
            }


            if (id_p == 2)
            {
                SearchEmployee.Items.Add("Все Тестировщики");
                NameEmpl.Content = "Тестировщики";
                fullname = Convert.ToString(users.Where(x => x.IdPost == 3).ToList());

                dev.Name = fullname;

                var devep = db.Employee.Where(x => x.IdPost == 3);

                foreach (var man in devep)
                {
                    SearchEmployee.Items.Add(man.FullName);
                }

                var tsk_creation = db.Task.Where(x => x.IdPhase == 1 && x.Id_Developer == id_e).ToList();
                lstw_creation.ItemsSource = tsk_creation;
                var tsk_devlop_expect = db.Task.Where(x => x.IdPhase == 2 && x.Id_Developer == id_e).ToList();
                lstw_develep_expect.ItemsSource = tsk_devlop_expect;
                var tsk_develop = db.Task.Where(x => x.IdPhase == 3 && x.Id_Developer == id_e).ToList();
                lstw_develep.ItemsSource = tsk_develop;
                var tsk_test_expect = db.Task.Where(x => x.IdPhase == 4 && x.Id_Developer == id_e).ToList();
                lstw_test_expect.ItemsSource = tsk_test_expect;
                var tsk_test = db.Task.Where(x => x.IdPhase == 5 && x.Id_Developer == id_e).ToList();
                lstw_test.ItemsSource = tsk_test;
                var tsk_ready = db.Task.Where(x => x.IdPhase == 6 && x.Id_Developer == id_e).ToList();
                lstw_ready.ItemsSource = tsk_ready;
            }
            else if (id_p == 3)
            {
                SearchEmployee.Items.Add("Все Разработчики");
                NameEmpl.Content = "Разработчики";
                fullname = Convert.ToString(users.Where(x => x.IdPost == 2).ToList()[0].FullName);

                test.Name = fullname;

                var devep = db.Employee.Where(x => x.IdPost == 2);

                foreach (var man in devep)
                {
                    SearchEmployee.Items.Add(man.FullName);
                }
                var tsk_creation = db.Task.Where(x => x.IdPhase == 1 && x.Id_Tester == id_e).ToList();
                lstw_creation.ItemsSource = tsk_creation;
                var tsk_devlop_expect = db.Task.Where(x => x.IdPhase == 2 && x.Id_Tester == id_e).ToList();
                lstw_develep_expect.ItemsSource = tsk_devlop_expect;
                var tsk_develop = db.Task.Where(x => x.IdPhase == 3 && x.Id_Tester == id_e).ToList();
                lstw_develep.ItemsSource = tsk_develop;
                var tsk_test_expect = db.Task.Where(x => x.IdPhase == 4 && x.Id_Tester == id_e).ToList();
                lstw_test_expect.ItemsSource = tsk_test_expect;
                var tsk_test = db.Task.Where(x => x.IdPhase == 5 && x.Id_Tester == id_e).ToList();
                lstw_test.ItemsSource = tsk_test;
                var tsk_ready = db.Task.Where(x => x.IdPhase == 6 && x.Id_Tester == id_e).ToList();
                lstw_ready.ItemsSource = tsk_ready;

            }
            else if (id_p == 1)
            {

                CreateTask.Visibility = Visibility.Visible;
                SearchEmployee.Items.Add("Все Разработчики");

                test.Name = fullname;

                var devep = db.Employee.Where(x => x.IdPost == 2);

                foreach (var man in devep)
                {
                    SearchEmployee.Items.Add(man.FullName);
                }

                SearchEmployee.Items.Add("Все Тестировщики");

                devep = db.Employee.Where(x => x.IdPost == 3);

                foreach (var man in devep)
                {
                    SearchEmployee.Items.Add(man.FullName);
                }

                NameEmpl.Content = "Работники";

                var tsk_creation = db.Task.Where(x => x.IdPhase == 1).ToList();
                lstw_creation.ItemsSource = tsk_creation;
                var tsk_devlop_expect = db.Task.Where(x => x.IdPhase == 2).ToList();
                lstw_develep_expect.ItemsSource = tsk_devlop_expect;
                var tsk_develop = db.Task.Where(x => x.IdPhase == 3).ToList();
                lstw_develep.ItemsSource = tsk_develop;
                var tsk_test_expect = db.Task.Where(x => x.IdPhase == 4).ToList();
                lstw_test_expect.ItemsSource = tsk_test_expect;
                var tsk_test = db.Task.Where(x => x.IdPhase == 5).ToList();
                lstw_test.ItemsSource = tsk_test;
                var tsk_ready = db.Task.Where(x => x.IdPhase == 6).ToList();
                lstw_ready.ItemsSource = tsk_ready;

            }
            else
            {
                SearchEmployee.Items.Add("Все Разработчики");

                test.Name = fullname;

                var devep = db.Employee.Where(x => x.IdPost == 2);

                foreach (var man in devep)
                {
                    SearchEmployee.Items.Add(man.FullName);
                }

                SearchEmployee.Items.Add("Все Тестировщики");

                devep = db.Employee.Where(x => x.IdPost == 3);

                foreach (var man in devep)
                {
                    SearchEmployee.Items.Add(man.FullName);
                }

                NameEmpl.Content = "Работники";

                var tsk_creation = db.Task.Where(x => x.IdPhase == 1).ToList();
                lstw_creation.ItemsSource = tsk_creation;
                var tsk_devlop_expect = db.Task.Where(x => x.IdPhase == 2).ToList();
                lstw_develep_expect.ItemsSource = tsk_devlop_expect;
                var tsk_develop = db.Task.Where(x => x.IdPhase == 3).ToList();
                lstw_develep.ItemsSource = tsk_develop;
                var tsk_test_expect = db.Task.Where(x => x.IdPhase == 4).ToList();
                lstw_test_expect.ItemsSource = tsk_test_expect;
                var tsk_test = db.Task.Where(x => x.IdPhase == 5).ToList();
                lstw_test.ItemsSource = tsk_test;
                var tsk_ready = db.Task.Where(x => x.IdPhase == 6).ToList();
                lstw_ready.ItemsSource = tsk_ready;
            }

        }

        private void EnterTask_Click(object sender, RoutedEventArgs e)
        {
            //Task tsk = lstw_creation.SelectedItem as Task;
            //SelectTask._select_task.Add(tsk);
            //Window1 wind1 = new Window1();
            //wind1.Show();
            //this.Close();

            if (lstw_creation.SelectedItem != null)
            {
                Task selectedItem = lstw_creation.SelectedItem as Task;
                if (selectedItem != null)
                {
                    designation = selectedItem.Designation;


                    Window1 wind1 = new Window1();
                    wind1.Show();
                    this.Close();
                }
            }
        }

        private void EnterTask1_Click(object sender, RoutedEventArgs e)
        {
            //Task tsk = lstw_develep_expect.SelectedItem as Task;
            //SelectTask._select_task.Add(tsk);
            //Window1 wind1 = new Window1();
            //wind1.Show();
            //this.Close();

            if (lstw_develep_expect.SelectedItem != null)
            {
                Task selectedItem = lstw_develep_expect.SelectedItem as Task;
                if (selectedItem != null)
                {
                    designation = selectedItem.Designation;

                    Window1 wind1 = new Window1();
                    wind1.Show();
                    this.Close();
                }
            }
        }

        private void EnterTask2_Click(object sender, RoutedEventArgs e)
        {
            //Task tsk = lstw_develep.SelectedItem as Task;
            //SelectTask._select_task.Add(tsk);
            //Window1 wind1 = new Window1();
            //wind1.Show();
            //this.Close();

            if (lstw_develep.SelectedItem != null)
            {
                Task selectedItem = lstw_develep.SelectedItem as Task;
                if (selectedItem != null)
                {
                    designation = selectedItem.Designation;

                    Window1 wind1 = new Window1();
                    wind1.Show();
                    this.Close();
                }
            }
        }

        private void EnterTask3_Click(object sender, RoutedEventArgs e)
        {
            //Task tsk = lstw_test_expect.SelectedItem as Task;
            //SelectTask._select_task.Add(tsk);
            //Window1 wind1 = new Window1();
            //wind1.Show();
            //this.Close();
            if (lstw_test.SelectedItem != null)
            {
                Task selectedItem = lstw_test.SelectedItem as Task;
                if (selectedItem != null)
                {
                    designation = selectedItem.Designation;

                    Window1 wind1 = new Window1();
                    wind1.Show();
                    this.Close();
                }
            }
        }

        private void EnterTask4_Click(object sender, RoutedEventArgs e)
        {
            //    Task tsk = lstw_test.SelectedItem as Task;
            //    SelectTask._select_task.Add(tsk);
            //    Window1 wind1 = new Window1();
            //    wind1.Show();
            //    this.Close();

            if (lstw_ready.SelectedItem != null)
            {
                Task selectedItem = lstw_ready.SelectedItem as Task;
                if (selectedItem != null)
                {
                    designation = selectedItem.Designation;

                    Window1 wind1 = new Window1();
                    wind1.Show();
                    this.Close();
                }
            }
        }

        private void EnterTask5_Click(object sender, RoutedEventArgs e)
        {
            //    Task tsk = lstw_ready.SelectedItem as Task;
            //    SelectTask._select_task.Add(tsk);


            if (lstw_creation.SelectedItem != null)
            {
                Task selectedItem = lstw_creation.SelectedItem as Task;
                if (selectedItem != null)
                {
                    designation = selectedItem.Designation;

                    Window1 wind1 = new Window1();
                    wind1.Show();
                    this.Close();
                }
            }


        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            Window2 wind2 = new Window2();
            wind2.Show();
            Close();
        }

        private void Depend_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var tsk_creation = lstw_creation.ItemsSource;
            //var tsk_devlop_expect = lstw_develep_expect.ItemsSource;
            //var tsk_develop = lstw_develep.ItemsSource;
            //var tsk_test_expect = lstw_test_expect.ItemsSource;
            //var tsk_test = lstw_test.ItemsSource
            //var tsk_ready = lstw_ready.ItemsSource;
            var users = db.Employee;


            int id_p = 0;
            int id_e = 0;
            foreach (var h in User._user)
            {
                id_p = h.IdPost;
                id_e = h.Id_employee;
            }
            if (id_p == 2)
            {
                string value = SearchEmployee.Text;
                var id_arr = db.Employee.FirstOrDefault(x => x.FullName == value);
                if (id_arr != null)
                {

                }
                var tsk_creation = db.Task.Where(x => x.IdPhase == 1 && x.Id_Developer == id_e).ToList();
                lstw_creation.ItemsSource = tsk_creation;
                var tsk_devlop_expect = db.Task.Where(x => x.IdPhase == 2 && x.Id_Developer == id_e).ToList();
                lstw_develep_expect.ItemsSource = tsk_devlop_expect;
                var tsk_develop = db.Task.Where(x => x.IdPhase == 3 && x.Id_Developer == id_e).ToList();
                lstw_develep.ItemsSource = tsk_develop;
                var tsk_test_expect = db.Task.Where(x => x.IdPhase == 4 && x.Id_Developer == id_e).ToList();
                lstw_test_expect.ItemsSource = tsk_test_expect;
                var tsk_test = db.Task.Where(x => x.IdPhase == 5 && x.Id_Developer == id_e).ToList();
                lstw_test.ItemsSource = tsk_test;
                var tsk_ready = db.Task.Where(x => x.IdPhase == 6 && x.Id_Developer == id_e).ToList();
                lstw_ready.ItemsSource = tsk_ready;
            }
            else if (id_p == 3)
            {

                var tsk_creation = db.Task.Where(x => x.IdPhase == 1 && x.Id_Tester == id_e).ToList();
                lstw_creation.ItemsSource = tsk_creation;
                var tsk_devlop_expect = db.Task.Where(x => x.IdPhase == 2 && x.Id_Tester == id_e).ToList();
                lstw_develep_expect.ItemsSource = tsk_devlop_expect;
                var tsk_develop = db.Task.Where(x => x.IdPhase == 3 && x.Id_Tester == id_e).ToList();
                lstw_develep.ItemsSource = tsk_develop;
                var tsk_test_expect = db.Task.Where(x => x.IdPhase == 4 && x.Id_Tester == id_e).ToList();
                lstw_test_expect.ItemsSource = tsk_test_expect;
                var tsk_test = db.Task.Where(x => x.IdPhase == 5 && x.Id_Tester == id_e).ToList();
                lstw_test.ItemsSource = tsk_test;
                var tsk_ready = db.Task.Where(x => x.IdPhase == 6 && x.Id_Tester == id_e).ToList();
                lstw_ready.ItemsSource = tsk_ready;
            }
            else
            {
                var tsk_creation = db.Task.Where(x => x.IdPhase == 1).ToList();
                lstw_creation.ItemsSource = tsk_creation;
                var tsk_devlop_expect = db.Task.Where(x => x.IdPhase == 2).ToList();
                lstw_develep_expect.ItemsSource = tsk_devlop_expect;
                var tsk_develop = db.Task.Where(x => x.IdPhase == 3).ToList();
                lstw_develep.ItemsSource = tsk_develop;
                var tsk_test_expect = db.Task.Where(x => x.IdPhase == 4).ToList();
                lstw_test_expect.ItemsSource = tsk_test_expect;
                var tsk_test = db.Task.Where(x => x.IdPhase == 5).ToList();
                lstw_test.ItemsSource = tsk_test;
                var tsk_ready = db.Task.Where(x => x.IdPhase == 6).ToList();
                lstw_ready.ItemsSource = tsk_ready;

            }
        }

        private void SearchTypeOS_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var tsk_creation = lstw_creation.ItemsSource;
            var tsk_devlop_expect = lstw_develep_expect.ItemsSource;
            var tsk_develop = lstw_develep.ItemsSource;
            var tsk_test_expect = lstw_test_expect.ItemsSource;
            var tsk_test = lstw_test.ItemsSource;
            var tsk_ready = lstw_ready.ItemsSource;

            string value = SearchTypeOS.Text;
            var id_arr = db.TypeOS.FirstOrDefault(x => x.NameTypeOS == value);

            if (id_arr != null)
            {

            }

        }

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source is ListViewItem item && item.DataContext != null)
            {
                isDragging = true;
                draggedData = item.DataContext;
                DragDrop.DoDragDrop(item, draggedData, DragDropEffects.Move);
            }
        }

        private void ListViewItem_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging && e.LeftButton == MouseButtonState.Pressed)
            {
                ListViewItem draggedItem = sender as ListViewItem;
                DataObject dragData = new DataObject("myFormat", draggedData);
                DragDrop.DoDragDrop(draggedItem, dragData, DragDropEffects.Move);
            }
        }

        private void ListViewItem_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isDragging = false;
            draggedData = null;
        }

        private void lstw_test_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("myFormat"))
            {
                var data = e.Data.GetData("myFormat");
                if (data != null)
                {
                    // Add the dropped data to the lstw_test
                    (sender as ListView).Items.Add(data);
                }
            }
        }

        private void lstw_ready_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("myFormat"))
            {
                var data = e.Data.GetData("myFormat");
                if (data != null)
                {
                    // Add the dropped data to the lstw_ready
                    (sender as ListView).Items.Add(data);
                }
            }
        }
        private void lstw_develep_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("myFormat"))
            {
                var data = e.Data.GetData("myFormat");
                if (data != null)
                {
                    // Add the dropped data to the lstw_ready
                    (sender as ListView).Items.Add(data);
                }
            }
        }
        private void lstw_creation_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("myFormat"))
            {
                var data = e.Data.GetData("myFormat");
                if (data != null)
                {
                    // Add the dropped data to the lstw_ready
                    (sender as ListView).Items.Add(data);
                }
            }
        }
        private void lstw_test_expect_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("myFormat"))
            {
                var data = e.Data.GetData("myFormat");
                if (data != null)
                {
                    // Add the dropped data to the lstw_ready
                    (sender as ListView).Items.Add(data);
                }
            }
        }
        private void lstw_develep_expect_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("myFormat"))
            {
                var data = e.Data.GetData("myFormat");
                if (data != null)
                {
                    // Add the dropped data to the lstw_ready
                    (sender as ListView).Items.Add(data);
                }
            }
        }

    }
}

