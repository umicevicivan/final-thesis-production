import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { ProductsComponent } from './products/products.component';
import { ProductsAddComponent } from './products/products-add/products-add.component';
import { AuthGuard } from './_guards/auth.guard';
import { ProductEditComponent } from './products/product-edit/product-edit.component';
import { ProductEditResolver } from './_resolvers/product-edit.resolver';
import { PreventUnsavedChanges } from './_guards/prevent-unsaved-changes.guard';
import { AnnualPlansComponent } from './annual-plans/annual-plans.component';
import { AnnualPlansAddComponent } from './annual-plans/annual-plans-add/annual-plans-add.component';
import { AnnualPlansEditComponent } from './annual-plans/annual-plans-edit/annual-plans-edit.component';
import { AnnualPlanEditResolver } from './_resolvers/annual-plan-edit.resolver';

// rute rade po principu na koji prvi naleti, ako ne naleti ni na jedan od ovih pogodice '**'
// i on ce da ga redirektuje na home, znaci da ta ruta ne postoji na nasoj app
// posto je bitan red, onda to mora da bude na kraju
export const appRoutes: Routes = [
  { path: '', component: LoginComponent },
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      { path: 'products', component: ProductsComponent },
      { path: 'products/add', component: ProductsAddComponent, canDeactivate: [PreventUnsavedChanges] },
      {
        path: 'products/edit/:id',
        component: ProductEditComponent,
        resolve: { product: ProductEditResolver },
        canDeactivate: [PreventUnsavedChanges]
      },
      {
        path: 'annualproductionplan',
        component: AnnualPlansComponent,
      },
      { path: 'annualproductionplan/add', component: AnnualPlansAddComponent, canDeactivate: [PreventUnsavedChanges] },
      {
        path: 'annualproductionplan/edit/:id',
        resolve: {annualPlan: AnnualPlanEditResolver},
        component: AnnualPlansEditComponent,
        canDeactivate: [PreventUnsavedChanges]
      }
    ],
  },
  { path: '**', redirectTo: '', pathMatch: 'full' },
];
