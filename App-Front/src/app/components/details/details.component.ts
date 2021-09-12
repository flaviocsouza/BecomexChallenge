import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CountryService } from '../../services/country.service';


@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {

  country:any;

  constructor(
    private route: ActivatedRoute,
    private router:Router,    
    private countryService:CountryService
  ) { }

  ngOnInit(): void {    
    this.country = this.route.snapshot.data['country'];
    console.log(this.country);
  }

  
  backToSearch(){
    this.router.navigate(['search'])
  }

  getCountry(countryCode) {
    
    this.router.navigate(['details',  countryCode])
    this.countryService
      .getCountriesByInitials(countryCode)
      .subscribe(country => this.country = country)
    
  }

}
