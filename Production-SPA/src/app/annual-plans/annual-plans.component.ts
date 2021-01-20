import { Component, OnInit } from '@angular/core';
import {AnnualPlan} from '../models/annual-production-plan';
import { AnnualPlansService } from '../_services/annual-plans.service';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-annual-plans',
  templateUrl: './annual-plans.component.html',
  styleUrls: ['./annual-plans.component.scss']
})
export class AnnualPlansComponent implements OnInit {
  
  plans: AnnualPlan[];
  headElements = ['ID', 'Date Of Issue', 'Expiration Date', 'Description', 'Note', 'Worker', 'Action'];
  constructor(private planService: AnnualPlansService, private alertify: AlertifyService, private router: Router) { }

  ngOnInit() {
    this.loadPlans();
  }

  loadPlans(){
    this.planService.getPlans().subscribe((aaa: AnnualPlan[]) => {
      this.plans = aaa;
    }, error => {
      this.alertify.error(error);
    });
  }

  test(plan: AnnualPlan){
    this.plans = this.plans.filter(obj => obj !== plan);
  }

  openForAdding(){
    this.router.navigate(['annualproductionplan/add']);
  }

  deletePlan(plan: AnnualPlan){
    this.planService.deletePlan(plan.id).subscribe(() => {
      this.alertify.success('Annual Production Plan is deleted');
      this.loadPlans();

    }, error => {
      this.alertify.error(error);
    });
  }

}
