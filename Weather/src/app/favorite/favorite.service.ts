import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { City } from '../_models/city';

@Injectable()
export class FavoriteService {
  constructor(private http: HttpClient) { }

  getFavoriteList(): Promise<City[]> {
    let url: string = `api/Favorite`;
    return <Promise<City[]>>this.http.get(url).toPromise();
  }

  addFavorite(city: City) {
    let url: string = "api/Favorite";
    return this.http.post(url, city).toPromise();
  }

  removeFavorite(city: City) {
    let url: string = `api/Favorite/${city.key}`;
    return this.http.delete(url).toPromise();
  }
}
