import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Product } from '../models/product';

@Injectable({
  providedIn: 'root',
})
export class ProductsService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.baseUrl + 'product');
  }

  getProduct(id): Observable<Product> {
    return this.http.get<Product>(this.baseUrl + 'product/' + id);
  }

  updateProduct(id: number, product: Product) {
    return this.http.put(this.baseUrl + 'product/' + id, product);
  }

  addProduct(product: Product) {
    return this.http.post(this.baseUrl + 'product', product);
  }

  deleteProduct(id: number){
    return this.http.delete(this.baseUrl + 'product/' + id);
  }
}
