import { __decorate } from "tslib";
import { Component, EventEmitter, Input, Output } from '@angular/core';
let CityListComponent = class CityListComponent {
    constructor() {
        this.citySelected = new EventEmitter();
    }
    select(city) {
        this.citySelected.emit(city);
    }
};
__decorate([
    Input()
], CityListComponent.prototype, "cities", void 0);
__decorate([
    Output()
], CityListComponent.prototype, "citySelected", void 0);
CityListComponent = __decorate([
    Component({
        selector: 'city-list',
        templateUrl: './city-list.component.html'
    })
], CityListComponent);
export { CityListComponent };
//# sourceMappingURL=city-list.component.js.map