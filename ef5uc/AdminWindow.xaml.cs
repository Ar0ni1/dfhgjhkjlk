using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using ef5uc.SalavaClubDataSetTableAdapters;

namespace ef5uc
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private SalavaClubEntities context = new SalavaClubEntities();
        private string currentTableName;

        public AdminWindow()
        {
            InitializeComponent();
        }

        private void ReadRolesTable()
        {
            currentTableName = "Roles";
            AdminDataGrid.ItemsSource = context.Roles.ToList();

            AdminDataGrid.Columns.Clear();
            AdminDataGrid.Columns.Add(new DataGridTextColumn { Header = "ID", Binding = new Binding("RolesId") });
            AdminDataGrid.Columns.Add(new DataGridTextColumn { Header = "Название роли", Binding = new Binding("NameRoles") });
            AdminDataGrid.Columns.Add(new DataGridTextColumn { Header = "Логин", Binding = new Binding("Ilogin") });
            AdminDataGrid.Columns.Add(new DataGridTextColumn { Header = "Пароль", Binding = new Binding("Passwords") });
        }

        private void ReadSotrudnikiTable()
        {
            currentTableName = "Sotrudniki";
            AdminDataGrid.ItemsSource = context.Sotrudniki.ToList();

            AdminDataGrid.Columns.Clear();
            AdminDataGrid.Columns.Add(new DataGridTextColumn { Header = "ID", Binding = new Binding("SotrudnikiID") });
            AdminDataGrid.Columns.Add(new DataGridTextColumn { Header = "Имя", Binding = new Binding("Namep") });
            AdminDataGrid.Columns.Add(new DataGridTextColumn { Header = "Фамилия", Binding = new Binding("Surname") });
            AdminDataGrid.Columns.Add(new DataGridTextColumn { Header = "Должность", Binding = new Binding("Dolznost") });
        }

        private void Roles_Click(object sender, EventArgs e)
        {
            ReadRolesTable();
        }

        private void Sotrudniki_Click(object sender, EventArgs e)
        {
            ReadSotrudnikiTable();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (currentTableName == "Roles")
            {
                Roles newRole = new Roles { NameRoles = NewValueTextBox.Text, Ilogin = Convert.ToInt32(NewValueTextBox1.Text), Passwords = NewValueTextBox2.Text };
                context.Roles.Add(newRole);
                context.SaveChanges();
                ReadRolesTable();
            }
            else if (currentTableName == "Sotrudniki")
            {
                Sotrudniki newSotrudnik = new Sotrudniki { Namep = NewValueTextBox.Text, Surname = NewValueTextBox1.Text, Dolznost = NewValueTextBox2.Text, RolesID = Convert.ToInt32 (NewValueTextBox4.Text) };
                context.Sotrudniki.Add(newSotrudnik);
                context.SaveChanges();
                ReadSotrudnikiTable();
            }
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            if (AdminDataGrid.SelectedItem != null)
            {
                if (currentTableName == "Roles")
                {
                    Roles selectedRole = (Roles)AdminDataGrid.SelectedItem;
                    selectedRole.NameRoles = NewValueTextBox.Text; selectedRole.Ilogin = Convert.ToInt32(NewValueTextBox1.Text); selectedRole.Passwords = NewValueTextBox2.Text;
                    context.SaveChanges();
                    AdminDataGrid.ItemsSource = context.Roles.ToList();
                }
                else if (currentTableName == "Sotrudniki")
                {
                    Sotrudniki selectedSotrudnik = (Sotrudniki)AdminDataGrid.SelectedItem;
                    selectedSotrudnik.Surname = NewValueTextBox1.Text; selectedSotrudnik.Namep = NewValueTextBox.Text; selectedSotrudnik.Dolznost = NewValueTextBox2.Text; selectedSotrudnik.RolesID = Convert.ToInt32(NewValueTextBox4.Text);
                    context.SaveChanges();
                    AdminDataGrid.ItemsSource = context.Sotrudniki.ToList();
                }
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (AdminDataGrid.SelectedItem != null)
            {
                if (currentTableName == "Roles")
                {
                    context.Roles.Remove(AdminDataGrid.SelectedItem as Roles);
                    context.SaveChanges();
                    ReadRolesTable();
                }
                else if (currentTableName == "Sotrudniki")
                {
                    context.Sotrudniki.Remove(AdminDataGrid.SelectedItem as Sotrudniki);
                    context.SaveChanges();
                    ReadSotrudnikiTable();
                }
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            string query = SearchTextBox.Text;
            Search(query);
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            ClearTextBoxes(this);
        }

        private void Search(string query)
        {
            if (currentTableName == "Roles")
            {
                AdminDataGrid.ItemsSource = context.Roles.Where(r => r.NameRoles.Contains(query)).ToList();
            }
            else if (currentTableName == "Sotrudniki")
            {
                AdminDataGrid.ItemsSource = context.Sotrudniki.Where(s => s.Namep.Contains(query) || s.Surname.Contains(query) || s.Dolznost.Contains(query)).ToList();
            }
        }

        private void ClearTextBoxes(DependencyObject obj)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                var child = VisualTreeHelper.GetChild(obj, i);
                if (child is TextBox textBox)
                {
                    textBox.Clear();
                }
                ClearTextBoxes(child);
            }
        }
    }
}
