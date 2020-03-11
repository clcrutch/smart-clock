import { Component, OnInit } from '@angular/core';
import { WeatherService, WeatherForecast } from '../weather.service';

@Component({
  selector: 'app-weather',
  templateUrl: './weather.component.html',
  styleUrls: ['./weather.component.scss']
})
export class WeatherComponent implements OnInit {

  forecast: WeatherForecast = new WeatherForecast();

  constructor(private weatherService: WeatherService) { }

  ngOnInit(): void {
    this.weatherService.weatherForecast.subscribe(x => {
      this.forecast = x[0];
    });
  }

}
