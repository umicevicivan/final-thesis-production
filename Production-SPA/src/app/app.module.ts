import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { JwtModule } from '@auth0/angular-jwt';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';


import { AppComponent } from './app.component';
import { ValueComponent } from './value/value.component';
import { LoginComponent } from './login/login.component';
import { AuthService } from './_services/auth.service';
import { ErrorInterceptorProvider } from './_services/error.interceptior';
import { NavComponent } from './nav/nav.component';
import { ProductsComponent } from './products/products.component';
import { appRoutes } from './routes';
import { AlertifyService } from './_services/alertify.service';
import { ProductsService } from './_services/products.service';
import { UnitsOfMeasureService } from './_services/units-of-measure.service';
import { ProductsAddComponent } from './products/products-add/products-add.component';
import { ProductEditComponent } from './products/product-edit/product-edit.component';
import { ProductEditResolver } from './_resolvers/product-edit.resolver';
import { PreventUnsavedChanges } from './_guards/prevent-unsaved-changes.guard';
import { AnnualPlansComponent } from './annual-plans/annual-plans.component';
import { AnnualPlansAddComponent } from './annual-plans/annual-plans-add/annual-plans-add.component';
import { WorkersService } from './_services/workers.service';
import { AnnualPlansService } from './_services/annual-plans.service';
import { AnnualPlansEditComponent } from './annual-plans/annual-plans-edit/annual-plans-edit.component';
import { AnnualPlanEditResolver } from './_resolvers/annual-plan-edit.resolver';
import { from } from 'rxjs';

export function tokenGetter() {
  return localStorage.getItem('token');
}

@NgModule({
  declarations: [
    AppComponent,
      ValueComponent,
      LoginComponent,
      NavComponent,
      ProductsComponent,
      ProductsAddComponent,
      ProductEditComponent,
      AnnualPlansComponent,
      AnnualPlansAddComponent,
      AnnualPlansEditComponent
   ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BsDatepickerModule.forRoot(),
    RouterModule.forRoot(appRoutes),
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ['localhost:5000'],
        disallowedRoutes: ['localhost:5000/api/auth']
      }
    })
  ],
  providers: [
    AuthService,
    ErrorInterceptorProvider,
    AlertifyService,
    ProductsService,
    WorkersService,
    AnnualPlansService,
    UnitsOfMeasureService,
    ProductEditResolver,
    AnnualPlanEditResolver,
    PreventUnsavedChanges

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
