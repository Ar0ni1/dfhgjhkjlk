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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ef5uc.SalavaClubDataSetTableAdapters;
namespace ef5uc
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RolesTableAdapter adapter = new RolesTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ClButtonAVT(object sender, RoutedEventArgs e)
        {
            var allLogins = adapter.GetData().Rows;
            bool isLoggedIn = false;

            for (int i = 0; i < allLogins.Count; i++)
            {
                if (allLogins[i][2].ToString() == LoginTbx.Text && 
                    allLogins[i][3].ToString() == PasswordTbx.Password)
                {
                    isLoggedIn = true;
                    int roleid = (int)allLogins[i][0];

                    switch (roleid)
                    {
                        case 1:
                            AdminWindow role = new AdminWindow();
                            role.Show();
                            this.Close();
                            break;
                        case 2:
                            KassirWindow kassir = new KassirWindow();
                            kassir.Show();
                            this.Close();
                            break;
                    }

                }

            }
            if (!isLoggedIn)
             {
               MessageBox.Show("Неправильный логин или пароль. Пожалуйста, попробуйте снова.", "Ошибка входа", MessageBoxButton.OK, MessageBoxImage.Error);
             }
        }
    }
}
