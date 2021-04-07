import { __decorate } from "tslib";
import { Injectable } from '@angular/core';
let SearchService = class SearchService {
    constructor(http) {
        this.http = http;
    }
    search(query) {
        let url = `api/Search/${query}`;
        return this.http.get(url).toPromise();
    }
};
SearchService = __decorate([
    Injectable()
], SearchService);
export { SearchService };
//# sourceMappingURL=search.service.js.map