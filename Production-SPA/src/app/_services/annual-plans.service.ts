import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { AnnualPlan } from '../models/annual-production-plan';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AnnualPlansService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getPlans(): Observable<AnnualPlan[]> {
    return this.http.get<AnnualPlan[]>(this.baseUrl + 'annualproductionplan');
  }

  getPlan(id): Observable<AnnualPlan> {
    return this.http.get<AnnualPlan>(this.baseUrl + 'annualproductionplan/' + id);
  }

  updatePlan(id: number, plan: AnnualPlan) {
    return this.http.put(this.baseUrl + 'annualproductionplan/' + id, plan);
  }

  addPlan(plan: AnnualPlan) {
    return this.http.post(this.baseUrl + 'annualproductionplan', plan);
  }

  deletePlan(id: number){
    return this.http.delete(this.baseUrl + 'annualproductionplan/' + id);
  }
}
