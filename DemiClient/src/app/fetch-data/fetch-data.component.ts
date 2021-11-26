import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthInterceptor } from '../services/auth.interceptor';
import { AuthService } from '../login/auth.service';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: WeatherForecast[] = [];

  constructor(http: HttpClient,) {
    let token = localStorage.getItem("jwt");
    http.get<WeatherForecast[]>("https://localhost:44358/WeatherForecast", ).subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }
}
/*
, {
    headers: {
      "Authorization": `Bearer ${token}`
      }
    }
*/
interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
