using freight.control.maui.Components.Chart;
using freight.control.maui.MVVM.Base.ViewModels;
using freight.control.maui.Repositories;
using freight.control.maui.Services.Chart;
using Microcharts;

namespace freight.control.maui.MVVM.ViewModels;

public class ChartsViewModel : BaseViewModel
{
    #region Properties
   
    private readonly FreightRepository _freightRespository;
     
    private ChartEntry[] _freightChartEntries;
    public ChartEntry[] FreightChartEntries
    {
        get => _freightChartEntries;
        set
        {
            _freightChartEntries = value;
            OnPropertyChanged();
        }
    }

    private Chart _freightChart;
    public Chart FreightChart
    {
        get { return _freightChart; }
        set
        {
            _freightChart = value;
            OnPropertyChanged(nameof(FreightChart));
        }
    }
   
    private Style _yearButtonStyle = App.GetResource<Style>("buttonDarkLightFilterSecondary");
    public Style YearButtonStyle
    {
        get => _yearButtonStyle;
        set
        {
            _yearButtonStyle = value;
            OnPropertyChanged();
        }

    }

    private Style _mounthButtonStyle = App.GetResource<Style>("buttonDarkLightFilterPrimary");
    public Style MounthButtonStyle
	{
		get => _mounthButtonStyle;
		set
		{
			_mounthButtonStyle = value;
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

    public ChartsViewModel()
	{
        _freightRespository = new();      
    }

    public async Task LoadEntrysToCharts()
    {
        IsBusy = true;

        try
        {
            var annualList = await _freightRespository.GetByDateInitialAndFinal(initial: new DateTime(DateTime.Now.Year, 01, 01), final: new DateTime(DateTime.Now.Year, 12, 31));
         
            var instanceChartService = MyInterfaceFactoryChartService.CreateInstance();
          
            var lineChartFreight = instanceChartService.GenerateLineChartFreight(annualList);

            SetWidthRequestToFreightChart(count: lineChartFreight.Count());
            
            FreightChartEntries = lineChartFreight;

            FreightChart = ChartStyleCustom.GetLineChartCustom(FreightChartEntries);
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

    private void SetWidthRequestToFreightChart(int count)
    {
        var displayInfo = DeviceDisplay.MainDisplayInfo;
        double screenWidthPixels = displayInfo.Width / displayInfo.Density;

        var calc = count * 100 - 100;

        WidthLineChartFreight = calc > screenWidthPixels ? calc : screenWidthPixels;
    }
}
