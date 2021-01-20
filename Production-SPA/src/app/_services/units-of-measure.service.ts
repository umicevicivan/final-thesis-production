import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { UnitOfMeasure } from '../models/unit-of-measure';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UnitsOfMeasureService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }
  
  getUnits(): Observable<UnitOfMeasure[]> {
    return this.http.get<UnitOfMeasure[]>(this.baseUrl + 'unitsofmeasure');
  }
  
  getUnit(id): Observable<UnitOfMeasure>{
    return this.http.get<UnitOfMeasure>(this.baseUrl + 'unitsofmeasure/' + id);
  }
  
}
