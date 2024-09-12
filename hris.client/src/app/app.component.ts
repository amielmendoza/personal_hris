import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AuthService } from './services/auth.service';

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent implements OnInit {
  isLoading: boolean = true;
  constructor(private http: HttpClient, private authService: AuthService) {}

  ngOnInit() {
    setTimeout(() => {
      this.isLoading = false;
    }, 3000);
  }

  title = 'RGC';
}
