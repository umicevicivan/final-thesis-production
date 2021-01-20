import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { AnnualPlansService } from '../_services/annual-plans.service';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AuthService } from '../_services/auth.service';
import { AnnualPlan } from '../models/annual-production-plan';

@Injectable()
export class AnnualPlanEditResolver implements Resolve<AnnualPlan> {
  constructor(
    private planService: AnnualPlansService,
    private router: Router,
    private alertify: AlertifyService,
    private authService: AuthService
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<AnnualPlan> {
    return this.planService.getPlan(route.params['id']).pipe(
      catchError((error) => {
        this.alertify.error('Problem retrieving your data');
        this.router.navigate(['/annualproductionplan']);
        return of(null);
      })
    );
  }
}
