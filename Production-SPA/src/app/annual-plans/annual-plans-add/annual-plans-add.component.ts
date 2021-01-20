import { Component, OnInit, HostListener } from '@angular/core';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { AnnualPlansService } from 'src/app/_services/annual-plans.service';
import { Router } from '@angular/router';
import { ProductsService } from 'src/app/_services/products.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Product } from 'src/app/models/product';
import { WorkersService } from 'src/app/_services/workers.service';
import { AnnualPlan } from 'src/app/models/annual-production-plan';
import { PlanItem } from 'src/app/models/plan-item';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';

@Component({
  selector: 'app-annual-plans-add',
  templateUrl: './annual-plans-add.component.html',
  styleUrls: ['./annual-plans-add.component.scss'],
})
export class AnnualPlansAddComponent implements OnInit {
  addForm: FormGroup;
  addItemForm: FormGroup;
  products: Product[];
  workers: Worker[];
  annualPlan: AnnualPlan;
  planItems: Array<PlanItem> = [];
  planItem: any;
  bsConfig: Partial<BsDatepickerConfig>;
  today: any;
  minDate: Date;
  headElements = ['Quantity', 'Description', 'Product', 'Action'];

  @HostListener('window:beforeunload', ['$event'])
  unloadNotification($event: any) {
    if (this.addForm.dirty) {
      $event.returnValue = true;
    }
  }

  constructor(
    private alertify: AlertifyService,
    private planService: AnnualPlansService,
    private router: Router,
    private productService: ProductsService,
    private fb: FormBuilder,
    private workerService: WorkersService,
    private annualPlanService: AnnualPlansService
  ) {
  }

  ngOnInit() {
    this.bsConfig = {
      containerClass: 'theme-green',
    };
    this.createAddForm();
    this.createAddItemForm();
    this.loadProducts();
    this.loadWorkers();
    this.createCurrentDate();
    this.minDate = new Date();

  }

  createCurrentDate() {
    this.today = new Date();
    const dd = String(this.today.getDate()).padStart(2, '0');
    const mm = String(this.today.getMonth() + 1).padStart(2, '0');
    const yyyy = this.today.getFullYear();

    this.today = mm + '/' + dd + '/' + yyyy;
  }

  createAddForm() {
    this.addForm = this.fb.group({
      dateOfIssue: [null],
      expirationDate: [null, Validators.required],
      description: ['', Validators.required],
      note: ['', Validators.required],
      worker: ['', Validators.required],
    });
  }

  createAddItemForm() {
    this.addItemForm = this.fb.group({
      quantity: ['', [Validators.required, Validators.pattern('([1-9][0-9]*)')] ],
      description: ['', Validators.required],
      product: ['', Validators.required],
    });
  }

  loadProducts() {
    this.productService.getProducts().subscribe(
      (aaa: Product[]) => {
        this.products = aaa;
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }

  loadWorkers() {
    this.workerService.getWorkers().subscribe(
      (aaa: Worker[]) => {
        this.workers = aaa;
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }

  addPlan() {
    if (this.addForm.valid) {
      this.annualPlan = Object.assign({}, this.addForm.value);
      this.annualPlan.dateOfIssue = new Date();
      this.annualPlan.planItems = this.planItems;
      this.annualPlan.workerId = this.annualPlan.worker.id;
      this.annualPlanService.addPlan(this.annualPlan).subscribe(
        () => {
          this.alertify.success('Annual Plann is Added Successfully');
          this.router.navigate(['/annualproductionplan']);
        },
        (error) => {
          this.alertify.error(error);
        }
      );
    }
  }

  addItem() {
    if (this.addItemForm.valid) {
      this.planItem = Object.assign({}, this.addItemForm.value);
      this.planItem.productId = this.planItem.product.id;
      this.planItems.push(this.planItem);
      this.createAddItemForm();
    }
  }

  deleteItem(planItem: PlanItem) {
    this.planItems = this.planItems.filter((obj) => obj !== planItem);
  }

  cancel() {
    this.alertify.message('Canceled');
    this.router.navigate(['/annualproductionplan']);
  }
}
