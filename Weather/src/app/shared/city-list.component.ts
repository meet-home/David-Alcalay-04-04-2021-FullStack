import { Component, EventEmitter, Input, Output } from '@angular/core';
import { NgForm } from '@angular/forms';
import { City } from '../_models/city';

@Component({
  selector:'city-list',
  templateUrl: './city-list.component.html'
})
export class CityListComponent {
  @Input() cities: City[];
  @Output() citySelected = new EventEmitter<City>();

  select(city) {
    this.citySelected.emit(city);
  }
}
