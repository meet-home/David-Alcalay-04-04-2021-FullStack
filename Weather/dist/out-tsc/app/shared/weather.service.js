import { __decorate } from "tslib";
import { Injectable } from '@angular/core';
let WeatherService = class WeatherService {
    constructor(http) {
        this.http = http;
    }
    getWeather(cityId) {
        let url = `api/Weather/${cityId}`;
        return this.http.get(url).toPromise();
    }
};
WeatherService = __decorate([
    Injectable()
], WeatherService);
export { WeatherService };
//# sourceMappingURL=weather.service.js.map