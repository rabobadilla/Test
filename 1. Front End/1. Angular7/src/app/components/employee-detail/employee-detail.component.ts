import { Component, OnInit } from '@angular/core';

import { Employee } from 'src/app/models/Employee';

import { EmployeesService } from 'src/app/services/employees.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-employee-detail',
  templateUrl: './employee-detail.component.html',
  styleUrls: ['./employee-detail.component.css']
})
export class EmployeeDetailComponent implements OnInit {

  employee = this.getMockEmployee();

  constructor(private employeesService: EmployeesService, private router: Router, private activatedRoute: ActivatedRoute) { }

  ngOnInit() {

  }

  getEmployee(id: number) {

    if (id === null) {
      alert('Incorrect value of Id');
      this.employee = this.getMockEmployee();
      return this.employee;
    }
    if (isNaN(Number(id.toString())) === true) {
      alert('Incorrect value of Id');
      this.employee = this.getMockEmployee();
      return this.employee;
    }
       this.employeesService.getEmployee(id)
        .subscribe(
          res => {
            let employees: any = [];
            employees = res;

            if (employees.length !== 0) {
               this.employee = employees[0];
            } else {
              alert('Employee doesnt exist');
              this.employee = this.getMockEmployee();
              return this.employee;
            }

           return this.employee;
          },
          err => console.log(err)
        );
    }

  public getMockEmployee(): Employee {
    const mockEmployee: Employee =  {
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
    return mockEmployee;
}
}




