
export class Worker {
  id: number;
  name: string;
  surname: string;
  jmbg: number;
  dateOfBirth: Date;
  dateOfEmployment: Date;
  accountNumber: string;
  workplaceNumber: number;
  organizationalUnitNumber: number;

  constructor(p?: any) {
    if (p == null) {
      return;
    }
    this.id = p.id;
    this.name = p.name;
    this.surname = p.surname;
    this.jmbg = p.jmbg;
    this.dateOfBirth = p.dateOfBirth;
    this.dateOfEmployment = p.dateOfEmployment;
    this.accountNumber = p.accountNumber;
    this.workplaceNumber = p.workplaceNumber;
    this.organizationalUnitNumber = p.organizationalUnitNumber;
  }
}
