using PRG1_MAUI_ERP_Activum.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows.Input;

namespace PRG1_MAUI_ERP_Activum.ViewModels
{
    public class InsuranceViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private ObservableCollection<Insurance> _allInsurances = new();
        private ObservableCollection<Insurance> _displayInsurances = new();

        public ObservableCollection<Insurance> DisplayInsurances
        {
            get => _displayInsurances;
            set
            {
                _displayInsurances = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DisplayInsurances)));
            }
        }

        public string? NewInsuranceType { get; set; }
        public string? NewPremium { get; set; }
        public string? NewStatus { get; set; }
        public string? NewCustomerId { get; set; }

        public ICommand AddInsuranceCommand { get; }
        public ICommand RemoveInsuranceCommand { get; }
        public ICommand SearchCommand { get; }

        public InsuranceViewModel()
        {
            _allInsurances = new ObservableCollection<Insurance>
            {
                new Insurance { InsuranceType = "Bilförsäkring", Premium = 5000, Status = "Aktiv", StartDate = DateTime.Now.AddMonths(-5), CustomerId = "19900101"},
                new Insurance { InsuranceType = "Hemförsäkring", Premium = 2500, Status = "Aktiv", StartDate = DateTime.Now.AddYears(-2), CustomerId = "19850505"}
            };


            DisplayInsurances = new ObservableCollection<Insurance>(_allInsurances);

            AddInsuranceCommand = new Command(() =>
                {
                    if (!string.IsNullOrWhiteSpace(NewInsuranceType) && double.TryParse(NewPremium, out double premiumValue))
                    {
                        var newInsurance = new Insurance
                        {
                            InsuranceType = NewInsuranceType,
                            Premium = premiumValue,
                            Status = string.IsNullOrWhiteSpace(NewStatus) ? "Aktiv" : NewStatus,
                            StartDate = DateTime.Now,
                            CustomerId = NewCustomerId ?? "Okänd"
                        };
                        _allInsurances.Add(newInsurance);
                        DisplayInsurances.Add(newInsurance);
                    }
                });
            RemoveInsuranceCommand = new Command<Insurance>((insurance) =>
                {
                    if (insurance != null)
                    {
                        _allInsurances.Remove(insurance);
                        DisplayInsurances.Remove(insurance);
                    }
                });

            SearchCommand = new Command<string>((searchText) =>
            {
                if (string.IsNullOrWhiteSpace(searchText))
                {
                    DisplayInsurances = new ObservableCollection<Insurance>(_allInsurances);
                }
                else
                {
                    var filtered = _allInsurances.Where(i =>
                    (i.InsuranceType != null && i.InsuranceType.ToLower().Contains(searchText.ToLower())) ||
                    (i.CustomerId != null && i.CustomerId.Contains(searchText))
                    ).ToList();

                    DisplayInsurances = new ObservableCollection<Insurance>(filtered);
                }
            });
        }
    }
}