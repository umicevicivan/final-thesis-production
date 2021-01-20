import { Component, OnInit, Input, HostListener } from '@angular/core';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { ProductsService } from 'src/app/_services/products.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { UnitOfMeasure } from 'src/app/models/unit-of-measure';
import { Product } from 'src/app/models/product';
import { UnitsOfMeasureService } from 'src/app/_services/units-of-measure.service';

@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.scss']
})
export class ProductEditComponent implements OnInit {

  product: Product;
  addForm: FormGroup;
  unitsOfMeasure: UnitOfMeasure[];
  idToSend: number;

  
  @HostListener('window:beforeunload', ['$event'])
  unloadNotification($event: any){
    if(this.addForm.dirty){
      $event.returnValue = true;
    }
  }
  
  constructor(private route: ActivatedRoute, private alertify: AlertifyService, private productService: ProductsService,
    private router: Router, private fb: FormBuilder, private unitService: UnitsOfMeasureService) {}


  ngOnInit() {
    this.route.data.subscribe(data => {
      this.product = data['product'];
    });
    this.createAddForm();
    this.loadUnits();
    this.idToSend = this.product.id;
  }

  createAddForm(){
    this.addForm = this.fb.group({
      name: ['', Validators.required],
      professionalName: [''],
      shape: [''],
      description: [''],
      instruction: [''],
      price: ['', [Validators.required, Validators.pattern('([1-9][0-9]*)')]],
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

  editProduct(){
    this.product = Object.assign({}, this.addForm.value);
    this.product.unitOfMeasureID = this.product.unitOfMeasure.unitOfMeasureId;
    this.productService.updateProduct(this.idToSend, this.product).subscribe(() => {
      this.alertify.success('Product Edited Successfully');
      this.router.navigate(['/products']);
    }, error => {
      this.alertify.error(error);
    });
  }

  cancel(){
    this.router.navigate(['/products']);
    this.alertify.message('Canceled');
  }



}
