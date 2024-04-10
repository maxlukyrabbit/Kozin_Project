using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project_development
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public static List<Employee> user = new List<Employee>();
        int trys = 0;
        public static string fullname;
        public static int idpost;
        public static int idempl;


        DevelopmentEntities db = new DevelopmentEntities();
        Employee NSP = new Employee();


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            var users = db.Employee;
            if (users.Select(x => x.Login).ToList().Contains(Log.Text))
            {
                if (users.Where(x => x.Login == Log.Text).ToList()[0].Password == Psw.Text)
                {
                    fullname = Convert.ToString(users.Where(x => x.Login == Log.Text).ToList()[0].FullName);
                    idpost = Convert.ToInt32(users.Where(x => x.Login == Log.Text).ToList()[0].IdPost);
                    idempl = Convert.ToInt32(users.Where(x => x.Login == Log.Text).ToList()[0].Id_employee);



                    NSP.Name = fullname;
                    NSP.IdPost = idpost;
                    NSP.Id_employee = idempl;

                    User._user.Add(NSP);

                    Main main = new Main();
                    main.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Вы ввели неверный логин или пароль. Пожалуйста, проверьте ещё раз введенные данные");
                trys++;
                if (trys == 3)
                {
                    MessageBox.Show("Вы 3 раза не верно авторизовались, перепроверьте свои данные и попробуйте снова");
                    this.Close();
                }
            }
            
        }
    }
}
