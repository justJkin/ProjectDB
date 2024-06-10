using System.Linq;
using System.Windows;
using financialApp.Interfaces;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using financialApp.Views;

namespace financialApp.Views
{
    public partial class UserDashboard : Window, INotifyPropertyChanged
    {
        private readonly IUserService _userService;
        private decimal _totalBalance;
        private decimal _totalExpenses;
        private decimal _totalSavings;
        private decimal _totalTransactionsAmount;
        private string _username;
        private string _email;
        private int _userId;

        public event PropertyChangedEventHandler PropertyChanged;

        public decimal TotalBalance
        {
            get { return _totalBalance; }
            set { _totalBalance = value; OnPropertyChanged(); }
        }

        public decimal TotalExpenses
        {
            get { return _totalExpenses; }
            set { _totalExpenses = value; OnPropertyChanged(); }
        }

        public decimal TotalSavings
        {
            get { return _totalSavings; }
            set { _totalSavings = value; OnPropertyChanged(); }
        }

        public decimal TotalTransactionsAmount
        {
            get { return _totalTransactionsAmount; }
            set { _totalTransactionsAmount = value; OnPropertyChanged(); }
        }

        public string Username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged(); }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged(); }
        }

        public UserDashboard(IUserService userService, int userId)
        {
            InitializeComponent();
            DataContext = this;
            _userService = userService;
            _userId = userId;

            LoadDashboardData();
        }

        private void LoadDashboardData()
        {
            TotalBalance = _userService.GetTotalBalance(_userId);
            TotalExpenses = _userService.GetTotalExpenses(_userId);
            TotalSavings = _userService.GetTotalSavings(_userId);
            Username = _userService.GetUsername(_userId);
            Email = _userService.GetEmail(_userId);
            TotalTransactionsAmount = _userService.GetUserTransactions(_userId).Sum(t => t.Amount);
        }

        private void ViewTransactions_Click(object sender, RoutedEventArgs e)
        {
            // Otwórz widok transakcji
            //var transactionsWindow = new TransactionsWindow(_userService, _userId);
            //transactionsWindow.Show();
        }

        private void ViewSavingGoals_Click(object sender, RoutedEventArgs e)
        {
            // Otwórz widok celów oszczędnościowych
            //var savingGoalsWindow = new SavingGoalsWindow(_userService, _userId);
            //savingGoalsWindow.Show();
        }

        private void ViewReports_Click(object sender, RoutedEventArgs e)
        {
            // Otwórz widok raportów
            //var reportsWindow = new ReportsWindow(_userService, _userId);
            //reportsWindow.Show();
        }

        private void ViewReminders_Click(object sender, RoutedEventArgs e)
        {
            // Otwórz widok przypomnień
            //var remindersWindow = new RemindersWindow(_userService, _userId);
            //remindersWindow.Show();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new LoginWindow(_userService);
            loginWindow.Show();
            this.Close();
        }

        private void AddIncomes_Click(object sender, RoutedEventArgs e)
        {
            var addIncomeWindow = new AddIncomeWindow();
            if (addIncomeWindow.ShowDialog() == true)
            {
                decimal newIncomeAmount = addIncomeWindow.IncomeAmount;
                // Logika dodawania przychodów, np. aktualizacja bazy danych
                MessageBox.Show($"Income added: {newIncomeAmount}", "Income Added", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void AddSpendings_Click(object sender, RoutedEventArgs e)
        {
            // Logika dodawania wydatków
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
