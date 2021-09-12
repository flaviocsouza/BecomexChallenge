import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DetailsComponent } from './components/details/details.component';
import { SearchComponent } from './components/search/search.component';
import { CountryDetailsResolve } from './services/country-details.resolve';

const routes: Routes = [
  { path: 'search', component: SearchComponent },
  { path: 'details/:alpha3Code', component: DetailsComponent, resolve:{
    country: CountryDetailsResolve
  } },
  { path: '',   redirectTo: '/search', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
