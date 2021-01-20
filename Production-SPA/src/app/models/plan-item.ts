import { Product } from '../models/product';

export class PlanItem {
  id: number;
  annualProductionPlanId: number;
  quantity: number;
  description: string;
  productId: number;
  product: Product;

  constructor(p?: any) {
    if (p == null) {
      return;
    }
    this.id = p.id;
    this.annualProductionPlanId = p.annualProductionPlanId;
    this.quantity = p.quantity;
    this.description = p.description;
    this.productId = p.productId;
    this.product = new Product(p.product);
  }
}
