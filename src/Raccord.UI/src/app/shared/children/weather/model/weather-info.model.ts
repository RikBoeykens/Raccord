import { BaseModel, LatLng } from '../../..';

export class WeatherInfo extends BaseModel {
  public date: Date;
  public summary: string;
  public icon: string;
  public temperatureLow: number;
  public temperatureLowTime: Date;
  public temperatureHigh: number;
  public temperatureHighTime: Date;
  public sunriseTime: Date;
  public sunsetTime: Date;
  public latLng: LatLng;

  constructor(obj?: {
    date: Date,
    summary: string,
    icon: string,
    temperatureLow: number,
    temperatureLowTime: Date,
    temperatureHigh: number,
    temperatureHighTime: Date,
    sunriseTime: Date,
    sunsetTime: Date,
    latLng: LatLng
  }) {
    super();
    if (obj) {
      this.date = obj.date;
      this.summary = obj.summary;
      this.icon = obj.icon;
      this.temperatureLow = obj.temperatureLow;
      this.temperatureLowTime = obj.temperatureLowTime;
      this.temperatureHigh = obj.temperatureHigh;
      this.temperatureHighTime = obj.temperatureHighTime;
      this.sunriseTime = obj.sunriseTime;
      this.sunsetTime = obj.sunsetTime;
      this.latLng = obj.latLng;
    }
  }
}
