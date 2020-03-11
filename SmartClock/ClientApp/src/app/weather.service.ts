import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Subject, Observable } from 'rxjs';
import { InfoService } from './info.service';

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

  constructor(private httpClient: HttpClient,
              private infoService: InfoService) {
    this.weatherForecast = this.weatherForecastSubject.asObservable();

    this.getWeather();
    this.infoService.getVersion();
    setInterval(() => this.getWeather(), 5 * 60 * 1000);
  }

  private getWeather() {
    console.log('weather');

    this.httpClient.get('/api/weather').subscribe(x => this.weatherForecastSubject.next(x as any));
  }
}
