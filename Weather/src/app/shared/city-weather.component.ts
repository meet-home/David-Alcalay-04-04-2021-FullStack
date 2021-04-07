import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FavoriteService } from '../favorite/favorite.service';
import { City } from '../_models/city';
import { Weather } from '../_models/Weather';
import { WeatherService } from './weather.service';

@Component({
  selector:'city-weather',
  templateUrl: './city-weather.component.html'
})
export class CityWeatherComponent {
  @Output() favoritesChanged = new EventEmitter();

  @Input() showAddFavorite: boolean;
  @Input() showRemoveFavorite: boolean;

  @Input() set city(city: City) {
    if (city != null) {
      this.currentCity = city;
      this.loadWeatherForCity(city)
    }
  };

  currentCity: City;
  currentWeather: Weather;

  constructor(private weatherService: WeatherService, private favoriteService: FavoriteService) {
  }

  loadWeatherForCity(city:City) {
    this.weatherService.getWeather(city.key)
      .then(r => this.currentWeather=r)
  }

  addToFavorites() {
    this.favoriteService.addFavorite(this.currentCity)
      .finally(() => this.favoritesChanged.emit());
  }

  removeFromFavorites() {
    this.favoriteService.removeFavorite(this.currentCity)
      .finally(() => this.favoritesChanged.emit());
  }
}
