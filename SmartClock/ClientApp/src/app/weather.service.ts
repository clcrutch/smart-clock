import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Subject, Observable } from 'rxjs';

export enum WeatherCondition {
  unknown = "Unknown",
  cloudy = "Cloudy",
  partlyCloudy = "PartlyCloudy",
  rainy = "Rainy",
  sunny = "Sunny"
}

export class WeatherForecast {
  condition: WeatherCondition;
  date: Date;
  temperature: number;
}

@Injectable({
  providedIn: 'root'
})
export class WeatherService {

  private weatherForecastSubject = new Subject<WeatherForecast[]>();
  weatherForecast: Observable<WeatherForecast[]>;

  constructor(private httpClient: HttpClient) {
    this.weatherForecast = this.weatherForecastSubject.asObservable();

    this.getWeather();
    setInterval(this.getWeather, 5 * 60 * 1000);
  }

  private getWeather() {
    this.httpClient.get('/api/weather').subscribe(x => this.weatherForecastSubject.next(x as any));
  }
}
