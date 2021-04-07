import { Component, OnInit } from '@angular/core';
import { City } from '../_models/city';
import { FavoriteService } from './favorite.service';

@Component({
  templateUrl: './favorite.component.html'
})
export class FavoriteComponent implements OnInit {
  favoriteList: City[];
  selectedCity: City;

  constructor(private _service: FavoriteService) {

  }

  ngOnInit() {
    this.loadFavoriteList();
  }

  loadFavoriteList() {
    this._service.getFavoriteList()
      .then(r => this.favoriteList = r);
  }

  setCity(city: City) {
    this.selectedCity = city;
  }
}
