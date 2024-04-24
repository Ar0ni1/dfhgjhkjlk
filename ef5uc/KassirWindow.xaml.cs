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
using System.Xml.Linq;

namespace ef5uc
{
    /// <summary>
    /// Логика взаимодействия для KassirWindow.xaml
    /// </summary>
    public partial class KassirWindow : Window
    {
        private SalavaClubEntities context = new SalavaClubEntities();
        private string currentTableName;
        public KassirWindow()
        {
            InitializeComponent();
        }
        private void readproduct()
        {
            currentTableName = "Tovari";
            KassirDataGrid.ItemsSource = context.Tovari.ToList();

            KassirDataGrid.Columns.Clear();
            KassirDataGrid.Columns.Add(new DataGridTextColumn { Header = "ID", Binding = new Binding("TOvariID") });
            KassirDataGrid.Columns.Add(new DataGridTextColumn { Header = "Название товара", Binding = new Binding("NameTovara") });
            KassirDataGrid.Columns.Add(new DataGridTextColumn { Header = "Цена товара", Binding = new Binding("PriceUnit") });
            KassirDataGrid.Columns.Add(new DataGridTextColumn { Header = "В наличии", Binding = new Binding("inStock") });
            KassirDataGrid.Columns.Add(new DataGridTextColumn { Header = "ID категории товара", Binding = new Binding("KAtegoriaTovaraID") });
            KassirDataGrid.Columns.Add(new DataGridTextColumn { Header = "ID Корзины", Binding = new Binding("KorzinaID") });
        }
        private void readOrders()
        {
            currentTableName = "Orders";
            KassirDataGrid.ItemsSource = context.Orders.ToList();

            KassirDataGrid.Columns.Clear();
            KassirDataGrid.Columns.Add(new DataGridTextColumn { Header = "ID", Binding = new Binding("OrdersID") });
            KassirDataGrid.Columns.Add(new DataGridTextColumn { Header = "Дата заказа", Binding = new Binding("DateOrders") });
            
        }
        private void readKAtegoriiTovara()
        {
            currentTableName = "KAtegoriaTovara";
            KassirDataGrid.ItemsSource = context.KAtegoriaTovara.ToList();

            KassirDataGrid.Columns.Clear();
            KassirDataGrid.Columns.Add(new DataGridTextColumn { Header = "ID", Binding = new Binding("KAtegoriaTovaraID") });
            KassirDataGrid.Columns.Add(new DataGridTextColumn { Header = "Название категории", Binding = new Binding("NazvanieKAtegorii") });
        }
        private void readPokupateli()
        {
            currentTableName = "Pokupatel";
            KassirDataGrid.ItemsSource = context.Pokupatel.ToList();

            KassirDataGrid.Columns.Clear();
            KassirDataGrid.Columns.Add(new DataGridTextColumn { Header = "ID", Binding = new Binding("PokupatelID") });
            KassirDataGrid.Columns.Add(new DataGridTextColumn { Header = "Имя", Binding = new Binding("Namep") });
            KassirDataGrid.Columns.Add(new DataGridTextColumn { Header = "Фамилия", Binding = new Binding("Surname") });
            KassirDataGrid.Columns.Add(new DataGridTextColumn { Header = "Email", Binding = new Binding("Email") });
            KassirDataGrid.Columns.Add(new DataGridTextColumn { Header = "Адрес", Binding = new Binding("Adresses") });
        }
        private void readCheckcsinf()
        {
            currentTableName = "ChecksInfo";
            KassirDataGrid.ItemsSource = context.ChecksInfo.ToList();

            KassirDataGrid.Columns.Clear();
            KassirDataGrid.Columns.Add(new DataGridTextColumn { Header = "ID", Binding = new Binding("ChecksInfolID") });
            KassirDataGrid.Columns.Add(new DataGridTextColumn { Header = "Адрес", Binding = new Binding("Adresses") });
            KassirDataGrid.Columns.Add(new DataGridTextColumn { Header = "Суммарная цена", Binding = new Binding("SummaryPrice") });
            KassirDataGrid.Columns.Add(new DataGridTextColumn { Header = "Время", Binding = new Binding("Times") });
        }
        private void readKorzina()
        {
            currentTableName = "Korzina";
            KassirDataGrid.ItemsSource = context.Korzina.ToList();

            KassirDataGrid.Columns.Clear();
            KassirDataGrid.Columns.Add(new DataGridTextColumn { Header = "ID", Binding = new Binding("KorzinaID") });
            KassirDataGrid.Columns.Add(new DataGridTextColumn { Header = "ID заказа", Binding = new Binding("OrdersID") });
            KassirDataGrid.Columns.Add(new DataGridTextColumn { Header = "Количество", Binding = new Binding("Kollichestvo") });
            KassirDataGrid.Columns.Add(new DataGridTextColumn { Header = "Цена", Binding = new Binding("PriceUnit") });
            KassirDataGrid.Columns.Add(new DataGridTextColumn { Header = "ID сотрудника", Binding = new Binding("SotrudnikiID") });
        }
        private void readVozvratTovara()
        {
            currentTableName = "VozvratTovara";
            KassirDataGrid.ItemsSource = context.VozvratTovara.ToList();

            KassirDataGrid.Columns.Clear();
            KassirDataGrid.Columns.Add(new DataGridTextColumn { Header = "ID", Binding = new Binding("VozvratTovaraID") });
            KassirDataGrid.Columns.Add(new DataGridTextColumn { Header = "ID заказа", Binding = new Binding("ReasonVozvrata") });
        }
        private void readChecks()
        {
            currentTableName = "Checks";
            KassirDataGrid.ItemsSource = context.Checks.ToList();

            KassirDataGrid.Columns.Clear();
            KassirDataGrid.Columns.Add(new DataGridTextColumn { Header = "ID", Binding = new Binding("ChecksID") });
            KassirDataGrid.Columns.Add(new DataGridTextColumn { Header = "ID товара", Binding = new Binding("TovatiID") });
            KassirDataGrid.Columns.Add(new DataGridTextColumn { Header = "ID информации о чеке", Binding = new Binding("ChecksInfoID") });
        }
        private void Products_Click(object sender, RoutedEventArgs e)
        {
            readproduct();
        }
        private void Orders_Click(object sender, RoutedEventArgs e)
        {
            readOrders();
        }
        private void ProductCategories_Click(object sender, RoutedEventArgs e)
        {
            readKAtegoriiTovara();
        }
        private void Customers_Click(object sender, RoutedEventArgs e)
        {
            readPokupateli();
        }
        private void OrderDetails(object sender, RoutedEventArgs e)
        {
            readCheckcsinf();
        }
        private void Korzina(object sender, RoutedEventArgs e)
        {
            readKorzina();
        }
        private void Returns(object sender, RoutedEventArgs e)
        {
            readVozvratTovara();
        }
        private void Checks(object sender, RoutedEventArgs e)
        {
            readChecks();
        }
        private void add(object sender, EventArgs e)
        {
            if (currentTableName == "Tovari")
            {
                Tovari newTovati = new Tovari { NameTovara = NewVAlueTbx.Text,PriceUnit = Convert.ToInt32 (NewVAlueTbx2.Text), inStock = Convert.ToInt32(NewVAlueTbx3.Text), KAtegoriaTovaraID = Convert.ToInt32(NewVAlueTbx4.Text), KorzinaID = Convert.ToInt32(NewVAlueTbx5.Text)};
                context.Tovari.Add(newTovati);
                context.SaveChanges();
                readproduct();
            }
            else if (currentTableName == "Orders")
            {
                Orders newOrders = new Orders { DateOrders = NewVAlueTbx.Text, PokupatelID = Convert.ToInt32(NewVAlueTbx2.Text), VozvratTovaraID = Convert.ToInt32(NewVAlueTbx3.Text) };
                context.Orders.Add(newOrders);
                context.SaveChanges();
                readOrders();
            }
            else if (currentTableName == "KAtegoriaTovara")
            {
                KAtegoriaTovara newKat = new KAtegoriaTovara { NazvanieKAtegorii = NewVAlueTbx.Text };
                context.KAtegoriaTovara.Add(newKat);
                context.SaveChanges();
                readOrders();
            }
            else if (currentTableName == "Pokupatel")
            {
                Pokupatel newPOk = new Pokupatel { Namep = NewVAlueTbx.Text, Surname = NewVAlueTbx2.Text, Email = NewVAlueTbx3.Text, Adresses = NewVAlueTbx4.Text };
                context.Pokupatel.Add(newPOk);
                context.SaveChanges();
                readOrders();
            }
            else if (currentTableName == "ChecksInfo")
            {
                ChecksInfo newinf = new ChecksInfo { Adresses = NewVAlueTbx.Text, SummaryPrice = Convert.ToInt32(NewVAlueTbx2.Text), Times = Convert.ToInt32(NewVAlueTbx3.Text) };
                context.ChecksInfo.Add(newinf);
                context.SaveChanges();
                readOrders();
            }
            else if (currentTableName == "Korzina")
            {
                Korzina newKor = new Korzina { Kollichestvo = Convert.ToInt32(NewVAlueTbx2.Text), OrdersID = Convert.ToInt32(NewVAlueTbx.Text),PriceUnit = Convert.ToInt32(NewVAlueTbx3.Text ),SotrudnikiID =Convert.ToInt32(NewVAlueTbx4.Text) };
                context.Korzina.Add(newKor);
                context.SaveChanges();
                readOrders();
            }
            else if (currentTableName == "VozvratTovara")
            {
                VozvratTovara newvoz = new VozvratTovara { ReasonVozvrata = NewVAlueTbx.Text };
                context.VozvratTovara.Add(newvoz);
                context.SaveChanges();
                readOrders();
            }
            else if (currentTableName == "Checks")
            {
                Checks newch = new Checks { TovatiID = Convert.ToInt32( NewVAlueTbx.Text), ChecksInfoID = Convert.ToInt32(NewVAlueTbx2.Text) };
                context.Checks.Add(newch);
                context.SaveChanges();
                readOrders();
            }
        }

        private void edit(object sender, EventArgs e)
        {
            if (KassirDataGrid.SelectedItem != null)
            {
                if (currentTableName == "Tovari")
                {
                    Tovari selectedT = (Tovari)KassirDataGrid.SelectedItem;
                    selectedT.NameTovara = NewVAlueTbx.Text; selectedT.PriceUnit = Convert.ToInt32(NewVAlueTbx2.Text); selectedT.inStock = Convert.ToInt32(NewVAlueTbx3.Text);  selectedT.KAtegoriaTovaraID = Convert.ToInt32(NewVAlueTbx4.Text); selectedT.KorzinaID = Convert.ToInt32(NewVAlueTbx5.Text);
                    context.SaveChanges();
                    KassirDataGrid.ItemsSource = context.Tovari.ToList();
                }
                else if (currentTableName == "Orders")
                {
                    Orders selectedO = (Orders)KassirDataGrid.SelectedItem;
                    selectedO.DateOrders = NewVAlueTbx.Text;
                    context.SaveChanges();
                    KassirDataGrid.ItemsSource = context.Orders.ToList();
                }
                else if (currentTableName == "KAtegoriaTovara")
                {
                    KAtegoriaTovara selectedNAz = (KAtegoriaTovara)KassirDataGrid.SelectedItem;
                    selectedNAz.NazvanieKAtegorii = NewVAlueTbx.Text;
                    context.SaveChanges();
                    KassirDataGrid.ItemsSource = context.KAtegoriaTovara.ToList();
                }
                else if (currentTableName == "Pokupatel")
                {
                    Pokupatel selectedPoc = (Pokupatel)KassirDataGrid.SelectedItem;
                    selectedPoc.Namep = NewVAlueTbx.Text; selectedPoc.Surname = NewVAlueTbx2.Text; selectedPoc.Email = NewVAlueTbx3.Text; selectedPoc.Adresses = NewVAlueTbx4.Text;
                    context.SaveChanges();
                    KassirDataGrid.ItemsSource = context.Pokupatel.ToList();
                }
                else if (currentTableName == "ChecksInfo")
                {
                    ChecksInfo selectedCHIF = (ChecksInfo)KassirDataGrid.SelectedItem;
                    selectedCHIF.Adresses = NewVAlueTbx.Text; selectedCHIF.SummaryPrice = Convert.ToInt32(NewVAlueTbx2.Text); selectedCHIF.Times = Convert.ToInt32(NewVAlueTbx3.Text);
                    context.SaveChanges();
                    KassirDataGrid.ItemsSource = context.ChecksInfo.ToList();
                }
                else if (currentTableName == "Korzina")
                {
                    Korzina selectedKOr = (Korzina)KassirDataGrid.SelectedItem;
                    selectedKOr.Kollichestvo = Convert.ToInt32(NewVAlueTbx.Text); selectedKOr.OrdersID = Convert.ToInt32(NewVAlueTbx.Text); selectedKOr.PriceUnit = Convert.ToInt32(NewVAlueTbx3.Text); selectedKOr.SotrudnikiID = Convert.ToInt32(NewVAlueTbx4.Text);
                    context.SaveChanges();
                    KassirDataGrid.ItemsSource = context.Korzina.ToList();
                }
                else if (currentTableName == "VozvratTovara")
                {
                    VozvratTovara selectedVoz = (VozvratTovara)KassirDataGrid.SelectedItem;
                    selectedVoz.ReasonVozvrata = NewVAlueTbx.Text;
                    context.SaveChanges();
                    KassirDataGrid.ItemsSource = context.VozvratTovara.ToList();
                }
                else if (currentTableName == "Checks")
                {
                    Checks selectedChec = (Checks)KassirDataGrid.SelectedItem;
                    selectedChec.TovatiID =Convert.ToInt32 (NewVAlueTbx.Text); selectedChec.TovatiID = Convert.ToInt32(NewVAlueTbx.Text); selectedChec.ChecksInfoID = Convert.ToInt32(NewVAlueTbx2.Text);
                    context.SaveChanges();
                    KassirDataGrid.ItemsSource = context.Checks.ToList();
                }
            }
        }

        private void delete(object sender, EventArgs e)
        {
            if (KassirDataGrid.SelectedItem != null)
            {
                if (currentTableName == "Tovari")
                {
                    context.Tovari.Remove(KassirDataGrid.SelectedItem as Tovari);
                    context.SaveChanges();
                    readproduct();
                }
                else if (currentTableName == "Orders")
                {
                    context.Orders.Remove(KassirDataGrid.SelectedItem as Orders);
                    context.SaveChanges();
                    readOrders();
                }
                else if (currentTableName == "KAtegoriaTovara")
                {
                    context.KAtegoriaTovara.Remove(KassirDataGrid.SelectedItem as KAtegoriaTovara);
                    context.SaveChanges();
                    readOrders();
                }
                else if (currentTableName == "Pokupatel")
                {
                    context.Pokupatel.Remove(KassirDataGrid.SelectedItem as Pokupatel);
                    context.SaveChanges();
                    readOrders();
                }
                else if (currentTableName == "ChecksInfo")
                {
                    context.ChecksInfo.Remove(KassirDataGrid.SelectedItem as ChecksInfo);
                    context.SaveChanges();
                    readOrders();
                }
                else if (currentTableName == "Korzina")
                {
                    context.Korzina.Remove(KassirDataGrid.SelectedItem as Korzina);
                    context.SaveChanges();
                    readOrders();
                }
                else if (currentTableName == "VozvratTovara")
                {
                    context.VozvratTovara.Remove(KassirDataGrid.SelectedItem as VozvratTovara);
                    context.SaveChanges();
                    readOrders();
                }
                else if (currentTableName == "Checks")
                {
                    context.Checks.Remove(KassirDataGrid.SelectedItem as Checks);
                    context.SaveChanges();
                    readOrders();
                }
            }
        }

    }
}
