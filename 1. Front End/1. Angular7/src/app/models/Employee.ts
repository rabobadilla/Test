import { Title } from '@angular/platform-browser';

export interface Employee {
    id?: number;
    name: string;
    contractTypeName: string;
    roleId?: number;
    roleName: string;
    roleDescription: string;
    hourlySalary?: number;
    monthlySalary?: number;
    calculatedAnnualSalary?: number;
}
