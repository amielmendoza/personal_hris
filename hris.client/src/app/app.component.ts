import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

@Component({
  selector: 'app-root',
  // template: '<router-outlet />',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {
  public forecasts: WeatherForecast[] = [];
  isAuthenticated: boolean = false;
  constructor(private http: HttpClient) {}

  ngOnInit() {
  }

  title = 'hris.client';
}
