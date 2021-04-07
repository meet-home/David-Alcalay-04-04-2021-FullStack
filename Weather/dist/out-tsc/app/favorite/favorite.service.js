import { __decorate } from "tslib";
import { Injectable } from '@angular/core';
let FavoriteService = class FavoriteService {
    constructor(http) {
        this.http = http;
    }
    getFavoriteList() {
        let url = `api/Favorite`;
        return this.http.get(url).toPromise();
    }
    addFavorite(city) {
        let url = "api/Favorite";
        return this.http.post(url, city).toPromise();
    }
    removeFavorite(city) {
        let url = `api/Favorite/${city.key}`;
        return this.http.delete(url).toPromise();
    }
};
FavoriteService = __decorate([
    Injectable()
], FavoriteService);
export { FavoriteService };
//# sourceMappingURL=favorite.service.js.map