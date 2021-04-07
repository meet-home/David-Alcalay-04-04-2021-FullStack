import { __decorate } from "tslib";
import { Component } from '@angular/core';
let SearchComponent = class SearchComponent {
    constructor(_service) {
        this._service = _service;
        this.submitted = false;
    }
    search(form) {
        if (form.valid) {
            this.submitted = false;
            this._service.search(this.query)
                .then(r => {
                this.searchResults = r;
            });
        }
        else
            this.submitted = true;
    }
    setCity(city) {
        this.selectedCity = city;
    }
};
SearchComponent = __decorate([
    Component({
        templateUrl: './search.component.html'
    })
], SearchComponent);
export { SearchComponent };
//# sourceMappingURL=search.component.js.map