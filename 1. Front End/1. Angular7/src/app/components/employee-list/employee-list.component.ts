import { EmployeeDetailComponent } from './../employee-detail/employee-detail.component';
import { Component, OnInit } from '@angular/core';
import { EmployeesService } from '../../services/employees.service';
import { Employee } from 'src/app/models/Employee';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit {

  employee: Employee =  {
    id: null,
    name: '',
    contractTypeName: '',
    roleId: null,
    roleName: '',
    roleDescription: '',
    hourlySalary: null,
    monthlySalary: null,
    calculatedAnnualSalary: null
  };

  employees: any = [];
  columns: string[] = ['Id', 'Employee Name', 'Contract Type', 'Role Id', 'Role Name',
  'Role Descripction', 'Hourly Salary', 'Monthly Salary', 'Calculated Annual Salary' ];

  constructor(private employeesService: EmployeesService) { }

  ngOnInit() {
    this.getEmployees(0);
  }

  getEmployees(id: any) {
    if (id === null || id === '') {
        id = 0;
    }
    if (isNaN(Number(id.toString())) === true) {
      alert('Incorrect value of Id');
      return this.employee;
    }

    this.employeesService.getEmployee(id)
      .subscribe(
        res => {
          this.employees = res;
        },
        err => console.error(err)
      );
  }
}
