export class UnitOfMeasure{
    
    unitOfMeasureId: number;
    fullName: string;
    shortName: string;

    constructor(u: any) {
        if (u == null) {
            return;
        }
        this.fullName = u.fullName;
        this.shortName = u.shortName;
        this.unitOfMeasureId = u.unitOfMeasureId;
    }
}
