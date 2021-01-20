import { UnitOfMeasure } from '../models/unit-of-measure';

export class Product {
  id: number;
  name: string;
  professionalName: string;
  shape: string;
  description: string;
  instruction: string;
  price: number;
  unitOfMeasureID: number;
  unitOfMeasure: UnitOfMeasure;

  constructor(p?: any) {
    if (p == null) {
      return;
    }
    this.id = p.id;
    this.name = p.name;
    this.professionalName = p.professionalName;
    this.shape = p.shape;
    this.description = p.description;
    this.instruction = p.instruction;
    this.price = p.price;
    this.unitOfMeasureID = p.unitOfMeasureID;
    this.unitOfMeasure = new UnitOfMeasure(p.UnitOfMeasure);
  }
}
