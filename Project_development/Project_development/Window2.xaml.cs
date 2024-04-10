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
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        DevelopmentEntities db = new DevelopmentEntities();
        Task T = new Task();
        public static string developer;
        public static string tester;
        public static char version;
        public static string prioritet;
        public static string os;
        public static string assemble;
        public Window2()
        {
            InitializeComponent();

            var typeos = db.TypeOS;
            foreach (var type in typeos)
            {
                OS.Items.Add(type.NameTypeOS);
            }

            var assemtype = db.AssemblyType;
            foreach (var assembl in assemtype)
            {
                Asmb.Items.Add(assembl.NameAssemblyType);
            }

            var release = db.Release;
            foreach (var rel in release)
            {
                Rel.Items.Add(rel.NameRelease);
            }

            var prioritet = db.Priority;
            foreach (var pri in prioritet)
            {
                Prior.Items.Add(pri.NamePriority);
            }

            var devop = db.Employee.Where(x => x.IdPost == 2);
            foreach (var dv in devop)
            {
                Dev.Items.Add(dv.FullName);
            }

            var testor = db.Employee.Where(x => x.IdPost == 3);
            foreach (var tst in testor)
            {
                Test.Items.Add(tst.FullName);
            }
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                Task task = new Task();
                if (!string.IsNullOrEmpty(Discript.Text) && !string.IsNullOrEmpty(Discription.Text) && Dev != null && Test != null && Asmb != null && OS != null && Rel != null && Prior != null)
                {
                    task.Id_Developer = db.Employee.FirstOrDefault(x => Dev.Text.Contains(x.Surname)).Id_employee;
                    task.Id_Tester = db.Employee.FirstOrDefault(x => Test.Text.Contains(x.Surname)).Id_employee;
                    task.IdRelease = db.Release.FirstOrDefault(x => x.NameRelease == Rel.Text).Id_Release;
                    task.IdAssemblyType = db.AssemblyType.FirstOrDefault(x => x.NameAssemblyType == Asmb.Text).Id_AssemblyType;
                    task.IdTypeOS = db.TypeOS.FirstOrDefault(x => x.NameTypeOS == OS.Text).Id_TypeOS;
                    task.IdPriority = db.Priority.FirstOrDefault(x => x.NamePriority == Prior.Text).IdPriority;
                    task.Designation = Discript.Text;
                    task.DescriptionTask = Discription.Text;
                    task.Access = false;
                    task.IdPhase = 1;
                    task.Id_Creator = MainWindow.idempl;
                    db.Task.Add(task);
                    db.SaveChanges();
                    MessageBox.Show("Задача успешно создана!");
                }
                else
                {
                    MessageBox.Show("Есть пустые поля!");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка!");
            }

        }

        private void Enter1_Click(object sender, RoutedEventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Close();
        }
    }
}
