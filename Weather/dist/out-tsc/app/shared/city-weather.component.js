import { __decorate } from "tslib";
import { Component, EventEmitter, Input, Output } from '@angular/core';
let CityWeatherComponent = class CityWeatherComponent {
    constructor(weatherService, favoriteService) {
        this.weatherService = weatherService;
        this.favoriteService = favoriteService;
        this.favoritesChanged = new EventEmitter();
    }
    set city(city) {
        if (city != null) {
            this.currentCity = city;
            this.loadWeatherForCity(city);
        }
    }
    ;
    loadWeatherForCity(city) {
        this.weatherService.getWeather(city.key)
            .then(r => this.currentWeather = r);
    }
    addToFavorites() {
        this.favoriteService.addFavorite(this.currentCity)
            .finally(() => this.favoritesChanged.emit());
    }
    removeFromFavorites() {
        this.favoriteService.removeFavorite(this.currentCity)
            .finally(() => this.favoritesChanged.emit());
    }
};
__decorate([
    Output()
], CityWeatherComponent.prototype, "favoritesChanged", void 0);
__decorate([
    Input()
], CityWeatherComponent.prototype, "showAddFavorite", void 0);
__decorate([
    Input()
], CityWeatherComponent.prototype, "showRemoveFavorite", void 0);
__decorate([
    Input()
], CityWeatherComponent.prototype, "city", null);
CityWeatherComponent = __decorate([
    Component({
        selector: 'city-weather',
        templateUrl: './city-weather.component.html'
    })
], CityWeatherComponent);
export { CityWeatherComponent };
//# sourceMappingURL=city-weather.component.js.map