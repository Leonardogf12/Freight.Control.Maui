using freight.control.maui.Components.Chart;
using freight.control.maui.Controls.Resources;
using freight.control.maui.MVVM.Base.ViewModels;
using freight.control.maui.Repositories;
using freight.control.maui.Services.Chart;
using Microcharts;

namespace freight.control.maui.MVVM.ViewModels
{
    public class ChartsViewModel : BaseViewModel
    {
        #region Properties

        private readonly FreightRepository _freightRespository;

        #region Chart Freight

        private Chart _freightChart;
        public Chart FreightChart
        {
            get => _freightChart;
            set
            {
                _freightChart = value;
                OnPropertyChanged();
            }
        }

        private ChartEntry[] _listFreightChartMonthlyBackup = new ChartEntry[0];
        public ChartEntry[] ListFreightChartMonthlyBackup
        {
            get => _listFreightChartMonthlyBackup;
            set
            {
                _listFreightChartMonthlyBackup = value;
                OnPropertyChanged();
            }
        }

        private ChartEntry[] _listFreightChartDailyBackup = new ChartEntry[0];
        public ChartEntry[] ListFreightChartDailyBackup
        {
            get => _listFreightChartDailyBackup;
            set
            {
                _listFreightChartDailyBackup = value;
                OnPropertyChanged();
            }
        }

        private double _widthLineChartFreight;
        public double WidthLineChartFreight
        {
            get => _widthLineChartFreight;
            set
            {
                _widthLineChartFreight = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Chart ToFuel

        private Chart _toFuelChart;
        public Chart ToFuelChart
        {
            get => _toFuelChart;
            set
            {
                _toFuelChart = value;
                OnPropertyChanged();
            }
        }

        private ChartEntry[] _listToFuelChartMonthlyBackup = new ChartEntry[0];
        public ChartEntry[] ListToFuelChartMonthlyBackup
        {
            get => _listToFuelChartMonthlyBackup;
            set
            {
                _listToFuelChartMonthlyBackup = value;
                OnPropertyChanged();
            }
        }

        private ChartEntry[] _listToFuelChartDailyBackup = new ChartEntry[0];
        public ChartEntry[] ListToFuelChartDailyBackup
        {
            get => _listToFuelChartDailyBackup;
            set
            {
                _listToFuelChartDailyBackup = value;
                OnPropertyChanged();
            }
        }

        private double _widthLineChartToFuel;
        public double WidthLineChartToFuel
        {
            get => _widthLineChartToFuel;
            set
            {
                _widthLineChartToFuel = value;
                OnPropertyChanged();
            }
        }

        #endregion

        private Style _monthButtonStyle = ControlResources.GetResource<Style>("buttonDarkLightFilterSecondary");
        public Style MonthButtonStyle
        {
            get => _monthButtonStyle;
            set
            {
                _monthButtonStyle = value;
                OnPropertyChanged();
            }
        }

        private Style _dayButtonStyle = ControlResources.GetResource<Style>("buttonDarkLightFilterPrimary");
        public Style DayButtonStyle
        {
            get => _dayButtonStyle;
            set
            {
                _dayButtonStyle = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public ChartsViewModel()
        {
            _freightRespository = new();
        }

        #region Public methods

        #region Freight Chart

        public async Task LoadEntriesFreightChartMonthly()
        {
            IsBusy = true;

            try
            {
                if (ListFreightChartMonthlyBackup.Length > 0)
                {
                    LoadFreightChartEntriesWithListsBackup(chartEntries: ListFreightChartMonthlyBackup);
                    SetWidthRequestToFreightChart(length: ListFreightChartMonthlyBackup.Length);
                    return;
                }

                var list = await _freightRespository.GetByDateInitialAndFinal(initial: GetFirstDayOfCurrentYear(), final: GetLastDayOfCurrentYear());

                var instanceChartService = MyInterfaceFactoryChartService.CreateInstance();

                ListFreightChartMonthlyBackup = instanceChartService.GenerateLineChartFreightMonthly(list);
                
                SetWidthRequestToFreightChart(length: ListFreightChartMonthlyBackup.Length);

                FreightChart = ChartStyleCustom.GetLineChartCustom(ListFreightChartMonthlyBackup);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task LoadEntriesFreightChartsDaily()
        {
            IsBusy = true;

            try
            {
                if (ListFreightChartDailyBackup.Count() > 0)
                {
                    LoadFreightChartEntriesWithListsBackup(chartEntries: ListFreightChartDailyBackup);
                    SetWidthRequestToFreightChart(length: ListFreightChartDailyBackup.Length);
                    return;
                }

                var list = await _freightRespository.GetByDateInitialAndFinal(initial: GetFirstDayOfCurrentYear(), final: GetLastDayOfCurrentYear());

                var instanceChartService = MyInterfaceFactoryChartService.CreateInstance();

                ListFreightChartDailyBackup = instanceChartService.GenerateLineChartFreightDaily(list);
                 
                SetWidthRequestToFreightChart(length: ListFreightChartDailyBackup.Length);

                FreightChart = ChartStyleCustom.GetLineChartCustom(ListFreightChartDailyBackup);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        #endregion

        #region ToFuel Chart

        public async Task LoadEntriesToFuelChartMonthly()
        {
            IsBusy = true;

            try
            {
                if (ListToFuelChartMonthlyBackup.Length > 0)
                {
                    LoadToFuelChartEntriesWithListsBackup(chartEntries: ListToFuelChartMonthlyBackup);
                    SetWidthRequestToFuelChart(length: ListToFuelChartMonthlyBackup.Length);
                    return;
                }

                var list = await _freightRespository.GetByDateInitialAndFinal(initial: GetFirstDayOfCurrentYear(), final: GetLastDayOfCurrentYear());

                var instanceChartService = MyInterfaceFactoryChartService.CreateInstance();

                ListToFuelChartMonthlyBackup = await instanceChartService.GenerateLineChartToFuelMonthly(list);
                 
                SetWidthRequestToFuelChart(length: ListToFuelChartMonthlyBackup.Length);

                ToFuelChart = ChartStyleCustom.GetLineChartCustom(ListToFuelChartMonthlyBackup);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task LoadEntriesToFuelChartsDaily()
        {
            IsBusy = true;

            try
            {
                if (ListToFuelChartDailyBackup.Length > 0)
                {
                    LoadToFuelChartEntriesWithListsBackup(chartEntries: ListToFuelChartDailyBackup);
                    SetWidthRequestToFuelChart(length: ListToFuelChartDailyBackup.Length);
                    return;
                }

                var list = await _freightRespository.GetByDateInitialAndFinal(initial: GetFirstDayOfCurrentYear(), final: GetLastDayOfCurrentYear());

                var instanceChartService = MyInterfaceFactoryChartService.CreateInstance();

                ListToFuelChartDailyBackup = await instanceChartService.GenerateLineChartToFuelDaily(list);

                SetWidthRequestToFuelChart(length: ListToFuelChartDailyBackup.Length);

                ToFuelChart = ChartStyleCustom.GetLineChartCustom(ListToFuelChartDailyBackup);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        #endregion

        #endregion

        #region Private methods

        private void LoadFreightChartEntriesWithListsBackup(ChartEntry[] chartEntries)
        {
            FreightChart = ChartStyleCustom.GetLineChartCustom(chartEntries);
        }

        private void LoadToFuelChartEntriesWithListsBackup(ChartEntry[] chartEntries)
        {
            ToFuelChart = ChartStyleCustom.GetLineChartCustom(chartEntries);
        }

        private void SetWidthRequestToFreightChart(int length)
        {
            var displayInfo = DeviceDisplay.MainDisplayInfo;
            double screenWidthPixels = displayInfo.Width / displayInfo.Density;

            var calc = length * 100 - 100;

            WidthLineChartFreight = calc > screenWidthPixels ? calc : screenWidthPixels;
        }

        private void SetWidthRequestToFuelChart(int length)
        {
            var displayInfo = DeviceDisplay.MainDisplayInfo;
            double screenWidthPixels = displayInfo.Width / displayInfo.Density;

            var calc = length * 100 - 100;

            WidthLineChartToFuel = calc > screenWidthPixels ? calc : screenWidthPixels;
        }

        private DateTime GetFirstDayOfCurrentYear() => new DateTime(DateTime.Now.Year, 01, 01);

        private DateTime GetLastDayOfCurrentYear() => new DateTime(DateTime.Now.Year, 12, 31);

        #endregion
    }
}