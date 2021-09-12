import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs';
import { map } from "rxjs/operators"

@Injectable({
  providedIn: 'root'
})
export class CountryService {

  private urlApi:string = 'https://localhost:44378/Country';

  constructor(private http:HttpClient) { }

  getCountriesByName(name:string):Observable<any> {
    return this.http.get<any>(`${this.urlApi}/Name/${name}`).pipe(map(data => data));
  }
  
  getCountriesByInitials(name:string):Observable<any> {
    return this.http.get<any>(`${this.urlApi}/Code/${name}`).pipe(map(data => data));
  }

  getCountriesByCurrency(name:string):Observable<any> {
    return this.http.get<any>(`${this.urlApi}/Currency/${name}`).pipe(map(data => data));
  }
}
