import { Worker } from '../models/worker';
import { PlanItem } from './plan-item';

export class AnnualPlan {
  id: number;
  dateOfIssue: Date;
  expirationDate: Date;
  description: string;
  note: string;
  workerId: number;
  worker: Worker;
  planItems: PlanItem[];

  constructor(p?: any) {
    if (p == null) {
      return;
    }
    this.id = p.id;
    this.dateOfIssue = p.dateOfIssue;
    this.expirationDate = p.expirationDate;
    this.description = p.description;
    this.note = p.note;
    this.workerId = p.workerId;
    this.worker = new Worker(p.UnitOfMeasure);
    this.planItems = new Array(p.planItems);
  }
}