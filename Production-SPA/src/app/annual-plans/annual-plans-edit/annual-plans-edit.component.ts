import { Component, OnInit, HostListener } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Product } from 'src/app/models/product';
import { AnnualPlan } from 'src/app/models/annual-production-plan';
import { PlanItem } from 'src/app/models/plan-item';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { ProductsService } from 'src/app/_services/products.service';
import { AnnualPlansService } from 'src/app/_services/annual-plans.service';
import { WorkersService } from 'src/app/_services/workers.service';

@Component({
  selector: 'app-annual-plans-edit',
  templateUrl: './annual-plans-edit.component.html',
  styleUrls: ['./annual-plans-edit.component.scss']
})
export class AnnualPlansEditComponent implements OnInit {

  addForm: FormGroup;
  addItemForm: FormGroup;
  products: Product[];
  workers: Worker[];
  annualPlan: AnnualPlan;
  planItems: Array<PlanItem> = [];
  planItem: PlanItem;
  bsConfig: Partial<BsDatepickerConfig>;
  today: any;
  minDate: Date;
  editedItem: PlanItem;
  idToSend: number;
  editedAnnualPlan = new AnnualPlan();
  headElements = ['Id', 'Annual Production Plan Id', 'Quantity', 'Description', 'Product', 'Action'];

  
  @HostListener('window:beforeunload', ['$event'])
  unloadNotification($event: any){
    if(this.addForm.dirty){
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
    private annualPlanService: AnnualPlansService,
    private route: ActivatedRoute
  ) {
  }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.annualPlan = data['annualPlan'];
    });
    this.createAddForm();
    this.createAddItemForm();
    this.loadWorkers();
    this.loadProducts();
    this.createCurrentDate();
    this.planItems = this.annualPlan.planItems;
    this.idToSend = this.annualPlan.id;
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

  editAnnualPlan(){
    this.editedAnnualPlan = Object.assign({}, this.addForm.value);
    this.editedAnnualPlan.dateOfIssue = this.annualPlan.dateOfIssue;
    this.editedAnnualPlan.id = this.annualPlan.id;
    this.editedAnnualPlan.workerId = this.editedAnnualPlan.worker.id;
    this.editedAnnualPlan.planItems = this.planItems;
    this.annualPlanService.updatePlan(this.idToSend, this.editedAnnualPlan).subscribe(() => {
      this.alertify.success('Annual Plan Edited Successfully');
      this.router.navigate(['/annualproductionplan']);
    }, error => {
      this.alertify.error(error);
    });
  }

  

  cancel(){
    this.router.navigate(['/annualproductionplan']);
    this.alertify.message('Canceled');
  }

}
