using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempControlAvaloniaUI.Model;

namespace TempControlAvaloniaUI.ViewModel
{
    internal class MainWindowViewModel:ViewModelBase
    {
        private double _currentTemperature;
        private double _currentHumidity;
        private double _currentPressure;
        private double _targetTemperature;
        private int _selectedTransportIndex;
        private bool _isAutoMode;
        public ObservableCollection<ClimateData> ClimateRecords { get; set; }

        public MainWindowViewModel()
        {
            using (var db = new ClimateDbContext())
            {
                // 2. Добавляем создание базы данных (тот самый предыдущий код)
                db.Database.EnsureCreated();

                // 3. Загружаем все сохраненные записи из базы данных в коллекцию для UI
                ClimateRecords = new ObservableCollection<ClimateData>(db.ClimateDatas.ToList());
            }
        }
        public double CurrentTemperature
        {
            get => _currentTemperature;
            set { _currentTemperature = value; OnPropertyChanged(); }
        }

        public double CurrentHumidity
        {
            get => _currentHumidity;
            set { _currentHumidity = value; OnPropertyChanged(); }
        }

        public double CurrentPressure
        {
            get => _currentPressure;
            set { _currentPressure = value; OnPropertyChanged(); }
        }

        public double TargetTemperature
        {
            get => _targetTemperature;
            set { _targetTemperature = value; OnPropertyChanged(); }
        }

        public int SelectedTransportIndex
        {
            get => _selectedTransportIndex;
            set { _selectedTransportIndex = value; OnPropertyChanged(); }
        }

        public bool IsAutoMode
        {
            get => _isAutoMode;
            set { _isAutoMode = value; OnPropertyChanged(); }
        }

        public void TurnOnRelay() { }
        public void TurnOffRelay() { }
    }
}
