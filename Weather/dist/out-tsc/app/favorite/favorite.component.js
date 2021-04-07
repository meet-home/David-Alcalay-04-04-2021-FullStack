import { __decorate } from "tslib";
import { Component } from '@angular/core';
let FavoriteComponent = class FavoriteComponent {
    constructor(_service) {
        this._service = _service;
    }
    ngOnInit() {
        this.loadFavoriteList();
    }
    loadFavoriteList() {
        this._service.getFavoriteList()
            .then(r => this.favoriteList = r);
    }
    setCity(city) {
        this.selectedCity = city;
    }
};
FavoriteComponent = __decorate([
    Component({
        templateUrl: './favorite.component.html'
    })
], FavoriteComponent);
export { FavoriteComponent };
//# sourceMappingURL=favorite.component.js.map