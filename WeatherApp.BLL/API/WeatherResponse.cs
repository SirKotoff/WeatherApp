namespace WeatherApp.BLL.API;

public class WeatherResponse
{
    public TemperatureInfo Main { get; set; }
    public TemperatureInfo[] weather { get; set; }

    public string Name { get; set; }
}