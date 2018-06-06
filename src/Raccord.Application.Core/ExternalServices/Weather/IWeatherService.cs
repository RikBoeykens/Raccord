namespace Raccord.Application.Core.ExternalServices.Weather
{
  public interface IWeatherService
  {
    WeatherInfoDto GetWeatherInfo(WeatherRequestDto requestDto);
  }
}