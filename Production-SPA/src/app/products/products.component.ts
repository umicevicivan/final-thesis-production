import { Component, OnInit } from '@angular/core';
import { Product } from '../models/product';
import { ProductsService } from '../_services/products.service';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

  products: Product[];
  headElements = ['ID', 'Name', 'Professional Name', 'Shape', 'Description', 'Instruction', 'Price', 'Unit Of Measure', 'Action'];
  constructor(private productsService: ProductsService, private alertify: AlertifyService, private router: Router) { }

  ngOnInit() {
    this.loadProducts();
  }

  loadProducts(){
    this.productsService.getProducts().subscribe((pro: Product[]) => {
      this.products = pro;
    }, error => {
      this.alertify.error(error);
    });
  }

  openForAdding(){
    this.router.navigate(['products/add']);
  }

  deleteProduct(product: Product){
    this.productsService.deleteProduct(product.id).subscribe(() => {
      this.alertify.success('Product is deleted');
      this.products = this.products.filter(obj => obj !== product);
    }, error => {
      this.alertify.error(error);
    });

  }

}
