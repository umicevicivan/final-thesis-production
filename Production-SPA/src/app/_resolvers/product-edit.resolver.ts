import { Injectable } from '@angular/core';
import {Resolve, Router, ActivatedRouteSnapshot} from '@angular/router';
import {ProductsService} from '../_services/products.service';
import {AlertifyService} from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AuthService } from '../_services/auth.service';
import { Product } from '../models/product';


@Injectable()
export class ProductEditResolver implements Resolve<Product>{

    constructor(private productService: ProductsService, private router: Router,
        private alertify: AlertifyService, private authService: AuthService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<Product>{
        return this.productService.getProduct(route.params['id']).pipe(
            catchError(error => {
                this.alertify.error('Problem retrieving your data');
                this.router.navigate(['/products']);
                return of(null);
            })
        )
    }

}