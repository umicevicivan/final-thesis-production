import { Component, OnInit, HostListener } from '@angular/core';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { ProductsService } from 'src/app/_services/products.service';
import { FormGroup, FormControl, FormBuilder, FormArray, Validators, AbstractControl } from '@angular/forms';
import { Router } from '@angular/router';
import { UnitOfMeasure } from 'src/app/models/unit-of-measure';
import { UnitsOfMeasureService } from 'src/app/_services/units-of-measure.service';
import { Product } from 'src/app/models/product';
import { min } from 'rxjs/operators';

@Component({
  selector: 'app-products-add',
  templateUrl: './products-add.component.html',
  styleUrls: ['./products-add.component.css']
})
export class ProductsAddComponent implements OnInit {

  addForm: FormGroup;
  unitsOfMeasure: UnitOfMeasure[];
  product: Product;

  @HostListener('window:beforeunload', ['$event'])
  unloadNotification($event: any){
    if(this.addForm.dirty){
      $event.returnValue = true;
    }
  }
  constructor(private alertify: AlertifyService, private productService: ProductsService,
    private router: Router, private unitService: UnitsOfMeasureService, private fb: FormBuilder) { }

  ngOnInit() {
    this.createAddForm();
    this.loadUnits();
  }

  createAddForm(){
    this.addForm = this.fb.group({
      name: ['', Validators.required],
      professionalName: ['', Validators.required],
      shape: ['', Validators.required],
      description: ['', Validators.required],
      instruction: ['', Validators.required],
      price: ['', [Validators.required, Validators.pattern('([1-9][0-9]*)')] ],
      unitOfMeasure: ['', Validators.required]
    });
  }


  loadUnits(){
    this.unitService.getUnits().subscribe((aaa: UnitOfMeasure[]) => {
      this.unitsOfMeasure = aaa;
    }, error => {
      this.alertify.error(error);
    });
  }

  addProduct(){
    if(this.addForm.valid){

      this.product = Object.assign({}, this.addForm.value);
      this.productService.addProduct(this.product).subscribe(() => {
        this.alertify.success('Product Added Successfully');
        this.router.navigate(['/products']);
      }, error => {
        this.alertify.error(error);
      });
    }
  }

  cancel(){
    this.alertify.message('Canceled');
    this.router.navigate(['/products']);
  }

}
