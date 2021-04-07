import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { City } from '../_models/city';
import { SearchService } from './search.service';

@Component({
  templateUrl: './search.component.html'
})
export class SearchComponent {
  submitted: boolean = false;
  searchResults: City[];
  query: string;

  selectedCity: City;

  constructor(private _service: SearchService,) {
  }

  search(form: NgForm) {
    if (form.valid) {
      this.submitted = false;

      this._service.search(this.query)
        .then(r => {
          this.searchResults = r;
        })
    }
    else
      this.submitted = true;
  }

  setCity(city: City) {
    this.selectedCity = city; 
  }
}
