import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment as env } from 'src/environments/environment';
import { WeatherInfo } from '../models/weatherInfo.model';

@Injectable({
  providedIn: 'root'
})
export class ApiComponentService {

  constructor(private http: HttpClient) { }

  GetWeathers(): Observable<WeatherInfo[]> {
    return this.http.get<WeatherInfo[]>(env.apilink);
  }

  GetWeather(id: number): Observable<WeatherInfo[]> {
    return this.http.get<WeatherInfo[]>(env.apilink + id);
  }

  PostWeather(weatherInfo: WeatherInfo){
    return this.http.post<WeatherInfo>(env.apilink, weatherInfo);
  }

  DeleteWeather(id: number){
    return this.http.delete(env.apilink + id);
  }

  PutWeather(weatherInfo: WeatherInfo){
    return this.http.put(env.apilink + weatherInfo.id, weatherInfo);
  }

}
