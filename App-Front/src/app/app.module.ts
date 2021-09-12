import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { SearchComponent } from './components/search/search.component';
import { DetailsComponent } from './components/details/details.component';
import { HttpClientModule } from '@angular/common/http';
import { CountryListComponent } from './components/country-list/country-list.component';

import { CurrenciesToString } from './utils/CurrenciesToString';
import { BlocsToString } from './utils/BlocsToString'
import { CountryDetailsResolve } from './services/country-details.resolve';

@NgModule({
  declarations: [
    AppComponent,
    SearchComponent,
    DetailsComponent,
    CountryListComponent,
    CurrenciesToString,
    BlocsToString
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [
    CountryDetailsResolve
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
