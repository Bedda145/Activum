using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using PRG1_MAUI_ERP_Activum.Models;

namespace PRG1_MAUI_ERP_Activum.ViewModels
{
    public class CustomerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private ObservableCollection<Customer> _allCustomers = new();

        private ObservableCollection<Customer> _displayCustomers = new();
        public ObservableCollection<Customer> DisplayCustomers
        {
            get => _displayCustomers;
            set
            {
                _displayCustomers = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DisplayCustomers)));
            }
        }
        public string? NewFirstName { get; set; }
        public string? NewLastName { get; set; }
        public string? NewPersonalNumber { get; set; }
        public string? NewEmail { get; set; }
        public string? NewPhoneNumber { get; set; }

        public ICommand AddCustomerCommand { get; }
        public ICommand RemoveCustomerCommand { get; }
        public ICommand SearchCommand { get; }

        public CustomerViewModel()
        {
            _allCustomers = new ObservableCollection<Customer>
            {
                new Customer { FirstName = "Anna", LastName = "Andersson", PersonalNumber = "19900101-1234", Email = "anna@gmail.com", PhoneNumber = "070-1234567" },
                new Customer { FirstName = "Bertil", LastName = "Bentsson", PersonalNumber = "19850505-5678", Email = "bertil@gmail.com", PhoneNumber = "070-7654321" }
            };

            DisplayCustomers = new ObservableCollection<Customer>(_allCustomers);

            AddCustomerCommand = new Command(() =>
            {
                if (!string.IsNullOrWhiteSpace(NewFirstName) && !string.IsNullOrWhiteSpace(NewLastName))
                {
                    var newCustomer = new Customer
                    {
                        FirstName = NewFirstName,
                        LastName = NewLastName,
                        PersonalNumber = NewPersonalNumber,
                        Email = NewEmail,
                        PhoneNumber = NewPhoneNumber
                    };
                    _allCustomers.Add(newCustomer);
                    DisplayCustomers.Add(newCustomer);
                }
            });

            RemoveCustomerCommand = new Command<Customer>((customer) =>
            {
                if (customer != null)
                {
                    _allCustomers.Remove(customer);
                    DisplayCustomers.Remove(customer);
                }
            });

            SearchCommand = new Command<string>((searchText) =>
            {
                if (string.IsNullOrWhiteSpace(searchText))
                {
                    DisplayCustomers = new ObservableCollection<Customer>(_allCustomers);
                }
                else
                {
                    var filtered = _allCustomers.Where(c =>
                    c.FullName.ToLower().Contains(searchText.ToLower()) ||
                    c.PersonalNumber.Contains(searchText)).ToList();

                    DisplayCustomers = new ObservableCollection<Customer>(filtered);
                }
            });
        }
    }
}