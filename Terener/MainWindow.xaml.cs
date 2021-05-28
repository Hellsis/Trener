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

namespace Terener
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static TrenerEntities db = new TrenerEntities();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var client = new clients();
            client.LastName = LN.Text;
            client.MiddleName = MN.Text;
            client.FirstName = FN.Text;
            client.Phone = P.Text;
            client.Email = E.Text;
            db.clients.Add(client);
            db.SaveChanges();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int idInt = Convert.ToInt32(Id.Text);
            var client = db.clients.Where(p => p.Id == idInt).FirstOrDefault();
            db.clients.Remove(client);
            db.SaveChanges();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int idInt = Convert.ToInt32(Id.Text);
            var client = db.clients.Where(p => p.Id == idInt).FirstOrDefault();
            if(FN.Text != "")
            {
                client.FirstName = FN.Text; 
            }
            if (MN.Text != "")
            {
                client.MiddleName = MN.Text;
            }
            if (LN.Text != "")
            {
                client.LastName = LN.Text;
            }
            if (P.Text != "")
            {
                client.Phone = P.Text;
            }
            if (E.Text != "")
            {
                client.Email = E.Text;
            }
            db.SaveChanges();
        }
    }
}
