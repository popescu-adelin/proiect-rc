import { Component, OnInit } from '@angular/core';
import { EmployeesService } from './services/employees.service';
import { Observable } from 'rxjs';
import { Employee } from './models/employeee';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'webClient';
  employees: Employee[] = [];
  employees$: Observable<Employee[]> | undefined;
  constructor(
    private employeeService: EmployeesService
  ) { }

  ngOnInit(): void {
    this.employeeService.getEmployees().subscribe(data => {
      this.employees = data;
    })

    console.log(this.employees);
    this.employees$ = this.employeeService.getEmployees();
  }

}
