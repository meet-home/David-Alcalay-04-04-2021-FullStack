import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FavoriteComponent } from './favorite/favorite.component';
import { SearchComponent } from './search/search.component';
import { SearchService } from './search/search.service';
import { FavoriteService } from './favorite/favorite.service';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { CityListComponent } from './shared/city-list.component';
import { CityWeatherComponent } from './shared/city-weather.component';
import { WeatherService } from './shared/weather.service';

@NgModule({
  declarations: [
    AppComponent, FavoriteComponent, SearchComponent, CityListComponent, CityWeatherComponent 
  ],
  imports: [
    BrowserModule, AppRoutingModule, HttpClientModule, FormsModule
  ],
  providers: [FavoriteService, SearchService, WeatherService],
  bootstrap: [AppComponent]
})
export class AppModule { }
