import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-country-list',
  templateUrl: './country-list.component.html',
  styleUrls: ['./country-list.component.css']
})
export class CountryListComponent implements OnInit {

  constructor(private router:Router) { }

  @Input() countryList:any
  ngOnInit(): void {
  }

  redirectToDetails(country){
    this.router.navigate(['details',  country.alpha3Code])
  }

}
