using Candidate_BussinessObject;
using Candidate_Service;
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

namespace CandidateManagement_WPF
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private IHRAccountService hrAccountService;
        public Login()
        {
            InitializeComponent();
            hrAccountService = new HRAccountService();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            Hraccount hraccount = hrAccountService.GetHraccountByEmail(EmailTxt.Text);
            if (hraccount != null && hraccount.Password.Equals(PwdTxt.Password)) 
            {
                MessageBox.Show($"Hello {hraccount.FullName}");
                MainWindow mainWindow = new MainWindow(hraccount.MemberRole.Value);
                this.Close();
                mainWindow.Show();
            }
            else
            {
                MessageBox.Show("You are not allowed to do this function!");
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
