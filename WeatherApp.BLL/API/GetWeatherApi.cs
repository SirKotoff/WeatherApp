using Newtonsoft.Json;
using System.Net;

namespace WeatherApp.BLL.API;

public class GetWeatherApi
{
    public string GetWeather(string uri, string city)
    {
        string response = "";

        if (string.IsNullOrEmpty(city))
        {
            throw new ArgumentNullException("uri");
        }

        HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);

        HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();


        using (StreamReader sr = new StreamReader(httpWebResponse.GetResponseStream()))
        {
            response = sr.ReadToEnd();
        }

        WeatherResponse weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(response);

        Console.WriteLine(response);
        return new string($"{weatherResponse.Main.temp.ToString()}\n{weatherResponse.weather[0].main.ToString()}");
    }
}