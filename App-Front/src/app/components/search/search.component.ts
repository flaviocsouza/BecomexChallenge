import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CountryService } from '../../services/country.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {

  searchForm:FormGroup;
  countryList:any[];

  optionsSearch = [
    { id: 1, label:'Name' },    
    { id: 2, label:'Initials' },
    { id: 3, label:'Currency' }
  ]

  constructor(
    private fromBuilder:FormBuilder,
    private countryService:CountryService
  ) { }

  ngOnInit(): void {
    this.searchForm = this.fromBuilder.group({
      typeSearch:[null],
      textSearch:['', Validators.required]
    });
  }

  getCountries(){
    if(this.searchForm.invalid) return;

    let textSearch = this.searchForm.value.textSearch;
    let typeSearch =  this.searchForm.value.typeSearch;
    
    switch(typeSearch) {
      case 1: {
        this.getCountriesByName(textSearch);
        break;
      }
      case 2: {
        this.getCountriesByInitials(textSearch);
        break;
      }
      case 3: {
        this.getCountriesByCurrency(textSearch);
        break;
      }
    }
  }    
  getCountriesByName(name){
    return this.countryService
      .getCountriesByName(name)
      .subscribe(response => this.countryList = response);
  }
  getCountriesByInitials(name){
    return this.countryService
      .getCountriesByInitials(name)
      .subscribe(response => this.countryList = [response]);
  }
  getCountriesByCurrency(name){
    return this.countryService
      .getCountriesByCurrency(name)
      .subscribe(response => this.countryList = response);
  }

}
