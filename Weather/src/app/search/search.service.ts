import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { City } from '../_models/city';

@Injectable()
export class SearchService {
  constructor(private http: HttpClient) { }

  search(query: string): Promise<City[]> {
    let url: string = `api/Search/${query}`;
    return <Promise<City[]>>this.http.get(url).toPromise();
  }
}
