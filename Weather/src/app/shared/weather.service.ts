import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Weather } from '../_models/Weather';

@Injectable()
export class WeatherService {
  constructor(private http: HttpClient) { }

  getWeather(cityId: number) {
    let url: string = `api/Weather/${cityId}`;
    return <Promise<Weather>>this.http.get(url).toPromise();
  }
}
