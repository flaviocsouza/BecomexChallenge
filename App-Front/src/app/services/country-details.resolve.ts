import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot} from '@angular/router';
import { CountryService } from "./country.service";

@Injectable()

export class CountryDetailsResolve implements Resolve<any> {

    constructor(private countryService:CountryService){}

    resolve(route: ActivatedRouteSnapshot) {
        return this.countryService.getCountriesByInitials(route.params.alpha3Code);
    }

}